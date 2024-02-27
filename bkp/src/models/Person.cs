using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Cs
{
    class Person
    {

        private int _id;
        private string _name;
        private string _lastName;
        private string _document;
        private string _address;
        private int _age;
        private string _phoneNumber;
        private DateTime _birthDate;

        public Person()
        {

        }
        public Person(int id, string name, string lastName, string document, string address, int age, string phoneNumber, DateTime birthDate)
        {
            _id = id;
            _name = name;
            _lastName = lastName;
            _document = document;
            _address = address;
            _age = age;
            _phoneNumber = phoneNumber;
            _birthDate = birthDate;
        }

        public Person(string name, string lastName, string document, string address, int age, string phoneNumber, DateTime birthDate)
        {
            _name = name;
            _lastName = lastName;
            _document = document;
            _address = address;
            _age = age;
            _phoneNumber = phoneNumber;
            _birthDate = birthDate;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string LastName { get {  return _lastName; } set { _lastName = value; } }
        public string Document { get { return _document; } set { _document = value; } }
        public string Address { get { return _address; } set { _address = value; } }   
        public int Age { get { return _age; } set { _age = value; } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public DateTime BirthDate { get { return _birthDate; } set { _birthDate = value; } }

    }
}
