using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace IRepository
{
    public interface IEmployee
    {
        Task<bool> InsertEmployeeDetails(ClsEmployeeviewModel data);
        Task<List<TblEmployeeType>> GetEmployeeType();
        Task<List<ClsEmployeeviewModel>> GetallEmployeeDetails();
        Task<bool> UpdateEmployeeDetails(int id, string EmployeeName, string EmployyeNumber, int EmployeeType, string EmployeeSalary, string EmployeeAdharNo);
        Task<bool> DeleteEmployeeDetails(int id);
        Task<ClsEmployeeviewModel> GetEmployeeDetailsBYID(int ID);
    }

        
}
