namespace WebApplication1
{   
    public class Point
    {
        private static long nextId = 1;

        public long id { get;  set; }
        public string WKT { get; set; } // Store WKT format directly
        public string Name { get; set; }

        public Point()
        {
            id = nextId++;
        }
    }
}   
