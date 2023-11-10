using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_Map_WillB
{
    internal class Program
    {
        static char[,] map = new char[,] // dimensions defined by following data:
    {
        {'^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
        {'^','^','`','`','`','*','*','`','#','#','#','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','`','`','`','#','#','#','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','|','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','|','`','`','`','`','`','`','`','#','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','~','~','~','~','#','-','+','-','-','-','-','-','-','#','#','`','`','`','`','^','^','`','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','`','|','`','`','`','`','`','`','`','#','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','|','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','|','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','#','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','#','#','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
    };


        // usage: map[y, x]

        // map legend:
        // ^ = mountain
        // ` = grass
        // ~ = water
        // * = trees
        static string adjustSize;
        
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|Hello!                               |" +
                            "\n|Welcome to Will's Text Based RPG Map.|" + "\n" +
                              "|Press any key to begin:              | ");
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
            Console.WriteLine("Displaying Base Map");
            DisplayMap();
            Console.WriteLine("Dispalying Map 2x");
            DisplayMap(2);
            Console.WriteLine("Displaying Map 3x");
            DisplayMap(3);
            Console.WriteLine("Displaying Map -4x");
            DisplayMap(-4);
            Console.WriteLine("That was the last map scale, press any key to quit");
            Console.ReadKey();
        }
        static void DisplayMap( int scale)
        {
            if( scale <= 0)
            {
                Console.WriteLine("Error. Cannot scale by a negative number. Converting scale to one.");
                scale = 1;
            }
            Console.Write("+================+\n" +
                          "| ^ - Mountain   |\n"
                         +"| ` - Grass      |\n"
                         +"| ~ - Water      |\n"
                         +"| * - Tree       |\n"
                         +"| # - Village    |\n"
                         +"| - - Path       |\n"
                         +"+================+\n");
            
            Console.WriteLine("+" + new string('=', map.GetLength(1) * scale) + "+");
            
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for (int scale1 = 0; scale1 < scale; scale1++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    for(int x = 0; x < map.GetLength(1); x++)
                    {
                        for(int scale2 = 0;scale2 < scale; scale2++)
                        {
                            if (map[y,x] == '^')
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (map[y, x] == '`')
                            {
                                Console.ForegroundColor= ConsoleColor.Green;
                            }
                            if (map[y,x] == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            if (map[y,x] == '~')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            if (map[y,x] == '#')
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            if (map[y, x] == '-')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            if (map[y,x] == '|')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            Console.Write(map[y,x]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                }
            }
            Console.WriteLine("+" + new string('=', map.GetLength(1) * scale) + "+");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void DisplayMap()
        {
            int width = map.GetLength(1);
            int height = map.GetLength(0);
            int current = 0;
            for (int x = 0; x <= width; x++)
            {
                if (x == 0)
                {
                    Console.Write("+");
                }

                Console.Write("-");

                if (x == width - 1)
                {
                    Console.Write("+");
                    Console.Write("\n");
                    break;
                }
            }

            foreach (char MapCell in map)
            {
                if (current == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                if (MapCell == '^')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (MapCell == '`')
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                }
                if(MapCell == '*')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (MapCell == '~')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if(MapCell == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if(MapCell == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                if(MapCell == '+')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                if(MapCell == '|')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Write(MapCell);
                

                if (current >= width - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                    current = 0;
                }
                else
                {
                    current++;
                }
                Console.ForegroundColor = ConsoleColor.White;
                
            }
            for (int x = 0; x <= width; x++)
            {
                if (x == 0)
                {
                    Console.Write("+");
                }

                Console.Write("-");

                if (x == width - 1)
                {
                    Console.Write("+");
                    Console.Write("\n");
                    break;
                }
            }
            Console.ReadLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
