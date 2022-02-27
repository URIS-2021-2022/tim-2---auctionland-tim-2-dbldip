using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Helpers
{
    public class CheckTotalSurfaceOfPlots
    {
        public bool checkIfTotalSurfaceIsOverLimit(List<PlotEntity> listOfPlots)
        {
            var sum = 0;
            foreach(var el in listOfPlots)
            {
                sum += el.surfaceArea;
                if(sum > 500)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
