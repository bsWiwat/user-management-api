namespace UserManagement.Application.Common.Responses
{
    public class BaseResponse<T>
    {
        public StatusResponse Status { get; set; } = new();
        public T? Data { get; set; }
    }

    public class StatusResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}