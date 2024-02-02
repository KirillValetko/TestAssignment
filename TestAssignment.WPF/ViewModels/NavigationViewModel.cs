using System.Windows.Input;
using TestAssignment.WPF.Commands;

namespace TestAssignment.WPF.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand FirstTaskCommand { get; set; }
        public ICommand SecondTaskCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void FirstTask(object obj) => CurrentView = new FirstTaskViewModel();
        private void SecondTask(object obj) => CurrentView = new SecondTaskViewModel();

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            FirstTaskCommand = new RelayCommand(FirstTask);
            SecondTaskCommand = new RelayCommand(SecondTask);
            CurrentView = new HomeViewModel();
        }
    }
}
