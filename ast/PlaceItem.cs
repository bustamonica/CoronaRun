using System;

namespace first.ast
{
    public class PlaceItem: Statement
    {
        private ItemType _type;
        private CoordList _coords;

        public PlaceItem(ItemType type, CoordList coords)
        {
            _type = type;
            _coords = coords;
        }

        public ItemType GetItemType()
        {
            return _type;
        }

        public CoordList GetCoords()
        {
            return _coords;
        }
    }
}