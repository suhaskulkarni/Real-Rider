//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderMainService.cs"
//*************************************************************************************************

namespace RealRider.Core.Services
{
    using RealRider.Core.Common;
    using RealRider.Core.DataModel;
    using RealRider.Core.Enums;
    using RealRider.Core.Interfaces;
    using RealRider.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderMainService : IRealRiderMainService
    {
        /// <summary>
        /// RealRider data provider member.
        /// </summary>
        private RealRiderDataProvider realRiderDataProvider { get; set; }

        /// <summary>
        /// RealRider list of items.
        /// </summary>
        public List<RealRiderListItemModel> RealRiderListItems { get; set; }

        /// <summary>
        /// RealRiderMainService constructor.
        /// </summary>
        public RealRiderMainService()
        {
            realRiderDataProvider = new RealRiderDataProvider();

            realRiderDataProvider.GetRealRiderDataProvider();
        }

        /// <summary>
        /// Gets the RealRiderListItemModel list items.
        /// </summary>
        /// <returns></returns>
        public List<RealRiderListItemModel> GetRealRiderListItems()
        {
            RealRiderListItems = new List<RealRiderListItemModel>();

            foreach (var realRiderItem in realRiderDataProvider.RealRiderListPageItem.RealRiderItems)
            {
                RealRiderListItems.Add(new RealRiderListItemModel
                {
                    CompanyDistanceFromCurrLocation = realRiderItem.CompanyDistance,
                    CompanyTitle = realRiderItem.CompanyName,
                    CompanyTypeBackgroundIcon = getcompanyTypeBackground((CompanyTypeEnum)realRiderItem.CompanyType),
                    CompanyTypeIcon = getCompanyTypeIcon((CompanyTypeEnum)realRiderItem.CompanyType),
                    CompanyTypeText = getCompanyTypeText((CompanyTypeEnum)realRiderItem.CompanyType),
                    CompanyTypeBackgroundText = getCompanyTypeTextBackground((CompanyTypeEnum)realRiderItem.CompanyType),
                    CompanyType = (CompanyTypeEnum)realRiderItem.CompanyType,
                    ImageUrl = realRiderItem.CompanyImageUrl,
                    RecommendedRide = realRiderItem.RideRecommendation,
                    IsGreen = isGreen((CompanyTypeEnum)realRiderItem.CompanyType),
                    IsBlue = isBlue((CompanyTypeEnum)realRiderItem.CompanyType),
                    NoOfOffers = realRiderItem.NoOfOffersText,
                    OfferImageUrl = realRiderItem.OfferImage,
                    OfferText = realRiderItem.OfferText
                });
            }

            return RealRiderListItems;
        }

        /// <summary>
        /// Gets the Show spinner items.
        /// </summary>
        /// <returns>ShowSelectedItemModel collection.</returns>
        public ObservableCollection<ShowSelectedItemModel> GetShowSpinnerItems()
        {
            ObservableCollection<ShowSelectedItemModel> collection = new ObservableCollection<ShowSelectedItemModel>();
            foreach (var realRiderData in realRiderDataProvider.RealRiderListPageItem.ShowItemsList)
            {
                ShowSelectedItemModel model = new ShowSelectedItemModel();
                model.ShowSelectedItemText = realRiderData;
                collection.Add(model);
            }
            return collection;
        }

        /// <summary>
        /// Gets the where spinner items.
        /// </summary>
        /// <returns>WhereSelectionItemModel collection.</returns>
        public ObservableCollection<WhereSelectionItemModel> GetWhereSpinnerItems()
        {
            ObservableCollection<WhereSelectionItemModel> collection = new ObservableCollection<WhereSelectionItemModel>();
            foreach (var realRiderData in realRiderDataProvider.RealRiderListPageItem.WhereItemsList)
            {
                WhereSelectionItemModel model = new WhereSelectionItemModel();
                model.WhereSelectedItemText = realRiderData;
                collection.Add(model);
            }
            return collection;
        }

        /// <summary>
        /// Green background visibility based on company type.
        /// </summary>
        /// <param name="type">Company type</param>
        /// <returns>Returns bool.</returns>
        private bool isGreen(CompanyTypeEnum type)
        {
            switch (type)
            {
                case CompanyTypeEnum.Retailer:
                    return true;
                case CompanyTypeEnum.OffRoad:
                    return false;
                case CompanyTypeEnum.Dealership:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Blue background visibility based on company type.
        /// </summary>
        /// <param name="type">Company type</param>
        /// <returns>Returns bool.</returns>
        private bool isBlue(CompanyTypeEnum type)
        {
            switch (type)
            {
                case CompanyTypeEnum.Retailer:
                    return false;
                case CompanyTypeEnum.OffRoad:
                    return true;
                case CompanyTypeEnum.Dealership:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns the path of the company type background.
        /// </summary>
        /// <param name="type">Company type enum.</param>
        /// <returns>Path of background type.</returns>
        private string getcompanyTypeBackground(CompanyTypeEnum type)
        {
            if (type == CompanyTypeEnum.Retailer || type == CompanyTypeEnum.Dealership)
            {
                return CommonImageSource.GetCompanyTypeBackgroundIcon(CompanyColorEnum.Green);
            }
            else if (type == CompanyTypeEnum.OffRoad)
            {
                return CommonImageSource.GetCompanyTypeBackgroundIcon(CompanyColorEnum.Blue);
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Gets the path of company type icon.
        /// </summary>
        /// <param name="type">Company type enum.</param>
        /// <returns>string path of company type.</returns>
        private string getCompanyTypeIcon(CompanyTypeEnum type)
        {
            switch (type)
            {
                case CompanyTypeEnum.Retailer:
                    return CommonImageSource.GetCompanyTypeIcon(CompanyTypeEnum.Retailer);
                case CompanyTypeEnum.OffRoad:
                    return CommonImageSource.GetCompanyTypeIcon(CompanyTypeEnum.OffRoad);
                case CompanyTypeEnum.Dealership:
                    return CommonImageSource.GetCompanyTypeIcon(CompanyTypeEnum.Dealership);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the color of company type background.
        /// </summary>
        /// <param name="type">Company type enum.</param>
        /// <returns>String path of company type background.</returns>
        private string getCompanyTypeTextBackground(CompanyTypeEnum type)
        {
            switch (type)
            {
                case CompanyTypeEnum.Retailer:
                case CompanyTypeEnum.Dealership:
                    return RealRider.Core.Common.Constants.GreenCompanyBackgroundText;
                case CompanyTypeEnum.OffRoad:
                    return RealRider.Core.Common.Constants.BlueCompanyBackgroundText;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the company type text.
        /// </summary>
        /// <param name="type">Company type enum.</param>
        /// <returns>String of company type.</returns>
        private string getCompanyTypeText(CompanyTypeEnum type)
        {
            switch (type)
            {
                case CompanyTypeEnum.Retailer:
                    return RealRider.Core.Common.Constants.GeneralRetailerText;
                case CompanyTypeEnum.OffRoad:
                    return RealRider.Core.Common.Constants.OffRoadText;
                case CompanyTypeEnum.Dealership:
                    return RealRider.Core.Common.Constants.DealershipText;
                default:
                    return string.Empty;
            }
        }
    }
}
