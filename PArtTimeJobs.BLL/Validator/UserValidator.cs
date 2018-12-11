using PartTimeJobs.DAL.Models;
using System;
using System.Linq;
using System.Net.Mail;

namespace PartTimeJobs.BLL.Validator
{
    public class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ValidatorException("User name shouldn't be empty");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ValidatorException("Password shouldn't be empty");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ValidatorException("Email shouldn't be empty");
            }
            else if (!IsEmail(user.Email))
            {
                throw new ValidatorException("Email is incorrect");
            }

            if (!string.IsNullOrEmpty(user.PhoneNumber) && !IsPhoneNumber(user.PhoneNumber))
            {
                throw new ValidatorException("PhoneNumber is incorrect");
            }
        }

        private bool IsEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool IsPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }

            if (!phoneNumber.StartsWith("07"))
            {
                return false;
            }

            if (phoneNumber.Any(c => !char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }
    }
}
