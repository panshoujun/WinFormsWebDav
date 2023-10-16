namespace WinFormsWebDav.Modes.Dto.Base
{
    public class PagedApiResult<T> : ApiResult<IEnumerable<T>>
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class PagedApiResult : PagedApiResult<object>
    { }
}
