namespace first.ast
{
    public class PlaceEnemy: Statement
    {
        private Range _patrolRange;

        public PlaceEnemy(Range patrolRange)
        {
            _patrolRange = patrolRange;
        }

        public Range GetPatrolRange()
        {
            return _patrolRange;
        }
    }
}