using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using student.Models;
using System.Data.SqlClient;

namespace Marklist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        IList<Student> Student = new List<Student>()
        {
           new  Student
           {
               stduentnmae="santhosh",tamil=43,english=34,maths=34,science=34,social=34
           },
        };


        [HttpGet]
        public IList<Student> Get()
        {
            IList<Student> answer = new List<Student>();
            try
            {
                var connectionString = (@"Data Source=LAPTOP-VLB86T9D\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
                using (var connection = new SqlConnection(connectionString))
                {
                    var Getquery = "sELECT stduentnmae As stduentnmae,tamil As tamil,english As english,maths As maths, science As science ,social As social FROM students";
                    answer = connection.Query<Student>(Getquery).ToList();  //for get data
                }
            }
            catch (Exception ex)
            { 
            
            }
            return (IList<Student>)answer;
        }
        [HttpPost]
        public string InsertData(string strStudentName)
        {
            string strMessage = string.Empty;
            try
            {
                var connectionString = (@"Data Source=LAPTOP-VLB86T9D\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
                using (var connection = new SqlConnection(connectionString))
                {
                    var Getquery = "update students set stduentnmae='"+ strStudentName + "'";
                    var rowsAffected = connection.Execute(Getquery); // insert update delete
                    if (rowsAffected > 0)
                    {
                        strMessage = "updated successfully";
                    }
                    else { 
                        strMessage = "Unable to update";
                    }
                }
            }
            catch (Exception ex)
            {
                strMessage = "Problem occured while update";

            }
            return strMessage;
        }
    }


}