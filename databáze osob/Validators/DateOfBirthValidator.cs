using PersonDatabase.Interfaces;
using System;

namespace PersonDatabase.Validators
{
    class DateOfBirthValidator : IDateTimeValidator
    {
        public bool IsValid(DateTime d)
        {
            return d != null && d < DateTime.Now && DateTime.Now - d < new TimeSpan(365 * 150, 0, 0, 0);
        }
    }
}
