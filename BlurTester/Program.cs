using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SuperfastBlur.BlurTester
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide an image file name as an argument");
                return;
            }

            var fileName = args[0];
            //var fileName = @"C:\a_sample_blur2\topcon_blur_sample\output\20200704_144120_bMS3D_Image_000013.jpg";
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} does not exist");
                return;
            }

            var image = Image.FromFile(fileName);
            var blur = new GaussianBlur(image as Bitmap);

            var sw = Stopwatch.StartNew();
            var result = blur.Process(30);
            Console.WriteLine($"Finished in: {sw.ElapsedMilliseconds}ms");
            result.Save("blur.jpg", ImageFormat.Jpeg);
            result.Save("blur.png", ImageFormat.Png);
            Console.ReadLine();
        }
    }
}
