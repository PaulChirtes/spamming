using System;

namespace PartTimeJobs.BLL.Validator
{
    class ValidatorException : Exception
    {
        public ValidatorException(string message) : base(message)
        {
        }
    }
}
