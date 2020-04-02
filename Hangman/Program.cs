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

        static ConsoleKeyInfo userGuess;

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

            /*userGuess.Key = '\0'*/;

            userGuessed = "";

            userGuessString = string.Empty;

            currentWordStatus = new string[wordToGuess.Length];

            currentWordStatus = UpdateWordStatus();

            gameLoopShouldContinue = true;

            gameIsLost = false;

            gameIsWon = false;
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
            checkLoopShouldContinue = true;

            while (checkLoopShouldContinue)
            {
                // TODO: Prompt for inout

                RetrieveCharacter();

                CheckInputs();
            }
        }

        private static void RetrieveCharacter()
        {
            userGuess = Console.ReadKey();
            //userGuess = Char.ToUpper(Console.ReadKey().KeyChar);
        }

        /// <summary>
        /// Verify if input is valid and set flag to end input if so
        /// </summary>
        /// 

        // THE BOOLEAN HERE IS WHERE I AM HAVING TROUBLE with:  && (userGuess.Modifiers & ConsoleModifiers.Alt) != 0
        public static void CheckInputs()
        {
            if (userGuess.KeyChar == 'Q' && (userGuess.Modifiers & ConsoleModifiers.Alt) != 0)
            {
                checkLoopShouldContinue = false;
                gameLoopShouldContinue = false;
            }
            else if (userGuess.KeyChar == 'G' && (userGuess.Modifiers & ConsoleModifiers.Alt) != 0)
            {
                userGuessed = "";
                checkLoopShouldContinue = false;
                gameLoopShouldContinue = false;
                guessWord();
            }
            else if (char.IsLetter(userGuess.KeyChar))
            {
                if (userGuessed.Contains(char.ToUpper(userGuess.KeyChar)))
                {
                    Console.WriteLine("\r\nYou have already guessed " + char.ToUpper(userGuess.KeyChar) + "\r\nPlease enter another guess");
                }
                else
                {
                    checkLoopShouldContinue = false;
                    userGuessed += $"{char.ToUpper(userGuess.KeyChar)}";
                }
            }
            else
            {
                Console.WriteLine("\r\nPlease Enter a Letter");
            }
        }

        private static void guessWord()
        {
            string playerGuess;

            Console.WriteLine("\r\nMake your guess, if you are wrong you will lose.");
            playerGuess = Console.ReadLine().ToUpper();
            if (playerGuess == wordToGuess)
            {
                gameIsWon = true;
            }
            else
            {
                //gameIsLost = true;
                numberIncorrect = 4;
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Update the game state, determine victory and loss conditions
        /// </summary>
        private static void Update()
        {
            if (wordToGuess.Contains(char.ToUpper(userGuess.KeyChar)) == true)
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
                    gameIsWon = true;
                }
            }
            else
            {
                numberIncorrect++;

                if (numberIncorrect == 5)
                {
                    gameIsLost = true;
                }
            }

            Console.Clear();

            Console.SetCursorPosition(0, 0);
        }

        public static string HangmanProgress(int num01)
        {
            string[] hProgress;
            
            hProgress = new string[6] {"", "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n|______\r\n|      |","\r\n\r\n\r\n\r\n\r\n\r\n|\r\n|\r\n|______\r\n|      |",
            "\r\n\r\n\r\n\r\n|\r\n|\r\n|\r\n|\r\n|______\r\n|      |","\r\n-----\r\n|   |\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|______\r\n|      |",
            "\r\n-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|______\r\n|      |"};

            //hProgress = new string[6] {"", "-----\r\n|   \r\n|   \r\n|   \r\n|   \r\n|  \r\n|\r\n|\r\n------", "-----\r\n|   |\r\n|   O\r\n|  \r\n|   \r\n|  \r\n|\r\n|\r\n------",
            //"-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   \r\n|  \r\n|\r\n|\r\n------","-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  \r\n|\r\n|\r\n------",
            //"-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|\r\n------"};

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
                DrawGame();
                DrawVictoryScreen();
            }
            else if (gameIsLost)
            {
                DrawGame();
                DrawLosingScreen();
            }
            else
            {
                DrawGame();
            }
        }

        private static void DrawLosingScreen()
        {
            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("\r\nGAME OVER\r\nYOU ARE DEAD");
            PlayAgain();
        }

           private static void DrawVictoryScreen()
        {
            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine("\r\nCONGRADULATION, YOU WIN!!");
            PlayAgain();
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

            Console.WriteLine("Press any letter to guess, Shift+G to guess the word, and Shift+Q to quit the game.");
        }

        #endregion

        #region Session

        public static void PlayAgain()
        {
            userGuessed = "";

            Console.WriteLine("WOULD YOU LIKE TO PLAY AGAIN (Y/N)?");

            GetInput();

            // TODO: Convert to if else chain?

            if (char.ToLower(userGuess.KeyChar) != 'y' && char.ToLower(userGuess.KeyChar) != 'n')
            {
                while (char.ToLower(userGuess.KeyChar) != 'y' && char.ToLower(userGuess.KeyChar) != 'n')
                {
                    Console.WriteLine("\r\nPLEASE ENTER 'Y' OR 'N'");

                    GetInput();

                    Console.WriteLine("\r\nUser input: " + userGuess);
                }
            }

            if (char.ToLower(userGuess.KeyChar) == 'y')
            {
                InitializeGameState();

                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Draw();
            }

            if (char.ToLower(userGuess.KeyChar) == 'n')
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
