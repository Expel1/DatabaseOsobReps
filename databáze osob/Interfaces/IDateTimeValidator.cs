using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDatabase.Interfaces
{
    public interface IDateTimeValidator
    {
        bool IsValid(DateTime d);
    }
}
