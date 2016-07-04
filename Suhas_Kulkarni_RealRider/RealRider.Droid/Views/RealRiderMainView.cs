//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderMainView.cs"
//*************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Locations;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using RealRider.Core.DataModel;
using RealRider.Core.ViewModels;
using RealRider.Droid.Adapters;

namespace RealRider.Droid.Views
{
    [Activity(Label = "RealRider")]
    public class RealRiderMainView : MvxActivity, IOnMapReadyCallback, ILocationListener
    {
        /// <summary>
        /// Drawer layout member.
        /// </summary>
        DrawerLayout mDrawerLayout;

        /// <summary>
        /// List of drawer items.
        /// </summary>
        List<string> drawerItems = new List<string>();

        /// <summary>
        /// The drawer adapter.
        /// </summary>
        ArrayAdapter drawerAdapter;

        /// <summary>
        /// The drawer view.
        /// </summary>
        View drawerView;

        /// <summary>
        /// The bundle member.
        /// </summary>
        public Bundle mBundle;

        /// <summary>
        /// Drawer list view.
        /// </summary>
        ListView drawerListView;

        /// <summary>
        /// The drawer image.
        /// </summary>
        ImageButton drawerImageButton;

        /// <summary>
        /// Button list.
        /// </summary>
        Button listButton;

        /// <summary>
        /// Button to open map.
        /// </summary>
        Button mapButton;

        /// <summary>
        /// The Google map.
        /// </summary>
        private GoogleMap _googleMap;

        /// <summary>
        /// The map fragment to get the map
        /// </summary>
        private MapFragment _mapFragment;

        /// <summary>
        /// The location manager
        /// </summary>
        private LocationManager _locationManager;

        /// <summary>
        /// The location member to get latitude and longitude
        /// </summary>
        private Location _location;

        /// <summary>
        /// The location reset flag.
        /// </summary>
        private bool _locationReset;

        /// <summary>
        /// The location provider
        /// </summary>
        private string _locationProvider;

        /// <summary>
        /// Latitude and longitude member.
        /// </summary>
        LatLng latLng;

        /// <summary>
        /// Current location floating button member.
        /// </summary>
        private FloatingActionButton currentLocation;

        /// <summary>
        /// Marker member.
        /// </summary>
        List<Marker> marker;

        /// <summary>
        /// Marker options member.
        /// </summary>
        List<MarkerOptions> markerOptions;

        /// <summary>
        /// Creates the RealRider main view.
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            mBundle = bundle;
            Window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            var color = new Color(153, 99, 0);
            Window.SetStatusBarColor(color);
            ActionBar.Hide();
            SetContentView(Resource.Layout.RealRiderMainView);

            currentLocation = FindViewById<FloatingActionButton>(Resource.Id.myLocationButton);
            InitiateListItems();

            listButton = FindViewById<Button>(Resource.Id.ListButton);
            mapButton = FindViewById<Button>(Resource.Id.MapButton);

            listButton.Click += ListButtonClick;
            mapButton.Click += MapButtonClick;

            InitMapFragment();
        }

        /// <summary>
        /// Current location floating button click handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentLocationButtonClick(object sender, EventArgs e)
        {
            if (_location != null)
            {
                _locationReset = true;
                OnLocationChanged(_location);
            }
        }

        /// <summary>
        /// Segment control list button click handler.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void ListButtonClick(object obj, EventArgs e)
        {
            currentLocation.Click -= CurrentLocationButtonClick;

            listButton.SetBackgroundResource(Resource.Drawable.selected_button);
            listButton.SetTextColor(Color.White);
            mapButton.SetBackgroundResource(Resource.Drawable.button_selector);
            mapButton.SetTextColor(Color.Black);
            FindViewById<MvxListView>(Resource.Id.CompaniesListView).Visibility = ViewStates.Visible;
            FindViewById<Android.Views.View>(Resource.Id.MapFragment).Visibility = ViewStates.Invisible;
            FindViewById<LinearLayout>(Resource.Id.BottomAppBar).Visibility = ViewStates.Invisible;
            currentLocation.Visibility = ViewStates.Invisible;
            FindViewById<FloatingActionButton>(Resource.Id.myInfoButton).Visibility = ViewStates.Invisible;
        }

        /// <summary>
        /// Segment control map button click handler.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void MapButtonClick(object obj, EventArgs e)
        {
            currentLocation.Click += CurrentLocationButtonClick;

            mapButton.SetBackgroundResource(Resource.Drawable.selected_button);
            mapButton.SetTextColor(Color.White);
            listButton.SetBackgroundResource(Resource.Drawable.button_selector);
            listButton.SetTextColor(Color.Black);
            FindViewById<Android.Views.View>(Resource.Id.MapFragment).Visibility = ViewStates.Visible;
            FindViewById<MvxListView>(Resource.Id.CompaniesListView).Visibility = ViewStates.Invisible;
            FindViewById<LinearLayout>(Resource.Id.BottomAppBar).Visibility = ViewStates.Visible;
            currentLocation.Visibility = ViewStates.Visible;
            FindViewById<FloatingActionButton>(Resource.Id.myInfoButton).Visibility = ViewStates.Visible;
        }

        /// <summary>
        /// Initiates list button items.
        /// </summary>
        private void InitiateListItems()
        {
            FindViewById<MvxListView>(Resource.Id.CompaniesListView).Visibility = ViewStates.Visible;
            FindViewById<Android.Views.View>(Resource.Id.MapFragment).Visibility = ViewStates.Invisible;
            FindViewById<LinearLayout>(Resource.Id.BottomAppBar).Visibility = ViewStates.Invisible;
            currentLocation.Visibility = ViewStates.Invisible;
            FindViewById<FloatingActionButton>(Resource.Id.myInfoButton).Visibility = ViewStates.Invisible;
            List<RealRiderListItemModel> rrDetailModel = new List<RealRiderListItemModel>();
            foreach (var item in (this.ViewModel as RealRiderMainViewModel).RealRiderListItems)
            {
                rrDetailModel.Add(item);
            }

            FindViewById<ListView>(Resource.Id.CompaniesListView).Adapter = new CustomAdapter(this, rrDetailModel, mBundle);

            drawerView = FindViewById<View>(Resource.Id.drawer);

            drawerImageButton = FindViewById<ImageButton>(Resource.Id.DrawerImage);

            drawerImageButton.Click += DrawerButtonClick;

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerlayout);
            drawerListView = FindViewById<ListView>(Resource.Id.drawerlayoutList);

            drawerItems.Add("Previous Rides");
            drawerItems.Add("Referrals");

            drawerAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, drawerItems);
            drawerListView.Adapter = drawerAdapter;
        }

        /// <summary>
        /// The drawer button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DrawerButtonClick(object sender, EventArgs e)
        {
            mDrawerLayout.OpenDrawer(drawerView);
        }

        /// <summary>
        /// Initiates a map fragment
        /// </summary>
        private void InitMapFragment()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);

            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);
            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }

            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                Android.App.FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.MapFragment, _mapFragment, "map");
                fragTx.Commit();
            }
        }

        /// <summary>
        /// When GPS enabled.
        /// </summary>
        /// <param name="provider"></param>
        public void OnProviderEnabled(string provider)
        {
            // Not implemented
        }

        /// <summary>
        /// When GPS is disabled. Navigate to GPS.
        /// </summary>
        /// <param name="provider"></param>
        public void OnProviderDisabled(string provider)
        {
            Intent intent = new Intent(Settings.ActionLocationSourceSettings);
            StartActivity(intent);
        }

        /// <summary>
        /// On map ready.
        /// </summary>
        /// <param name="map"></param>
        public void OnMapReady(GoogleMap map)
        {
            //Not implemented.
        }

        /// <summary>
        /// This overriden method called to request location updates and initiate google map.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 1000, 2, this);
            _googleMap = _mapFragment.Map;
            _googleMap.UiSettings.ZoomControlsEnabled = false;
            _googleMap.CameraChange += CameraPositionChanged;
        }

        /// <summary>
        /// Camera position changed handler.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void CameraPositionChanged(object obj, GoogleMap.CameraChangeEventArgs e)
        {
            Geocoder geoCoder = new Geocoder(this);
            marker = new List<Marker>();
            markerOptions = new List<MarkerOptions>();
            try
            {
                if (_location != null)
                {
                    var addressList = geoCoder.GetFromLocation(e.Position.Target.Latitude, e.Position.Target.Longitude, 5);
                    foreach (var address in addressList)
                    {
                        markerOptions.Add(new MarkerOptions().SetPosition(new LatLng(e.Position.Target.Latitude, e.Position.Target.Longitude))
                                          .SetTitle(address.GetAddressLine(0) + address.GetAddressLine(1)).Draggable(false));
                    }

                    int count = markerOptions.Count;
                    foreach (var markerOp in markerOptions)
                    {
                        count--;
                        if (count > 0)
                            marker.Add(_googleMap.AddMarker(markerOp));
                    }

                    foreach (var mark in marker)
                    {
                        mark.ShowInfoWindow();
                    }
                    Toast.MakeText(this, "Session Timed Out. Unable to reach the server", ToastLength.Long);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Session Timed Out. Unable to reach the server", ToastLength.Long);
            }
        }

        /// <summary>
        /// Location changed handler.
        /// </summary>
        /// <param name="location"></param>
        public void OnLocationChanged(Location location)
        {
            if (_location != null && !_locationReset)
                return;

            latLng = new LatLng(location.Latitude, location.Longitude);
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(latLng, 15);
            _googleMap.MoveCamera(cameraUpdate);
            _location = location;
            _locationReset = false;
        }

        /// <summary>
        /// Status changed handler.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="status"></param>
        /// <param name="extras"></param>
        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            // Not implemented
        }

        /// <summary>
        /// Map click handler.
        /// </summary>
        /// <param name="point"></param>
        public void OnMapClick(LatLng point)
        {
            _googleMap.AnimateCamera(CameraUpdateFactory.NewLatLng(point));
        }

        /// <summary>
        /// Hardware back press button handler.
        /// </summary>
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            System.Environment.Exit(0);
        }
    }
}