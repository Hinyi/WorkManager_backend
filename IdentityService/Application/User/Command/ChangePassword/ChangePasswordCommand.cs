using MediatR;

namespace IdentityService.Application.User.Command.ChangePassword;

public record ChangePasswordCommand(string oldPassword, string newPassword, string confirmNewPassword) : IRequest;
