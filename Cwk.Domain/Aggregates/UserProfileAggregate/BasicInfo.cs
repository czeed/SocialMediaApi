using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfo
    {
        public string FirstName {  get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; }  = string.Empty ;
        public string PhoneNumber { get; private set; } = string.Empty;
        public DateTime DayOfBirth {  get; private set; }
        public string CurrentCity { get; private set; } = string.Empty;

        private BasicInfo()
        {
            
        }

        public static BasicInfo CreateBsicInfo(string firstName, string lastName, string email, string phoneNumber, DateTime dateBorth, string currentCity)
        {
            // to do : implementation, errorhandling strategies

            return new BasicInfo()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                DayOfBirth = dateBorth,
                CurrentCity = currentCity
            };
        }
    }

    
}
