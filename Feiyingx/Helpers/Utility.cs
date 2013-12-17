using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feiyingx.Code.DataConstants;

namespace Feiyingx.Helpers
{
    public class Utility
    {
        public static String GetProjectTypeName(int type)
        {
            return ((Enumerations.ProjectType)type).ToString();
        }

        public static String GetSeasonString(DateTime date)
        {
            String season = "";
            if (date.Month == 12 || date.Month < 3) //Months 12,1,2
            {
                season = "Winter";
            }
            if (date.Month < 6)
            { //Months 3,4,5
                season = "Spring";
            }
            else if (date.Month < 9)
            { //Months 6,7,8
                season = "Summer";
            }
            else if (date.Month < 12)
            {
                //Months 9,10,11
                season = "Fall";
            }
            return season;
        }
    }
}