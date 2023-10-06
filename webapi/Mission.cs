namespace webapi;

    public class Mission
    {
        private List<Rover> rovers = new List<Rover>();
        private Map map;
        public Mission() {

            this.map = new Map(5,5);

            // according to test we init 2 rovers;
            this.rovers.Add(new Rover());
            this.rovers.Add(new Rover());

        }
        public void AddRover()
        {
            this.rovers.Add(new Rover());
        }



    }
