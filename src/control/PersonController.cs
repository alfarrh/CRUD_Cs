using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using Projeto_Teste.src.db;
using Projeto_Teste.src.view;

namespace Projeto_Teste.src.control
{
    class PersonController
    {
        private SQLite _dbSQL;
        private DataBase _db;

        public PersonController()
        {
            this._db = TestView.db;
            this._dbSQL = new SQLite();
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

            Person query = _dbSQL.Find(document, where: "document");
            if (query != null) throw new Exception("Pessoa já cadastrada.");

            else _dbSQL.Insert(person);
        }

        //Read
        public Person Find(int id)
        {
            //Person person = _db.FindById(id);
            
            Person person = _dbSQL.Find(id, where:"id");

            if (person == null) throw new Exception("Pessoa não cadastrada.");
            else return person;
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
            _db.Delete(id);
        }

        //List
        public List<Person> List()
        {
            List<Person> people = new List<Person>();

            return people = people == null ? throw new Exception("Não existem cadastros.") : _dbSQL.FindMany();
        }
    }
}
