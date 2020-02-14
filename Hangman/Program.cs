using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberIncorrect = 0;
            int numberCorrect = 0;
            
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);

            string[] hangmanWords;
            hangmanWords = new string[10] {"AWKWARD","DWARVES","CRYPT","HAPHAZARD","BAGPIPES","NUMBSKULL","FJORD","GAZEBO","PIXEL","BYTE"};

            string[] hangmanProgress;
            hangmanProgress = new string[6] {"", "-----\r\n|   \r\n|   \r\n|   \r\n|   \r\n|  \r\n|\r\n|\r\n------", "-----\r\n|   |\r\n|   O\r\n|  \r\n|   \r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   \r\n|  \r\n|\r\n|\r\n------","-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  \r\n|\r\n|\r\n------",
            "-----\r\n|   |\r\n|   O\r\n|  \\ /\r\n|   |\r\n|  / \\\r\n|\r\n|\r\n------"};

            string wordToGuess = hangmanWords[randomNumber];

            string currentWordStatus = "";

            Console.WriteLine(hangmanProgress[numberIncorrect]);
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (i == 0)
                {
                    currentWordStatus = "_ ";
                }
                else
                {
                    currentWordStatus = currentWordStatus + " _ ";
                }
            }

            while (numberCorrect != wordToGuess.Length ^ numberIncorrect != 6)
            {
                Console.WriteLine(hangmanProgress[numberIncorrect]);
                Console.WriteLine(currentWordStatus);
                Console.WriteLine("Guess a letter");

                Console.ReadLine();
            }
            //Console.WriteLine(hangmanProgress[0] + "\r\n" + hangmanProgress[1] + "\r\n" + hangmanProgress[2] + "\r\n" + hangmanProgress[3] + "\r\n" + hangmanProgress[4] + "\r\n" + hangmanProgress[5]);
        }
    }
}
