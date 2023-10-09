namespace webapi;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using System;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Any;
using System.Diagnostics.Metrics;
using GraphQL;

/*using static IRoverInterface;
using static Map;
using Microsoft.AspNetCore.Components.Routing;*/
interface IRoverInterface
{
// was going to have an interface but there was actual space stuff learned here i had to simplifiy for a demo
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

    public Rover(Map map)
    {
        this.map = map;
    }

    public void Move(String input)
    {
        Heading xyz = SetOrientation(input);
    }

}