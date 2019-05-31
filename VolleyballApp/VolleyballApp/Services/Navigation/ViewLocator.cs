using System;
using System.Collections.Generic;
using System.Text;
using VolleyballApp.ViewModels;
using Xamarin.Forms;

namespace VolleyballApp.Services.Navigation
{
    public class ViewLocator : IViewLocator
    {
        public Page CreateAndBindPage<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var pageType = FindPageForViewModel(viewModel.GetType());
            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            return page;
        }

        public Page CreateAndBindPage<TViewModel>(TViewModel viewModel, string viewName) where TViewModel : ViewModelBase
        {
            var pageType = FindPageByName(viewName);
            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            return page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            var pageTypeName = viewModelType.AssemblyQualifiedName.Replace("ViewModel", "View");

            return Type.GetType(pageTypeName) ?? throw new ArgumentException(pageTypeName + " не существует");
        }

        protected virtual Type FindPageByName(string viewName)
        {
            return Type.GetType(viewName) ?? throw new ArgumentException(viewName + "не существует");
        }
    }
}
