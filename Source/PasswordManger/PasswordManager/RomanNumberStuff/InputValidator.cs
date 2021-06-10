namespace PasswordManger.RomanNumberStuff
{
    internal static class InputValidator
    {
        public static bool IsInputValid(int currentInput)
        {
            return currentInput is >= Constants.MinimumValueComputable and <= Constants.MaximumValueComputable;
        }
    }
}
