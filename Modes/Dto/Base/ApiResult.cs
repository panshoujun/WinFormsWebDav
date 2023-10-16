using Newtonsoft.Json;

namespace WinFormsWebDav.Modes.Dto.Base
{
    public class ApiResult<T>
    {
        public int Code { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }

        public long Timestamp { get; set; } = DateTime.UtcNow.Ticks;
    }

    public class ApiResult : ApiResult<object>
    {
    }
}
