using System;

namespace CaesarCipher
{
  class Program
  {
    static char[] Decrypt(char[] encryptedMessage, int key = 3)
    {
      char[] fixedMessage = new char[encryptedMessage.Length];
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      for (int i = 0; i < encryptedMessage.Length; i++)
      {
        char c = encryptedMessage[i];
        if (Char.IsLetter(c))
        {
          int subKey = key;
          int charPos = Array.IndexOf(alphabet, c);
          while (charPos-subKey < 0)
          {
              subKey-=alphabet.Length;
          }
          int encPos = charPos - subKey;
          char encChar = alphabet[encPos];
          fixedMessage[i] = encChar;
        }
      }
      return fixedMessage;
    }
    
    static char[] Encrypt(char[] secretMessage, int key = 3)
    {
      char[] encryptedMessage = new char[secretMessage.Length];
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      for (int i = 0; i < secretMessage.Length; i++)
      {
        char c = secretMessage[i];
        if (Char.IsLetter(c))
        {
          int charPos = Array.IndexOf(alphabet, c);
          int encPos = (charPos + key)% alphabet.Length;
          char encChar = alphabet[encPos];
          encryptedMessage[i] = encChar;
        }

      }
      return encryptedMessage;
    }
    static void Main(string[] args)
    {
      
      
      Console.WriteLine("What is the message?");
      string secret = Console.ReadLine();
      secret = secret.ToLower();
      char[] secretMessage = secret.ToCharArray();
      Console.WriteLine("Enter encryption key:");
      int key = Convert.ToInt32(Console.ReadLine());
      char[] encryptedMessage = Encrypt(secretMessage, key);
      
      string encryptedText= String.Join("",encryptedMessage);
      Console.WriteLine(encryptedText);

      char[] encryptedArray = encryptedText.ToCharArray();
      char[] fixedArray = Decrypt(encryptedArray, key);
      string fixedMessage= String.Join("", fixedArray);
      Console.WriteLine(fixedMessage);


    }
  }
}