using System;

namespace XamarinTestTask.ViewModels
{
    public class DateProposalsViewModel : SelectableBaseViewModel
    {
        public DateProposalsViewModel(DateTime day, bool anyPending, bool anyActive, bool anyCompleted)
        {
            Date = day;
            Day = day.Day;
            DayOfTheWeek = ((DayOfWeek)day.DayOfWeek).ToString().Substring(0, 2);

            AnyPending = anyPending;
            AnyActive = anyActive;
            AnyCompleted = anyCompleted;
        }

        public DateTime Date { get; set; }

        public string DayOfTheWeek { get; set; }

        public int Day { get; set; }

        public bool AnyPending { get; set; }
        public bool AnyActive { get; set; }
        public bool AnyCompleted { get; set; }
    }
}
