//*************************************************************************************************
// REALRIDER® Technical Test.
// file="CommonImageSource.cs"
//*************************************************************************************************

namespace RealRider.Core.Common
{
   using RealRider.Core.Enums;
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Threading.Tasks;

   public class CommonImageSource
   {
        /// <summary>
        /// Gets the company type background icon based on company color.
        /// </summary>
        /// <param name="colorEnum">CompanyColorEnum type.</param>
        /// <returns></returns>
       public static string GetCompanyTypeBackgroundIcon(CompanyColorEnum colorEnum)
       {
           switch (colorEnum)
           {
               case CompanyColorEnum.Green:
                   return Constants.GreenBackground;
               case CompanyColorEnum.Blue:
                   return Constants.BlueBackground;
               default:
                   return string.Empty;
           }
       }

       /// <summary>
       /// Gets the company icon path, based on company type enum.
       /// </summary>
       /// <param name="companyTypeEnum">CompanyType enum.</param>
       /// <returns></returns>
       public static string GetCompanyTypeIcon(CompanyTypeEnum companyTypeEnum)
       {
           switch (companyTypeEnum)
           {
               case CompanyTypeEnum.Retailer:
                   return Constants.RetailerCompanyType;
               case CompanyTypeEnum.OffRoad:
                   return Constants.FlagCompanyType;
               case CompanyTypeEnum.Dealership:
                   return Constants.BikeCompanyType;
               default:
                   return string.Empty;
           }
       }
   }
}
