namespace FootballLeague.Models
{
    using System;
    using Utils;

    public class Player
    {
        private const int MinimumAllowedYear = 1980;
        private const int MinStringLength = 3;

        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime dateOfBirth;

        public Player(string firstName, string lastName, decimal salary, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringCantBeNullOrEmpty, "Player first name"));
                }

                if (value.Length < MinStringLength)
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringShouldBeAtLeast, "Player first name", MinStringLength));
                }

                this.firstName = value;
            }
        }

        public  string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringCantBeNullOrEmpty, "Player last name"));
                }

                if (value.Length < MinStringLength)
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringShouldBeAtLeast, "Player last name", MinStringLength));
                }

                this.lastName = value;
            }
        }

        private decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MsgConstants.NumberCantBeNegative, "Player salary"));
                }

                this.salary = value;
            }
        }

        private DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value.Year < MinimumAllowedYear)
                {
                    throw new ArgumentException(string.Format(MsgConstants.DateShouldBeAfter, "Player birth date", MinimumAllowedYear));
                }

                this.dateOfBirth = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} ({this.Salary:C})";
        }
    }
}