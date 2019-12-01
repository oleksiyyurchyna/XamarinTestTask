namespace XamarinTestTask.ViewModels
{
    public class StatusViewModel : SelectableBaseViewModel
    {
        public StatusViewModel(string title, Xamarin.Forms.Color color)
        {
            Title = title;
            Color = color;
        }

        public string Title { get; private set; }

        public Xamarin.Forms.Color Color { get; set; }
    }
}
