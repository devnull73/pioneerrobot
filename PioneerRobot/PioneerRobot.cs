using System;
using System.Collections.Generic;
using Ara3D.Parakeet;

namespace PioneerRobot
{
    class Program
    {
        public static int Main()
        {
            Console.WriteLine("Welcome to Pioneer Robot!");
            var currentCommand = "";
            var tableTop = new Tabletop();
            var robot = new Robot(tableTop);
            
            do
            {
                Console.Write("> ");
                currentCommand = Console.ReadLine();
                
                if (currentCommand != "QUIT")
                {
                    var state = RobotGrammar.Instance.Parse(currentCommand);
                    switch (state)
                    {
                        case null:
                            Console.WriteLine("Invalid command");
                            break;
                        default:
                            if (state.CharsLeft != 0)
                            {
                                Console.WriteLine("Invalid command");
                                break;
                            }
                            var node = state.Node;
                            var nodes = new Stack<ParserNode>();
                            while (node != null)
                            {
                                if (node.Start != node.End)
                                    nodes.Push(node);
                                node = node.Previous;
                            }

                            while (nodes.Count > 0)
                            {
                                node = nodes.Pop();
                                switch (node.Name)
                                {
                                    case "XPos":
                                        robot.X = int.Parse(node.Contents);
                                        break;
                                    case "YPos":
                                        robot.Y = int.Parse(node.Contents);
                                        break;
                                    case "Direction":
                                        robot.Direction = node.Contents.Trim();
                                        break;
                                    case "Left":
                                        robot.Left();
                                        break;
                                    case "Right":
                                        robot.Right();
                                        break;
                                    case "Move":
                                        if (!robot.Move())
                                        {
                                            Console.WriteLine("Can't move - I would fall to my death!");
                                        }
                                        break;
                                    case "Report":
                                        var (direction, x, y) = robot.Report();
                                        Console.WriteLine("{0},{1},{2}",x ,y ,direction);
                                        tableTop.Display(robot);
                                        break;
                                }
                            }
                            break;
                    }           
                }

            } while (currentCommand != "QUIT");

            return 0;
        }
    }
}
