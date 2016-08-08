using System;

namespace TimeSheet2017.AppCode
{
    public class DateIs
    {
        //determines if a string date falls within this week's current pay period 
        //defined as 12:00 AM Sunday through 11:59 PM Saturday.  Returns boolian

        public bool inCurrentPayPeriod(String _inDate)
        {
            //check to make sure it looks like a date
            DateTime temp;
            if (!DateTime.TryParse(_inDate, out temp)) { return false; }

            //convert the input date string to Date Time type so we can work with it
            DateTime inDate = Convert.ToDateTime(_inDate);
            DateTime start_day = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            DateTime end_day = start_day.AddDays(6);

            //test to see if date is within the current pay period
            if (inDate >= start_day && inDate <= end_day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}