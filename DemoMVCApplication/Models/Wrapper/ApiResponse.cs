namespace DemoMVCApplication.Models.Wrapper
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }
        public List<T> Data { get; set; }
    }

    public class Meta
    {
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
