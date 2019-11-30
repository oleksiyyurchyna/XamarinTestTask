using System.Collections.ObjectModel;

namespace XamarinTestTask.ViewModels
{
    public class ProposalViewModel : BaseViewModel
    {
        public ObservableCollection<string> JobDates { get; set; } = new ObservableCollection<string>() { "one","two","three"};
    }
}
