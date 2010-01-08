using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Web.UI.WebControls;

namespace EPM.Helpers
{
    public static class EPM_Calendar
    {
        private static int blank;
        public static string calendar(this HtmlHelper helper, string target, string text) 
        { 
            //This gets today's date
            DateTime date = DateTime.Now;
            
            //This puts the day, month, and year in seperate variables
            int day     = date.Day;
            int month   = date.Month;
            int year    = date.Year;

            //Here we generate the first day of the month
            DateTime temp = date;
            DateTime temp1 = date;
            DateTime first_day = temp.AddDays(-(temp.Day - 1));  
            DateTime last_day  = temp1.AddMonths(1).AddDays(-(temp1.Day));

            //This gets us the month name
            string title = date.ToString("MMMM"); 

            //Here we find out what day of the week the first day of the month falls on
            string day_of_week = first_day.DayOfWeek.ToString();

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
            int days_in_month = last_day.Day - first_day.Day + 1 ; 

            //Here we start building the table heads
            string cal = "";
            cal += "<table border=1 width=294>";
            cal +=  "<tr><th colspan=7>" + title + " " + year + "</th></tr>";
            cal +=  "<tr><td width=42>S</td><td width=42>M</td><td width=42>T</td><td width=42>W</td><td width=42>T</td><td width=42>F</td><td width=42>S</td></tr>";

            //This counts the days in the week, up to 7
            int day_count = 1;

            cal +=  "<tr>";
            //first we take care of those blank days
            while ( blank > 0 )
            {
                cal +=  "<td></td>";
                blank = blank-1;
                day_count++;
            } 

            //sets the first day of the month to 1
            int day_num = 1;

            //count up the days, untill we've done all of them in the month
            while ( day_num <= days_in_month )
            {
                cal +=  "<td> " + day_num +" </td>";
                day_num++;
                day_count++;

                //Make sure we start a new row every week
                if (day_count > 7)
                {
                    cal +=   "</tr><tr>";
                    day_count = 1;
                }
            } 

            //Finaly we finish out the table with some blank details if needed
            while ( day_count >1 && day_count <=7 )
            {
                cal += "<td> </td>";
                day_count++;
            }
            cal += "</tr></table>";

            return cal;
        } 
    }    		
}
