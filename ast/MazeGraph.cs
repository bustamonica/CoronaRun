using System;
using System.Collections.Generic;

namespace first.ast
{
    public class MazeGraph
    {
        private Dictionary<Coord, List<Coord>> adjVertices;
        private readonly Coord[,] coords;
        public MazeGraph(Maze m)
        {
            adjVertices = new Dictionary<Coord, List<Coord>>();
            Coord c = m.getDimensions();
            coords = new Coord[c.x + 1 ,c.y + 1];
            for (int i = 0; i <= c.x; i++)
            {
                for (int j = 0; j <= c.y; j++)
                {
                    Coord next = new Coord(i, j);
                    coords[i,j] = next;
                    List<Coord> l = new List<Coord>();
                    adjVertices.Add(next, l);
                }
            }
            BuildMazeGraph(m.getPaths());
        }

        //assume path is at least of length 2
        public bool HasPath(List<Coord> path)
        {
            //check if consecutive paths in path are connected
            for (int i = 0; i < path.Count - 1; i++)
            {
                Coord a = path[i];
                Coord b = path[i + 1];
                if (!IsConnected(a, b))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsConnected(Coord a, Coord b)
        {
            a = coords[a.x, a.y];
            b = coords[b.x, b.y];
            HashSet<Coord> visited = new HashSet<Coord>();
            Queue<Coord> q = new Queue<Coord>();
            q.Enqueue(a);
            while (q.Count != 0)
            {
                Coord next = q.Dequeue();
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    foreach (var n in adjVertices.GetValueOrDefault(next))
                    {
                        if (n.equals(b))
                        {
                            return true;
                        }
                        else
                        {
                            q.Enqueue(n);
                        }
                    }
                }
            }
            return false;
        }

        public void PrintGraph()
        { 
            foreach(KeyValuePair<Coord, List<Coord>> entry in adjVertices)
            {
                Coord curr = entry.Key;
                List<Coord> adj = entry.Value;
                Console.WriteLine(curr.toString());
                foreach (Coord c in adj)
                {
                    Console.WriteLine(c.toString());
                }
            }
        }

        private void BuildMazeGraph(List<List<Coord>> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                AddPath(paths[i]);
            }
        }

        //assume path is valid
        private void AddPath(List<Coord> path)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                Coord a = path[i];
                Coord b = path[i + 1];
                if (a.x == b.x)
                {
                    if (a.y < b.y)
                    {
                        for (int j = a.y; j < b.y; j++)
                        {
                            AddEdge(coords[a.x, j], coords[a.x, j + 1]);
                        }
                    } else //b.y < a.y
                    {
                        for (int j = b.y; j < a.y; j++)
                        {
                            AddEdge(coords[a.x, j], coords[a.x, j + 1]);
                        }
                    }
                }
                else
                {
                    if (a.x < b.x)
                    {
                        for (int j = a.x; j < b.x; j++)
                        {
                            AddEdge(coords[j, a.y], coords[j + 1, a.y]);
                        }
                    }
                    else //b.x < a.x
                    {
                        for (int j = b.x; j < a.x; j++)
                        {
                            AddEdge(coords[j, a.y], coords[j + 1, a.y]);
                        }
                    }
                    
                }
            }


        }

        private void AddEdge(Coord a, Coord b)
        {
            List<Coord> adjA = adjVertices.GetValueOrDefault(a);
            List<Coord> adjB = adjVertices.GetValueOrDefault(b);
            if (!adjA.Contains(b))
            {
                adjA.Add(b);
            }
            if (!adjB.Contains(a))
            {
                adjB.Add(a);
            }
        }

    }
}
