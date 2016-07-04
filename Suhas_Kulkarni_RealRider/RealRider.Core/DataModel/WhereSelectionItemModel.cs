//*************************************************************************************************
// REALRIDER® Technical Test.
// file="WhereSelectionItemModel.cs"
//*************************************************************************************************

namespace RealRider.Core.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WhereSelectionItemModel
    {
        /// <summary>
        /// Where spinner selected text.
        /// </summary>
        private string _whereSelectedItemText;

        /// <summary>
        /// The where spinner selected text.
        /// </summary>
        public string WhereSelectedItemText
        {
            get
            {
                return _whereSelectedItemText;
            }
            set
            {
                _whereSelectedItemText = value;
            }
        }
    }
}
