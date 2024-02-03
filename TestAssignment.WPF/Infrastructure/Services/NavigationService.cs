using TestAssignment.WPF.Infrastructure.Models;
using TestAssignment.WPF.Infrastructure.Services.Interfaces;
using TestAssignment.WPF.ViewModels;

namespace TestAssignment.WPF.Infrastructure.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, BaseViewModel> _viewModelFactory;
        private BaseViewModel _currentView;

        public BaseViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<T>() where T : BaseViewModel
        {

            var viewModel = _viewModelFactory.Invoke(typeof(T));
            CurrentView = viewModel;
        }
    }
}
