using System;
using System.Collections.Generic;
using System.Text;
using VolleyballApp.ViewModels;
using Xamarin.Forms;

namespace VolleyballApp.Services.Navigation
{
    public interface IViewLocator
    {
        Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
    }
}
