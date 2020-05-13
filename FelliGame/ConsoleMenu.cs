﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// Class to use as a menu for the Console application.
    /// </summary>
    public class ConsoleMenu
    {
        // The Dictionary is used to swap between menus.
        Dictionary<string, string> menus = new Dictionary<string, string>();

        // The List is used to save the current menu the user is in so we can
        // go back between the menus.
        List<string> historic = new List<string>();

        // Variable to check the current menu we're at.
        string currentMenu;

        // Create a new game.
        ConsoleGame game = new ConsoleGame();

        // Automatically run the Menu for Console.
        public ConsoleMenu()
        {
            RenderConsoleMenu();
        }

        private void RenderConsoleMenu()
        {
            menus.Add("menu1", "1 - Start Game\n2 - Instructions\nb - Exit");
            menus.Add("menu2", "*** How does the game work? ***\n" +
                "\nFelliGame is a PvP tabletop game." +
                "\nWhere each player have 6 pieces." +
                "\n6 white pieces are placed on one side of the map, where " +
                "6 black pieces are placed on the opposite side of the map." +
                "\nThe players play in turns." +
                "\nThe players can move the pieces (always following the " +
                "path line) in any direction where exists a free adjacent spot." +
                "\nYou can take out enemy pieces by jumping above them, and " +
                "you'll land on the free spot adjacent to the previous enemy" +
                " spot. (Just like in Checkers.)" +
                "\n\n*** Win conditions ***\n" +
                "\nThe player who takes all the opponent pieces first wins!" +
                "\nIf the current player blocks all the opponent's pieces," +
                " the current player wins!" +
                "\nb - Back");

            currentMenu = "menu1";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("FelliGame");
                Console.ResetColor();

                Console.WriteLine(menus[currentMenu]);
                switch (Console.ReadLine())
                {
                    // This option will start the game.
                    case "1":
                        Console.WriteLine("\n*** Game is starting! ***\n");
                        game.Play();
                        Console.WriteLine("\n*** Game is over! ***\n");
                        break;

                    // Open the instructions menu.
                    case "2":
                        if (currentMenu == "menu1")
                        {
                            historic.Add(currentMenu);
                            currentMenu = "menu2";
                        }
                        break;

                    // Exit the game, if we're at the top level of our menu.
                    case "b":
                        if (currentMenu == "menu1")
                        {
                            System.Environment.Exit(1);
                        }
                        currentMenu = historic[historic.Count - 1];
                        historic.RemoveAt(historic.Count - 1);
                        break;

                    // Always ask for a valid option while in the menu.
                    default:
                        Console.WriteLine("Insert a valid input!");
                        break;
                }
            }
        }
    }
}
