//*************************************************************************************************
// REALRIDER® Technical Test.
// file="Setup.cs"
//*************************************************************************************************

namespace RealRider.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using MvvmCross.Droid.Platform;
    using MvvmCross.Core.ViewModels;
    using RealRider.Core;

    public class Setup : MvxAndroidSetup
    {
        /// <summary>
        /// The setup constructor.
        /// </summary>
        /// <param name="applicationContext"></param>
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        /// <summary>
        /// Returns the instance of coreapp.
        /// </summary>
        /// <returns></returns>
        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }

        /// <summary>
        /// Creates navigation serializer.
        /// </summary>
        /// <returns></returns>
        protected override IMvxNavigationSerializer CreateNavigationSerializer()
        {
            return base.CreateNavigationSerializer();
        }
    }
}