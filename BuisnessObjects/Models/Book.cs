using BusinessObjects.Models;

namespace BusinessObjects
{
    public class Book : SqlEntityBase //Price add maybe
    {
        public string BookName { get; set; } = null!;
        public string Author { get; set; } = null!; //TODO new table
    }
}
