using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Validation;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new NotDefaultAttribute();

            var isValid1 = validator.IsValid(Guid.Empty);
            var isValid2 = validator.IsValid(DateTime.MinValue);
            var isValid3 = validator.IsValid(new int());
            var isValid4 = validator.IsValid(new bool());
            isValid1 = validator.IsValid(Guid.NewGuid());

            Console.ReadKey();
        }
    }
}
