using System;
using System.Collections.Generic;
using System.Text;

namespace CorCentric
{
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private string _gender;
        private string _mobileNumber;

        public static Student Create(string firstName, string lastName, string gender, string mobileNumber)
        {
            return new Student(firstName, lastName, gender, mobileNumber);
        }

        private Student(string firstName, string lastName, string gender, string mobileNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _mobileNumber = mobileNumber;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Gender => _gender;
        public string MobileNumber => _mobileNumber;
    }
}
