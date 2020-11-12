// using System.Text.RegularExpressions;

// namespace JCLib
// {
//     public class InputValidator
//     {
//         /// <summary>
//         /// These are The Methods That I Use To Validate The Various Kinds Of User Input Thoughout My UI
//         /// </summary>
        
//         public static bool ValidateNameInput(string name)
//         {
//             return Regex.IsMatch(name, @"^[^\d\s]+$");
//         }

//         public static bool ValidatePasswordInput(string password)
//         {
//             return Regex.IsMatch(password, @"^[^\s]{4,20}$");
//         }

//         public static bool ValidateYesOrNoInput(string YesOrNo)
//         {
//             return Regex.IsMatch(YesOrNo, @"^[^\d\s]$");
//         }

//         public static bool ValidateDigitInput(string digit)
//         {
//             return Regex.IsMatch(digit, @"^[\d]$");
//         }

//         public static bool ValidateEmailInput(string email)
//         {
//             return Regex.IsMatch(email, @"^[A-Za-z0-9]{3,20}@[A-Za-z]{3,10}.(com|net|org)$");
//         }
//     }
// }