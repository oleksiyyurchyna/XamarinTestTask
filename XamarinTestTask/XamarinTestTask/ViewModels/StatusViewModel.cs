namespace XamarinTestTask.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        private bool _isSelected;

        public StatusViewModel(string title, Xamarin.Forms.Color color)
        {
            Title = title;
            Color = color;
        }

        public string Title { get; private set; }

        public Xamarin.Forms.Color Color { get; set; }
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; OnPropertyChanged(); } }
    }
}
