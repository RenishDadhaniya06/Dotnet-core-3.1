
namespace RepositorywithDI.Services.Interfaces
{
    #region Using
    using RepositorywithDI.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// IStoreProcedureService
    /// </summary>
    public interface IStoreProcedureService
    {
        List<Users> GetUsersfromSP();
        Task<List<Role>> GetRole(int take, int skip);
    }
}
