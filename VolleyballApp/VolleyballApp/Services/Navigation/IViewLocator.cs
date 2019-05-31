using System;
using System.Collections.Generic;
using System.Text;
using VolleyballApp.ViewModels;
using Xamarin.Forms;

namespace VolleyballApp.Services.Navigation
{
    public interface IViewLocator
    {
        Page CreateAndBindPage<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
        Page CreateAndBindPage<TViewModel>(TViewModel viewModel, string viewName) where TViewModel : ViewModelBase;
    }
}
