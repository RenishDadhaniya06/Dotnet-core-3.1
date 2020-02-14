
namespace RepositorywithDI.Models.ViewModel
{
    #region Using
    using System.ComponentModel.DataAnnotations;
    #endregion


    /// <summary>
    /// AuthenticateModel
    /// </summary>
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
