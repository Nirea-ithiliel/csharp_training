using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
                set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return Regex.Replace(phone, "[ -()]", "")  + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName
                && SecondName == other.SecondName;
        }

        public override int GetHashCode()
        {
            return (FirstName + " " + SecondName).GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = SecondName.CompareTo(other.SecondName);
            if (result !=0)
            {
                return result;
            }
            else
            {
                return FirstName.CompareTo(other.FirstName);
            }
            
        }
    }
}