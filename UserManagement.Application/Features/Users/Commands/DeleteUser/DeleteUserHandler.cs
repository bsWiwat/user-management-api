using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<bool>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return new BaseResponse<bool>
            {
                Status = new StatusResponse
                {
                    Code = "404",
                    Description = "User not found"
                },
                Data = false
            };
        }

        user.DateDelete = DateTime.UtcNow;
        var isDeleted = await _userRepository.DeleteUserAsync(request.UserId);

        if (!isDeleted)
        {
            return new BaseResponse<bool>
            {
                Status = new StatusResponse
                {
                    Code = "500",
                    Description = "Failed to delete user"
                },
                Data = false
            };
        }

        return new BaseResponse<bool>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "User deleted successfully"
            },
            Data = true
        };

    }
}