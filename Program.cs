using System;
using System.Drawing;
using System.IO;

namespace Ottimmuth
{
    internal class Program
    {
        static void Main(string[] _)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string rootPath = executablePath.Substring(0, executablePath.IndexOf("bin"));

            string[] localAssets = Directory.GetFiles(rootPath + "assets", "*.png");

            if (localAssets.Length == 0)
            {
                Console.WriteLine("Es wurden keine Bilder gefunden.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Wählen Sie ein Bild aus, das Sie bearbeiten möchten: ");

            for (int i = 0; i < localAssets.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + Path.GetFileName(localAssets[i]));
                if (i == localAssets.Length - 1) Console.WriteLine("\n");
            }

            int selectedOption = int.Parse(Console.ReadLine()) - 1;

            if (selectedOption < 0 || selectedOption >= localAssets.Length)
            {
                Console.WriteLine("Die ausgewählte Option ist ungültig.");
                Console.ReadKey();
                return;
            }

            if (File.Exists(rootPath + "assets/" + Path.GetFileNameWithoutExtension(localAssets[selectedOption]) + "_bearbeitet.png"))
            {
                Console.WriteLine("Das Bild wurde bereits bearbeitet, und befindet sich im assets/bearbeitet-Ordner. (" + Path.GetFileNameWithoutExtension(localAssets[selectedOption]) + "_bearbeitet.png" + ")");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nDas Bild wird bearbeitet...\n");

            Bitmap newImage = new Bitmap(localAssets[selectedOption]);

            if (!File.Exists(localAssets[selectedOption]))
            {
                Console.WriteLine("Das Bild konnte nicht geladen werden.");
                Console.ReadKey();
                return;
            }

            Ottimmuth ottimmuth = new Ottimmuth(newImage);

            ottimmuth.startProcessing();

            newImage.Save(rootPath + "assets/bearbeitet/" + Path.GetFileNameWithoutExtension(localAssets[selectedOption]) + "_bearbeitet.png");
            newImage.Dispose();

            Console.WriteLine("Das Bild wurde erfolgreich bearbeitet, und befindet sich im assets/bearbeitet-Ordner. (" + Path.GetFileNameWithoutExtension(localAssets[selectedOption]) + "_bearbeitet.png" + ")");
            Console.ReadKey();
        }
    }
}