using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.ViewModels
{
    public class ViewModelBase : PropertyChangedBase, IViewModelLifecycle
    {
        public virtual Task AfterDismissed()
        {
            return Task.CompletedTask;
        }

        public virtual Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }
    }
}
