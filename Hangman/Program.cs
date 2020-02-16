using System;

namespace Hangman
{
    class Program
    {
        // Test comment from Keith

        static void Main(string[] args)
        {
            int numberIncorrect = 0;
            int numberCorrect = 0;

            string wordToGuess = ChooseWord();

            char userGuess = '\0';

            string userGuessed = "";

            string userGuessString;

            string[] currentWordStatus = new string[wordToGuess.Length];

            currentWordStatus = UpdateWordStatus(userGuessed, wordToGuess);

            while (userGuess != '~')
            {
                //Draw current view
                Console.WriteLine(HangmanProgress(numberIncorrect));
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    Console.WriteLine(currentWordStatus[i]);

                    if (i != wordToGuess.Length - 1)
                    {
                        Console.SetCursorPosition(i * 2 + 2, Console.CursorTop - 1);
                    }

                }
                Console.WriteLine("Letters Guessed: " + userGuessed);
                Console.WriteLine(wordToGuess);
                Console.WriteLine("Guess a letter or enter ~ to give up");

                //Take user input and format appropriately
                userGuessString = Console.ReadLine();

                userGuessString = userGuessString.ToUpper();

                userGuessed += userGuessString[0];

                userGuess = userGuessString[0];

                //check guess, update variables, and check victory conditions.
                if (wordToGuess.Contains(userGuess))
                {
                    currentWordStatus = UpdateWordStatus(userGuessed, wordToGuess);
                    numberCorrect++;
                }
                else
                {
                    numberIncorrect++;
                    if (numberIncorrect == 6)
                    {
                        Console.WriteLine("GAME OVER\r\nYOU ARE DEAD\r\n WOULD YOU LIKE TO PLAY AGAIN (Y/N)?");
                        userGuessString = Console.ReadLine();
                        userGuessString = userGuessString.ToUpper();
                        userGuess = userGuessString[0];

                        if (userGuess != 'Y' || userGuess != 'N')
                        {
                            while (userGuess != 'Y' || userGuess != 'N')
                            {
                                Console.WriteLine("PLEASE ENTER 'Y' OR 'N'");
                                userGuessString = Console.ReadLine();
                                userGuessString = userGuessString.ToUpper();
                                userGuess = userGuessString[0];
                                Console.WriteLine("User input: " + userGuess);
                            }
                        }
                        if (userGuess == 'Y')
                        {
                            numberIncorrect = 0;
                            numberCorrect = 0;

                            wordToGuess = ChooseWord();

                            userGuess = '\0';

                            userGuessed = "";

                            userGuessString = "";

                            currentWordStatus = UpdateWordStatus(userGuessed, wordToGuess);
                        }
                        if (userGuess == 'N')
                        {
                            Console.WriteLine("Bye-Bye Now!");
                            userGuess = '~';
                        }
                    }
                }

                Console.Clear();
                Console.SetCursorPosition(0,0);
            }
        }

        public static string ChooseWord() 
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);

            string[] hangmanWords;
            hangmanWords = new string[10] { "AWKWARD", "DWARVES", "CRYPT", "HAPHAZARD", "BAGPIPES", "NUMBSKULL", "FJORD", "GAZEBO", "PIXEL", "BYTE" };

            string selectedWord = hangmanWords[randomNumber];

            return selectedWord;
        }

        public static string HangmanProgress(int num01) 
        {
            string[] hProgress;

            hProgress = new string[6] {"", "-----\r\n|   \r\n|   \r\n|   \r\n|   \r\n|  \r\n|\r\n|\r\n------", "-----\r\n|   |\r\n|   O\r\n|  \r\n|   \r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   \r\n|  \r\n|\r\n|\r\n------","-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|\r\n------"};

            return hProgress[num01];
        }

        public static string[] UpdateWordStatus(string userGuesses, string hangmanWord)
        {
            string[] newStatus = new string[hangmanWord.Length];

            if (userGuesses == "")
            {
                for (int i = 0; i < (hangmanWord.Length); i++)
                {
                    newStatus[i] = "_ ";
                }
            }

            else
            {
                for (int i = 0; i < (hangmanWord.Length); i++)
                {
                    if (userGuesses.Contains(hangmanWord[i]))
                    {
                        newStatus[i] = hangmanWord[i] + " ";
                    }

                    else
                    {
                        newStatus[i] = "_ ";
                    }
                }
            }

            return newStatus;

            //for (int i = 0; i < hangmanWord.Length; i++)
            //{
            //    for (int j = 0; j < userGuesses.Length; j++)
            //    {
            //        if (hangmanWord.Contains(userGuesses[j]))
            //        {
            //            newStatus += userGuesses[j] + " ";

            //            Console.WriteLine(newStatus);
            //        }

            //        else
            //        {
            //            newStatus += "_ ";

            //            Console.WriteLine(newStatus);
            //        }
            //    }
            //}
        }


    }
}
