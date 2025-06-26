using System.Security.Claims;
using HttpContextAuthentication.Peticiones.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpContextAuthentication.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    public LoginModel() { }

    [BindProperty(SupportsGet = true)]
    public LoginRequest? LoginRequest { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnGetLoginAsync()
    {
        return await OnPostLoginAsync();
    }

    public async Task<IActionResult> OnPostLoginAsync()
    {
        var respuestaLogin = new
        {
            Codigo = 1,
            NombreUsuario = LoginRequest.UserName,
            RoleUsuario = "Usuario",
        };

        ClaimsIdentity? identity = new("Cookies");
        identity.AddClaim(new Claim(ClaimTypes.Role, respuestaLogin.RoleUsuario));
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, respuestaLogin.Codigo.ToString()));
        identity.AddClaim(new Claim(ClaimTypes.Name, respuestaLogin.NombreUsuario));

        AuthenticationProperties? prop = new() { IsPersistent = false };
        await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity), prop);

        return LocalRedirect(ReturnUrl ?? "/");
    }
}
