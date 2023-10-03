//namespace webapi;
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
        get
        {
            if (instance == null)
            {
                instance = new Map();
            }

            return Instance;
        }
    }

    public Rover[] Rovers
    {
        get { return rovers; }
        set { rovers = value; }
    }

    public Map(int x = 0, int y = 0)
    {
        this.bx = x;
        this.by = y;
    }
}
