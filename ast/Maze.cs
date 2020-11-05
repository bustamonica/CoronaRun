using System.Collections.Generic;

namespace first.ast
{
    public class Maze
    {
        private Coord _mazeDimensions;
        private Coord _start;
        private Coord _finish;
        private List<List<Coord>> _paths;
        private List<Item> _items;
        private List<Enemy> _enemies;

        public Maze()
        {
            _paths = new List<List<Coord>>();
            _items = new List<Item>();
            _enemies = new List<Enemy>();
        }

        public void SetDimensions(Coord dimension)
        {
            _mazeDimensions = dimension;
        }
        
        public void SetStart(Coord start)
        {
            _start = start;
        }
        
        public void SetFinish(Coord finish)
        {
            _finish = finish;
        }

        public void AddPaths(List<Coord> path)
        {
            _paths.Add(path);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public Coord getDimensions()
        {
            return _mazeDimensions;
        }

        public List<List<Coord>> getPaths() {
            return _paths;
        }

        public List<Item> getItems() {
            return _items;
        }

        public List<Enemy> getEnemies() {
            return _enemies;
        }

        public Coord getStart()
        {
            return _start;
        }

        public Coord getFinish()
        {
            return _finish;
        }


    }
}