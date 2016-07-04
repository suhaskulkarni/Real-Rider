//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderMainViewModel.cs"
//*************************************************************************************************

namespace RealRider.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using RealRider.Core.DataModel;
    using RealRider.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderMainViewModel : MvxViewModel
    {
        /// <summary>
        /// RealRider service member.
        /// </summary>
        private IRealRiderMainService realRiderMainService;

        /// <summary>
        /// RealRider list item model collection member.
        /// </summary>
        private ObservableCollection<RealRiderListItemModel> _realRiderListItems;

        /// <summary>
        /// Binded RealRider list item model collection.
        /// </summary>
        public ObservableCollection<RealRiderListItemModel> RealRiderListItems
        {
            get
            {
                return _realRiderListItems;
            }
            set
            {
                _realRiderListItems = value;
                RaisePropertyChanged(() => RealRiderListItems);
            }
        }

        /// <summary>
        /// Show spinner items collection member.
        /// </summary>
        private ObservableCollection<ShowSelectedItemModel> _showItems;

        /// <summary>
        /// Show spinner items binded collection member.
        /// </summary>
        public ObservableCollection<ShowSelectedItemModel> ShowItems
        {
            get
            {
                return _showItems;
            }
            set
            {
                _showItems = value;
                RaisePropertyChanged(() => ShowItems);
            }
        }

        /// <summary>
        /// Show spinner selected item member.
        /// </summary>
        private ShowSelectedItemModel _showSelectedItem;

        /// <summary>
        /// Show spinner selected item binded member.
        /// </summary>
        public ShowSelectedItemModel ShowSelectedItem
        {
            get
            {
                return _showSelectedItem;
            }
            set
            {
                _showSelectedItem = value;
                RaisePropertyChanged(() => ShowSelectedItem);
            }
        }

        /// <summary>
        /// Where spinner collection member.
        /// </summary>
        private ObservableCollection<WhereSelectionItemModel> _whereItems;

        /// <summary>
        /// Show spinner collection binded member.
        /// </summary>
        public ObservableCollection<WhereSelectionItemModel> WhereItems
        {
            get
            {
                return _whereItems;
            }
            set
            {
                _whereItems = value;
                RaisePropertyChanged(() => WhereItems);
            }
        }

        /// <summary>
        /// Where spinner selected item member.
        /// </summary>
        private WhereSelectionItemModel _whereSelectedItem;

        /// <summary>
        /// Where spinner selected binded item member.
        /// </summary>
        public WhereSelectionItemModel WhereSelectedItem
        {
            get
            {
                return _whereSelectedItem;
            }
            set
            {
                _whereSelectedItem = value;
                RaisePropertyChanged(() => WhereSelectedItem);
            }
        }

        /// <summary>
        /// View Model constructor.
        /// </summary>
        /// <param name="realRiderMainService">RealRider service injected.</param>
        public RealRiderMainViewModel(IRealRiderMainService realRiderMainService)
        {
            this.realRiderMainService = realRiderMainService;
            PageLoad();
        }

        /// <summary>
        /// Load the page when app starts.
        /// </summary>
        public void PageLoad()
        {
            RealRiderListItems = new ObservableCollection<RealRiderListItemModel>();
            ShowSelectedItem = new ShowSelectedItemModel();
            WhereSelectedItem = new WhereSelectionItemModel();

            var rrItems = realRiderMainService.GetRealRiderListItems();
            foreach (var item in rrItems)
            {
                RealRiderListItems.Add(item);
            }

            ShowItems = realRiderMainService.GetShowSpinnerItems();
            ShowSelectedItem.ShowSelectedItemText = ShowItems.FirstOrDefault().ShowSelectedItemText;

            WhereItems = realRiderMainService.GetWhereSpinnerItems();
            WhereSelectedItem = WhereItems.FirstOrDefault();
        }
    }
}
