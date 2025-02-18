using DAL;
using IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

//namespace Services
//{
//    public class EmployeeService :IEmployee
//    {
//        private readonly IConfiguration _config;
//        private readonly IDAL  _dal;
//        public EmployeeService(IConfiguration config, IDAL dal ) {

//            _config = config;
//            _dal = dal;

//        }



//        public async Task<bool> InsertEmployeeDetails(ClsEmployeeviewModel data)
//        {
//            bool result = false;
//            try
//            {
//                SqlCommand cmd = new SqlCommand("SP_InsertEmployeeDetails");
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Employnumber", data.Employnumber);
//                cmd.Parameters.AddWithValue("@Employname", data.EmployeeName);
//                cmd.Parameters.AddWithValue("@EmployType", data.EmployeeType);
//                cmd.Parameters.AddWithValue("@EmploySalary", data.EmployeeSalary);
//                cmd.Parameters.AddWithValue("@AdharNo", data.AdharNo);
//                cmd.Parameters.AddWithValue("@panNo", data.Panno);
//                cmd.Parameters.AddWithValue("@FileName", data.FileName);
//                _dal.ExecuteAsync(cmd);
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//            return true;


//        }




//        public async Task<List<TblEmployeeDummy>> GetAllEmployeeDetails()
//        {
//            List<TblEmployeeDummy> employees = new List<TblEmployeeDummy>();
//            try
//            {
//                SqlCommand cmd = new SqlCommand("getallemployeedetail");
//                cmd.CommandType = CommandType.StoredProcedure;

//                DataTable dt = await _dal.GetDataAsync(cmd);
//                foreach (DataRow row in dt.Rows)
//                {
//                    employees.Add(new TblEmployeeDummy
//                    {
//                        Id= row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0,
//                        Employnumber = row["Employnumber"] != DBNull.Value ? Convert.ToString(row["Employnumber"]) : "",
//                        EmployeeName = row["EmployeeName"] != DBNull.Value ? row["EmployeeName"].ToString() : "",
//                        EmployeeSalary = row["EmployeeSalary"] != DBNull.Value ? Convert.ToDecimal(row["EmployeeSalary"]) : 0,
//                        AdharNo = row["AdharNo"] != DBNull.Value ? row["AdharNo"].ToString() : "",
//                        Panno = row["Panno"] != DBNull.Value ? row["Panno"].ToString() : "",

//                    });
//                }

//            }
//            catch (Exception)
//            {

//            }
//            return employees;


//            }

//        public  async Task<List<TblEmployeeType>> GetEmployeeType()
//        {
//            List<TblEmployeeType> employees = new List<TblEmployeeType>();
//            try
//            {
//                SqlCommand cmd = new SqlCommand("getallemployeedetail");
//                cmd.CommandType = CommandType.StoredProcedure;

//                DataTable dt = await _dal.GetDataAsync(cmd);
//                foreach (DataRow row in dt.Rows)
//                {
//                    employees.Add(new TblEmployeeType
//                    {
//                        Id = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0,
//                        EmployeeType = row["EmployeeType"] != DBNull.Value ? Convert.ToString(row["EmployeeType"]) : "",


//                    });
//                }

//            }
//            catch (Exception)
//            {

//            }
//            return employees;
//        }


//        public async Task<bool> UpdateEmployeeDetails(string Employeename, string Employeenumber, string panno, string aadharno, decimal employeesalary, int employeetype, int id,string FileName)
//        {
//            try
//            {
//                SqlCommand cmd = new SqlCommand("SP_UpdateEmployeeDetails")
//                {
//                    CommandType = CommandType.StoredProcedure
//                };
//                cmd.Parameters.AddWithValue("@EmployeeId", id);
//                cmd.Parameters.AddWithValue("@Employnumber", Employeenumber);
//                cmd.Parameters.AddWithValue("@Employname", Employeename);
//                cmd.Parameters.AddWithValue("@EmployType", employeetype);
//                cmd.Parameters.AddWithValue("@EmploySalary", employeesalary);
//                cmd.Parameters.AddWithValue("@AdharNo", aadharno);
//                cmd.Parameters.AddWithValue("@panNo", panno);
//                cmd.Parameters.AddWithValue("@FileName", FileName);

//                return await _dal.ExecuteAsync(cmd);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }


//        public async Task<bool> DeleteEmployee(int employeeId)
//        {
//            try
//            {
//                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee")
//                {
//                    CommandType = CommandType.StoredProcedure
//                };
//                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

//                return await _dal.ExecuteAsync(cmd);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<TblEmployeeDummy> getAllEmployeeBYID(int id)
//        {
//            TblEmployeeDummy employee = null; // Change to a single object
//            try
//            {
//                SqlCommand cmd = new SqlCommand("Sp_EmployeeDetailsByID");
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@id", id);

//                DataTable dt = await _dal.GetDataAsync(cmd);
//                if (dt.Rows.Count > 0) // Ensure at least one record is returned
//                {
//                    DataRow row = dt.Rows[0]; // Take the first row
//                    employee = new TblEmployeeDummy
//                    {
//                        Id = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0,
//                        Employnumber = row["Employnumber"] != DBNull.Value ? Convert.ToString(row["Employnumber"]) : "",
//                        EmployeeName = row["EmployeeName"] != DBNull.Value ? row["EmployeeName"].ToString() : "",
//                        EmployeeType = row["EmployeeType"] != DBNull.Value ? Convert.ToInt32(row["EmployeeType"]) : 0,
//                        EmployeeSalary = row["EmployeeSalary"] != DBNull.Value ? Convert.ToDecimal(row["EmployeeSalary"]) : 0,
//                        AdharNo = row["AdharNo"] != DBNull.Value ? row["AdharNo"].ToString() : "",
//                        Panno = row["Panno"] != DBNull.Value ? row["Panno"].ToString() : "",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (consider using logging frameworks like Serilog or NLog)
//                Console.WriteLine(ex.Message);
//            }

//            return employee; // Return a single employee object or null if not found
//        }

//    }
//}

namespace Services
{
    public class EmployeeService : IEmployee
    {

        private readonly IDAL db;
        private readonly IConfiguration config;

        public EmployeeService(IDAL db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }



        public async Task<List<TblEmployeeType>> GetEmployeeType()
        {


            List<TblEmployeeType> Rsp = new List<TblEmployeeType>();
            SqlCommand cmd = new SqlCommand("GetEMployeeType");
            //cmd.Parameters.AddWithValue("@userID", userID);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = db.GetData(cmd);
            Rsp = dataTable.AsEnumerable().Select(
                row => new TblEmployeeType
                {
                    Id = row.Table.Columns.Contains("id") && !row.IsNull("id") ? row.Field<int>("id") : 0,
                    EmployeeType = row.Table.Columns.Contains("EmployeeType") && !row.IsNull("EmployeeType") ? row.Field<string>("EmployeeType") : "",

                }).ToList();

            return Rsp;
        }

        public async Task<bool> InsertEmployeeDetails(ClsEmployeeviewModel data)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SetEmployeeDetails");
                cmd.Parameters.AddWithValue("@EmployeeName", data.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeNumber", data.Employnumber);
                cmd.Parameters.AddWithValue("@EmployeeRegDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@EmployeeType", data.EmployeeType);
                cmd.Parameters.AddWithValue("@EmployeeSalary", data.EmployeeSalary);
                cmd.Parameters.AddWithValue("@EmployeeAddharNo", data.AdharNo);
                cmd.CommandType = CommandType.StoredProcedure;
                db.Execute(cmd);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public async Task<List<ClsEmployeeviewModel>> GetallEmployeeDetails()
        {
            List<ClsEmployeeviewModel> Rsp = new List<ClsEmployeeviewModel>();
            SqlCommand cmd = new SqlCommand("GetEmployeeDetails");
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = db.GetData(cmd);
            Rsp = dataTable.AsEnumerable().Select(
                row => new ClsEmployeeviewModel
                {
                    EmployeeID = row.Table.Columns.Contains("id") && !row.IsNull("id") ? row.Field<int>("id") : 0,
                    Employnumber = row.Table.Columns.Contains("Employnumber") && !row.IsNull("Employnumber") ? row.Field<string>("Employnumber") : "",
                    EmployeeName = row.Table.Columns.Contains("EmployeeName") && !row.IsNull("EmployeeName") ? row.Field<string>("EmployeeName") : "",
                    AdharNo = row.Table.Columns.Contains("AdharNo") && !row.IsNull("AdharNo") ? row.Field<string>("AdharNo") : "",
                    EmployeeType = row.Table.Columns.Contains("EmployeeType") && !row.IsNull("EmployeeType") ? row.Field<int>("EmployeeType") : 0,
                    EmployeeSalary = row.Table.Columns.Contains("EmployeeSalary") && !row.IsNull("EmployeeSalary") ? row.Field<decimal>("EmployeeSalary") : 0,

                }).ToList();

            return Rsp;
        }


        public async Task<ClsEmployeeviewModel> GetEmployeeDetailsBYID(int ID)
        {
            ClsEmployeeviewModel employee = null;
            SqlCommand cmd = new SqlCommand("GetEmployeeDetailsbyID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            DataTable dataTable = db.GetData(cmd);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0]; // Get the first row
                employee = new ClsEmployeeviewModel
                {
                    EmployeeID = row.Table.Columns.Contains("id") && !row.IsNull("id") ? row.Field<int>("id") : 0,
                    Employnumber = row.Table.Columns.Contains("EmployyeNumber") && !row.IsNull("EmployyeNumber") ? row.Field<string>("EmployyeNumber") : "",
                    EmployeeName = row.Table.Columns.Contains("EmployeeName") && !row.IsNull("EmployeeName") ? row.Field<string>("EmployeeName") : "",
                    AdharNo = row.Table.Columns.Contains("EmployeeAdharNo") && !row.IsNull("EmployeeAdharNo") ? row.Field<string>("EmployeeAdharNo") : "",
                    EmployeeType = row.Table.Columns.Contains("EmployeeType") && !row.IsNull("EmployeeType") ? row.Field<int>("EmployeeType") : 0,
                    EmployeeSalary = row.Table.Columns.Contains("EmployeeSalary") && !row.IsNull("EmployeeSalary") ? row.Field<decimal>("EmployeeSalary") : 0,
                };
            }

            return employee; // Returns null if no records found
        }


        public async Task<bool> UpdateEmployeeDetails(int id, string EmployeeName, string EmployyeNumber, int EmployeeType, string EmployeeSalary, string EmployeeAdharNo)
        {
            SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeNumber", EmployyeNumber);
            cmd.Parameters.AddWithValue("@EmployeeRegDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@EmployeeType", EmployeeType);
            cmd.Parameters.AddWithValue("@EmployeeSalary", EmployeeSalary);
            cmd.Parameters.AddWithValue("@EmployeeAddharNo", EmployeeAdharNo);
            cmd.CommandType = CommandType.StoredProcedure;
            db.Execute(cmd);

            return true;
        }

        public async Task<bool> DeleteEmployeeDetails(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteEmployeeDetails");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            db.Execute(cmd);
            return true;
        }
    }
}