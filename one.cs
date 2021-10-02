using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp5
{
    class Program
    {
        enum Menu
        {
            PlayGame = 1,
            Exit
        }

        static void Main(string[] args)
        {

            
            PrintMenuScreen();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }
        static void PrintHeader()
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------------------");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
        }
        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");

            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.PlayGame)
            {
                PlayGameHangman();
            }
            else if (menu == Menu.Exit)
            {
                Console.ReadLine();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }
        static void PlayGameHangman()
        {
            Console.Clear();
            PrintHeader2();
            Hanggame();
            start();
        }
        static void PrintHeader2()
        {
            Console.WriteLine("Play Game Hangman");
            Console.WriteLine("----------------------------------------------------");
        }
        static void Hanggame()
        {
            int wrong = 0;
            Console.WriteLine("Incorrect Score:" + wrong);
            
        }
        static void start()
        {

            
            Random random = new Random((int)DateTime.Now.Ticks);
            string[] word = { "tennis", "football", "badminton" };
            string wordGuess = word[random.Next(0, word.Length)];
            string wordUppercase = wordGuess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(wordGuess.Length);
            for (int i = 0; i < wordGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correct = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 6;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;
            while (!won && lives > 0)
            {
                Console.Write("Input letter alphabet:");
                
               
                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correct.Contains(guess))
                {
                    Console.WriteLine("correct!");
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("wrong!");
                    continue;
                }

                if (wordUppercase.Contains(guess))
                {
                    correct.Add(guess);

                    for (int i = 0; i < wordGuess.Length; i++)
                    {
                        if (wordUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordGuess.Length)
                        won = true;
                   
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    lives--;
                    Console.WriteLine("Incorrect Score:" + (6-lives));
                    
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine("You won!");
            else
                Console.WriteLine("You lost! It was '{0}'", wordGuess);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }

    }


        