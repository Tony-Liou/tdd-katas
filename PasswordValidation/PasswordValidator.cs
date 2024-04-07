namespace PasswordValidation;

public class PasswordValidator
{
    public static ValidationResult Validate(string password)
    {
        List<string> errors = [];

        if (password.Length < 8)
        {
            errors.Add("Password must be at least 8 characters");
        }

        if (password.Count(char.IsDigit) < 2)
        {
            errors.Add("The password must contain at least 2 numbers");
        }

        if (!password.Any(char.IsUpper))
        {
            errors.Add("password must contain at least one capital letter");
        }

        if (password.All(char.IsLetterOrDigit))
        {
            errors.Add("password must contain at least one special character");
        }

        return errors.Count == 0
            ? new ValidationResult { IsValid = true }
            : new ValidationResult { IsValid = false, Message = string.Join('\n', errors) };
    }
}

public class ValidationResult
{
    public bool IsValid { get; init; }
    public string? Message { get; init; }
}