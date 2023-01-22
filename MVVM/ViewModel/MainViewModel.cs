using Boosty.Core;
using Boosty.MVVM.View;
using System.Threading;
using System.Windows.Threading;

namespace Boosty.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand BasicViewCommand { get; set; }
        public RelayCommand AdvancedViewCommand { get; set; }
        public RelayCommand CleanUpViewCommand { get; set; }
        public RelayCommand RestoreViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; } = new HomeViewModel();
        public BasicViewModel BasicVM { get; set; } = new BasicViewModel();
        public AdvancedViewModel AdvancedVM { get; set; } = new AdvancedViewModel();
        public CleanUpViewModel CleanUpVM { get; set; } = new CleanUpViewModel();
        public RestoreViewModel RestoreVM { get; set; } = new RestoreViewModel();

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Thread t1 = new Thread(new ThreadStart(changeView));
            t1.Start();

        }
        public void changeView()
        {
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });
            BasicViewCommand = new RelayCommand(o =>
            {
                CurrentView = BasicVM;
            });
            AdvancedViewCommand = new RelayCommand(o =>
            {
                CurrentView = AdvancedVM;
            });
            CleanUpViewCommand = new RelayCommand(o =>
            {
                CurrentView = CleanUpVM;
            });
            RestoreViewCommand = new RelayCommand(o =>
            {
                CurrentView = RestoreVM;
            });
        }

    }
}
