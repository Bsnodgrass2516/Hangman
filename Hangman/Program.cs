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

            string wordToGuess = chooseWord();

            string currentWordStatus = "";

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                currentWordStatus += "_ ";
            }

            Console.WriteLine(hangmanProgress(numberIncorrect));
            Console.WriteLine(currentWordStatus);
            Console.WriteLine(wordToGuess);

            //while (numberCorrect != wordToGuess.Length ^ numberIncorrect != 6)
            //{
            //    Console.WriteLine(hangmanProgress[numberIncorrect]);
            //    Console.WriteLine(currentWordStatus);
            //    Console.WriteLine("Guess a letter");

            //    Console.ReadLine();
            //}
            //Console.WriteLine(hangmanProgress[0] + "\r\n" + hangmanProgress[1] + "\r\n" + hangmanProgress[2] + "\r\n" + hangmanProgress[3] + "\r\n" + hangmanProgress[4] + "\r\n" + hangmanProgress[5]);
        }

        public static string chooseWord() 
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);

            string[] hangmanWords;
            hangmanWords = new string[10] { "AWKWARD", "DWARVES", "CRYPT", "HAPHAZARD", "BAGPIPES", "NUMBSKULL", "FJORD", "GAZEBO", "PIXEL", "BYTE" };

            string selectedWord = hangmanWords[randomNumber];

            return selectedWord;
        }

        public static string hangmanProgress(int num01) 
        {
            string[] hProgress;

            hProgress = new string[6] {"", "-----\r\n|   \r\n|   \r\n|   \r\n|   \r\n|  \r\n|\r\n|\r\n------", "-----\r\n|   |\r\n|   O\r\n|  \r\n|   \r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   \r\n|  \r\n|\r\n|\r\n------","-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|\r\n------"};

            return hProgress[num01];
        }

    }
}
