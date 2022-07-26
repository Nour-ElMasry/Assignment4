using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain
{
    public class BirthDateException : Exception
    {
        public BirthDateException(string? message) : base(message)
        {
        }
    }
}
