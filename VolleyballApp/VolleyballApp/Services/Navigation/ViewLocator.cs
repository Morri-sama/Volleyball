using System;
using System.Collections.Generic;
using System.Text;
using VolleyballApp.ViewModels;
using Xamarin.Forms;

namespace VolleyballApp.Services.Navigation
{
    public class ViewLocator : IViewLocator
    {
        public Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var pageType = FindPageForViewModel(viewModel.GetType());
            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            return page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            var pageTypeName = viewModelType.AssemblyQualifiedName.Replace("ViewModel", "Page");

            return Type.GetType(pageTypeName) ?? throw new ArgumentException(pageTypeName + " не существует");
        }
    }
}
