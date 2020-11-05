Add entries to this file summarising each project milestone. Don't forget that these need to have been discussed with your TA before the milestone deadline; also, remember to commit and push them by then!

MILESTONE 1: Description of planned DSL idea
*	A maze game in which the user designs a 2D map with various features such as traps, enemies, powerups and a mandatory start and finish point.
*	After defining the attributes of the maze, our DSL will generate the corresponding maze with graphics and the user can then play his/her game.
*	The objective of the game is for the player to reach the finish point without dying. 
*	User would be able to use the DSL to define:
    *	Start and finish points
    *	Pathways in the maze
    * Place enemies within the maze and define their behavior (simple recursive movements/loops)
    *	Place obstacles/traps within the maze (Nice to have)
    *	Set time limits of the game (Nice to have)

Feedback from TA discussion:
* Added 'nice to have' to mark non-essential features
* Potential/target users for this DSL would be anyone interested in creating a custom maze game for entertainment or other reasons.

MILESTONE 2: TASK ALLOCATION, ROADMAP, PROGRESS SO FAR
Planned division of main responsibilities between team members:
* Define DSL grammar (everyone)
* Modify the language based on the result of the study (everyone)
* Tokenize/Parse (Michael)
* Validate (Abdurahman)
* Evaluate (everyone - break down further as we begin)
   * Implement GUI (Devant/Monica)
   * Implement user controls (TBD)
   * Implement maze enemies + movement based on DSL (TBD)
   * Demo video (everyone)

Roadmap for what should be done when:
* 9/25 - Milestone 2
* Define DSL grammar - 9/30
* 10/2 - Milestone 3 
* Tokenize/Parse  done - 10/9
* Validation done -10/9
* GUI started - 10/9
* 10/9 - Milestone 4 (10 days before due date)
* Evaluation 
* 10/14 - Working app done 
* testing/bugfixing - 10/14 -> 10/18
* Final user study: 10/14 -> 10/16
* Video demo - 10/16 -> 10/18
* 10/19 - Project 1 Due date

Summary of progress so far:
* First draft of DSL Grammar finished

Milestone 3:

Grammar:
* INPUT ::== CREATEMAP DRAWMAP+
* DRAWMAP ::== DRAWPATH | PLACEOBJECT
* CREATEMAP ::=“createMap COORD “;” START “;” FINISH “;”
* NUM ::= [0-9]+ 
* COORD ::= “(“ “NUM”, “NUM” “)”
* START ::= “setStart”  COORD ”;”
* FINISH ::= “setFinish”  COORD “;”
* RANGE ::= “[“ COORD [“-” COORD]+ “]” ”;”
* DRAWPATH ::= “drawPath”  RANGE ”;”
* PLACEOBJECT ::= PLACEBOMB | PLACEGOLD | PLACEENEMY
* PLACEBOMB ::=”placeBomb” “[” COORD  (“,” COORD)* “]” ”;”
* PLACEGOLD ::=”placeGold” “[” COORD  (“,” COORD)* “]” ”;”
* PLACEENEMY :: = “placeEnemy” RANGE “;”

User test:

* Create a map of size 7 * 7;
* Set start point at (0,3)
* Set finish point at (6,3) 
* Draw a path [(0,0) - (1,0)]
* Draw a path [(0,1) - (0, 6)]
* Draw a path [(0,1) - (1,1)]
* Draw a path [(1,2) - (1,4) - (3,4)]
* Place gold at [(2, 0), (5,1), (5,5)]
* Place an enemy [(0,1) - (4,1)]
* Place an enemy [(0,1) - (4,1)]
* Place an enemy [(0,1) - (4,1)]
 
User feedback:
* Unable to set the start position of the ghost
* Would be more convenient if can place multiple golds with one command
* What if there is a dead end?
* Easy to use
 
User test result:
* Produce same result as expected

Milestone 4

Status of Implementation:
* Tokenizing/Parsing - 50% done
* Validation - 20% done
* Game:
   * Map creation finished
   * General framework setup, basic controls implemented, collisions, etc

Plans for Final User Study:
* Planned date: Oct 15/16th
* User tasks TBD

Timeline of remaining days:
* Tokenizing/Parsing/Validation finished by Mon Oct 12
* Modify game to generate mazes based on sets of input by Mon Oct 12
* Combine components together, add UI for user input by Wed Oct 14
* Bug fixing/ Final testing by Thrus Oct 15
* User study completed by end of Fri Oct 16
* Make video demo Oct 17/18
