namespace first.ast
{
    public class DrawPath: Statement
    {
        private Range _path;

        public DrawPath(Range path)
        {
            _path = path;
        }

        public Range GetPath()
        {
            return _path;
        }
    }
}