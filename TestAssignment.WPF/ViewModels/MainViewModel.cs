using CommunityToolkit.Mvvm.Input;
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
            NavigateToHome = new RelayCommand(NavigationService.NavigateTo<HomeViewModel>);
            NavigateToFirstTask = new RelayCommand(NavigationService.NavigateTo<FirstTaskViewModel>);
            NavigateToSecondTask = new RelayCommand(NavigationService.NavigateTo<SecondTaskViewModel>);
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
