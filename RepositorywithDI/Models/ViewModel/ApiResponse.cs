using System.Collections.Generic;

namespace RepositorywithDI.Models.ViewModel
{
    /// <summary>
    /// ApiResponse
    /// </summary>
    public class AuthenticationResponse : BaseResponse
    {
        public TokenResponse Token { get; set; }
    }

    public class BaseResponse
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
    }

    public class ListReponse<T>  where T : class
    {
        public int Count { get; set; }
        public List<T> Data { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }

    public class SingleReponse<T> where T : class
    {
        public T Data { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
