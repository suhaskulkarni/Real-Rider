//*************************************************************************************************
// REALRIDER® Technical Test.
// file="RealRiderListPageItems.cs"
//*************************************************************************************************

namespace RealRider.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RealRiderListPageItems
    {
        /// <summary>
        /// RealRider items list.
        /// </summary>
        public List<RealRiderItem> RealRiderItems { get; set; }

        /// <summary>
        /// Show spinner items list.
        /// </summary>
        public List<string> ShowItemsList { get; set; }

        /// <summary>
        /// Where spinner items list.
        /// </summary>
        public List<string> WhereItemsList { get; set; }
    }
}
