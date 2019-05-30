using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.Extensions;
using VolleyballApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace VolleyballApp.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IHaveMainPage _presentationRoot;
        private readonly IViewLocator _viewLocator;

        public NavigationService(IHaveMainPage presentationRoot, IViewLocator viewLocator)
        {
            _presentationRoot = presentationRoot;
            _viewLocator = viewLocator;
        }

        private INavigation Navigator => _presentationRoot.MainPage.Navigation;


        public async Task NavigateTo(ViewModelBase viewModel)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            await viewModel.BeforeFirstShown();

            await Navigator.PushAsync(page);
        }

        public async Task NavigateBack()
        {
            var dismissing = Navigator.NavigationStack.Last().BindingContext as ViewModelBase;

            await Navigator.PopAsync();

            dismissing?.AfterDismissed();
        }

        public async Task NavigateBackToRoot()
        {
            var toDismiss = Navigator.NavigationStack.Skip(1).Select(vw => vw.BindingContext).OfType<ViewModelBase>().ToArray();

            await Navigator.PopToRootAsync();

            foreach (ViewModelBase viewModel in toDismiss)
            {
                viewModel.AfterDismissed().FireAndForget();
            }
        }

        public void PresentAsMaingPage(ViewModelBase viewModel)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            IEnumerable<ViewModelBase> viewModelsToDismiss = FindViewModelsToDismss(_presentationRoot.MainPage);

            if (_presentationRoot.MainPage is NavigationPage navPage)
            {
                navPage.PopRequested -= NavPagePopRequested;
            }
        }

        private IEnumerable<ViewModelBase> FindViewModelsToDismss(Page dismissingPage)
        {
            var viewModels = new List<ViewModelBase>();

            if (dismissingPage is NavigationPage)
            {
                viewModels.AddRange(Navigator.NavigationStack.Select(p => p.BindingContext).OfType<ViewModelBase>());
            }
            else
            {
                var viewModel = dismissingPage?.BindingContext as ViewModelBase;
                if (viewModel != null)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public void PresentAsNavigatableMainPage(ViewModelBase viewModel)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            NavigationPage newNavigationPage = new NavigationPage(page);

            IEnumerable<ViewModelBase> viewModelsToDismiss = FindViewModelsToDismss(_presentationRoot.MainPage);

            if (_presentationRoot.MainPage is NavigationPage navPage)
            {
                navPage.PopRequested -= NavPagePopRequested;
            }

            viewModel.BeforeFirstShown();

            newNavigationPage.PopRequested += NavPagePopRequested;
            _presentationRoot.MainPage = newNavigationPage;

            foreach (ViewModelBase toDismiss in viewModelsToDismiss)
            {
                toDismiss.AfterDismissed();
            }
        }

        private void NavPagePopRequested(object sender, NavigationRequestedEventArgs e)
        {
            if (Navigator.NavigationStack.LastOrDefault()?.BindingContext is ViewModelBase poppingPage)
            {
                poppingPage.AfterDismissed();
            }
        }
    }
}
