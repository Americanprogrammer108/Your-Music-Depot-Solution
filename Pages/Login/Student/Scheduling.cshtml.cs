using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Your_Music_Depot_Application_DBAS6201.Pages.Login.Student
{
    public class SchedulingModel : PageModel
    {
        public int monthnumber = DateTime.Now.Month;
        public string monthname = "";
        public List<Month> Months = new List<Month>();
        public void OnGet()
        {

            Month month = new Month();

            if (monthnumber == 1)
            {
                monthname= "January";
            }
            else if (monthnumber == 2)
            {
                monthname= "February";
            }
            else if (monthnumber == 3)
            {
                monthname= "March";
            }
            else if (monthnumber == 4)
            {
                monthname = "April";
            }
            else if (monthnumber == 5)
            {
                monthname = "May";
            }
            else if (monthnumber == 6)
            {
                monthname = "June";
            }
            else if (monthnumber == 7)
            {
                monthname = "July";
            }
            else if (monthnumber == 8)
            {
                monthname = "August";
            }
            else if (monthnumber == 9)
            {
                monthname = "September";
            }
            else if (monthnumber == 10)
            {
                monthname = "October";
            }
            else if (monthnumber == 11)
            {
                monthname = "November";
            }
            else if (monthnumber == 12)
            {
                monthname = "December";
            }
            month.name = monthname;
            Months.Add(month);
        }

        public void OnPost()
        {
            //monthnumber = DateTime.Now.Month;
            Month month = new Month();
            
            if (Request.Form["next"] == "next")
            {
                if (monthnumber == 12)
                {
                    monthnumber = 1;
                }
                else
                {
                    monthnumber++;
                }
                Console.WriteLine(monthnumber);
            }


            if (monthnumber == 1)
            {
                monthname = "January";
            }
            else if (monthnumber == 2)
            {
                monthname = "February";
            }
            else if (monthnumber == 3)
            {
                monthname = "March";
            }
            else if (monthnumber == 4)
            {
                monthname = "April";
            }
            else if (monthnumber == 5)
            {
                monthname = "May";
            }
            else if (monthnumber == 6)
            {
                monthname = "June";
            }
            else if (monthnumber == 7)
            {
                monthname = "July";
            }
            else if (monthnumber == 8)
            {
                monthname = "August";
            }
            else if (monthnumber == 9)
            {
                monthname = "September";
            }
            else if (monthnumber == 10)
            {
                monthname = "October";
            }
            else if (monthnumber == 11)
            {
                monthname = "November";
            }
            else if (monthnumber == 12)
            {
                monthname = "December";
            }

            month.name = monthname;
            Months.Add(month);
        }

        public class Month
        {
            public string name;
        }
    }
}
