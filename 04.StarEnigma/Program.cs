using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                int decryptionKey = CountLetters(encryptedMessage);

                string decryptedMessage = DecryptMessage(encryptedMessage, decryptionKey);

                Match match = Regex.Match(decryptedMessage, @"@(?<planet>[A-Za-z]+)[^@!:>-]*:(?<population>\d+)[^@!:>-]*!(?<type>[AD])![^@!:>-]*->(?<soldiers>\d+)");

                if (match.Success)
                {
                    string planetName = match.Groups["planet"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    char type = match.Groups["type"].Value[0];
                    int soldiers = int.Parse(match.Groups["soldiers"].Value);

                    if (type == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (type == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (string planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static int CountLetters(string message)
        {
            int count = 0;

            foreach (char c in message.ToLower())
            {
                if (c == 's' || c == 't' || c == 'a' || c == 'r')
                {
                    count++;
                }
            }

            return count;
        }

        static string DecryptMessage(string message, int key)
        {
            string decrypted = "";

            foreach (char c in message)
            {
                decrypted += (char)(c - key);
            }

            return decrypted;
        }
    }
}