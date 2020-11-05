using System;
using System.Collections.Generic;

namespace first.ast
{
    public class Range
    {
        private List<Coord> _coords;

        public Range(List<Coord> coordList)
        {
            if (coordList.Count < 2)
            {
                throw new Exception("Error: Range has less than 2 coordinates");
            }
            _coords = coordList;
        }

        public List<Coord> GetRange()
        {
            return _coords;
        }
    }
}