using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using Crud_Cs.src.db;
using Crud_Cs.src.view;

namespace Crud_Cs.src.control
{
    class PersonController
    {
        private SQLite _db;

        public PersonController()
        {
            this._db = new SQLite();
        }
        
        //Create
        public void Create
            (
                string name,
                string lastName,
                string document,
                string address,
                int age,
                string phoneNumber,
                DateTime birthDate
            )
        {
            Person person = new Person(name, lastName, document, address, age, phoneNumber, birthDate);

            Person query = _db.Find(document, where: "document");
            if (query != null) throw new Exception("Pessoa já cadastrada.");

            else _db.Insert(person);
        }

        //Read
        public Person Find(int id)
        {
            Person person = _db.Find(id, where:"id");

            if (person == null) throw new Exception("Pessoa não cadastrada.");
            else return person;
        }

        public List<Person> Find(string name)
        {
            List<Person> people = _db.FindMany(name, where: "name");

            if (people == null) throw new Exception("Pessoa não cadastrada.");
            else return people;
        }

        //Update
        public void Update
            (
                int id,
                string name,
                string lastName,
                string documento,
                string endereco,
                int idade,
                string telefone,
                DateTime dataNasc
            )
        {
            Person person = new Person(id, name,lastName, documento, endereco,idade, telefone,dataNasc);

            _db.Update(person);
        }
        
        //Delete
        public void Delete( int id )
        {
            Person person = _db.Find(id, where: "id");

            if (person == null) throw new Exception("Pessoa não cadastrada.");
            else _db.Delete(id);
        }

        //List
        public List<Person> List(string query = null)
        {
            List<Person> people = new List<Person>();

            return people = people == null ? throw new Exception("Não existem cadastros.") : _db.FindMany(query, "name");
        }
    }
}
