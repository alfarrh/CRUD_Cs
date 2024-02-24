using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste.src.db
{
    class DataBase
    {
        private List<Person> Data = new List<Person>();
        private int cont;
        
        public DataBase()
        {
            cont = 0;
        }

        public void CadastrarPessoa(Person person)
        {
            if (cont == 30) throw new Exception("Banco cheio");

            Random rnd = new Random();
            person.Id = rnd.Next(100000, 999999);

            Data.Add(person);
            cont++;
        }

        public Person FindByDocument(string document)
        {
            if(Data.Count == 0) return null;

            try { return Data.Single(r => r.Document == document); }
            catch
            {
                Console.WriteLine("Pessoa não cadastrada.");
                return null;
            }
        }

        public Person FindById(int id)
        {
            if (Data.Count == 0) { return null; }

            try { return Data.Single(r => r.Id == id); }
            catch
            {
                Console.WriteLine("Pessoa não cadastrada.");
                return null;
            }
        }

        public Person Update(Person person)
        {
            if (Data.Count == 0) { throw new Exception("Ainda não existem registros."); }

            try 
            {
                int index = Data.FindIndex(r => r.Id == person.Id);
                Data[index] = person;

                return person;
            }
            catch
            {
                Console.WriteLine("Pessoa não cadastrada.");
                return null;
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
