
using System;

//public class Program
//{
//    public static void Main()
//    {
//        int totalFridays = GetTotalFridaysInYear(DateTime.Today.Year);
//        Console.WriteLine($"Total Fridays in {DateTime.Today.Year}: {totalFridays}");
//    }

//    public static int GetTotalFridaysInYear(int year, int month)
//    {
//        int currentYear = DateTime.Today.Year;

//        int totalDays = DateTime.IsLeapYear(currentYear) ? 366 : 365;

//        int totalHours = totalDays * 24;

//        DateTime firstDayOfYear = new DateTime(year, 1, 1);
//        DateTime firstFriday = firstDayOfYear.AddDays((DayOfWeek.Friday - firstDayOfYear.DayOfWeek + 7) % 7);

//        int totalFridays = (int)((new DateTime(year, 12, 31) - firstFriday).TotalDays / 7) + 1;

//        int daysInMonth = DateTime.DaysInMonth(year, month);
//        int fridayCount = 0;

//        for (int day = 1; day <= daysInMonth; day++)
//        {
//            DateTime date = new DateTime(year, month, day);

//            // Check if the day is a Friday
//            if (date.DayOfWeek == DayOfWeek.Friday)
//            {
//                fridayCount++;
//            }
//        }
//        return fridayCount;
//    }

    public class Program1
    {
        public static void Main()
        {
            int month = 12; // December
            int year = 2024;
            int workingHoursPerDay = 8; // Example: 8 hours per working day

            int totalWorkingHours = GetTotalWorkingHoursInMonth(year, month, workingHoursPerDay);
            Console.WriteLine($"Total Working Hours in {month}/{year}: {totalWorkingHours}");
        }

        public static int GetTotalWorkingHoursInMonth(int year, int month, int workingHoursPerDay)
        {
            int workingDaysCount = 0;

            // Get the number of days in the specified month
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Check each day of the month
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);

                // Check if the day is a working day (Monday to Friday)
                if (date.DayOfWeek != DayOfWeek.Friday)
                {
                    workingDaysCount++;
                }
            }

            
            int totalWorkingHours = workingDaysCount * workingHoursPerDay;
            return totalWorkingHours;
        }
    }
 