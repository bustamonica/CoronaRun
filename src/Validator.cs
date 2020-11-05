using System;
using first.ast;
using System.Collections.Generic;

namespace first
{

    public class Validator
    {
        private readonly int max_height = 100;
        private readonly int max_width = 100;
        private Maze m;
        private MazeGraph mg;

        public Validator(Maze maze)
        {
            m = maze;
        }

        public bool Validate()
        {
            Coord dim = m.getDimensions();
            if (dim.x < 0 || dim.x > max_width || dim.y < 0 || dim.y > max_height)
            {
                Console.WriteLine("Invalid maze dimensions");
                return false;
            }

            Coord start = m.getStart();
            Coord finish = m.getFinish();

            if (start.equals(finish))
            {
                Console.WriteLine("Start can't be the same as finish");
                return false;
            }

            if (!PointInMaze(start) || !PointInMaze(finish))
            {
                Console.WriteLine("Start and finish have to be within maze");
                return false;
            }

            if (!ValidatePaths()) { return false; }

            mg = new MazeGraph(m);

            if (!ValidateItems()) { return false; }
            if (!ValidateEnemies()) { return false;  }
            if (!SolutionExists()) { return false; }

            return true;
        }

        private bool PointsInMaze(List<Coord> c)
        {
            for(int i = 0; i < c.Count; i++)
            {
                if (!PointInMaze(c[i])) {
                    return false;
                }
            }
            return true;
        }

        private bool PointInMaze(Coord c)
        {
            Coord dim = m.getDimensions();
            return c.x >= 0 && c.y >= 0 && c.x <= dim.x && c.y <= dim.y;
        }

        private bool ValidatePaths()
        {
            List<List<Coord>> paths = m.getPaths();
            for(int i = 0; i < paths.Count; i++) {
                if (!ValidatePath(paths[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidatePath(List<Coord> path)
        {
            if (!PointsDistinct(path))
            {
                Console.WriteLine("Path Coordinates must be distinct");
                return false;
            }
            if (!PointsInMaze(path))
            {
                Console.WriteLine("All path points must be in maze");
                return false;
            }
            int length = path.Count;
            if (length == 0 || length == 1)
            {
                Console.WriteLine("There must be at least two coordinates for a path");
            }
            for (int i = 0; i < length - 1; i++)
            {
                Coord a = path[i];
                Coord b = path[i + 1];
                if (!((a.x == b.x) || (a.y == b.y)))
                {
                    Console.WriteLine("Path Coordinates must line up vertically or horizontally");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateItems()
        {
            List<Item> items = m.getItems();
            for (int i = 0; i < items.Count; i++)
            {
                if(!PointInMaze(items[i].GetLocation()))
                {
                    Console.WriteLine("Item must be in maze");
                    return false;
                }


            }


            List<Coord> l = new List<Coord>();
            foreach (Item i in items)
            {
                l.Add(i.GetLocation());
            }

            //no two items can have the same coordinate
            if (!PointsDistinct(l))
            {
                Console.WriteLine("Items points must be distinct");
                return false;
            }
            //item must be reachable
            foreach (var c in l)
            {
                if (!mg.IsConnected(m.getStart(), c))
                {
                    Console.WriteLine("Items must be reachable");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateEnemies()
        {
            Console.WriteLine("Validating enemies");
            List<Enemy> enemies = m.getEnemies();
            for (int i = 0; i < enemies.Count; i++)
            {
                List<Coord> patrolPath = enemies[i].GetPatrolPath();
                if (!PointsInMaze(patrolPath))
                {
                    Console.WriteLine("Enemy patrol path has to be within graph");
                    return false;
                }
                if (!mg.HasPath(patrolPath))
                {
                    Console.WriteLine("Enemy patrol path has to be a valid path in the graph");
                    return false;
                }
            }
            Console.WriteLine("Enemies valid");
            return true;
        }

        private bool SolutionExists()
        {
            //player has at least one route from start to finish
            if (!mg.IsConnected(m.getStart(), m.getFinish())) {
                Console.WriteLine("There must be at least one route from start to finish");
                return false;
            }
            return true;
        }

        private bool PointsDistinct(List<Coord> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[i].equals(l[j]))
                    {
                        Console.WriteLine(l[i] + ", " + l[j]);
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
