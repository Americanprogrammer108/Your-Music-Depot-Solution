using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Your_Music_Depot_Application_DBAS6201.Pages.Login.Student;

namespace Your_Music_Depot_Application_DBAS6201.Pages.Login.Instructor
{
    public class StudentSummaryModel : PageModel
    {
        public List<Student> Students = new List<Student>();
        public void OnGet()
        {
            try
            {
                String connectionstring = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot_Database;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "SELECT * FROM [Students/Étudiants];";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student instructorInfo = new Student();
                                instructorInfo.FName = reader.GetString(1);
                                instructorInfo.LName = reader.GetString(2);
                                instructorInfo.PhoneNumber = reader.GetInt64(4);
                                instructorInfo.Email = reader.GetString(5);

                                Students.Add(instructorInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }
    public class Student
    {
        public string FName;
        public string LName;
        public string Instrument;
        public long PhoneNumber;
        public string Email;
    }
}
