using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace first
{
    public class DSLTokenizer: Tokenizer
    {
        private string _input;
        private readonly List<string> _fixedLiterals = new List<string> {"createMap",
            "setStart",
            "setFinish",
            "drawPath",
            "placeItem",
            "placeEnemy",
            ",",
            ";",
            "(",
            ")",
            "[",
            "]",
            "-"
        };
        private readonly string _reserveword = "_";
        private int _currToken = 0;
        private string[] _tokens;

        public DSLTokenizer(string input)
        {
            _input = input;
            Tokenize();
        }

        private void Tokenize()
        {
            var tokenized = _input.Replace("\n", "");
            tokenized = tokenized.Replace(" ", "");
            foreach (var literal in _fixedLiterals)
            {
                tokenized = tokenized.Replace(literal, _reserveword + literal + _reserveword);
            }
            tokenized = tokenized.Replace(_reserveword + _reserveword, _reserveword);
            if (tokenized.StartsWith(_reserveword))
            {
                tokenized = tokenized.Substring(_reserveword.Length);
            }
            if (tokenized.EndsWith(_reserveword))
            {
                tokenized = tokenized.Substring(0, tokenized.Length - _reserveword.Length);
            }
            _tokens = tokenized.Split(_reserveword);
            for (int i = 0; i < _tokens.Length; i++)
            {
                _tokens[i] = _tokens[i].Trim();
            }
        }
        
        public string GetNext()
        {
            string token = "EMPTY_TOKEN";
            if (_currToken < _tokens.Length)
            {
                token = _tokens[_currToken];
                _currToken++;
            }
            return token;
        }

        public string GetAndCheckNext(string regex)
        {
            string token = GetNext();
            if (Regex.IsMatch(token, regex))
            {
                return token;
            }
            throw new Exception("Unable to parse token: " + token + " did not match " + regex);
        }

        public bool MoreTokens()
        {
            return _currToken < _tokens.Length;
        }

        public string CheckNext()
        {
            string token = "EMPTY_TOKEN";
            if (_currToken < _tokens.Length)
            {
                token = _tokens[_currToken];
            }
            return token;
        }

        public bool CheckToken(string regex)
        {
            string token = CheckNext();
            return Regex.IsMatch(token, regex);
        }
    }
}