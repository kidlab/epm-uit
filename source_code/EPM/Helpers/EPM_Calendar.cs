using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Web.UI.WebControls;
using EPM.Models;

namespace EPM.Helpers
{
    public static class EPM_Calendar
    {
        public static Task Task { get; private set; }
        public static ITaskRepository _taskRepository = new TaskRepository();
        public static Milestone Milestone { get; private set; }
        public static IMilestoneRepository _milestoneRepository = new MilestoneRepository();  

        private static int blank;
        private static DateTime date;
        private static int day;
        private static int month;
        private static int year;
        private static DateTime temp;
        private static DateTime temp1;
        private static DateTime first_day;  
        private static DateTime last_day;
        private static string title; 
        private static string day_of_week;
        private static int days_in_month;
        private static List<Milestone> allMilestones = new List<Milestone>();
        private static List<Task> allTasks = new List<Task>();

        public static string calendar(this HtmlHelper helper, int type, int user_id, int project_id) 
        { 
            //This gets today's date
            date = DateTime.Now;
            
            //This puts the day, month, and year in seperate variables
            day     = date.Day;
            month   = date.Month;
            year    = date.Year;

            //Here we generate the first day of the month
            temp = date;
            temp1 = date;
            first_day = temp.AddDays(-(temp.Day - 1));  
            last_day  = temp1.AddMonths(1).AddDays(-(temp1.Day));

            //This gets us the month name
            title = date.ToString("MMMM"); 

            //Here we find out what day of the week the first day of the month falls on
            day_of_week = first_day.DayOfWeek.ToString();

            //Once we know what day of the week it falls on, we know how many blank days occure before it. If the first day of the week is a Sunday then it would be zero
            
            switch(day_of_week){
                case "Sunday": blank = 0; break;
                case "Monday": blank = 1; break;
                case "Tueday": blank = 2; break;
                case "Wedday": blank = 3; break;
                case "Thuday": blank = 4; break;
                case "Friday": blank = 5; break;
                case "Satday": blank = 6; break;
            }

            //We then determine how many days are in the current month
            days_in_month = last_day.Day - first_day.Day + 1 ;

            if (type == 1)
            {
                return renderBigCalendar(user_id, project_id);
            }
            else
            {
                return renderSmallCalendar();
            }
        }

        public static string renderBigCalendar(int user_id, int project_id)
        {
            //Here we start building the table heads
            string cal = "<div class='table-cover'>  Calendar </div>";
            cal += "<div class='calendar-wrapper'>";
            cal += "<table border=1 width=294>";
            cal += "<tr><th colspan=7>" + title + " " + year + "</th></tr>";
            cal += "<tr class='header'><td width=42>S</td><td width=42>M</td><td width=42>T</td><td width=42>W</td><td width=42>T</td><td width=42>F</td><td width=42>S</td></tr>";

            //This counts the days in the week, up to 7
            int day_count = 1;

            cal += "<tr>";
            //first we take care of those blank days
            while (blank > 0)
            {
                cal += "<td></td>";
                blank = blank - 1;
                day_count++;
            }

            //sets the first day of the month to 1
            int day_num = 1;

            //--------------------
            
            
            if (project_id < 0)
            {
                allMilestones = _milestoneRepository.GetMilestonesByUser(user_id).ToList();
                allTasks = _taskRepository.GetTasksByUser(user_id).ToList();
            }
            else
            {
                allMilestones = _milestoneRepository.GetMilestonesByUserProjectId(user_id, project_id).ToList();
                allTasks = _taskRepository.GetTaskByUserProjectId(user_id, project_id).ToList();
            }
            //-----------------

            //count up the days, untill we've done all of them in the month
            while (day_num <= days_in_month)
            {
                string classes = "";
                if (first_day.Date.Equals(date.Date))
                {
                    classes = "class='link'";
                }
                string task_str = "";
                foreach (Task task in allTasks)
                {
                    if (first_day.Date.Equals(task.end.Date))
                    {
                        task_str = "<a href='/Task/Edit/" + task.id + "'><img src='/Content/images/task.png'></img></a>";
                    }
                }
                string milestone_str = "";
                foreach (Milestone milestone in allMilestones)
                {
                    if (first_day.Date.Equals(milestone.end))
                    {
                        milestone_str = "<a href='/Milestone/Edit/" + milestone.id + "'><img src='/Content/images/miles.png'></img></a>";
                    }
                }

                cal += "<td " + classes + "> " + day_num + "<div>" + milestone_str + task_str + "</div></td>";
                day_num++;
                first_day = first_day.AddDays(1);
                day_count++;

                //Make sure we start a new row every week
                if (day_count > 7)
                {
                    cal += "</tr><tr>";
                    day_count = 1;
                }
            }

            //Finaly we finish out the table with some blank details if needed
            while (day_count > 1 && day_count <= 7)
            {
                cal += "<td> </td>";
                day_count++;
            }
            cal += "</tr></table></div>";

            return cal;
        }

        public static string renderSmallCalendar()
        {
            //Here we start building the table heads
            string cal = "<div class='calendar-sidebar-wrapper'>";
            cal += "<table border=1 width=294>";
            cal += "<tr><th colspan=7>" + title + " " + year + "</th></tr>";
            cal += "<tr class='header'><td width=42>S</td><td width=42>M</td><td width=42>T</td><td width=42>W</td><td width=42>T</td><td width=42>F</td><td width=42>S</td></tr>";

            //This counts the days in the week, up to 7
            int day_count = 1;

            cal += "<tr>";
            //first we take care of those blank days
            while (blank > 0)
            {
                cal += "<td></td>";
                blank = blank - 1;
                day_count++;
            }

            //sets the first day of the month to 1
            int day_num = 1;

            //--------------------
  //          List<Task> allTasks = _taskRepository.GetTasksByUser(1).ToList();

            //-----------------

            //count up the days, untill we've done all of them in the month
            while (day_num <= days_in_month)
            {

                string classes = "";
  //              foreach (Task task in allTasks)
  //              {
                    if (first_day.Date.Equals(date.Date))
                    {
                        classes = "link";
                    }
 //               }

                cal += "<td class='" + classes + "'> " + day_num + " </td>";
                day_num++;
                first_day = first_day.AddDays(1);
                day_count++;

                //Make sure we start a new row every week
                if (day_count > 7)
                {
                    cal += "</tr><tr>";
                    day_count = 1;
                }
            }

            //Finaly we finish out the table with some blank details if needed
            while (day_count > 1 && day_count <= 7)
            {
                cal += "<td> </td>";
                day_count++;
            }
            cal += "</tr></table></div>";

            return cal;
        }
    }    		
}
