using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Users.Queries.GetAllUser;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, BaseResponse<PagedResponse<UserResponseDTO>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<PagedResponse<UserResponseDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var searchModel = new SearchModel
        {
            orderBy = request.orderBy ?? "",
            orderDirection = request.orderDirection ?? "",
            pageNumber = request.pageNumber ?? 1,
            pageSize = request.pageSize ?? 10,
            search = request.search ?? ""
        };

        var result = await _userRepository.GetAllUsersAsync(searchModel);

        return new BaseResponse<PagedResponse<UserResponseDTO>>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Users retrieved successfully"
            },
            Data = new PagedResponse<UserResponseDTO>
            {
                Data = result.Data.Select(user => new UserResponseDTO
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Username = user.Username,
                    Role = new RoleDTO
                    {
                        RoleId = user.Role.RoleId,
                        RoleName = user.Role.RoleName
                    },
                    Permissions = user.Permissions.Select(p => new PermissionDTO
                    {
                        PermissionId = p.PermissionId,
                        PermissionName = p.Permission.PermissionName,
                    }).ToList(),
                    DateCreate = user.DateCreate,
                    DateUpdate = user.DateUpdate,
                    DateDelete = user.DateDelete
                }).ToList(),
                Total = result.Total
            }
        };
    }
}