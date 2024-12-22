using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class EmployeeData
    {
        SqlConnection connection=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        //public List<EmployeeData> employeeListData()
        //{
        //    List<EmployeeData> listData= new List<EmployeeData>();
        //    if(connection.State != ConnectionState.Open)
        //    {
        //        try
        //        {
        //            connection.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
        //}
    }
}
