using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto_Teste.src.db;
using Projeto_Teste.src.view;

namespace Projeto_Teste.src.control
{
    class PersonController
    {
        private DataBase _db;

        public PersonController()
        {
            this._db = TestView.db;
        }
        
        public void Create(string name, string lastName, string documento, string endereco, int idade, string telefone, DateTime dataNasc)
        {
            Person pessoa = new Person(name, lastName, documento, endereco, idade, telefone, dataNasc);

            try
            {
                /*
                Pessoa pessoa = await db.FindByDocumento(documento);
                */

                Person consulta = _db.FindByDocument(documento);
                if (consulta != null) throw new Exception("Pessoa já cadastrada.");

                else _db.CadastrarPessoa(pessoa);
            }
            catch (Exception err)
            {
                Console.WriteLine("Erro ao cadastrar: " + err);
            }

        }
        //Read
        public Person Find(int id)
        {
            return _db.FindById(id);
        }
        //Update
        //Delete

        public List<Person> Index()
        {
            try
            {
                List<Person> lista = _db.List();
                return lista;
            }
            catch (Exception err)
            {
                Console.WriteLine("Erro ao listar: " + err);
                return null;
            }
        }
    }
}
