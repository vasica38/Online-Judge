namespace Server.Models
{
    public class Test
    {
        public Test()
        {
            In = false;
            Out = false;
        }
        public bool In { get; set; }
        public bool Out { get; set; }
        public string Data { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}