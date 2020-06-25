using System;
using NetCore.AutoSort.Attributes;

namespace NetCore.AutoSort.Example.Model
{
    public class Person
    {
        public Person() { }
        public Person(string firstName, string lastName, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }

        [Sort(2)]
        public string FirstName { get; set; }
        [Sort]
        public string LastName { get; set; }
        [Sort(1)]
        public DateTime BirthDay { get; set; }

        public override bool Equals(object obj)
        {
            bool result;
            if (obj is Person person)
            {
                result = FirstName.Equals(person.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                   LastName.Equals(person.LastName, StringComparison.InvariantCultureIgnoreCase) &&
                   BirthDay.Equals(person.BirthDay);
            }
            else
            {
                result = base.Equals(obj);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return string.GetHashCode(FirstName, StringComparison.InvariantCultureIgnoreCase) +
                    string.GetHashCode(LastName, StringComparison.InvariantCultureIgnoreCase) +
                    BirthDay.GetHashCode();
        }
    }
}