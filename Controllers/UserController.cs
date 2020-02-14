
namespace RepositorywithDI.Controllers
{
    #region Using
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RepositorywithDI.Models;
    using RepositorywithDI.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion


    //[Route("api/[controller]")]
    /// <summary>
    /// UserController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        #region Properties
        public IUserService _userservice;
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userservice = userService;
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetAll")]
        public async Task<List<Users>> GetAll()
        {
            try
            {
                //return await _userrepository.GetAll();
                return await _userservice.GetUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/Get/{id}")]
        public async Task<Users> Get(Guid id)
        {
            try
            {
                //return await _userrepository.GetbyId(id);
                return await _userservice.GetUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/User/Post")]
        public async Task<Users> Post(Users model)
        {
            try
            {
                //model.Id = Guid.NewGuid();
                //return await _userrepository.Post(model);
                return await _userservice.InsertUser(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Posts the range.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/User/PostRange")]
        public async Task<List<Users>> PostRange(List<Users> obj)
        {
            try
            {
                //return await _userrepository.InsertRange(obj);
                return await _userservice.InsertUsers(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/User/Put")]
        public async Task<Users> Put(Users model)
        {
            try
            {
                //return await _userrepository.Put(model);
                return await _userservice.UpdateUser(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        [Route("api/User/Delete/{id}")]
        public async Task Delete(Guid id)
        {
            try
            {
                //await _userrepository.Delete(id);
                await _userservice.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the range.
        /// </summary>
        /// <param name="obj">The object.</param>
        [HttpDelete]
        [Route("api/User/DeleteRange")]
        public async Task DeleteRange(List<Users> obj)
        {
            try
            {
                //await _userrepository.DeleteRange(obj);
                await _userservice.DeleteUsers(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpDelete]
        //[Route("api/User/DeleteWhere")]
        //public async Task DeleteWhere()
        //{
        //    try
        //    {
        //        await _userrepository.DeleteWhere(_ => _.FirstName == "Dhaval");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpGet]
        //[Route("api/User/Find")]
        //public async Task<List<Users>> Find()
        //{
        //    try
        //    {
        //        return await _userrepository.FindBy(_ => _.FirstName == "Renish");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Sps the data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/SPData")]
        public List<Users> SPData()
        {
            try
            {
                return _userservice.GetUsersfromSP();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}