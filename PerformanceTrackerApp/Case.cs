using System;
using System.Globalization;

namespace PerformanceTrackerApp
{
    public class Case
    {
        public int Id { get; set; }
        public bool TakenOwnership { get; set; }
        public bool IsClosed { get; set; }
        public bool IsHandedOver { get; set; }

        public string ClosureSummary { get; set; } = "";
        public string HandoverSummary { get; set; } = "";

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Optional Extended Fields
        public string Team { get; set; } = "";
        public string Summary { get; set; } = "";
        public string WhatWentRight { get; set; } = "";
        public string WhatWentWrong { get; set; } = "";
        public string WhereHelpNeeded { get; set; } = "";
        public string WhereNotNeeded { get; set; } = "";

        // Week Group formatted like "2025-W27"
        public string WeekGroup => $"{IsoWeekHelper.GetYear(CreatedDate)}-W{IsoWeekHelper.GetWeekOfYear(CreatedDate):D2}";
    }

    public static class IsoWeekHelper
    {
        // Get ISO 8601 week number (week starts on Monday)
        public static int GetWeekOfYear(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }

        // Get the ISO year (it may differ from calendar year)
        public static int GetYear(DateTime date)
        {
            int week = GetWeekOfYear(date);
            int year = date.Year;

            if (date.Month == 1 && week >= 52)
                year--;
            else if (date.Month == 12 && week == 1)
                year++;

            return year;
        }
    }
}
