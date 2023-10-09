namespace webapi;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using System;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Any;
using static webapi.Location;
using System.Diagnostics.Metrics;
using GraphQL;

/*using static IRoverInterface;
using static Map;
using Microsoft.AspNetCore.Components.Routing;*/
interface IRoverInterface
{
/*    public Location location;
/*    public Location location;
    public Map map;*/
}

class Rover : IRoverInterface
{
/*    public Location location { get; set; }*/
    public Map map { get; set; }
    public string instructions { get; set; }

/*    Heading heading { get; set; } = Heading.N;*/
/*    Heading heading { get; set; } = Heading.N;*/

    public enum Heading
    {
        N = 0,
        E = 90,
        S = 180,
        W = 270
    }

    public int x { get; set; } = 0;
    public int y { get; set; } = 0;

    public Heading heading { get; set; }
    public string direction { get; set; }

    public Heading SetOrientation(string commands)
    {
        instructions = commands;

        foreach (char command in commands)
        {
            switch (command)
            {
                case 'L':
                    heading = (Heading)(((int)heading - 90 + 360) % 360);
                    break;

                case 'R':
                    heading = (Heading)(((int)heading + 90) % 360);
                    break;

                case 'M':
                    MoveRover(heading, 1);
                    break;

                default:
                    /*throw new ArgumentException("Invalid command: " + command);*/
                    break;
            }
        }
        this.direction = this.heading.ToString();
        return (Heading)heading;
    }


    public void MoveRover(Heading currentOrientation, int distance = 1)
    {

        // todo: check map bounds

        switch (currentOrientation)
        {
            case Heading.N:
                this.y += distance;
                break;
            case Heading.E:
                this.x += distance;
                break;
            case Heading.S:
                this.y -= distance;
                break;
            case Heading.W:
                this.x -= distance;
                break;
        }
    }




    /*    public void Instructions(string Input)
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

    *//*        foreach (char c in Input)
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
            }*//*
        }*/

    public void output(string inst)
    {

    }

    /*    public Rover(Location location)
        {

            this.location = location;

            *//*position.Split(" ").t*//*

            // real world we would have to do alot of tests of location 

        }*/

    public Rover(Map map)
    {
        this.map = map;

        /*        this.location = location;*/

        /*position.Split(" ").t*/

        // real world we would have to do alot of tests of location 

    }

public Orientation RotateOrientation(Orientation orientation, int angle)
    {
        // Normalize the angle to the range -90 to 90 degrees.
        angle %= 90;

        int orientationAsInt = (int)orientation;

        // Add the angle to the current orientation.
        /*orientation = (Orientation)((int)orientation + angle) % 4;*/

        Orientation newOrientation = (Orientation)((orientationAsInt + angle) % 4);
        // Return the new orientation.
        return newOrientation;
    }

    public string Move(String input)
    {
        char[] characters = input.ToCharArray();
        string Result = "";

        /*        Location xyz = SetOrientation(this.location, characters);
        */

        Heading xyz = SetOrientation(input);
 /*       foreach (char c in characters)
        {
            switch (c)
            {
                case 'L':
                    Result= "my name. ";
                    break;
                case 'R':
                  
                    break;
                case 'M':
           
                    break;
                default:
                    // Ignore invalid instructions.
                    break;
            }


        }*/
        return Result;

    }

/*    public Location SetOrientation(Location location, char[] commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'L':
                    //orientation = (Orientation)((int)(orientation - 1) % 4);
                    RotateOrientation(this.location.direction, -90);
                    break;
                case 'R':
                    //orientation = (Orientation)((int)(orientation + 1) % 4);
                    RotateOrientation(this.location.direction, 90);
                    break;
                default:
                    break;
                    *//*throw new ArgumentException($"Invalid command: {command}");*//*
            }
        }

        return location;
    }*/

    /*    public static Orientation SetOrientation(Orientation orientation, char command)
        {
            switch (command)
            {
                case 'L':
                    orientation = (orientation - 1) % 4;
                    break;
                case 'R':
                    orientation = (orientation + 1) % 4;
                    break;
                default:
                    throw new ArgumentException($"Invalid command: {command}");
            }

            return orientation;
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