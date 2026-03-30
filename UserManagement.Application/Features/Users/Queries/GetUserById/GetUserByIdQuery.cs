using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<BaseResponse<UserResponseDTO>>
{
    public Guid UserId { get; set; }
}