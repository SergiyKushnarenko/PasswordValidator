using PasswordValidator.Models;

namespace PasswordValidator.Helpers;

public static class PasswordHelper
{
    /// <summary>
    /// Validates all passwords in a file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>validPasswordsCount - Total count of valid password</returns>
    public static int PasswordValidatorFromFile(string filePath)
    {
        var validPasswordsCount = 0;

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var requirement = parts[0].Trim();
            var password = parts[1].Trim();

            if (CheckPasswordValidity(requirement, password))
            {
                validPasswordsCount++;
            }
        }

        return validPasswordsCount;
    }

    /// <summary>
    /// password validation logic
    /// </summary>
    /// <param name="requirement"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private static bool CheckPasswordValidity(string requirement, string password)
    {
        var character = requirement[0];
        var rangeParts = requirement.Substring(2).Split('-');
        var minSymbolRepeat = int.Parse(rangeParts[0]);
        var maxSymbolRepeat = int.Parse(rangeParts[1]);

        var totalRepeated = password.Count(c => c == character);

        return totalRepeated >= minSymbolRepeat && totalRepeated <= maxSymbolRepeat;
    }


    /// <summary>
    /// validate single password in the model
    /// </summary>
    /// <param name="passwordConfig"></param>
    /// <returns></returns>
    public static bool PasswordValidator(PasswordConfig passwordConfig)
    {
        var totalRepeated = 0;

        var passwordCharArray = passwordConfig.Password.ToCharArray();

        foreach (var currentSymbol in passwordCharArray)
        {
            if (passwordConfig.key.Equals(currentSymbol))
            {
                totalRepeated++;
            }
        }

        return totalRepeated >= passwordConfig.MinSymbolRepeat & totalRepeated <= passwordConfig.MaxSymbolRepeat;
    }
}
