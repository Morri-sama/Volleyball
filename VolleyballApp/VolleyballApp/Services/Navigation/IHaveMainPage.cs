using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VolleyballApp.Services.Navigation
{
    public interface IHaveMainPage
    {
        Page MainPage { get; set; }
    }
}
