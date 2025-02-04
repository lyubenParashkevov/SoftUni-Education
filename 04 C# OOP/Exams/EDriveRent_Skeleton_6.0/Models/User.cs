using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            
            IsBlocked = false;
        }
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.FirstNameNull);
                }

                firstName = value;
            }


        }
        
        public string LastName 
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.LastNameNull);
                }

                lastName = value;
            }
        }
        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.DrivingLicenseRequired);
                }

                drivingLicenseNumber = value;
            }
        }

        public double Rating { get; private set; }


        public bool IsBlocked { get; private set; }

        public void IncreaseRating()  //?
        {
            Rating += 0.5;
            if (Rating >= 10.0)
            {
                this.Rating = 10;
            }
        }

        public void DecreaseRating()  //?
        {
            Rating -= 2.0;
            if (Rating < 0.0)
            {
                this.Rating = 0.0;
                IsBlocked = true;
            }
        }

        
        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
