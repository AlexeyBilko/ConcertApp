﻿using ConcertApp.BLL.Modules;
using ConcertApp.UI.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.UI.Infrastructure
{
    public class ViewModelLocator
    {
        IKernel kernel;
        public ViewModelLocator()
        {
            kernel = new StandardKernel(new ConcertDBModule());
        }

        public LogInAppViewModel LogInAppViewModel => kernel.Get<LogInAppViewModel>();
        public TestViewModel TestViewModel => kernel.Get<TestViewModel>();
        public RegistrationViewModel RegistrationViewModel => kernel.Get<RegistrationViewModel>();
        public TopBarViewModel TopBarViewModel => kernel.Get<TopBarViewModel>();
        public TopBarAfterLogInViewModel TopBarAfterLogInViewModel => kernel.Get<TopBarAfterLogInViewModel>();
        public ProfileViewModel ProfileViewModel => kernel.Get<ProfileViewModel>();

        public ListConcertsViewModel ListConcertsViewModel => kernel.Get<ListConcertsViewModel>();

    }
}