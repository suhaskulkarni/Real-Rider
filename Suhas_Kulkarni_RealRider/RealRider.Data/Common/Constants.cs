//*************************************************************************************************
// REALRIDER® Technical Test.
// file="Constants.cs"
//*************************************************************************************************

namespace RealRider.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Constants
    {
        public const string CompanyName1 = "J&S Accessories Ltd";

        public const string CompanyUrl1 = "https://pbs.twimg.com/profile_images/567700706136571905/JvGdUaqa.jpeg";

        public const string CompanyName2 = "Afternoon Ride";

        public const string CompanyUrl2 = "http://www.fowlers.co.uk/news/wp-content/uploads/2014/12/xt5xpicqbcvcwtfcc2hb.jpeg";

        public const string CompanyName3 = "Triumph North East";

        public const string CompanyUrl3 = "http://www.realsafetechnologies.com/wp-content/uploads/2015/05/AR-Triumph.jpg";

        public const string CompanyName4 = "Kaapstad Motorcycle Adventure";

        public const string CompanyUrl4 = "https://twowheelexploring.files.wordpress.com/2011/11/alex1.jpg";

        public const int CompanyType0 = 0;

        public const int CompanyType1 = 1;

        public const int CompanyType2 = 2;

        public const string CompanyDistance1 = "1 mile away";

        public const string CompanyDistance2 = "11 miles away";

        public const string CompanyDistance3 = "2.1 miles away";

        public const string CompanyDistance4 = "12 miles away";

        public const string RecommendedRide = "REALRIDER recommended ride";

        public static readonly List<string> ShowList = new List<string>() { "All", "Rides only", "Helmet Stores", "Service Station" };

        public static readonly List<string> WhereList = new List<string>() { "Current location", "1 mile away", "2.5 miles away", "10 miles away" };

        public const string NoOfOffersString = "Offers at this location";

        public const string HelmetUrl = "http://www.revzilla.com/product_images/0049/5791/schuberth_c3_pro_helmet_detail.jpg";

        public const string HelmetOfferText = "Buy a new helmet and get a free service.";
    }
}
