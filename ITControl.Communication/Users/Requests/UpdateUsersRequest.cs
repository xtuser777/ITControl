using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Users.Interfaces;
using ITControl.Domain.Users.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class UpdateUsersRequest
{
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [CustomValidation(typeof(UpdateUsersRequest), nameof(ValidateUsername))]
    [Display(Name = nameof(Username), ResourceType = typeof(DisplayNames))]
    public string? Username { get; set; }

    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = nameof(Password), ResourceType = typeof(DisplayNames))]
    public string? Password { get; set; }

    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [EmailAddress(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = nameof(Errors.VALID_EMAIL))]
    [StringMaxLength(100)]
    [CustomValidation(typeof(UpdateUsersRequest), nameof(ValidateEmail))]
    [Display(Name = nameof(Email), ResourceType = typeof(DisplayNames))]
    public string? Email { get; set; }

    [StringLength(11)]
    [DocumentValue]
    [CustomValidation(typeof(CreateUsersRequest), nameof(ValidateDocument))]
    [Display(Name = nameof(Document), ResourceType = typeof(DisplayNames))]
    public string? Document { get; set; } 

    [BoolValue]
    [Display(Name = nameof(Active), ResourceType = typeof(DisplayNames))]
    public bool? Active { get; set; }

    [IntegerPositiveValue]
    [Display(Name = nameof(Enrollment), ResourceType = typeof(DisplayNames))]
    public int? Enrollment { get; set; }

    [GuidValue]
    [PositionConnection]
    [Display(Name = nameof(PositionId), ResourceType = typeof(DisplayNames))]
    public Guid? PositionId { get; set; }

    [GuidValue]
    [RoleConnection]
    [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
    public Guid? RoleId { get; set; }

    [GuidValue]
    [UnitConnection]
    [Display(Name = nameof(UnitId), ResourceType = typeof(DisplayNames))]
    public Guid? UnitId { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    [GuidValue]
    [DivisionConnection]
    [Display(Name = nameof(DivisionId), ResourceType = typeof(DisplayNames))]
    public Guid? DivisionId { get; set; }

    [RequiredField]
    [Display(Name = nameof(Equipments), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [RequiredField]
    [Display(Name = nameof(Systems), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];

    public static implicit operator UpdateUserParams(UpdateUsersRequest request) => new()
    {
        Username = request.Username,
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        Document = request.Document,
        Enrollment = request.Enrollment,
        Active = request.Active,
        PositionId = request.PositionId,
        RoleId = request.RoleId,
        UnitId = request.UnitId,
        DepartmentId = request.DepartmentId,
        DivisionId = request.DivisionId,
    };

    public static ValidationResult? ValidateUsername(string? username, ValidationContext context)
    {
        if (string.IsNullOrEmpty(username))
            return ValidationResult.Success;
        var usersRepository = context
            .GetService(typeof(IUsersRepository)) as IUsersRepository
            ?? throw new NullReferenceException();
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = usersRepository
            .ExclusiveAsync(new() { Id = id, Username = username })
            .GetAwaiter().GetResult();
        if (exists)
            return new ValidationResult(string.Format(Errors.UniqueField, context.DisplayName));

        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateEmail(string? email, ValidationContext context)
    {
        if (string.IsNullOrEmpty(email))
            return ValidationResult.Success;
        var usersRepository = context
            .GetService(typeof(IUsersRepository)) as IUsersRepository
            ?? throw new NullReferenceException();
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = usersRepository
            .ExclusiveAsync(new() { Id = id, Email = email })
            .GetAwaiter().GetResult();
        if (exists)
            return new ValidationResult(string.Format(Errors.UniqueField, context.DisplayName));

        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateDocument(string? document, ValidationContext context)
    {
        if (string.IsNullOrEmpty(document))
            return ValidationResult.Success;
        var usersRepository = context
            .GetService(typeof(IUsersRepository)) as IUsersRepository
            ?? throw new NullReferenceException();
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = usersRepository
            .ExclusiveAsync(new() { Id = id, Document = document })
            .GetAwaiter().GetResult();
        if (exists)
            return new ValidationResult(string.Format(Errors.UniqueField, context.DisplayName));

        return ValidationResult.Success;
    }
}