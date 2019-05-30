﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.Extensions
{
    public static class TaskExtensions
    {
        public static void FireAndForget(this Task task)
        {
            task.Dispose();
        }
    }
}
