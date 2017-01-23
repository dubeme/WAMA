namespace WAMA.Core.Models.DTOs
{
    public enum UserAccountType
    {
        Unknown,
        Patron = 1,
        Employee = 2,
        Manager = 4,
        Administrator = 8,
        Mantainance = 16
    }
}