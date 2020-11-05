namespace first.ast
{
    // Represents a coordinate in 2D grid space
    public class Coord
    {
        public int x;
        public int y;
        
        public Coord(int xCord, int yCord)
        {
            x = xCord;
            y = yCord;
        }

        public int GetXCord()
        {
            return x;
        }
        
        public int GetYCord()
        {
            return y;
        }

        public bool equals(Coord other)
        {
            return x == other.x && y == other.y;
        }

        public string toString()
        {
            return "( " + x + "," + y + " )";
        }
    }
}