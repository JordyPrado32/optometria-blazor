using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using optometria.Data;
using optometria.Models.Auth;

namespace optometria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailSender<ApplicationUser> _emailSender;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IEmailSender<ApplicationUser> emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            DocumentType = request.DocumentType.Trim(),
            DocumentNumber = request.DocumentNumber.Trim(),
            PhoneNumber = request.PhoneNumber.Trim(),
            BirthDate = request.BirthDate,
            Address = request.Address.Trim(),
            City = request.City.Trim(),
            Department = request.Department.Trim(),
            Country = request.Country.Trim(),
            EmergencyContact = request.EmergencyContact.Trim()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(new AuthResponse
            {
                Succeeded = false,
                Message = "No fue posible registrar el usuario.",
                Errors = result.Errors.Select(x => x.Description)
            });
        }

        await _signInManager.SignInAsync(user, isPersistent: false);

        return Ok(new AuthResponse
        {
            Succeeded = true,
            Message = "Usuario registrado e inicio de sesión realizado correctamente.",
            UserId = await _userManager.GetUserIdAsync(user),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = user.FullName,
            DocumentNumber = user.DocumentNumber,
            IsAuthenticated = true
        });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _signInManager.PasswordSignInAsync(
            request.Email,
            request.Password,
            request.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            return Ok(new AuthResponse
            {
                Succeeded = true,
                Message = "Inicio de sesión exitoso.",
                UserId = user is null ? null : await _userManager.GetUserIdAsync(user),
                Email = user?.Email,
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                FullName = user?.FullName,
                DocumentNumber = user?.DocumentNumber,
                IsAuthenticated = true
            });
        }

        if (result.IsLockedOut)
        {
            return Unauthorized(new AuthResponse
            {
                Succeeded = false,
                Message = "La cuenta está bloqueada temporalmente."
            });
        }

        if (result.RequiresTwoFactor)
        {
            return Unauthorized(new AuthResponse
            {
                Succeeded = false,
                Message = "La cuenta requiere autenticación de dos factores."
            });
        }

        return Unauthorized(new AuthResponse
        {
            Succeeded = false,
            Message = "Correo o contraseña inválidos."
        });
    }

    [HttpPost("logout")]
    public async Task<ActionResult<AuthResponse>> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok(new AuthResponse
        {
            Succeeded = true,
            Message = "Sesión cerrada correctamente.",
            IsAuthenticated = false
        });
    }

    [HttpGet("me")]
    public async Task<ActionResult<AuthResponse>> Me()
    {
        if (User.Identity?.IsAuthenticated != true)
        {
            return Unauthorized(new AuthResponse
            {
                Succeeded = false,
                Message = "No hay una sesión activa."
            });
        }

        var user = await _userManager.GetUserAsync(User);
        if (user is null)
        {
            return Unauthorized(new AuthResponse
            {
                Succeeded = false,
                Message = "No fue posible obtener el usuario autenticado."
            });
        }

        return Ok(new AuthResponse
        {
            Succeeded = true,
            Message = "Usuario autenticado.",
            UserId = await _userManager.GetUserIdAsync(user),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = user.FullName,
            DocumentNumber = user.DocumentNumber,
            IsAuthenticated = true
        });
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword(ForgotPasswordRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Ok(new ForgotPasswordResponse
            {
                Succeeded = true,
                Message = "Si el correo existe, se generó un enlace para recuperar la clave."
            });
        }

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encodedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var resetUrl = $"{Request.Scheme}://{Request.Host}/Account/ResetPassword";

        if (!string.IsNullOrWhiteSpace(resetUrl))
        {
            resetUrl = QueryHelpers.AddQueryString(resetUrl, "code", encodedCode);
            await _emailSender.SendPasswordResetLinkAsync(user, request.Email, resetUrl);
        }

        return Ok(new ForgotPasswordResponse
        {
            Succeeded = true,
            Message = "Se generó el enlace para recuperar la clave.",
            ResetCode = encodedCode,
            ResetUrl = resetUrl
        });
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> ResetPassword(ResetPasswordRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return BadRequest(new AuthResponse
            {
                Succeeded = false,
                Message = "No fue posible restablecer la clave."
            });
        }

        string decodedCode;
        try
        {
            decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
        }
        catch (FormatException)
        {
            return BadRequest(new AuthResponse
            {
                Succeeded = false,
                Message = "El token de recuperación no es válido."
            });
        }

        var result = await _userManager.ResetPasswordAsync(user, decodedCode, request.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new AuthResponse
            {
                Succeeded = false,
                Message = "No fue posible restablecer la clave.",
                Errors = result.Errors.Select(x => x.Description)
            });
        }

        return Ok(new AuthResponse
        {
            Succeeded = true,
            Message = "Clave restablecida correctamente."
        });
    }
}
