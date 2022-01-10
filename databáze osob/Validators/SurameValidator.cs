using PersonDatabase.Interfaces;

namespace PersonDatabase.Validators
{
    class SurnameValidator : IStringValidator
    {
        public bool IsValid(string s)
        {
            return s != null && s.Length > 1 && s.Length < 50;
        }
    }
}
