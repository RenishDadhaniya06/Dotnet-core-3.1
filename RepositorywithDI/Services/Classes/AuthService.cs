namespace RepositorywithDI.Services
{
    #region using

    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using RepositorywithDI.Extension;
    using RepositorywithDI.Models;
    using RepositorywithDI.Models.ViewModel;
    using RepositorywithDI.Repository.Interfaces;
    using RepositorywithDI.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// UserService
    /// </summary>
    /// <seealso cref="RepositorywithDI.Services.IUserService" />
    public class AuthService : IAuthService
    {
        #region Properties And Constructer
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IBaseRepository<RefreshToken> _refreshRepository;
        public AuthService(IBaseRepository<Users> userRepository, IBaseRepository<Employee> employeeRepository, IBaseRepository<RefreshToken> refreshRepository)
        {
            _userRepository = userRepository;
            _refreshRepository = refreshRepository;
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<TokenResponse> Authenticate(string username, string password)
        {
            var user = await _employeeRepository.FindOne(x => x.Email == username && x.Password == ExtensionMethods.Encrypt(password));
            ////var passwordE = ExtensionMethods.Encrypt(password);
            ////var passwordD = ExtensionMethods.Decrypt(passwordE);
            var refreshToken = Guid.NewGuid().ToString();
            await _refreshRepository.Post(new RefreshToken
            {
                Username = username,
                Refreshtoken = refreshToken
            });

            string token = GenrateToken();


            return new TokenResponse()
            {
               
                Token = token,
                Employee = user,
                ExpireIn = "864000",
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Genrates the token.
        /// </summary>
        /// <returns></returns>
        public static string GenrateToken()
        {
            var claims = new[]
             {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
             };
            var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(24),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns></returns>
        public async Task<TokenResponse> RefreshToken(string refreshToken)
        {
            var _refreshToken = await _refreshRepository.FindOne(m => m.Refreshtoken == refreshToken);

            if (_refreshToken == null)
            {
                return null;
            }

            _refreshToken.Refreshtoken = Guid.NewGuid().ToString();
            await _refreshRepository.Put(_refreshToken);
            string token = GenrateToken();

            return new TokenResponse()
            {
                Token = token,
                ExpireIn = "1000",
                RefreshToken = _refreshToken.Refreshtoken
            };
        }
        #endregion
    }

}
