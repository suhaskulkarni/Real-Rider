﻿//*************************************************************************************************
// REALRIDER® Technical Test.
// file="CoreApp.cs"
//*************************************************************************************************

namespace RealRider.Core
{
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform.IoC;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CoreApp : MvxApplication
    {
        /// <summary>
        /// The Services and viewmodels initializer.
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.RealRiderMainViewModel>();
        }
    }
}
