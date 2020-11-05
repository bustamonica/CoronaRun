using System.Collections.Generic;

namespace first.ast
{
    public class Enemy
    {
        private List<Coord> _patrolPath;

        public Enemy(List<Coord> patrolPath)
        {
            _patrolPath = patrolPath;
        }

        public List<Coord> GetPatrolPath()
        {
            return _patrolPath;
        }
    }
}