using System;

namespace XamarinTestTask.ViewModels
{
    public class DateProposalsViewModel : SelectableBaseViewModel
    {
        private bool _anyPending;
        private bool _anyActive;
        private bool _anyCompleted;

        public DateProposalsViewModel(DateTime day)
            : this(day, false, false, false)
        {
        }

        public DateProposalsViewModel(DateTime day, bool anyPending, bool anyActive, bool anyCompleted)
        {
            Date = day;
            Day = day.Day;
            DayOfTheWeek = ((DayOfWeek)day.DayOfWeek).ToString().Substring(0, 2);
            DateShort = $"{day.Day.ToString().PadLeft(2, '0')}.{day.Month.ToString().PadLeft(2, '0')}";

            AnyPending = anyPending;
            AnyActive = anyActive;
            AnyCompleted = anyCompleted;
        }

        public DateTime Date { get; set; }

        public string DayOfTheWeek { get; set; }

        public int Day { get; set; }

        public string DateShort { get; set; }

        public bool AnyPending { get { return _anyPending; } set { SetProperty(ref _anyPending, value); } }
        public bool AnyActive { get { return _anyActive; } set { SetProperty(ref _anyActive, value); } }
        public bool AnyCompleted { get { return _anyCompleted; } set { SetProperty(ref _anyCompleted, value); } }
    }
}
