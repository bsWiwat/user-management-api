using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Users.Queries.GetAllUser;

public class GetAllUserQuery : IRequest<BaseResponse<List<UserResponseDTO>>>
{
}