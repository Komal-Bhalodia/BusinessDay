using System;
using System.Linq;

namespace BusinessDay
{
    class CalculateBusinessDate
    {
        public DateTime calculateNthWorkingDay(int n)
        {
            DateTime date = DateTime.Now;
           
            DateTime firstOfNextMonth = new DateTime(date.Year,date.Month,1).AddMonths(1);
            DateTime lastOfThisMonth = firstOfNextMonth.AddDays(-1);
            int workingDays = 0;
            DateTime fromDate = new DateTime(2019,lastOfThisMonth.Month, lastOfThisMonth.Day);
                for (int i = 1; i <= n; i++)
                {
                    fromDate = fromDate.AddDays(1);
                    if (!IsWeekEnd(fromDate))
                    {
                        workingDays++;
                    }
                    else
                    {
                        n++;
                    }
                }
   
            return fromDate;
        }

        public bool IsWeekEnd(DateTime dateTime)
        {
            DateTime [] holidays = new DateTime[]
            {
                new DateTime(2019,03,21),
                new DateTime(2019,3,5) 

            };
            bool isWeekEnd = false;
            if ((dateTime.DayOfWeek == DayOfWeek.Saturday) || (dateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                isWeekEnd = true;
            }

            if (holidays.Contains(dateTime.Date))
            {
                isWeekEnd = true;
            }

            return isWeekEnd;
        }
    }

    class Program
    {
         static void Main(string[] args)
         {
               CalculateBusinessDate calculateBusiness = new CalculateBusinessDate();
               Console.WriteLine("the date is : " + calculateBusiness.calculateNthWorkingDay(3));
               Console.ReadLine();
         }
    }  
}
