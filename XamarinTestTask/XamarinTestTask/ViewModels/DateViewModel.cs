using System;

namespace XamarinTestTask.ViewModels
{
    public class DateViewModel : BaseViewModel
    {
        public DateViewModel(DateTime day)
        {
            Day = day.Day.ToString();
            DayOfTheWeek = ((DayOfWeek)day.DayOfWeek).ToString().Substring(0, 2);
        }

        public string DayOfTheWeek { get; set; }

        public string Day { get; set; }
    }
}
