using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashandHmacAlgorithms
{
    internal class Menu
    {
        private int index;
        Stopwatch stopwatch = new Stopwatch();
        private string[] options = new string[] {"MD5",
            "HMACMD5",
            "SHA-1",
            "HMACSHA-1",
            "SHA-256",
            "HMACSHA-256",
            "SHA-384",
            "HMACSHA-384",
            "SHA-512",
            "HMACSHA-512",
            "Exit"};
        public Menu()
        {
            index = 0;
        }
        public void MenuInput()
        {
            Console.CursorVisible = false;
            ConsoleKey key;
            index = 0;

            do
            {
                Console.SetCursorPosition(2, 0);
                DisplayMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    index--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    index++;
                }
                if (index < 0)
                {
                    index = options.Length - 1;
                }
                if (index >= options.Length)
                {
                    index = 0;
                }
            }
            while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            ChoiceSwitchCase(index);
        }

        private string GetTextInput()
        {
            Console.WriteLine("Write the text you want to hash: ");
            return Console.ReadLine();
        }

        private void ChoiceSwitchCase(int index)
        {
            Hasher hasher = new Hasher();
            HmacHasher hmacHasher = new HmacHasher();
            byte[] key = hmacHasher.GenerateKey();
            Console.Clear();
            string text = "";
            byte[] hashedText = new byte[] { };
            if (index != 10)
            {
                text = GetTextInput();
            }
            stopwatch.Start();
            switch (index)
            {
                case 0:
                    hashedText = hasher.ComputeMd5(Encoding.UTF8.GetBytes(text));
                    break;
                case 1:
                    hashedText = hmacHasher.ComputeMd5(Encoding.UTF8.GetBytes(text), key);
                    break;
                case 2:
                    hashedText = hasher.ComputeSha1(Encoding.UTF8.GetBytes(text));
                    break;
                case 3:
                    hashedText = hmacHasher.ComputeHmacSha1(Encoding.UTF8.GetBytes(text), key);
                    break;
                case 4:
                    hashedText = hasher.ComputeSha256(Encoding.UTF8.GetBytes(text));
                    break;
                case 5:
                    hashedText = hmacHasher.ComputeHmacsha256(Encoding.UTF8.GetBytes(text), key);
                    break;
                case 6:
                    hashedText = hasher.ComputeSha384(Encoding.UTF8.GetBytes(text));
                    break;
                case 7:
                    hashedText = hmacHasher.ComputeHmacsha384(Encoding.UTF8.GetBytes(text), key);
                    break;
                case 8:
                    hashedText = hasher.ComputeSha512(Encoding.UTF8.GetBytes(text));
                    break;
                case 9:
                    hashedText = hmacHasher.ComputeHmacsha512(Encoding.UTF8.GetBytes(text), key);
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
            }
            stopwatch.Stop();
            DisplayResults(hashedText);
            Console.WriteLine("Do you want to go back to the menu? y/n");
            string backToMenu = Console.ReadLine().ToLower();
            if (backToMenu.Contains("y"))
            {
                Console.Clear();
                MenuInput();
                stopwatch.Reset();
            }
        }
        private void DisplayResults(byte[] result)
        {
            Console.WriteLine($"Hash: {Convert.ToBase64String(result)}");
            Console.WriteLine($"HexaDecimal: {Convert.ToHexString(result)}");
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedTicks}");
        }
        private void DisplayMenu()
        {
            Console.WriteLine("Pick an algorithm:\n");
            for (int i = 0; i < options.Length; i++)
            {
                string prefix;
                string currentOption = options[i];
                if (index == i)
                {
                    prefix = "> ";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = "  ";
                    Console.ResetColor();
                }
                Console.WriteLine(prefix + currentOption);
            }
            Console.ResetColor();
        }
    }
}
