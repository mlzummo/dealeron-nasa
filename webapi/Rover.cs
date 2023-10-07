namespace webapi;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using System;
using static IRoverInterface;
using static Map;
using Microsoft.AspNetCore.Components.Routing;

interface IRoverInterface
{
    /*    enum Orientation
        {
            N = 'N',
            S = 'S',
            E = 'E',
            W = 'W'
        }

        void Instructions(string inst);
        //Orientation Heading { get; set; }
        //Orientation Heading;*/

    public struct Location
    {
        public enum Orientation
        {
            N,
            S,
            E,
            W
        }

        public Orientation Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Location(Orientation direction, int x, int y)
        {
            Direction = direction;
            X = x;
            Y = y;
        }
    }
}

class Rover : IRoverInterface
{
    //position of rover in coordinates of map
    Map Map;
    /*Orientation Heading;*/
    Location location;
    public void Instructions(string Input)
    {
        Console.WriteLine(Input);
        string[] instructions = Input.Split("\n");

        //        foreach (var instruction in instructions)
        //        {
        //            System.Console.WriteLine(instruction);

        //            switch(instruction)
        //            {
        //                default:
        //                    System.Console.WriteLine(instruction);
        //                    this.Instructions("N");
        //                    break;
        //
        //            }
        //        }

/*        foreach (char c in Input)
        {
            switch (c)
            {
                case 'N':
                    Heading = Orientation.N;
                    break;
                case 'S':
                    Heading = Orientation.S;
                    break;
                case 'E':
                    Heading = Orientation.E;
                    break;
                case 'W':
                    Heading = Orientation.W;
                    break;
                default:
                    // Ignore invalid instructions.
                    break;
            }
        }*/
    }

    public void output(string inst)
    {

    }

    public Rover(int x, int y, Orientation heading)
    {
        /*position.Split(" ").t*/

        // real world we would have to do alot of tests of location 

    }

    /*    private int Move(String instr)
        {
            // todo: cosign math would be best here for move left right

            return 0;
        }*/

    // code from others

    /*rivate char GetRotation() // todo: mz
    {
        return (char) this.Heading;
    }*/

    /*    void SetPosition(string instructions)
        {
            for (int i = 0; i < instructions.size(); i++)
            {
                if (instructions[i] == 'M')
                {
                    if (rover_rotation == 'W' || rover_rotation == 'E')
                    {
                        rover_x += (rover_rotation == 'W') ? -1 : 1;
                    }

                    else
                    {
                        rover_y += (rover_rotation == 'S') ? -1 : 1;
                    }
                }

                else
                {
                    SetRotation(instructions[i]);
                }
            }

            rover_position[0] = rover_x;
            rover_position[1] = rover_y;
        }*/

    /*    char SetRotation(char rotation)
        {
            int rotate_rover = (rotation == 'L') ? -1 : 1;

            for (int i = 0; i < sizeof(rover_rotationOptions); i++)
            {
                if (rover_rotation == rover_rotationOptions[i])
                {
                    i += (rotate_rover);
                    //handling whenever turn is negative (N -> W) and greater than array size whenever (W -> N)
                    i = (i < 0) ? (sizeof(rover_rotationOptions) - 1) : i;
                    i = (i == sizeof(rover_rotationOptions)) ? 0 : i;

                    rover_rotation = rover_rotationOptions[i];
                    break;
                }
            }

            return rover_rotation;
        }
    }*/

}