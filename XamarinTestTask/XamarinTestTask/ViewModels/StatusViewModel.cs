using XamarinTestTask.Enums;

namespace XamarinTestTask.ViewModels
{
    public class StatusViewModel : SelectableBaseViewModel
    {
        public StatusViewModel(ProposalStatus status, Xamarin.Forms.Color color)
        {
            Status = status;
            Color = color;
        }

        public ProposalStatus Status { get; private set; }

        public Xamarin.Forms.Color Color { get; set; }
    }
}
