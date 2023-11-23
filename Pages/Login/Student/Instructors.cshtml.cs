using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Your_Music_Depot_Application_DBAS6201.Pages.Login.Student
{
    public class InstructorsModel : PageModel
    {
        public List<Instructor> Instructors = new List<Instructor>();
        public void OnGet()
        {
            try
            {
                String connectionstring = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot_Database;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "SELECT * FROM [Instructors/Instructeurs] JOIN [Instructor Availability/Disponibilité des instructeurs] ON [Instructors/Instructeurs].[Instructor ID/ID d'instructeur] = [Instructor Availability/Disponibilité des instructeurs].[Instructor ID/ID d'instructeur];";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Instructor instructorInfo = new Instructor();
                                instructorInfo.ID = reader.GetInt64(0);
                                instructorInfo.FName = reader.GetString(1);
                                instructorInfo.LName = reader.GetString(2);
                                instructorInfo.PhoneNumber = reader.GetInt64(4);
                                instructorInfo.Email = reader.GetString(5);
                                instructorInfo.day = reader.GetString(8);
                                instructorInfo.start = reader.GetTimeSpan(9);
                                instructorInfo.end = reader.GetTimeSpan(10);

                                Instructors.Add(instructorInfo);
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

    public class Instructor
    {
        public long ID;
        public string FName;
        public string LName;
        public long PhoneNumber;
        public string Email;
        public string day;
        public TimeSpan start;
        public TimeSpan end;
        Boolean occuring;
    }
}
