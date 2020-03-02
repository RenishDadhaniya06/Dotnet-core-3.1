
namespace RepositorywithDI.Services.Classes
{
    #region Using
    using RepositorywithDI.DBContext;
    using RepositorywithDI.Models;
    using RepositorywithDI.Repository.Interfaces;
    using RepositorywithDI.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// StoreProcedureService
    /// </summary>
    /// <seealso cref="RepositorywithDI.Services.Interfaces.IStoreProcedureService" />
    public class StoreProcedureService : IStoreProcedureService
    {

        #region Properties
        private readonly DatabaseContext dbcontext;
        private readonly IBaseRepository<Role> _roleRepository;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="StoreProcedureService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public StoreProcedureService(DatabaseContext databaseContext, IBaseRepository<Role> roleRepository)
        {
            dbcontext = databaseContext;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Gets the usersfrom sp.
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsersfromSP()
        {
            try
            {
                List<Users> users = new List<Users>();
                SqlHelper.LoadStoredProc(dbcontext, "GetAllUsers")
                        //.WithSqlParam("@lastupdatedfrom", lastUpdatedFrom)
                        ////        .WithSqlParam("@startwithuserid", startWithUserId)
                        .ExecuteStoredProc((handler) =>
                        {
                            users.AddRange(handler.ReadToList<Users>());

                        });
                return users;
            }
            catch (Exception)
            {
                return new List<Users>();
            }
        }

        public async Task<List<Role>> GetRole(int take, int skip)
        {
            try
            {
                var employee = await _roleRepository.FindBy(_=>_.IsDelete == false);
                return employee.Take(take).Skip(skip).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
