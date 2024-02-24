using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto_Teste.src.db;
using Projeto_Teste.src.control;

namespace Projeto_Teste.src.view
{
    class TestView
    {
        public static DataBase db = new DataBase();
        private static void _printPerson(Person person)
        {
            Console.WriteLine(
                "\nID: " + person.Id +
                "\nNome: " + person.Name +
                "\nSobrenome: " + person.LastName +
                "\nDocumento: " + person.Document +
                "\nEndereco: " + person.Address +
                "\nIdade: " + person.Age +
                "\nTelefone: " + person.PhoneNumber +
                "\nData de Nascimento: " + person.BirthDate);
        }
        public static void Programa()
        {
            PersonController control = new PersonController();

            int id;
            string name;
            string lastName;
            string document;
            string address;
            int age;
            string phoneNumber;
            DateTime birthDate;

            bool it = true;
            ConsoleKey option;

            while (it)
            {
                Console.Clear();
                Console.WriteLine(
                    "MENU" +
                    "\n[1] - Consultar" +
                    "\n[2] - Cadastrar" +
                    "\n[3] - Listar" +
                    "\n[4] - Atualizar" +
                    "\n[5] - Remover" +
                    "\n[8] - Init" +
                    "\n[9] - Sair");

                try
                {
                    option = Console.ReadKey().Key;

                    switch (option)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();

                            Console.Write("ID (necessario): ");
                            id = Int32.Parse(Console.ReadLine()!);

                            Person person = control.Find(id);

                            _printPerson(person);

                            Console.ReadKey();

                            break;
                        case ConsoleKey.D2:
                            Console.Clear();

                            Console.Write("Nome: ");
                            name = Console.ReadLine()!;

                            Console.Write("Sobrenome: ");
                            lastName = Console.ReadLine()!;

                            Console.Write("Documento: ");
                            document = Console.ReadLine()!;

                            Console.Write("Endereco: ");
                            address = Console.ReadLine()!;

                            Console.Write("Idade: ");
                            age = Int32.Parse(Console.ReadLine()!);

                            Console.Write("Telefone: ");
                            phoneNumber = Console.ReadLine()!;

                            birthDate = DateTime.Now;

                            control.Create(name, lastName, document, address, age, phoneNumber, birthDate);
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();

                            List<Person> pessoas = control.Index();
                            if (pessoas != null)
                            {  
                                foreach (Person pessoa in pessoas) _printPerson(pessoa);
                            }
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();

                            Console.Write("ID (necessario): ");
                            id = Int32.Parse(Console.ReadLine()!);

                            Console.Write("Nome: ");
                            name = Console.ReadLine()!;

                            Console.Write("Sobrenome: ");
                            lastName = Console.ReadLine()!;

                            Console.Write("Documento: ");
                            document = Console.ReadLine()!;

                            Console.Write("Endereco: ");
                            address = Console.ReadLine()!;

                            Console.Write("Idade: ");
                            age = Int32.Parse(Console.ReadLine()!);

                            Console.Write("Telefone: ");
                            phoneNumber = Console.ReadLine()!;

                            birthDate = DateTime.Now;

                            control.Update(id, name, lastName, document, address, age, phoneNumber, birthDate);

                            Console.WriteLine("Atualizado com sucesso!");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D5:

                            Console.Clear();

                            Console.Write("ID (necessario): ");
                            id = Int32.Parse(Console.ReadLine()!);

                            control.Delete(id);

                            Console.WriteLine("Deletado com sucesso!");
                            Console.ReadKey();

                            break;

                        case ConsoleKey.D8:
                            control.Create("Alvaro", "Lima", "32233", "Rua 2", 23, "33223322", DateTime.Now);
                            control.Create("Lucas", "Souza", "12233", "Rua A", 24, "33223332", DateTime.Now);
                            control.Create("Rafael", "Nunes", "33344", "Rua B", 23, "33255522", DateTime.Now);

                            Console.Clear();
                            Console.WriteLine("Dados carregados.");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D9:
                            it = false;
                            break;
                        
                        default:
                            Console.WriteLine("Erro");
                            break;
                    }     
                }
                catch (Exception err)
                {
                    Console.Write("ERROR: " + err);
                    Console.ReadLine();
                }
            }
        }
    }
}
