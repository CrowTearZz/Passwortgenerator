namespace Passwordgenerator
{
   using System;
   using System.Collections.Generic;

   internal class Generator
   {
      public string pwNumbers = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789^!\"§$%&/()=?{[]}\\`´+*~#',.-_<>|°äöüÄÖÜß"; //Hier werden Buchstaben und Ascii Codes eingetragen
	
      private readonly Random random = new Random(); 
 
      public string passwort(int passwortLength)
      {
         string finalPassword = string.Empty;
         var passwordList = new List<string>();
         for (int i = 0; i < passwortLength; i++)
         {
            passwordList.Add(pwNumbers[random.Next(pwNumbers.Length)].ToString());
         }
 
         foreach (string PasswordItem in passwordList)
         {
            finalPassword = finalPassword + PasswordItem;
         }
 
         return finalPassword; 
      }
   } 
 
   internal class Program
   {
      private static void Main(string[] args)
      {
         bool state = false;
         int result;
         var generator = new Generator();
 
         while (!state)
         {
            Console.WriteLine("Wie lang soll das Passwort sein? (Maximal 35)");  //Nun müssen wir erstmal die Länge des Passworts angeben
            if (int.TryParse(Console.ReadLine(), out result))
            {
               string generatedPassword = generator.passwort(result);
               Console.WriteLine("═════════════════════════════════════");
                Console.WriteLine(generatedPassword); 
               Console.WriteLine("═════════════════════════════════════");//Gibt das Passwort auf dem Bildschirm aus
            }
            else
            {
               Console.WriteLine("Bitte nur ganze Zahl eingeben! Maximal 9999, da sonst das generieren des Passworts nicht mehr funktioniert!") ;  //Wenn wir keine Zahl eingeben sondern einen Buchstaben oder ein Sonderzeichen, dann erscheint diese Fehlermeldung
               state = false;
            }
         }
      }
 
   }
}