//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderItem.cs"
//*************************************************************************************************

namespace RealRider.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderItem
    {
        /// <summary>
        /// Company title.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Company image url.
        /// </summary>
        public string CompanyImageUrl { get; set; }

        /// <summary>
        /// The type of company.
        /// </summary>
        public int CompanyType { get; set; }

        /// <summary>
        /// The distance of company from current location.
        /// </summary>
        public string CompanyDistance { get; set; }

        /// <summary>
        /// Recommended ride string.
        /// </summary>
        public string RideRecommendation { get; set; }

        /// <summary>
        /// Offers available at company.
        /// </summary>
        public string NoOfOffersText { get; set; }

        /// <summary>
        /// The offer image url.
        /// </summary>
        public string OfferImage { get; set; }

        /// <summary>
        /// The text of the offer.
        /// </summary>
        public string OfferText { get; set; }
    }
}
