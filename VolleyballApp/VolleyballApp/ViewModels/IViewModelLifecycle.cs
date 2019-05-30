using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.ViewModels
{
    public interface IViewModelLifecycle
    {
        Task BeforeFirstShown();
        Task AfterDismissed();
    }
}
