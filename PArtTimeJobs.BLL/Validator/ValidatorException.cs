using System;

namespace PArtTimeJobs.BLL.Validator
{
    class ValidatorException : Exception
    {
        public ValidatorException(string message) : base(message)
        {
        }
    }
}
