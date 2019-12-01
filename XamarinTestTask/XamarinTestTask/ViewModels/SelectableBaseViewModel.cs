namespace XamarinTestTask.ViewModels
{
    public class SelectableBaseViewModel : BaseViewModel
    {
        private bool _isSelected;
        public bool IsSelected { get { return _isSelected; } set { SetProperty(ref _isSelected, value); } }
    }
}
