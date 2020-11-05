using System;
using System.Collections;
using System.Collections.Generic;
using first.ast;

namespace first
{
    class TestProgram
    {
        static void Main(string[] args)
        {

            Console.WriteLine("__________________________________");
            

            string input = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";

            string dim = "createMap(105, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string dim2 = "createMap(3, 105); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string items = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,2)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string items2 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,3), (1,4), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string items3 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5,5)];\n" +
                           "placeItem(gold, [(1,2), (1,3), (1,4), (2,5)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string path = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(4,3)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string path2 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "drawPath[(1,3)-(1, 5)];\n" +
                           "drawPath[(1,1)-(1,5)-(3, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" + //path might be invalid
                           "placeEnemy[(1,1)-(1,4)];";
            string path3 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "drawPath[(1,3)-(1, 5)];\n" +
                           "drawPath[(1,1)-(1,1)-(1, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string path4 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "drawPath[(1,3)-(1, 5)];\n" +
                           "drawPath[(1,1)-(1, 500)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,4)];";
            string enemies = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,5)];";
            string enemies1 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,6)];";
            string enemies2 = "createMap(5, 5); setStart(1,1); setFinish(5,5);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(2,1)-(3,1)];";
            string solvable = "createMap(5, 5); setStart(1,1); setFinish(4,4);\n" +
                           "drawPath[(1,1)-(1,5)-(5, 5)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,5)];";
            string solvable2 = "createMap(5, 5); setStart(1,1); setFinish(4,4);\n" +
                            "drawPath[(1,1)-(1,5)-(4, 5)];\n" +
                           "drawPath[(4,1)-(4, 4)];\n" +
                           "drawPath[(1,4)-(4, 4)];\n" +
                           "drawPath[(1,1)-(1, 4)];\n" +
                           "placeItem(gold, [(1,2), (1,3)]);\n" +
                           "placeEnemy[(1,1)-(1,5)];";

            TestValidator(input, true, "Basic valid program");
            TestValidator(dim, false, "Invalid maze dimensions");
            TestValidator(dim2, false, "Invalid maze dimensions");
            TestValidator(items, false, "Items points must be distinct");
            TestValidator(items2, false, "Items points must be distinct");
            TestValidator(items3, true, "Valid longer items list");
            TestValidator(path, false, "Path Coordinates must line up vertically or horizontally");
            TestValidator(path2, true, "Multiple paths valid");
            TestValidator(path3, false, "Path Coordinates must be distinct");
            TestValidator(path4, false, ("All path points must be in maze"));
            TestValidator(enemies, true, "Test valid enemy route");
            TestValidator(enemies1, false, "Enemy patrol path has to be within graph");
            TestValidator(enemies2, false, "Enemy patrol path has to be a valid path in the graph");
            TestValidator(solvable, false, "There must be at least one route from start to finish");
            TestValidator(solvable2, true, "More complicated but solvable path");
        }

        public static void TestValidator(string testcase, bool programIsValid, string expectedOutput)
        {

            Tokenizer t = new DSLTokenizer(testcase);

            Parser p = Parser.GetParser(t);
            Maze maze = p.ParseInput();
            Validator v = new Validator(maze);
            Console.WriteLine(testcase);
            Console.WriteLine("Validating");
            bool validatorReturnedValid = v.Validate(); //output
            if (!programIsValid && !validatorReturnedValid)
            {
                Console.WriteLine("Expected: " + expectedOutput);
            }
            else if (programIsValid && validatorReturnedValid)
            {
                Console.WriteLine("Program is valid and validator returned valid, test passed");
            }
            else if (!programIsValid && validatorReturnedValid) {
                Console.WriteLine("Validator returned valid, but program is invalid, test failed");
                Console.WriteLine("Expected: " + expectedOutput);
            }
            else 
            {
                Console.WriteLine("Validator returned invalid, but program is valid, test failed");
            }
            Console.WriteLine();
        }
    }
}