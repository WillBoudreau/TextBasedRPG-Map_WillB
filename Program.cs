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
        {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
    };


        // usage: map[y, x]

        // map legend:
        // ^ = mountain
        // ` = grass
        // ~ = water
        // * = trees
        static int i = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|Hello!                               |" +
                            "\n|Welcome to Will's Text Based RPG Map.|" + "\n" +
                              "|Press any key to begin:              | ");
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
            //DisplayMap();
            DisplayMap(2);

        }
        static void DisplayMap(int scale)
        {
            int width = map.GetLength(1);
            int height = map.GetLength(0);
            width = width * scale;
            height = height * scale;
            Console.WriteLine(width);
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

           for(int i = 0; i < height; i++)
           {
                for(int j = 0; j < scale; j++)
                {
                    for (int k = 0;k <width; k++)
                    {
                        for (int l = 0; l < scale; l++)
                        {
                            
                            Console.Write(map[i,k]);
                        }
                    }
                }
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
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            int width = map.GetLength(1);
            int height = map.GetLength(0);
            Console.WriteLine(width);
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
                    Console.Write("|");
                }
                Console.Write(MapCell);

                if (current >= width - 1)
                {
                    Console.WriteLine("|");
                    current = 0;
                }
                else
                {
                    current++;
                }
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
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
