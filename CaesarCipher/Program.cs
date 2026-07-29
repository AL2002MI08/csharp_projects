using System;

namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      Console.Write("Enter secret message: ");
      string msgString = Console.ReadLine();
      if(msgString != null){
        msgString = msgString.ToLower();
      }
      char[] secretMessage = msgString.ToCharArray();
      char[] encryptedMessage = new char[secretMessage.Length];
      for(int i=0; i<secretMessage.Length; i++){
        char currentChar = secretMessage[i];
        int msgPosition = Array.IndexOf(alphabet, currentChar);
        if(msgPosition == -1){
          continue;
        }
        int newPosition = (msgPosition + 3) % alphabet.Length;
        char newEncryptedChar = alphabet[newPosition];
        encryptedMessage[i] = newEncryptedChar;

      }
      Console.WriteLine(String.Join("", encryptedMessage));

      
    }
  }
}