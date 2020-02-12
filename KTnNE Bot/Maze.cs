using System;
using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class Maze : Module
    {
        int stage;
        int mazeId;
        int posx;
        int posy;
        int finishx;
        int finishy;
        Dictionary<int, char[,]> mazes = new Dictionary<int, char[,]>();
        public Maze()
        {
            TextSynthesizer.Speak("maze ok circle");
            Recognizer.SetContext(new List<string> { "one", "two", "three", "four", "five", "six" }, 2, 4);
            LoadMazes();
            stage = 0;
        }

        private void LoadMazes()
        {
            mazes[1] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','x','x','o','x','o','x','x','x','x','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','o','x','x','x','x','x','x','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','x','x','o','x','o','x','x','x','o','x'},
                {'x','o','x','o','o','o','o','o','x','o','o','o','x'},
                {'x','o','x','x','x','x','x','x','x','x','x','o','x'},
                {'x','o','o','o','o','o','x','o','o','o','x','o','x'},
                {'x','o','x','x','x','o','x','o','x','x','x','o','x'},
                {'x','o','o','o','x','o','o','o','x','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[2] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','x','o','o','o','o','o','x'},
                {'x','x','x','o','x','x','x','o','x','o','x','x','x'},
                {'x','o','o','o','x','o','o','o','x','o','o','o','x'},
                {'x','o','x','x','x','o','x','x','x','x','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','o','x','x','x','o','x','x','x','o','x'},
                {'x','o','o','o','x','o','o','o','x','o','x','o','x'},
                {'x','o','x','x','x','o','x','x','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','o','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','x','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[3] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','x','o','x','o','o','o','x'},
                {'x','o','x','x','x','o','x','o','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','o','o','x','o','x'},
                {'x','x','x','o','x','o','x','x','x','x','x','o','x'},
                {'x','o','o','o','x','o','x','o','o','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','o','x','o','x'},
                {'x','o','x','o','o','o','x','o','x','o','x','o','x'},
                {'x','o','x','x','x','x','x','o','x','o','x','o','x'},
                {'x','o','o','o','o','o','o','o','x','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[4] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','x','o','o','o','o','o','o','o','x'},
                {'x','o','x','o','x','x','x','x','x','x','x','o','x'},
                {'x','o','x','o','x','o','o','o','o','o','o','o','x'},
                {'x','o','x','o','x','o','x','x','x','x','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','o','x','x','x','o','x'},
                {'x','o','x','o','o','o','o','o','o','o','o','o','x'},
                {'x','o','x','x','x','x','x','x','x','x','x','o','x'},
                {'x','o','o','o','o','o','o','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','x','x','o','x','o','x'},
                {'x','o','o','o','o','o','x','o','o','o','x','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[5] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','o','o','o','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','o','x','o','x'},
                {'x','o','o','o','o','o','o','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','o','x','x','x','x','x'},
                {'x','o','o','o','x','o','o','o','x','o','o','o','x'},
                {'x','o','x','o','x','x','x','x','x','o','x','o','x'},
                {'x','o','x','o','o','o','o','o','x','o','x','o','x'},
                {'x','o','x','x','x','x','x','o','x','x','x','o','x'},
                {'x','o','x','o','o','o','o','o','o','o','x','o','x'},
                {'x','o','x','o','x','x','x','x','x','x','x','o','x'},
                {'x','o','x','o','o','o','o','o','o','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[6] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','o','x','o','x','x','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','o','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','x','x','o','x'},
                {'x','o','o','o','x','o','x','o','x','o','o','o','x'},
                {'x','o','x','x','x','x','x','o','x','o','x','x','x'},
                {'x','o','o','o','x','o','o','o','x','o','x','o','x'},
                {'x','x','x','o','x','o','x','o','x','o','x','o','x'},
                {'x','o','o','o','x','o','x','o','x','o','o','o','x'},
                {'x','o','x','x','x','x','x','o','x','x','x','o','x'},
                {'x','o','o','o','o','o','o','o','x','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[7] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','o','o','x','o','o','o','x'},
                {'x','o','x','x','x','x','x','o','x','o','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','x','o','x'},
                {'x','o','x','o','x','x','x','x','x','x','x','o','x'},
                {'x','o','o','o','x','o','o','o','x','o','o','o','x'},
                {'x','x','x','x','x','o','x','x','x','o','x','x','x'},
                {'x','o','o','o','x','o','o','o','o','o','x','o','x'},
                {'x','o','x','o','x','o','x','x','x','x','x','o','x'},
                {'x','o','x','o','x','o','o','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','x','x','o','x','o','x'},
                {'x','o','o','o','o','o','o','o','o','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[8] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','x','o','o','o','o','o','x','o','o','o','x'},
                {'x','o','x','o','x','x','x','o','x','o','x','o','x'},
                {'x','o','o','o','o','o','x','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','x','x','x','x','o','x'},
                {'x','o','x','o','o','o','o','o','o','o','x','o','x'},
                {'x','o','x','o','x','x','x','x','x','o','x','o','x'},
                {'x','o','x','o','o','o','x','o','o','o','o','o','x'},
                {'x','o','x','x','x','o','x','x','x','x','x','x','x'},
                {'x','o','x','o','x','o','o','o','o','o','o','o','x'},
                {'x','o','x','o','x','x','x','x','x','x','x','x','x'},
                {'x','o','o','o','o','o','o','o','o','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
            mazes[9] = new char[13, 13] {
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'},
                {'x','o','x','o','o','o','o','o','o','o','o','o','x'},
                {'x','o','x','o','x','x','x','x','x','o','x','o','x'},
                {'x','o','x','o','x','o','o','o','x','o','x','o','x'},
                {'x','o','x','o','x','o','x','x','x','o','x','o','x'},
                {'x','o','o','o','o','o','x','o','o','o','x','o','x'},
                {'x','o','x','x','x','x','x','o','x','x','x','o','x'},
                {'x','o','x','o','x','o','o','o','x','o','o','o','x'},
                {'x','o','x','o','x','o','x','x','x','x','x','o','x'},
                {'x','o','x','o','x','o','x','o','o','o','x','o','x'},
                {'x','o','x','o','x','o','x','o','x','o','x','x','x'},
                {'x','o','o','o','x','o','o','o','x','o','o','o','x'},
                {'x','x','x','x','x','x','x','x','x','x','x','x','x'}, };
        }

        public override void Interpret(string text)
        {
            if(stage == 0)
            {
                List<string> longText = text.Split(' ').ToList();
                if (longText.Count != 2)
                {
                    TextSynthesizer.Speak("again");
                    return;
                }
                switch (text)
                {
                    case "one two":
                        mazeId = 1;
                        break;
                    case "six three":
                        mazeId = 1;
                        break;
                    case "two four":
                        mazeId = 2;
                        break;
                    case "five two":
                        mazeId = 2;
                        break;
                    case "four four":
                        mazeId = 3;
                        break;
                    case "six four":
                        mazeId = 3;
                        break;
                    case "one one":
                        mazeId = 4;
                        break;
                    case "one four":
                        mazeId = 4;
                        break;
                    case "five three":
                        mazeId = 5;
                        break;
                    case "four six":
                        mazeId = 5;
                        break;
                    case "five one":
                        mazeId = 6;
                        break;
                    case "three five":
                        mazeId = 6;
                        break;
                    case "two one":
                        mazeId = 7;
                        break;
                    case "two six":
                        mazeId = 7;
                        break;
                    case "four one":
                        mazeId = 8;
                        break;
                    case "three four":
                        mazeId = 8;
                        break;
                    case "three two":
                        mazeId = 9;
                        break;
                    case "one five":
                        mazeId = 9;
                        break;
                    default:
                        TextSynthesizer.Speak("again");
                        return;
                }
                stage = 1;
                TextSynthesizer.Speak(text +" ok player");
            }
            else if(stage == 1)
            {
                List<string> longText = text.Split(' ').ToList();
                if (longText.Count != 2)
                {
                    TextSynthesizer.Speak("again");
                    return;
                }
                posy = (Converter.ToInt(longText[0]) * 2)-1;
                posx = (Converter.ToInt(longText[1]) * 2)-1;

                stage = 2;
                TextSynthesizer.Speak(text + " ok finish");
            }else if (stage == 2)
            {
                List<string> longText = text.Split(' ').ToList();
                if (longText.Count != 2)
                {
                    TextSynthesizer.Speak("again");
                    return;
                }
                finishy = (Converter.ToInt(longText[0]) * 2)-1;
                finishx = (Converter.ToInt(longText[1]) * 2)-1;

                stage = 3;
                TextSynthesizer.Speak(text + " ok");
                SolveMaze();
                Interpreter.IdleBomb();
            }
        }

        private void SolveMaze()
        {
            MazeNode currentNode = new MazeNode(null, posx, posy);
            char[,] maze = mazes[mazeId];
            List<string> path = new List<string>();
            CheckDirections(currentNode, maze);
            while (posx != finishx || posy != finishy)
            {
                
                if (path.Count > 0)
                {
                    if (path.Last() == "up") currentNode.directions["down"] = false; //dont go back
                    if (path.Last() == "down") currentNode.directions["up"] = false;
                    if (path.Last() == "left") currentNode.directions["right"] = false;
                    if (path.Last() == "right") currentNode.directions["left"] = false;
                }
                if (posx > finishx)
                {
                    string dir = TryGo("up",currentNode);
                    if(dir == "dead")
                    {
                        path.RemoveAt(path.Count - 1);
                        posx = currentNode.previousNode.posx;
                        posy = currentNode.previousNode.posy;
                        currentNode = currentNode.previousNode;
                        continue;
                    }
                    path.Add(dir);
                    currentNode.directions[dir] = false;
                    currentNode = new MazeNode(currentNode, posx, posy);
                    CheckDirections(currentNode, maze);
                    continue;
                }
                if(posx < finishx)
                {
                    string dir = TryGo("down", currentNode);
                    if (dir == "dead")
                    {
                        path.RemoveAt(path.Count - 1);
                        posx = currentNode.previousNode.posx;
                        posy = currentNode.previousNode.posy;
                        currentNode = currentNode.previousNode;
                        continue;
                    }
                    path.Add(dir);
                    currentNode.directions[dir] = false;
                    currentNode = new MazeNode(currentNode, posx, posy);
                    CheckDirections(currentNode, maze);
                    continue;
                }
                if (posy > finishy)
                {
                    string dir = TryGo("left", currentNode);
                    if (dir == "dead")
                    {
                        path.RemoveAt(path.Count - 1);
                        posx = currentNode.previousNode.posx;
                        posy = currentNode.previousNode.posy;
                        currentNode = currentNode.previousNode;
                        continue;
                    }
                    path.Add(dir);
                    currentNode.directions[dir] = false;
                    currentNode = new MazeNode(currentNode, posx, posy);
                    CheckDirections(currentNode, maze);
                    continue;
                }
                if (posy < finishy)
                {
                    string dir = TryGo("right", currentNode);
                    if (dir == "dead")
                    {
                        path.RemoveAt(path.Count - 1);
                        posx = currentNode.previousNode.posx;
                        posy = currentNode.previousNode.posy;
                        currentNode = currentNode.previousNode;
                        continue;
                    }
                    path.Add(dir);
                    currentNode.directions[dir] = false;
                    currentNode = new MazeNode(currentNode, posx, posy);
                    CheckDirections(currentNode, maze);
                    continue;
                }
            }
            string finished = "";
            foreach(string move in path)
            {
                finished += move + ", ";
            }
            TextSynthesizer.Speak(finished);
        }

        private string TryGo(string dir, MazeNode node)
        {
            switch (dir)
            {
                case "up":
                    if (node.directions["up"])
                    {
                        posx -= 2;
                        return "up";
                    }
                    if (node.directions["right"])
                    {
                        posy += 2;
                        return "right";
                    }
                    if (node.directions["left"])
                    {
                        posy -= 2;
                        return "left";
                    }
                    if (node.directions["down"])
                    {
                        posx += 2;
                        return "down";
                    }
                    return "dead";
                case "down":
                    if (node.directions["down"])
                    {
                        posx += 2;
                        return "down";
                    }
                    if (node.directions["right"])
                    {
                        posy += 2;
                        return "right";
                    }
                    if (node.directions["left"])
                    {
                        posy -= 2;
                        return "left";
                    }
                    if (node.directions["up"])
                    {
                        posx -= 2;
                        return "up";
                    }
                    return "dead";
                case "left":
                    if (node.directions["left"])
                    {
                        posy -= 2;
                        return "left";
                    }
                    if (node.directions["up"])
                    {
                        posx -= 2;
                        return "up";
                    }
                    if (node.directions["down"])
                    {
                        posx += 2;
                        return "down";
                    }
                    if (node.directions["right"])
                    {
                        posy += 2;
                        return "right";
                    }
                    return "dead";
                case "right":
                    if (node.directions["right"])
                    {
                        posy += 2;
                        return "right";
                    }
                    if (node.directions["up"])
                    {
                        posx -= 2;
                        return "up";
                    }
                    if (node.directions["down"])
                    {
                        posx += 2;
                        return "down";
                    }
                    if (node.directions["left"])
                    {
                        posy -= 2;
                        return "left";
                    }
                    return "dead";
            }
            return "er";
        }

        private void CheckDirections(MazeNode node,char[,] maze)
        {
            if(maze[posx-1,posy] == 'x')
            {
                node.directions["up"] = false;
            }
            else
            {
                node.directions["up"] = true;
            }
            if (maze[posx + 1, posy] == 'x')
            {
                node.directions["down"] = false;
            }
            else
            {
                node.directions["down"] = true;
            }
            if (maze[posx, posy-1] == 'x')
            {
                node.directions["left"] = false;
            }
            else
            {
                node.directions["left"] = true;
            }
            if (maze[posx, posy+1] == 'x')
            {
                node.directions["right"] = false;
            }
            else
            {
                node.directions["right"] = true;
            }
        }
    }
    internal class MazeNode {
        public MazeNode previousNode;
        public int posx;
        public int posy;
        public Dictionary<string, bool> directions;

        public MazeNode(MazeNode prev, int posx, int posy)
        {
            previousNode = prev;
            this.posx = posx;
            this.posy = posy;
            directions = new Dictionary<string, bool>();
        }
    }

}