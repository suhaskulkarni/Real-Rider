//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderListItemModel.cs"
//*************************************************************************************************

namespace RealRider.Core.DataModel
{
    using RealRider.Core.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderListItemModel
    {
        /// <summary>
        /// Image Url.
        /// </summary>
        private string _imageUrl;

        /// <summary>
        /// The image Url.
        /// </summary>
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
            }
        }

        /// <summary>
        /// Company title.
        /// </summary>
        private string _companyTitle;

        /// <summary>
        /// The company title.
        /// </summary>
        public string CompanyTitle
        {
            get
            {
                return _companyTitle;
            }
            set
            {
                _companyTitle = value;
            }
        }

        /// <summary>
        /// Company type enum.
        /// </summary>
        private CompanyTypeEnum _companyType;

        /// <summary>
        /// The company type enum.
        /// </summary>
        public CompanyTypeEnum CompanyType
        {
            get
            {
                return _companyType;
            }
            set
            {
                _companyType = value;
            }
        }

        /// <summary>
        /// Company type icon path.
        /// </summary>
        private string _companyTypeIcon;

        /// <summary>
        /// The company type icon path.
        /// </summary>
        public string CompanyTypeIcon
        {
            get
            {
                return _companyTypeIcon;
            }
            set
            {
                _companyTypeIcon = value;
            }
        }

        /// <summary>
        /// Company type background text.
        /// </summary>
        private string _companyTypeBackgroundText;

        /// <summary>
        /// The company type background text.
        /// </summary>
        public string CompanyTypeBackgroundText
        {
            get
            {
                return _companyTypeBackgroundText;
            }
            set
            {
                _companyTypeBackgroundText = value;
            }
        }

        /// <summary>
        /// The company type background icon path.
        /// </summary>
        private string _companyTypeBackgroundIcon;

        /// <summary>
        /// The company type background icon path.
        /// </summary>
        public string CompanyTypeBackgroundIcon
        {
            get
            {
                return _companyTypeBackgroundIcon;
            }
            set
            {
                _companyTypeBackgroundIcon = value;
            }
        }

        /// <summary>
        /// Company type text.
        /// </summary>
        private string _companyTypeText;

        /// <summary>
        /// The company type text.
        /// </summary>
        public string CompanyTypeText
        {
            get
            {
                return _companyTypeText;
            }
            set
            {
                _companyTypeText = value;
            }
        }

        /// <summary>
        /// Company distance text.
        /// </summary>
        private string _companyDistanceFromCurrLocation;

        /// <summary>
        /// The company distance text.
        /// </summary>` 
        public string CompanyDistanceFromCurrLocation
        {
            get
            {
                return _companyDistanceFromCurrLocation;
            }
            set
            {
                _companyDistanceFromCurrLocation = value;
            }
        }

        /// <summary>
        /// Recommended ride text.
        /// </summary>
        private string _recommendedRide;

        /// <summary>
        /// The recommended ride text.
        /// </summary>
        public string RecommendedRide
        {
            get
            {
                return _recommendedRide;
            }
            set
            {
                _recommendedRide = value;
            }
        }

        /// <summary>
        /// The type of company background visibility.
        /// </summary>
        private bool _isGreen;

        /// <summary>
        /// The type of company background visibility.
        /// </summary>
        public bool IsGreen
        {
            get
            {
                return _isGreen;
            }
            set
            {
                _isGreen = value;
            }
        }

        /// <summary>
        /// The type of company background visibility.
        /// </summary>
        private bool _isBlue;

        /// <summary>
        /// The type of company background visibility.
        /// </summary>
        public bool IsBlue
        {
            get
            {
                return _isBlue;
            }
            set
            {
                _isBlue = value;
            }
        }

        /// <summary>
        /// Offers in company.
        /// </summary>
        private string _noOfOffers;

        /// <summary>
        /// The offers in company.
        /// </summary>
        public string NoOfOffers
        {
            get
            {
                return _noOfOffers;
            }
            set
            {
                _noOfOffers = value;
            }
        }

        /// <summary>
        /// Offer image path.
        /// </summary>
        private string _offerImageUrl;

        /// <summary>
        /// The offer image path.
        /// </summary>
        public string OfferImageUrl
        {
            get
            {
                return _offerImageUrl;
            }
            set
            {
                _offerImageUrl = value;
            }
        }

        /// <summary>
        /// Offer text.
        /// </summary>
        private string _offerText;

        /// <summary>
        /// The offer text.
        /// </summary>
        public string OfferText
        {
            get
            {
                return _offerText;
            }
            set
            {
                _offerText = value;
            }
        }
    }
}
