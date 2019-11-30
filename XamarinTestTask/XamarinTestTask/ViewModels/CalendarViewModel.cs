using System.Collections.ObjectModel;
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

        public CalendarViewModel()
        {
            Title = "Calendar";
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

        public ObservableCollection<string> VisibleDates { get; set; } = new ObservableCollection<string>() { "1", "2", "3", "2", "3", "2", "3", "2", "3", "2", "3", "2", "3", "2", "3", "2", "3" };

        public ObservableCollection<string> Statuses { get; set; } = new ObservableCollection<string>() { "Pending", "Active", "Completed" };

        public ObservableCollection<ProposalViewModel> Proposals { get; set; } = new ObservableCollection<ProposalViewModel>() { new ProposalViewModel(), new ProposalViewModel() };

        private async Task Archive()
        {
            await AppService.DisplayAlert("Info", "Archived", "OK");
        }

        private async Task SwitchToMonth(bool isNext)
        {

        }
    }
}
