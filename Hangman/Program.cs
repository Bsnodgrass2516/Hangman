using System;

namespace Hangman
{
    class Program
    {
        #region Golbal Variables

        // 'Global variables avaialbe anywhere in the game code.
        // This is how you pass values from one part of the program to another.
        // By creating a variable here and assigning it a value, that value will
        // be availale in any part of the game code.

        // GLOBAL VARIABLES
        static int numberIncorrect;

        static int numberCorrect;

        static string wordToGuess;

        static char userGuess;

        static string userGuessed;

        static string userGuessString;

        static string[] currentWordStatus;

        static bool gameLoopShouldContinue = true;

        static bool checkLoopShouldContinue = true;

        static bool gameIsWon = false;

        static bool gameIsLost = false;

        #endregion

        static void Main(string[] args)
        {
            InitializeGameState();

            Draw();

            // Primary game loop
            while (gameLoopShouldContinue)  // See how this reads like english?  Makes understanding the code easier
            {
                // Collect Inputs
                // No need to render the game state first, as it will still be on the screen from the previous time through the loop.
                // If this is the first time through the loop, the Draw() call above outside the loop will render the initial game state.
                GetInput();

                // Update the game state
                Update();

                // Render the game
                Draw();
            }
        }

        #region Initialization

        private static void InitializeGameState()
        {
            // In here you should set the initial values of any global variables to get the game ready to play.
            // Make sure to think about things that might need to be 'reset' from a previous game, but also things
            // that need to be set if this is the first game

            // I copied the initializations from your old code to here

            numberIncorrect = 0;

            numberCorrect = 0;

            wordToGuess = ChooseWord();

            userGuess = '\0';

            userGuessed = "";

            userGuessString = string.Empty;

            currentWordStatus = new string[wordToGuess.Length];

            currentWordStatus = UpdateWordStatus();

            gameLoopShouldContinue = true;
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

        #endregion

        #region Get Input

        // Read the next input from the user, store it in a global variable
        private static void GetInput()
        {
            while (checkLoopShouldContinue)
            {
                // TODO: Prompt for inout

                RetrieveCharacter();

                CheckInputs();
            }
        }

        private static void RetrieveCharacter()
        {
            userGuess = Char.ToUpper(Console.ReadKey().KeyChar);
        }

        /// <summary>
        /// Verify if input is valid and set flag to end input if so
        /// </summary>
        public static void CheckInputs()
        {
            if (userGuess == '~')
            {
                checkLoopShouldContinue = false;
                gameLoopShouldContinue = false;
            }
            else if (char.IsLetter(userGuess))
            {
                if (userGuessed.Contains(userGuess))
                {
                    Console.WriteLine("\r\nYou have already guessed " + userGuess + "\r\nPlease enter another guess");
                }
                else
                {
                    checkLoopShouldContinue = false;
                    userGuessed += $"{userGuess}";
                }
            }
            else
            {
                Console.WriteLine("\r\nPlease Enter a Letter");
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Update the game state, determine victory and loss conditions
        /// </summary>
        private static void Update()
        {
            if (wordToGuess.Contains(userGuess) == true)
            {
                currentWordStatus = UpdateWordStatus();

                numberCorrect = 0;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (currentWordStatus[i] != "_ ")
                    {
                        numberCorrect++;
                        Console.WriteLine(numberCorrect);
                    }
                }

                if (numberCorrect == wordToGuess.Length)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("CONGRADULATION, YOU WIN!!");
                    PlayAgain();
                }
            }
            else
            {
                numberIncorrect++;

                if (numberIncorrect == 5)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER\r\nYOU ARE DEAD");
                    PlayAgain();
                }
            }

            Console.Clear();

            Console.SetCursorPosition(0, 0);
        }

        public static string HangmanProgress(int num01)
        {
            string[] hProgress;

            hProgress = new string[6] {"", "-----\r\n|   \r\n|   \r\n|   \r\n|   \r\n|  \r\n|\r\n|\r\n------", "-----\r\n|   |\r\n|   O\r\n|  \r\n|   \r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   \r\n|  \r\n|\r\n|\r\n------","-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|\r\n------"};

            return hProgress[num01];
        }

        public static string[] UpdateWordStatus()
        {
            string[] newStatus = new string[wordToGuess.Length];

            if (userGuessed == "")
            {
                for (int i = 0; i < (wordToGuess.Length); i++)
                {
                    newStatus[i] = "_ ";
                }
            }
            else
            {
                for (int i = 0; i < (wordToGuess.Length); i++)
                {
                    if (userGuessed.Contains(wordToGuess[i]))
                    {
                        newStatus[i] = wordToGuess[i] + " ";
                    }

                    else
                    {
                        newStatus[i] = "_ ";
                    }
                }
            }

            return newStatus;
        }

        #endregion

        #region Draw

        // Render the game state
        private static void Draw()
        {
            if (gameIsWon)
            {
                DrawVictoryScreen();
            }
            else if (gameIsLost)
            {
                DrawLosingScreen();
            }
            else
            {
                DrawGame();
            }
        }

        private static void DrawLosingScreen()
        {
            throw new NotImplementedException();
        }

        private static void RenderLossScreen()
        {
            throw new NotImplementedException();
        }

        private static void DrawVictoryScreen()
        {
            throw new NotImplementedException();
        }

        private static void DrawGame()
        {
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
        }

        #endregion

        #region Session

        public static void PlayAgain()
        {
            Console.WriteLine("WOULD YOU LIKE TO PLAY AGAIN (Y/N)?");

            GetInput();

            // TODO: Convert to if else chain?

            if (userGuess != 'Y' && userGuess != 'N')
            {
                while (userGuess != 'Y' && userGuess != 'N')
                {
                    Console.WriteLine("PLEASE ENTER 'Y' OR 'N'");

                    GetInput();

                    Console.WriteLine("User input: " + userGuess);
                }
            }

            if (userGuess == 'Y')
            {
                InitializeGameState();
            }

            if (userGuess == 'N')
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Console.WriteLine("Bye-Bye Now!");

                gameLoopShouldContinue = false;
            }
        }

        #endregion
    }
}
