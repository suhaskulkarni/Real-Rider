//*************************************************************************************************
// REALRIDER® Technical Test.
// file="IRealRiderMainService.cs"
//*************************************************************************************************

namespace RealRider.Core.Interfaces
{
    using RealRider.Core.DataModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRealRiderMainService
    {
        /// <summary>
        /// List of real rider items in List page.
        /// </summary>
        List<RealRiderListItemModel> RealRiderListItems { get; set; }

        /// <summary>
        /// Gets the list of real rider items.
        /// </summary>
        /// <returns>RealRiderListItemModel list.</returns>
        List<RealRiderListItemModel> GetRealRiderListItems();

        /// <summary>
        /// Returns collection of show spinner items.
        /// </summary>
        /// <returns>ShowSelectedItemModel collection.</returns>
        ObservableCollection<ShowSelectedItemModel> GetShowSpinnerItems();

        /// <summary>
        /// Returns collection of Where spinner items.
        /// </summary>
        /// <returns>WhereSelectionItemModel collection.</returns>
        ObservableCollection<WhereSelectionItemModel> GetWhereSpinnerItems();
    }
}
