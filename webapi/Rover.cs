namespace webapi;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using System;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Any;

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
    public Location location { get; set; }
    public Map map { get; set; }
    public string instructions { get; set; } 
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

    public Rover(Location location)
    {

        this.location = location;
        /*position.Split(" ").t*/

        // real world we would have to do alot of tests of location 
  
    }

    public string Move(String input)
    {
        char[] characters = input.ToCharArray();
        string Result = "";


        foreach (char c in characters)
        {
            switch (c)
            {
                case 'L':
                    Result = "my name";
                    break;
                case 'R':
                  
                    break;
                case 'M':
           
                    break;
                default:
                    // Ignore invalid instructions.
                    break;
            }


        }
        return input;

    }

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