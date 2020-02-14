namespace RepositorywithDI.Models.ViewModel
{
    /// <summary>
    /// TokenResponse
    /// </summary>
    public class TokenResponse 
    {
        public string Token { get; set; }
        public string ExpireIn { get; set; }
        public string RefreshToken { get; set; }

        public Employee Employee { get; set; }

    }
}
