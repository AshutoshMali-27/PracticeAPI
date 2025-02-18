using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services;

namespace WebApplication1.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee objMR;

        public EmployeeController(IEmployee _objMR)
        {
            objMR = _objMR;
        }

        [HttpGet("EmployeeType")]
        public async Task<IActionResult> GetEmployeeType()
        {
            var EmployeeType = await objMR.GetEmployeeType();
            return Ok(EmployeeType);
        }


        [HttpGet("GETEmployeeDetails")]
        public async Task<IActionResult> GETEmployeeDetails()
        {
            var EmployeeDetails = await objMR.GetallEmployeeDetails();
            return Ok(EmployeeDetails);
        }

        [HttpGet]
        [Route("GETEmployeeDetailbyID/{ID}")]
        public async Task<IActionResult> GETEmployeeDetailsByID(int ID)
        {
            var EmployeeDetailsbyid = await objMR.GetEmployeeDetailsBYID(ID);
            return Ok(EmployeeDetailsbyid);
        }

        [HttpPost("SetEmployee")]
        public async Task<IActionResult> SaveEmployeeDetails([FromBody] ClsEmployeeviewModel data)
        {
            bool Result = await objMR.InsertEmployeeDetails(data);
            return Ok(Result);
        }

        [HttpGet]
        [Route("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, string EmployeeName, string EmployyeNumber, int EmployeeType, string EmployeeSalary, string EmployeeAdharNo)
        {
            bool Result = await objMR.UpdateEmployeeDetails(id, EmployeeName, EmployyeNumber, EmployeeType, EmployeeSalary, EmployeeAdharNo);
            return Ok(Result);
        }

        [HttpGet]
        [Route("DeteleEmployee/{id}")]
        public async Task<IActionResult> DeteleEmployee(int id)
        {
            bool Result = await objMR.DeleteEmployeeDetails(id);
            return Ok(Result);
        }



    

}













}
