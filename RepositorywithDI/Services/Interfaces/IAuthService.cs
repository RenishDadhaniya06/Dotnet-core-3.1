
namespace RepositorywithDI.Services
{
    #region Using
    using RepositorywithDI.Models.ViewModel;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// IUserService
    /// </summary>
    public interface IAuthService
    {
        
        Task<TokenResponse> Authenticate(string username, string password);
        Task<TokenResponse> RefreshToken(string refreshToken);
    }
}
