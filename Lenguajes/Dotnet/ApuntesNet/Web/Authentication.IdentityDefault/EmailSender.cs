using Microsoft.AspNetCore.Identity;

namespace Authentication.IdentityDefault;

public class EmailSender : IEmailSender<IdentityUser<int>>
{
    public Task SendConfirmationLinkAsync(IdentityUser<int> user, string email, string confirmationLink)
    {
        return Task.CompletedTask;
    }

    public Task SendPasswordResetLinkAsync(IdentityUser<int> user, string email, string resetLink)
    {
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(IdentityUser<int> user, string email, string resetCode)
    {
        return Task.CompletedTask;
    }
}