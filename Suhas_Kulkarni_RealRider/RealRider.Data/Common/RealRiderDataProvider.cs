//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderDataProvider.cs"
//*************************************************************************************************

namespace RealRider.Data.Common
{
    using RealRider.Data.DataModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderDataProvider
    {
        /// <summary>
        /// RealRider List page items member.
        /// </summary>
        public RealRiderListPageItems RealRiderListPageItem { get; set; }

        /// <summary>
        /// Gets the real rider data.
        /// </summary>
        public void GetRealRiderDataProvider()
        {
            RealRiderListPageItem = new RealRiderListPageItems();
            RealRiderListPageItem.RealRiderItems = new List<RealRiderItem>();

            RealRiderListPageItem.RealRiderItems.Add(new RealRiderItem
            {
                CompanyDistance = Constants.CompanyDistance1,
                CompanyImageUrl = Constants.CompanyUrl1,
                CompanyName = Constants.CompanyName1,
                CompanyType = Constants.CompanyType0,
            });

            RealRiderListPageItem.RealRiderItems.Add(new RealRiderItem
            {
                CompanyDistance = Constants.CompanyDistance2,
                CompanyImageUrl = Constants.CompanyUrl2,
                CompanyName = Constants.CompanyName2,
                CompanyType = Constants.CompanyType1,
                RideRecommendation = Constants.RecommendedRide
            });

            RealRiderListPageItem.RealRiderItems.Add(new RealRiderItem
            {
                CompanyDistance = Constants.CompanyDistance3,
                CompanyImageUrl = Constants.CompanyUrl3,
                CompanyName = Constants.CompanyName3,
                CompanyType = Constants.CompanyType2,
                NoOfOffersText = Constants.NoOfOffersString,
                OfferImage = Constants.HelmetUrl,
                OfferText = Constants.HelmetOfferText
            });

            RealRiderListPageItem.RealRiderItems.Add(new RealRiderItem
            {
                CompanyDistance = Constants.CompanyDistance4,
                CompanyImageUrl = Constants.CompanyUrl4,
                CompanyName = Constants.CompanyName4,
                CompanyType = Constants.CompanyType1
            });

            RealRiderListPageItem.ShowItemsList = Constants.ShowList;
            RealRiderListPageItem.WhereItemsList = Constants.WhereList;
        }

    }
}
