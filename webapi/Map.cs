namespace webapi;


// to be honest I am not impressed with graphQL; I can do (and with simpler queries more with SQL)

using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Http.HttpResults;

class Map
{
    //0,0
    int ix = 0; // init
    int iy = 0; // //init 

    /*    //X,Y 
        public int bx = 0; // boundary
        public int by = 0;*/

    public int bx { get; set; }
    public int by { get; set; }

    private static Map instance = null;


    /*    private List<Map> map = new List<Map>();*/
    private Rover[] rovers;


    public static Map Instance
    {
        // create singleton
        get
        {
            // Singleton Pattern 
            if (instance == null)
            {
                instance = new Map(5, 5);
            }

            return Instance;
        }
    }

    public Rover[] Rovers
    {
        get { return rovers; }
        set { rovers = value; }
    }

    public Map(int bx, int by)
    {
        this.bx = bx;
        this.by = by;
    }
}
