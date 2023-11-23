using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static Your_Music_Depot_Application_DBAS6201.Pages.LoginModel;

namespace Your_Music_Depot_Application_DBAS6201.Pages
{
    public class RegisterModel : PageModel
    {
        public List<newStudent> UserInfo = new List<newStudent>();
        public newStudent newstudent = new newStudent();
        public void OnGet()
        {

        }

        public void OnPost()
        {
            Random rand = new Random();
            String lengthpassword = Request.Form["password"];

            //generate a random ID
            
            if (Request.Form["firstname"] == "" || long.TryParse(Request.Form["firstname"], out long invalidfirstname) ||
                Request.Form["lastname"] == "" || long.TryParse(Request.Form["lastname"], out long invalidlastname) ||
                Request.Form["age"] == "" || !long.TryParse(Request.Form["age"], out long invalidage) ||
                Request.Form["instrument"] == "" || long.TryParse(Request.Form["instrument"], out long invalidinstrument) ||
                Request.Form["skilllevel"] == "" || long.TryParse(Request.Form["skilllevel"], out long invalidskill) ||
                Request.Form["phonenumber"] == "" ||
                Request.Form["email"] == "" || Request.Form["email"].Contains("@") ||
                Request.Form["password"] == "" || lengthpassword.Length <= 8)
            {
                if (Request.Form["firstname"] == "")
                {
                    Console.WriteLine("Please enter a first name!");
                }
                else if (long.TryParse(Request.Form["firstname"], out invalidfirstname))
                {
                    Console.WriteLine("The first name cannot be a number!");
                }
            
                if (Request.Form["lastname"] == "")
                {
                    Console.WriteLine("Please enter a last name!");
                }
                else if (long.TryParse(Request.Form["lastname"], out invalidlastname))
                {
                    Console.WriteLine("The last name cannot be a number!");
                }

                if (Request.Form["age"] == "")
                {
                    Console.WriteLine("Please enter a age!");
                }
                else if (!long.TryParse(Request.Form["age"], out long invalidage2))
                {
                    Console.WriteLine("Age not numeric!");
                }

                if (Request.Form["instrument"] == "")
                {
                    Console.WriteLine("Please select an option!");
                }
                else if (long.TryParse(Request.Form["instrument"], out invalidinstrument))
                {
                    Console.WriteLine("Instrument cannot be a number!");
                }

                if (Request.Form["skilllevel"] == "")
                {
                    Console.WriteLine("Please select a level!");
                }

                if (Request.Form["phonenumber"] == "")
                {
                    Console.WriteLine("Please enter a phone number!");
                }

                if (Request.Form["email"] == "")
                {
                    Console.WriteLine("Please enter an email!");
                }
                else if (Request.Form["email"].Contains("@"))
                {
                    Console.WriteLine("The @ is missing!");
                }

                if (Request.Form["password"] == "")
                {
                    Console.WriteLine("Please enter a password");
                }
                else if (lengthpassword.Length <= 8)
                {
                    Console.WriteLine("Password is not strong enough!");
                }
                Console.WriteLine("Registration failed");
            }
            else
            {


                //if validation is successful, go here
                if (long.TryParse(Request.Form["phonenumber"], out long phonenumber))
                {
                    phonenumber = long.Parse(Request.Form["phonenumber"]);
                }
                newstudent.StudentEmail = Request.Form["email"];
                newstudent.StudentPassword = Request.Form["password"];

                if (long.TryParse(Request.Form["age"], out long age) )
                {
                    age = long.Parse(Request.Form["age"]);
                }
                Console.WriteLine(phonenumber);
                try
                {
                    Console.WriteLine(Request.Form["firstname"]);
                    Console.WriteLine(Request.Form["lastname"]);
                    Console.WriteLine(Request.Form["age"]);
                    Console.WriteLine(Request.Form["instrument"]);
                    Console.WriteLine(Request.Form["skilllevel"]);
                    Console.WriteLine(Request.Form["phonenumber"]);
                    Console.WriteLine(Request.Form["email"]);
                    Console.WriteLine(Request.Form["password"]);
                    /**/
                    String connectionString = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot_Database;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String insertNew = "INSERT INTO [Students/Étudiants] ([Student First Name/Prénom de l'étudiant], [Student Last Name/Nom de famille de l'étudiant], [Student Age/Âge de l'étudiant],  [Student Phone Number/Numéro de téléphone de l'étudiant], [Student Email/Courriel de l'étudiant], [Student Account Password/Mot de passe du compte étudiant]) VALUES('"+ Request.Form["firstname"] + "', '" + Request.Form["lastname"] + "', " + age + ", " + phonenumber +", '"+ Request.Form["email"] +"', HASHBYTES('SHA2_256', '"+ Request.Form["password"] +"'));";
                        Console.WriteLine(insertNew);

                        String retrieve = "SELECT * FROM [Students/Étudiants] WHERE [Student Email/Courriel de l'étudiant] = '" + Request.Form["email"] + "';";

                        Console.Write(retrieve);

                        String insertNew2 = "INSERT INTO [Student Music Progress/Progrès musicaux des étudiants]([Student ID/Carte d'étudiant], [Student Instrument/Instrument étudiant], [Student Skill Level/Niveau de compétence de l'étudiant]) VALUES ('" + Request.Form["instrument"] + "', '" + Request.Form["skilllevel"] + "');";
                        
                        Console.Write(insertNew2);
                        /*using (SqlCommand command = new SqlCommand(insertNew, connection))
                        {
                            command.ExecuteNonQuery();
                        }*/
                        
                        using (SqlCommand command2 =  new SqlCommand(retrieve, connection))
                        {
                            using (SqlDataReader reader = command2.ExecuteReader())
                            {
                                newStudent getuser = new newStudent();
                                while (reader.Read())
                                {
                                    getuser.StudentID = reader.GetInt64(0);
                                    getuser.StudentFirstName = reader.GetString(1);
                                    getuser.StudentLastName = reader.GetString(2);
                                    getuser.StudentAge = reader.GetByte(3);
                                    getuser.StudentPhoneNumber = reader.GetInt64(4);
                                    getuser.StudentEmail = reader.GetString(5);
                                    UserInfo.Add(getuser);
                                }
                                Console.WriteLine(getuser.StudentPassword);
                                
                            }
                            //insertNew2 = "INSERT INTO [Student Music Progress/Progrès musicaux des étudiants]([Student ID/Carte d'étudiant], [Student Instrument/Instrument étudiant], [Student Skill Level/Niveau de compétence de l'étudiant]) VALUES ( " + getuser.StudentID + ", '" + Request.Form["instrument"] + "', '" + Request.Form["skilllevel"] + "');";

                            using (SqlCommand command3 = new SqlCommand(insertNew2, connection))
                            {
                                command3.ExecuteNonQuery();
                            }
                        }
                        connection.Close();
                        Console.WriteLine("Login successful");

                        Response.Redirect("Login/Student/Dashboard");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        public class newStudent
        {
            public long StudentID;
            public string StudentFirstName;
            public string StudentLastName;
            public byte StudentAge;
            public string StudentInstrumentPreference;
            public string StudentSkillLevel;
            public long StudentPhoneNumber;
            public string StudentEmail;
            public string StudentPassword;
             
        }
    }
}
