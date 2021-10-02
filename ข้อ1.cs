using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp5
{
    class Program
    {
        enum Menu //ตัวเลือกของเมนูว่า1คือเล่น2คือออก
        {
            PlayGame = 1,
            Exit
        }

        static void Main(string[] args)
        {
            PrintMenuScreen(); //เรียกPrintMenuScreen
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }
        static void PrintHeader()//แสดงตัวต้อนรับ
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------------------");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1. Play game"); //กด1เพื่อเริ่มเกม
            Console.WriteLine("2. Exit");//กด2เพื่อออก
        }
        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: "); //ปริ้นเพื่อรับค่าเมนู

            Menu menu = (Menu)(int.Parse(Console.ReadLine())); //รับค่าเมนู

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
        static void ShowMessageInputMenuIsInCorrect() //คนใส่ค่าผิดเลยขึ้นอันนี้ให้ใส่ใหม่
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
            //ตัวสุ่มคำจากที่กำหนด
            
            Random random = new Random((int)DateTime.Now.Ticks);
            string[] word = { "tennis", "football", "badminton" };
            string Word = word[random.Next(0, word.Length)];
            string wordUppercase = Word.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(Word.Length);
            for (int i = 0; i < Word.Length; i++)
                displayToPlayer.Append('_');

            List<char> correct = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 6; //ผิดได้6ครั้ง
            bool won = false; 
            int lettersRevealed = 0;

            string input;
            char guess;
            while (!won && lives > 0)
            {
                Console.Write("Input letter alphabet:"); //รับตัวอักษรเพื่อเล่น
                
               
                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correct.Contains(guess))
                {
                    Console.WriteLine("correct!"); //ถ้าถูกขึ้นcorrect
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("wrong!"); //ถ้าผิดขึ้นwrong
                    continue;
                }

                if (wordUppercase.Contains(guess))
                {
                    correct.Add(guess);

                    for (int i = 0; i < Word.Length; i++) 
                    {
                        if (wordUppercase[i] == guess) 
                        {
                            displayToPlayer[i] = Word[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == Word.Length) 
                        won = true;
                   
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    lives--;
                    Console.WriteLine("Incorrect Score:" + (6-lives)); //บอกว่าผิดไปกี่ครั้งแล้ว
                    
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine("You won!"); //บอกว่าชนะ
            else
                Console.WriteLine("You lost! It was '{0}'", Word);  //บอกว่าแพ้แล้วเฉลยคำ

            Console.Write("Press ENTER to exit...");  //กดEnterเพื่อออก
            Console.ReadLine();
        }
    }

    }


        