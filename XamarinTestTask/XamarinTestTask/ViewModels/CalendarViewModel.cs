using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinTestTask.ViewModels
{
    public class CalendarViewModel : BasePageViewModel
    {
        private ICommand _archiveTappedCommand;
        private ICommand _previousMonthTappedCommand;
        private ICommand _nextMonthTappedCommand;

        private StatusViewModel _selectedStatus;

        public CalendarViewModel()
        {
            Title = "Calendar";

            Statuses = new ObservableCollection<StatusViewModel>()
            {
                new StatusViewModel("Pending", (Color)Application.Current.Resources["PendingColor"]),
                new StatusViewModel("Active", (Color)Application.Current.Resources["ActiveColor"]),
                new StatusViewModel("Completed", (Color)Application.Current.Resources["CompletedColor"]),
            };
            SelectedStatus = Statuses.First();

            var dates = new List<DateViewModel>();
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 1)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 2)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 3)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 4)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 5)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 6)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 7)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 8)));
            dates.Add(new DateViewModel(new System.DateTime(2019, 12, 9)));
            VisibleDates = new ObservableCollection<DateViewModel>(dates);
        }

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

        public ObservableCollection<DateViewModel> VisibleDates { get; set; }
        public ObservableCollection<StatusViewModel> Statuses { get; set; }

        public ObservableCollection<ProposalViewModel> Proposals { get; set; } = new ObservableCollection<ProposalViewModel>() 
        { 
            new ProposalViewModel(), 
            new ProposalViewModel() 
        };

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
            }
        }

        private async Task Archive()
        {
            await AppService.DisplayAlert("Info", "Archived", "OK");
        }

        private async Task SwitchToMonth(bool isNext)
        {

        }
    }
}
