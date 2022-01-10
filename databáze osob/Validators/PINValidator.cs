using PersonDatabase.Interfaces;
using System.Text.RegularExpressions;
namespace PersonDatabase.Validators
{
    class PINValidator : IStringValidator
    {

        public bool IsValid(string s)
        {
            if (s == null) { return false; }
            Regex rg = new Regex(@"\d{6}\/\d{3,4}");// 6/3(4)
            Match m = rg.Match(s);
            return m.Success && m.Index == 0 && m.Length == s.Length;
        }
    }
}
