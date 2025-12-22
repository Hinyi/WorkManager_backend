using IdentityService.Exceptions;
using IdentityService.Persistence;
using IdentityService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Services.CurrentUserProvider;

namespace IdentityService.Application.User.Command.ChangePassword;

internal sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly ILogger<ChangePasswordHandler> _logger;
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly UserDbContext _dbContext;
    
    public ChangePasswordHandler(ILogger<ChangePasswordHandler> logger, ICurrentUserProvider currentUserProvider, UserDbContext dbContext)
    {
        _logger = logger;
        _currentUserProvider = currentUserProvider;
        _dbContext = dbContext;
    }
    
    public Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = _dbContext.Users.FirstOrDefault(x=> x.Id == _currentUserProvider.GerCurrentUserId().ToString());

        if (user == null)
        {
            throw new UserNotFound();
        }
        else if(!PasswordHasher.ValidatePassword(request.oldPassword, user.PasswordHash))
        {
            throw new InvalidPassword();
        }

        user.PasswordHash = PasswordHasher.GetHash(request.newPassword);
        
        var response = _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
        
    }
}