using TestAssignment.WPF.ViewModels;

namespace TestAssignment.WPF.Infrastructure.Services.Interfaces
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>() where T : BaseViewModel;
    }
}
