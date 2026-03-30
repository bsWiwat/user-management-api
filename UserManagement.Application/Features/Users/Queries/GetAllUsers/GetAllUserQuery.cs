using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Users.Queries.GetAllUser;

public class GetAllUserQuery : IRequest<BaseResponse<PagedResponse<UserResponseDTO>>>
{
    public string? orderBy { get; set; }
    public string? orderDirection { get; set; }
    public int? pageNumber { get; set; }
    public int? pageSize { get; set; }
    public string? search { get; set; }
}