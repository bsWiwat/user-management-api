namespace UserManagement.Application.Common.Responses;

public static class ResponseFactory
{
    public static BaseResponse<T> Success<T>(T data, string description = "Success", string code = "200")
    {
        return new BaseResponse<T>
        {
            Status = new StatusResponse { Code = code, Description = description },
            Data = data
        };
    }

    public static BaseResponse<T> Error<T>(string description, string code = "400")
    {
        return new BaseResponse<T>
        {
            Status = new StatusResponse { Code = code, Description = description },
            Data = default
        };
    }
}