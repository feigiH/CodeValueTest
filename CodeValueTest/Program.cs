namespace CodeValueTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Encrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", "A");
            string b = Encrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", "Bcd A");
            string c = Encrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", "א");

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            Console.WriteLine(Decrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", a));
            Console.WriteLine(Decrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", b));
            Console.WriteLine(Decrypt("JIECHSDUGFRVAWNQTYBZOLKMPX", c));
        }

        internal static bool IsEnglisgUpper(int ascii)
        { 
            return (ascii >= (int)'A' && ascii <= (int)'Z'); 
        }
        internal static bool IsEnglisgLower(int ascii)
        { 
            return (ascii >= (int)'a' && ascii <= (int)'z'); 
        }

        internal static string Encrypt(string key, string message)
        {
            if (string.IsNullOrEmpty(key) || key.Length < 26 || string.IsNullOrEmpty(message))
            {
                return message;
            }
            char[] encrypted = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char current = message[i];
                int currentAscii = (int)current;
                if (IsEnglisgUpper(currentAscii))
                {
                    encrypted[i] = key[currentAscii - (int)'A'];
                }
                else if (IsEnglisgLower(currentAscii))
                {
                    encrypted[i] =  char.ToLower(key[currentAscii - (int)'a']);
                }
                else
                {
                    encrypted[i] = current;
                }
            }
            return new string(encrypted);
        }

        internal static string Decrypt(string key, string message)
        {
            if (string.IsNullOrEmpty(key) || key.Length < 26 || string.IsNullOrEmpty(message))
            {
                return message;
            }
            char[] encrypted = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char current = message[i];
                int currentAscii = (int)current;

                if (IsEnglisgUpper(currentAscii))
                {
                    encrypted[i] = (char)(key.IndexOf(current) +'A');
                }
                else if (IsEnglisgLower(currentAscii))
                {
                    encrypted[i] = (char)(key.IndexOf(char.ToUpper(current)) + 'a');
                }
                else
                {
                    encrypted[i] = current;
                }
            }
            return new string(encrypted);
        }



    }
}
