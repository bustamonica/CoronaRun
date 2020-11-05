namespace first.ast
{
    public class CreateMap
    {
        private Coord _dimensions;
        private Start _start;
        private Finish _finish;

        public CreateMap(Coord dimensions, Start start, Finish finish)
        {
            _dimensions = dimensions;
            _start = start;
            _finish = finish;
        }

        public Coord GetDimension()
        {
            return _dimensions;
        }
        
        public Start GetStart()
        {
            return _start;
        }
        
        public Finish GetFinish()
        {
            return _finish;
        }
    }
}