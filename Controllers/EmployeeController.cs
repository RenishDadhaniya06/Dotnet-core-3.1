using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorywithDI.Models;
using RepositorywithDI.Models.ViewModel;
using RepositorywithDI.Services.Interfaces;

namespace RepositorywithDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        #region Properties
        public IEmployeeService _service;
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="service">The Employee service.</param>
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll/{take}/{skip}")]
        public async Task<ListReponse<Employee>> GetAll(string take,string skip)
        {
            try
            {
                var data = await _service.Get(Convert.ToInt32(take), Convert.ToInt32(skip));
                return new ListReponse<Employee>()
                {
                    Data = data,
                    Count = data.Count,
                    IsError = false,
                    Message = string.Empty,
                };
            }
            catch (Exception ex)
            {
                return new ListReponse<Employee>()
                {
                    Data = new List<Employee>(),
                    Count = 0,
                    IsError = true,
                    Message = ex.Message,
                };
            }
        }


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<SingleReponse<Employee>> Get(Guid id)
        {
            try
            {
                var data = await _service.Get(id);

                return new SingleReponse<Employee>()
                {
                    Data = data,
                    IsError = false,
                    Message = string.Empty,
                };
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
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public async Task<SingleReponse<Employee>> Post(Employee model)
        {
            try
            {
                var employee = await _service.Insert(model);
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
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public async Task<SingleReponse<Employee>> Put(Employee model)
        {
            try
            {
                var employee = await _service.Update(model);
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
                        Message = "Employee Updated Sucessfully.",
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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<SingleReponse<Employee>> Delete(Guid id)
        {
            try
            {
                var employee = await _service.Delete(id);
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
                        Message = "Employee Deleted Sucessfully.",
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

    }
}