namespace database_assignment_1.Controllers
{
    public class OrderCreateModel
    {
        public string CustomerName { get; internal set; }
        public string CustomerAddress { get; internal set; }
        public IEnumerable<object> Products { get; internal set; }
    }
}