using System;
using System.Security.Cryptography.X509Certificates;

namespace webapi
{
    public struct Location
    {
        /*        public enum Orientation
                {
                    N = 'N',
                    S = 'S',
                    E = 'E',
                    W = 'W'
                }*/

        public enum Orientation
        {
            N =  0,
            E =  90,
            S =  180,
            W =  270,
        }

        /*public Orientation Direction { get; set; }*/ // makes public as export object with get set
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public string Heading { get; set; } // this(x,y) makes a public var
        public Orientation direction { get; internal set; }

        public double HeadingDegrees { get; set; }

        public Location(Orientation direction, int x, int y)
        {
          /*  this.Direction = direction; // we still want are using an enum cause we have a struct backing it (can do trig on this) with 4 coord math
        */    
            this.Heading = direction.ToString(); // this converts our enum to string without the headache
            this.X = x;
            this.Y = y;
        }


        /*        public void Rotate(double angle)
                {
                    // Rotate the coordinates of the spaceship.
                    (int x, int y) rotatedCoordinates = RotateCoordinates(X, Y, angle);

                    // Update the spaceship's coordinates.
                    X = rotatedCoordinates.x;
                    Y = rotatedCoordinates.y;

                    // Update the spaceship's heading.
                    HeadingDegrees = (HeadingDegrees + angle) % 360;
                    this.Heading = ConvertAngleToCardinalDirection(HeadingDegrees);
                }*/

        /*        public static (int x, int y) RotateCoordinates(int x, int y, double theta)
                {
                    // Convert the angle to radians.
                    double radians = theta * Math.PI / 180;

                    // Calculate the new coordinates.
                    int newX = (int)(x * Math.Cos(radians) - y * Math.Sin(radians));
                    int newY = (int)(x * Math.Sin(radians) + y * Math.Cos(radians));

                    // Return the new coordinates.
                    return (newX, newY);
                }

                public static string ConvertAngleToCardinalDirection(double angle)
                {
                    // Normalize the angle to the range 0 to 360 degrees.
                    angle %= 360;

                    // Divide the angle into eight sectors, each corresponding to a cardinal direction.
                    string[] cardinalDirections = { "N", "E", "S", "W", };
                    int sector = (int)(angle / 90);

                    // Return the cardinal direction corresponding to the sector.
                    return cardinalDirections[sector];
                }*/
    }
}


/*
 
Location location1 = new Location(Location.Orientation.N, 0, 0);
Location location2 = new Location(Location.Orientation.E, 2, 3);

Console.WriteLine($"Location 1: Direction = {location1.Direction}, X = {location1.X}, Y = {location1.Y}");
Console.WriteLine($"Location 2: Direction = {location2.Direction}, X = {location2.X}, Y = {location2.Y}");

*/
// https://chat.openai.com/c/ebe091f1-0d8c-4e6c-9d75-1dfae0fde122
// https://www.bing.com/search?toWww=1&redig=50DB4F31CE564A06B5D8A38A9BD9B822&q=Bing+AI&showconv=1
// https://chat.openai.com/c/a20295e6-8cc9-4184-979a-718e5a80c104
// https://bard.google.com/chat/c02b24545b6c2318?utm_source=sem&utm_medium=paid-media&utm_campaign=q3enUS_sem7