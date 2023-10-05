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
    int ix = 0;
    int iy = 0;

    int bx = 0;
    int by = 0;

    private static Map instance = null;


    private List<Map> map = new List<Map>();
    private Rover[] rovers;

    public static Map Instance
    {
        // create singleton
/*        get
        {

            // Singleton Pattern 
            if (instance == null)
            {
                instance = new Map();
            }

            return Instance;
        }*/
    }

    public Rover[] Rovers
    {
        get { return rovers; }
        set { rovers = value; }
    }

    public Map(int ix, int iy, int bx, int by)
    {
        this.ix = ix;
        this.iy = iy;
        this.bx = bx;
        this.by = by;
     /*   this.map = map;*/

    }
}
