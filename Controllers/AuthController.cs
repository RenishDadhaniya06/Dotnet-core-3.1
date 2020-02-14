
namespace RepositorywithDI.Controllers
{
    #region Using
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RepositorywithDI.Models;
    using RepositorywithDI.Models.ViewModel;
    using RepositorywithDI.Services;
    using RepositorywithDI.Services.Interfaces;
    using System;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// AuthController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        #region Properties
        private readonly IAuthService _authService;
        private readonly IEmployeeService _employeeService;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthController(IAuthService authService, IEmployeeService employeeService)
        {
            _authService = authService;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Authenticates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<AuthenticationResponse> Authenticate([FromBody]AuthenticateModel model)
        {
            try
            {
                var user = await _authService.Authenticate(model.Username, model.Password);

                if (user == null)
                {
                    return new AuthenticationResponse()
                    {
                        Token = user,
                        Message = "Username or password is incorrect",
                        IsError = true
                    };
                }

                return new AuthenticationResponse()
                {
                    Token = user,
                    Message = "Login Sucessfully",
                    IsError = false
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse()
                {
                    Token = new TokenResponse(),
                    Message = ex.Message,
                    IsError = true
                };
            }
         
        }
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<SingleReponse<Employee>> Post(Employee model)
        {
            try
            {
                var employee = await _employeeService.Insert(model);
                if (employee == null)
                {
                    return new SingleReponse<Employee>()
                    {
                        IsError = true,
                        Message = "An Error Occured While Processing Please Try Again Or Contact Administrator.",
                        Data = new Employee()
                    };
                }
                else
                {
                    return new SingleReponse<Employee>()
                    {
                        IsError = false,
                        Message = "Employee Created Sucessfully.",
                        Data = employee
                    };
                }
            }
            catch (Exception ex)
            {
                return new SingleReponse<Employee>()
                {
                    Data = new Employee(),
                    IsError = true,
                    Message = ex.Message,
                };
            }
        }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("{refreshToken}/refresh")]
        public async Task<SingleReponse<TokenResponse>> RefreshToken([FromRoute]string refreshToken)
        {
            try
            {
                var user = await _authService.RefreshToken(refreshToken);

                if (user == null)
                {
                    return new SingleReponse<TokenResponse>()
                    {
                        Data = user,
                        Message = "Refresh Token is incorrect",
                        IsError = true
                    };
                }
                return new SingleReponse<TokenResponse>()
                {
                    Data = user,
                    Message = "Token Granted Sucessfully",
                    IsError = false
                };
            }
            catch (Exception ex)
            {
                return new SingleReponse<TokenResponse>()
                {
                    Data = new TokenResponse(),
                    IsError = true,
                    Message = ex.Message,
                };
            }
           
        }
    }
}
