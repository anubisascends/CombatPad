using System.Text.RegularExpressions;

namespace CombatPad.Classes
{
    public static class Extensions
    {
        public static string SplitCamelCase(this string input) => Regex.Replace(input, "([A-Z])", "$1", RegexOptions.Compiled).Trim();
    }
}
