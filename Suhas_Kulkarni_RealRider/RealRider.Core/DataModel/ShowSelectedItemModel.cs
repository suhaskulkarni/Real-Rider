//*************************************************************************************************
// REALRIDER® Technical Test.
// file="ShowSelectedItemModel.cs"
//*************************************************************************************************

namespace RealRider.Core.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShowSelectedItemModel
    {
        /// <summary>
        /// Show spinner selected text.
        /// </summary>
        private string _showSelectedItemText;

        /// <summary>
        /// The show spinner selected text.
        /// </summary>
        public string ShowSelectedItemText
        {
            get
            {
                return _showSelectedItemText;
            }
            set
            {
                _showSelectedItemText = value;
            }
        }
    }
}
