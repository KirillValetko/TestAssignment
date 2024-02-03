using TestAssignment.WPF.Commands;
using TestAssignment.WPF.Infrastructure.Services.Interfaces;

namespace TestAssignment.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHome { get; set; }
        public RelayCommand NavigateToFirstTask { get; set; }
        public RelayCommand NavigateToSecondTask { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToHome = new RelayCommand(o => { NavigationService.NavigateTo<HomeViewModel>(); }, 
                o => true);
            NavigateToFirstTask = new RelayCommand(o => { NavigationService.NavigateTo<FirstTaskViewModel>(); },
                o => true);
            NavigateToSecondTask = new RelayCommand(o => { NavigationService.NavigateTo<SecondTaskViewModel>(); },
                o => true);
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
