using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Cs.src.db
{
    class DataBase
    {
        private List<Person> Data = new List<Person>();
        private int cont;

        public DataBase()
        {
            cont = 0;

            this.Insert(new Person("Gabriel", "Lima", "32233", "Rua 2", 23, "3322-3322", DateTime.Now));
            this.Insert(new Person("Lucas", "Souza", "12233", "Rua A", 24, "3322-3332", DateTime.Now));
            this.Insert(new Person("Rafael", "Nunes", "33344", "Rua B", 23, "3325-5522", DateTime.Now));
        }

        public void Insert(Person person)
        {
            Random rnd = new Random(Seed: cont);
            person.Id = rnd.Next(1000, 9999);

            Data.Add(person);
            cont++;
        }

        public List<Person> FindMany(string name = null)
        {
            if (Data.Count == 0) return null;
            if (name == null) return Data;

            try { return (List<Person>)Data.Where(r => r.Name == name); }
            catch
            {
                return null;
            }
        }

        public Person Find(int id, string where)
        {
            if (Data.Count == 0) { return null; }

            try { return Data.Single(r => r.Id == id); }
            catch
            {
                return null;
            }
        }

        public Person Find(string document, string where)
        {
            if (Data.Count == 0) { return null; }

            try { return Data.Single(r => r.Document == document); }
            catch
            {
                return null;
            }
        }

        public void Update(Person person)
        {
            if (Data.Count == 0) { throw new Exception("Ainda não existem registros."); }

            try
            {
                int index = Data.FindIndex(r => r.Id == person.Id);
                Data[index] = person;
            }
            catch
            {
                throw new Exception("Pessoa não cadastrada.");
            }
        }

        public void Delete(int id)
        {
            if (Data.Count == 0) { throw new Exception("Ainda não existem registros."); }

            Person person = Data.Single(r => r.Id == id);

            if (person == null) throw new Exception("Id inválido.");
            else { Data.Remove(person); }

        }

        public List<Person> List()
        {
            return Data;
        }


    }
}