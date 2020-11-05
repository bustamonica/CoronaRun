using System.Collections.Generic;

namespace first.ast
{
    public class CoordList
    {
        private List<Coord> _coordList;

        public CoordList(List<Coord> coordList)
        {
            this._coordList = coordList;
        }

        public List<Coord> getCoordList()
        {
            return this._coordList;
        }
    }
}