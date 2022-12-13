using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestGenerateTilesForLongLat
{
    internal class Program
    {

        static async Task Main(string[] args)
        {



            Program program = new Program();

            int zoomLevel = 14;
            int tileX;
            int tileY;

            //35.9132° N, 79.0558° W    Chapel Hill, NC

            // TEMP CODE
            tileX = 4592;
            tileY = 6436;
            // END TEMP CODE


            await program.Execute(zoomLevel, tileX, tileY);

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

        }

        private async Task Execute(int zoomLevel, int tileX, int tileY)
        {

            Console.WriteLine("Long = {0}, Lat = {1}", tilex2long(tileX, zoomLevel), tiley2lat(tileY, zoomLevel));

        }

        private static string PadZeroLeft(int inValue, int stringLength)
        {

            string returnValue = new string('0', stringLength) + inValue.ToString();

            returnValue = returnValue.Substring(returnValue.Length - stringLength);

            return returnValue;
        }

        int long2tilex(double lon, int z)
        {
            return (int)(Math.Floor((lon + 180.0) / 360.0 * (1 << z)));
        }

        int lat2tiley(double lat, int z)
        {
            return (int)Math.Floor((1 - Math.Log(Math.Tan(ToRadians(lat)) + 1 / Math.Cos(ToRadians(lat))) / Math.PI) / 2 * (1 << z));
        }

        double tilex2long(int x, int z)
        {
            return x / (double)(1 << z) * 360.0 - 180;
        }

        double tiley2lat(int y, int z)
        {
            double n = Math.PI - 2.0 * Math.PI * y / (double)(1 << z);
            return 180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }

        public double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

    }
}


/*
 * double tilex2long(int x, int z)
        {
            return x / (double)(1 << z) * 360.0 - 180;
        }

        double tiley2lat(int y, int z)
        {
            double n = Math.PI - 2.0 * Math.PI * y / (double)(1 << z);
            return 180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }

        public double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
 * */