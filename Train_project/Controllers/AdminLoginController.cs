using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Train_project.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Train_project.Controllers
{
    public class AdminLoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=(local)\\sqlexpress; database=Train_database; integrated security= SSPI";
        }
        [HttpPost]
        public IActionResult Verify(AdminLogin model)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.AdminLogins WHERE username='"+model.username+"' AND password='"+model.password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            

        }

    }
}
