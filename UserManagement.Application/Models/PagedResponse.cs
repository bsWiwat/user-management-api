public class PagedResponse<T>
{
    public List<T> Data { get; set; }
    public int Total { get; set; }
}