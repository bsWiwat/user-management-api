using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<BaseResponse<bool>>
{
    public Guid UserId { get; set; }
}