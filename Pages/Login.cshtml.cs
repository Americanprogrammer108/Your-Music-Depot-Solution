using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace Your_Music_Depot_Application_DBAS6201.Pages
{
    public class LoginModel : PageModel
    {
        public List<User> UserInfo = new List<User>();
        public void OnGet()
        {

        }

        public void OnPost() 
        {
            try
            {
                String connectionString = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot_Database;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (int.TryParse(Request.Form["id"], out int convertedID))
                    {
                        convertedID = int.Parse(Request.Form["id"]);
                    }
                    String selectall = "SELECT * FROM [Students/Étudiants] WHERE [Student Email/Courriel de l'étudiant] = " + Request.Form["email"] + " AND [Student Password/Mot de passe étudiant] = HASHBYTES('SHA2_256', '" + Request.Form["password"] + "');";
                    Console.WriteLine(selectall);
                    using (SqlCommand command = new SqlCommand(selectall, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            User getuser = new User();
                            while (reader.Read())
                            {
                                getuser.ID = reader.GetInt32(0);
                                getuser.password = reader.GetString(8);
                                UserInfo.Add(getuser);
                            }
                            Console.WriteLine(getuser.ID);
                            Console.WriteLine(getuser.password);
                            if (convertedID == getuser.ID)
                            {
                                Console.WriteLine("Login successful");
                                
                                Response.Redirect("Login/Student/Dashboard");
                            }
                            else if (Request.Form["id"] == "" || Request.Form["password"] == "")
                            {
                                Console.WriteLine("Please enter in a value!");
                            }
                            else
                            {
                                Console.WriteLine("The user is not found.");
                            }
                        }
                    }
                    connection.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public class User
        {
            public int ID;
            public string password;
        }
    }
}
