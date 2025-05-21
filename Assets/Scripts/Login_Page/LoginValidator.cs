public static class LoginValidator
{
    public static bool IsValidPhone(string phone)
    {
        return !string.IsNullOrEmpty(phone) && phone.Length == 10 && long.TryParse(phone, out _);
    }

    public static bool IsValidPassword(string password)
    {
        return !string.IsNullOrEmpty(password);
    }
}
