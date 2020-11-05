using System;
using System.Collections;
using System.Collections.Generic;

namespace first.ast
{
    public class Parser
    {
        private static readonly string _NUM = "[0-9]+";
        private static readonly string _ITEMTYPE = "bomb|gold";
        
        private readonly Tokenizer _tokenizer;
        private Maze _maze;

        public static Parser GetParser(Tokenizer tokenizer)
        {
            return new Parser(tokenizer);
        }
        
        private Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public Maze ParseInput()
        {
            _maze = new Maze();
            ParseCreateMap();
            while (_tokenizer.MoreTokens())
            {
                ParseStatement();
            }
            return _maze;
        }

        // STMT ::= CreateMap | DrawPath | PlaceItem | PlaceEnemy
        private void ParseStatement()
        {
            if (_tokenizer.CheckToken("drawPath"))
            {
                ParseDrawPath();
            }
            else if (_tokenizer.CheckToken("placeItem"))
            {
                ParsePlaceItem();
            }
            else if (_tokenizer.CheckToken("placeEnemy"))
            {
                ParsePlaceEnemy();
            }
            else
            {
                throw new Exception("Error: Unexpected token " + _tokenizer.GetNext());
            }
        }

        private void ParseCreateMap()
        {
            _tokenizer.GetAndCheckNext("createMap");
            _maze.SetDimensions(ParseCoord());
            _tokenizer.GetAndCheckNext(";");
            _maze.SetStart(ParseStart());
            _tokenizer.GetAndCheckNext(";");
            _maze.SetFinish(ParseFinish());
            _tokenizer.GetAndCheckNext(";");
        }
        
        private void ParseDrawPath()
        {
            Range range;
            _tokenizer.GetAndCheckNext("drawPath");
            range = ParseRange();
            _tokenizer.GetAndCheckNext(";");
            _maze.AddPaths(range.GetRange());
        }

        private Range ParseRange()
        {
            List<Coord> coords = new List<Coord>();
            _tokenizer.GetAndCheckNext("\\[");
            coords.Add(ParseCoord());
            while (_tokenizer.CheckToken("-"))
            {
                _tokenizer.GetAndCheckNext("-");
                coords.Add(ParseCoord());
            }
            _tokenizer.GetAndCheckNext("\\]");
            return new Range(coords);
        }
        
        private void ParsePlaceItem()
        {
            string itemType;
            List<Coord> coords;
            _tokenizer.GetAndCheckNext("placeItem");
            _tokenizer.GetAndCheckNext("\\(");
            itemType = ParseItemType();
            _tokenizer.GetAndCheckNext(",");
            coords = ParseCoordList();
            _tokenizer.GetAndCheckNext("\\)");
            _tokenizer.GetAndCheckNext(";");

            foreach (var coord in coords)
            {
                _maze.AddItem(new Item(itemType, coord));
            }
        }

        private List<Coord> ParseCoordList()
        {
            List<Coord> coords = new List<Coord>();
            _tokenizer.GetAndCheckNext("\\[");
            coords.Add(ParseCoord());
            while (_tokenizer.CheckToken(","))
            {
                _tokenizer.GetAndCheckNext(",");
                coords.Add(ParseCoord());
            }
            _tokenizer.GetAndCheckNext("\\]");
            return coords;
        }

        private string ParseItemType()
        {
            return _tokenizer.GetAndCheckNext(_ITEMTYPE);
        }
        
        private void ParsePlaceEnemy()
        {
            _tokenizer.GetAndCheckNext("placeEnemy");
            _maze.AddEnemy(new Enemy(ParseRange().GetRange()));
            _tokenizer.GetAndCheckNext(";");
        }

        private Coord ParseStart()
        {
            _tokenizer.GetAndCheckNext("setStart");
            return ParseCoord();
        }

        private Coord ParseFinish()
        {
            _tokenizer.GetAndCheckNext("setFinish");
            return ParseCoord();
        }

        private Coord ParseCoord()
        {
            int x, y;
            _tokenizer.GetAndCheckNext("\\(");
            x = int.Parse(_tokenizer.GetAndCheckNext(_NUM));
            _tokenizer.GetAndCheckNext(",");
            y = int.Parse(_tokenizer.GetAndCheckNext(_NUM));
            _tokenizer.GetAndCheckNext("\\)");
            return new Coord(x, y);
        }
    }
}