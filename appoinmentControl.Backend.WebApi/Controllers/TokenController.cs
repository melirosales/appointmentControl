using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using appointmentControl.Backend.WebApi.Helpers;
using Microsoft.Extensions.Configuration;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[AllowAnonymous]
public class TokenController : Controller
{
    private IConfiguration configuration;
    public TokenController(IConfiguration iConfiguration)
    {
        configuration = iConfiguration;
    }

    [Route("Token")]
    [Microsoft.AspNetCore.Mvc.HttpPost]
    public IActionResult Create([FromBody] Api_User user)
    {
        if (user.Usuario_Autenticacion != configuration.GetValue<string>("AppSettings:User") && user.Password_Autenticacion != configuration.GetValue<string>("AppSettings:Password"))
            return Unauthorized();

        var token = new JwtTokenBuilder()
                            .AddSecurityKey(JwtSecurityKey.Create(configuration.GetValue<string>("AppSettings:Secret")))
                            .AddSubject(user.userName)
                            .AddIssuer("MeliRosales")
                            .AddAudience("MeliRosales")
                            .AddClaim("tecnicalTest", "tecnicalTest")
                            .AddExpiry(245)
                            .Build();

        return Ok(token);
    }
}