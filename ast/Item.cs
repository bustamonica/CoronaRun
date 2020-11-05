namespace first.ast
{
    public class Item
    {
        private string _itemType;
        private Coord _location;

        public Item(string type, Coord location)
        {
            _itemType = type;
            _location = location;
        }

        public Coord GetLocation()
        {
            return _location;
        }

        public string GetItemType()
        {
            return _itemType;
        }
    }
}