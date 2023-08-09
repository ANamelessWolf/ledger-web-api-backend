namespace Nameless.WebApi.Models
{
    public class PageResult<T> where T : class
    {
        public int TotalRows { get; set; }
        public IEnumerable<T>? Items { get; set; }
    }
}

