using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.ViewModels;

namespace VolleyballApp.Services.Navigation
{
    public interface INavigationService
    {
        void PresentAsMainPage(ViewModelBase viewModel);

        void PresentAsNavigatableMainPage(ViewModelBase viewModel);

        Task NavigateTo(ViewModelBase viewModel);

        Task NavigateTo(ViewModelBase viewModel, string viewName);

        Task OpenModal(ViewModelBase viewModel, string viewName);

        Task PopModal();

        Task NavigateBack();

        Task NavigateBackToRoot();
    }
}
