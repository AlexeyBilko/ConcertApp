﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConcertApp.Admin.Infrastructure
{
    interface INavigate
    {
        void Navigate(UserControl page);
    }
}
