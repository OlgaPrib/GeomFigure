using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class SravPoPloshadi : IComparer<IGeomFig>
    {
        public int Compare(IGeomFig x, IGeomFig y)
        {
            if (x.ploshad > y.ploshad)
                return 1;
            else
                if (x.ploshad < y.ploshad)
                return -1;
            return 0;
        }
    }

    public class SravPoPerimetru : IComparer<IGeomFig>
    {
        public int Compare(IGeomFig x, IGeomFig y)
        {
            if (x.perimetr > y.perimetr)
                return 1;
            else
                if (x.perimetr < y.perimetr)
                return -1;
            return 0;
        }
    }
}
