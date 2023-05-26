using PasswordValidator.Helpers;
using PasswordValidator.Models;

var filePath = "passwords.txt";
var validPasswordsCount = PasswordHelper.PasswordValidatorFromFile(filePath);
Console.WriteLine("Number of valid passwords: " + validPasswordsCount);

#region additional method for validating a single model

var passwordConfig = new PasswordConfig()
{
    MaxSymbolRepeat = 5,
    MinSymbolRepeat = 2,
    key = 'a',
    Password = "abbasfa"
};

var result = PasswordHelper.PasswordValidator(passwordConfig);
Console.WriteLine("Expected Result - true");
Console.WriteLine(result);


#endregion
