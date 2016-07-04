//*************************************************************************************************
// REALRIDER® Technical Test.
// file="CustomAdapter.cs"
//*************************************************************************************************

namespace RealRider.Droid.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Android.App;
    using Android.Content;
    using Android.Gms.Maps;
    using Android.Gms.Maps.Model;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using MvvmCross.Binding.Droid.Views;
    using RealRider.Core.DataModel;

    public class CustomAdapter : BaseAdapter<RealRiderListItemModel>, IOnMapReadyCallback
    {
        /// <summary>
        /// The current activity context.
        /// </summary>
        private Activity context;

        /// <summary>
        /// The RealRider list item model list.
        /// </summary>
        private List<RealRiderListItemModel> realRiderListItemModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Current context.</param>
        /// <param name="model">RealRiderListItem model.</param>
        /// <param name="Bundle">bundle.</param>
        public CustomAdapter(Activity context, List<RealRiderListItemModel> model, Bundle bundle)
        {
            this.context = context;
            this.realRiderListItemModel = model;
            mBundle = bundle;
        }

        /// <summary>
        /// The count of RealRider list items.
        /// </summary>
        public override int Count
        {
            get
            {
                return realRiderListItemModel.Count;
            }
        }

        /// <summary>
        /// The current position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>RealRiderListItemModel</returns>
        public override RealRiderListItemModel this[int position]
        {
            get
            {
                return realRiderListItemModel[position];
            }
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Map view member.
        /// </summary>
        private MapView mapview;

        /// <summary>
        /// Bundle member.
        /// </summary>
        private Bundle mBundle;

        /// <summary>
        /// Google map member.
        /// </summary>
        GoogleMap map;

        /// <summary>
        /// RealRiderListItemModel member.
        /// </summary>
        RealRiderListItemModel item;

        /// <summary>
        /// Creates and gets the view.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            item = this[position];

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.list_segmentlayout, parent, false);
            }

            var layoutView = view.FindViewById<RelativeLayout>(Resource.Id.SegmentLayout);
            var companyType = view.FindViewById<TextView>(Resource.Id.CompanyTypeText);

            view.FindViewById<MvxImageView>(Resource.Id.CompanyImageView).ImageUrl = item.ImageUrl;
            view.FindViewById<MvxImageView>(Resource.Id.CompanyTypeBackgroundView).ImageUrl = item.CompanyTypeBackgroundIcon;
            view.FindViewById<MvxImageView>(Resource.Id.CompanyTypeIconView).ImageUrl = item.CompanyTypeIcon;
            view.FindViewById<TextView>(Resource.Id.RecommendationText).Text = item.RecommendedRide;
            view.FindViewById<TextView>(Resource.Id.CompanyNameText).Text = item.CompanyTitle;
            companyType.Text = item.CompanyTypeText;
            view.FindViewById<TextView>(Resource.Id.DistanceTextView).Text = item.CompanyDistanceFromCurrLocation;
            view.FindViewById<TextView>(Resource.Id.NoOfOffersTextView).Text = item.NoOfOffers;
            var recText = view.FindViewById<TextView>(Resource.Id.RecommendationText);
            var comText = view.FindViewById<TextView>(Resource.Id.CompanyNameText);

            if (item.CompanyType == Core.Enums.CompanyTypeEnum.Dealership)
            {
                view.FindViewById<TextView>(Resource.Id.NoOfOffersTextView).Visibility = ViewStates.Visible;
                view.FindViewById<TextView>(Resource.Id.NoOfOffersTextView).Text = item.NoOfOffers;
                view.FindViewById<MvxImageView>(Resource.Id.OfferImage).ImageUrl = item.OfferImageUrl;
                view.FindViewById<TextView>(Resource.Id.OfferText).Text = item.OfferText;
                view.FindViewById<RelativeLayout>(Resource.Id.OfferLayout).Visibility = ViewStates.Visible;
            }
            else
            {
                view.FindViewById<TextView>(Resource.Id.NoOfOffersTextView).Visibility = ViewStates.Gone;
                view.FindViewById<RelativeLayout>(Resource.Id.OfferLayout).Visibility = ViewStates.Gone;
            }

            RelativeLayout.LayoutParams parameters = (RelativeLayout.LayoutParams)comText.LayoutParameters;

            if (item.CompanyType == Core.Enums.CompanyTypeEnum.Retailer || item.CompanyType == Core.Enums.CompanyTypeEnum.Dealership)
            {
                companyType.SetBackgroundResource(Resource.Drawable.green_textbackground);
            }
            else
            {
                companyType.SetBackgroundResource(Resource.Drawable.blue_textbackground);
            }

            mapview = view.FindViewById<MapView>(Resource.Id.MapFragmentList);
            if (view != null)
            {
                mapview.OnCreate(mBundle);
                mapview.OnResume();
                mapview.GetMapAsync(this);
            }

            if (string.IsNullOrWhiteSpace(item.RecommendedRide))
            {
                mapview.Visibility = ViewStates.Gone;
            }

            if (string.IsNullOrWhiteSpace(recText.Text))
            {
                parameters.AddRule(LayoutRules.AlignParentTop);
                comText.LayoutParameters = parameters;
            }
            else
            {
                parameters.RemoveRule(LayoutRules.AlignParentTop);
                comText.LayoutParameters = parameters;
            }

            return view;
        }

        /// <summary>
        /// Initializes maps and positions the camera.
        /// </summary>
        /// <param name="googleMap"></param>
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            map.MapType = GoogleMap.MapTypeNormal;
            MapsInitializer.Initialize(context);
            double latitude = 54.9687501;
            double longitude = -1.7140047;
            MarkerOptions marker = new MarkerOptions().SetPosition(new LatLng(latitude, longitude)).SetTitle("RealRider");
            CameraPosition cameraPosition = new CameraPosition.Builder().Target(new LatLng(latitude, longitude)).Zoom(12).Build();
            map.AnimateCamera(CameraUpdateFactory.NewCameraPosition(cameraPosition));
        }
    }
}