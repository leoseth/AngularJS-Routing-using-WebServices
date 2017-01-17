using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
// System.Web.Extensions.dll 
namespace angular_routing_webservice
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentServiceasmx : System.Web.Services.WebService
    {
        [WebMethod]
        public void GetAllStudents()
        {
            List<STUDENTSclass> listStudents = new List<STUDENTSclass>();
            string cs = ConfigurationManager.ConnectionStrings["routing"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from STUDENTS", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    STUDENTSclass student = new STUDENTSclass();
                    student.id = Convert.ToInt32(sdr["id"]);
                    student.name = sdr["name"].ToString();
                    student.gender = sdr["gender"].ToString();
                    student.city = sdr["city"].ToString();
                    listStudents.Add(student);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listStudents));
        }
    }  
}
