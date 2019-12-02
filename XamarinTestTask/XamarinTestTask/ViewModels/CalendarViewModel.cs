using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamarinTestTask.ViewModels
{
    public class CalendarViewModel : BasePageViewModel
    {
        #region Fields

        private ICommand _archiveTappedCommand;
        private ICommand _previousMonthTappedCommand;
        private ICommand _nextMonthTappedCommand;
        private ICommand _statusItemTappedCommand;
        private ICommand _dateItemTappedCommand;

        private StatusViewModel _selectedStatus;
        private DateProposalsViewModel _selectedDate;

        private List<ProposalViewModel> _proposals = new List<ProposalViewModel>();

        #endregion

        #region Constructors

        public CalendarViewModel()
        {
            Title = "Calendar";

            LoadStatuses();
            LoadVisibleDates(DateTime.Today);
            LoadProposals();
        }

        #endregion

        #region Properties

        public ICommand ArchiveTappedCommand
        {
            get
            {
                return _archiveTappedCommand ?? (_archiveTappedCommand = new Command(async () => await Archive()));
            }
        }

        public ICommand PreviousMonthTappedCommand
        {
            get
            {
                return _previousMonthTappedCommand ?? (_previousMonthTappedCommand = new Command(async () => await SwitchToMonth(false)));
            }
        }

        public ICommand NextMonthTappedCommand
        {
            get
            {
                return _nextMonthTappedCommand ?? (_nextMonthTappedCommand = new Command(async () => await SwitchToMonth(true)));
            }
        }

        public ICommand StatusItemTappedCommand
        {
            get
            {
                return _statusItemTappedCommand ?? (_statusItemTappedCommand = new Command(StatusItemTapped));
            }
        }
        public ICommand DateItemTappedCommand
        {
            get
            {
                return _dateItemTappedCommand ?? (_dateItemTappedCommand = new Command(DateItemTapped));
            }
        }

        public ObservableCollection<DateProposalsViewModel> VisibleDates { get; set; } = new ObservableCollection<DateProposalsViewModel>();
        public ObservableCollection<StatusViewModel> Statuses { get; set; }

        public ObservableCollection<ProposalViewModel> Proposals
        {
            get
            {
                return new ObservableCollection<ProposalViewModel>(
                    _proposals.Where(x => x.JobDates.Any(jd => jd.Date == SelectedDate.Date) && 
                                          x.Status == SelectedStatus.Status));
            }
        }
        
        public StatusViewModel SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != null)
                {
                    _selectedStatus.IsSelected = false;
                }

                _selectedStatus = value;
                if (_selectedStatus != null)
                {
                    _selectedStatus.IsSelected = true;
                }

                OnPropertyChanged(nameof(Proposals));
            }
        }

        public DateProposalsViewModel SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != null)
                {
                    _selectedDate.IsSelected = false;
                }

                _selectedDate = value;
                if (_selectedDate != null)
                {
                    _selectedDate.IsSelected = true;
                }

                OnPropertyChanged(nameof(SelectedMonthTitle));
                OnPropertyChanged(nameof(Proposals));
            }
        }

        public string SelectedMonthTitle
        {
            get
            {
                return $"{(new DateTimeFormatInfo()).GetMonthName(SelectedDate.Date.Month)}, {SelectedDate.Date.Year}";
            }
        }

        #endregion

        #region Methods

        private void LoadStatuses()
        {
            Statuses = new ObservableCollection<StatusViewModel>()
            {
                new StatusViewModel(Enums.ProposalStatus.Pending, (Color)Application.Current.Resources["PendingColor"]),
                new StatusViewModel(Enums.ProposalStatus.Active, (Color)Application.Current.Resources["ActiveColor"]),
                new StatusViewModel(Enums.ProposalStatus.Completed, (Color)Application.Current.Resources["CompletedColor"]),
            };
            SelectedStatus = Statuses.First();
        }

        private void LoadVisibleDates(DateTime newDate)
        {
            VisibleDates.Clear();

            var dates = new List<DateProposalsViewModel>();
            for (int i = 1; i <= DateTime.DaysInMonth(newDate.Year, newDate.Month); i++)
            {
                VisibleDates.Add(new DateProposalsViewModel(
                    new System.DateTime(newDate.Year, newDate.Month, i)));
            }

            SelectedDate = VisibleDates.SingleOrDefault(x => x.Day == newDate.Day) ?? VisibleDates.First();
        }

        private void LoadProposals()
        {
            for (int i = 0; i < 5; i++)
            {
                _proposals.Add(new ProposalViewModel());
            }

            var dateStatuses = _proposals.Select(x => new { x.JobDates, x.Status });
            foreach (var ds in dateStatuses)
            {
                foreach (var d in ds.JobDates)
                {
                    var matchingDates = VisibleDates.Where(x => x.Date == d.Date);
                    switch (ds.Status)
                    {
                        case Enums.ProposalStatus.Pending:
                            matchingDates.ForEach(x => x.AnyPending = true);
                            break;
                        case Enums.ProposalStatus.Active:
                            matchingDates.ForEach(x => x.AnyActive = true);
                            break;
                        case Enums.ProposalStatus.Completed:
                            matchingDates.ForEach(x => x.AnyCompleted = true);
                            break;
                    }
                }
            }

            OnPropertyChanged(nameof(Proposals));
        }

        private async Task Archive()
        {
            await AppService.DisplayAlert("Info", "Archived", "OK");
        }

        private async Task SwitchToMonth(bool isNext)
        {
            var newDate = isNext ? SelectedDate.Date.AddMonths(1) : SelectedDate.Date.AddMonths(-1);
            LoadVisibleDates(newDate);
            LoadProposals();
        }

        private void DateItemTapped(object param)
        {
            var selectedDate = param as DateProposalsViewModel;
            if (selectedDate == null)
            {
                return;
            }

            SelectedDate = selectedDate;
        }

        private void StatusItemTapped(object param)
        {
            var selectedStatus = param as StatusViewModel;
            if (selectedStatus == null)
            {
                return;
            }

            SelectedStatus = selectedStatus;
        }

        #endregion
    }
}
