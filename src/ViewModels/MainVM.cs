using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Crud_Cs.Services;
using Crud_Cs.src.control;
using Crud_Cs.src.view;
using Crud_Cs.ViewModels;

namespace Crud_Cs.ViewModels
{
    class MainVM : BaseVM
    {
        public ICommand OpenSaveCommand {  get; set; }
        public ICommand OpenUpdateCommand { get; set; }

        public ICommand FindCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public string TextSearch { get; set; }
        public int Id {  get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DataRowView SelectedRow { get; set; }
        public ObservableCollection<Person> Itens { get; set; }

        private PersonController _control;

        public MainVM()
        {
            OpenSaveCommand = new DelegateCommand(OpenSave);
            //OpenUpdateCommand = new DelegateCommand(OpenUpdate);

            FindCommand = new DelegateCommand(Find);
            //UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);

            Itens = new ObservableCollection<Person>();
            _control = new PersonController();

            this.Find(new object { });
        }
        public void Find(object obj)
        {

            List<Person> people;

            try
            {
                int id = Int32.Parse(TextSearch);
                people = new List<Person> { _control.Find(id) };
            }
            catch (ArgumentException ex)
            {
                string parameter = TextSearch;
                people = _control.List(parameter);
            }

            Itens.Clear();

            foreach (Person person in people)
            {
                Itens.Add(person);
            }
            
        }
        public void OpenSave(object obj)
        {
            PersonInsert insert = new PersonInsert();
            insert.Show();
        }

        public void Delete(object obj)
        {
            DataRowView teste = SelectedRow;
            Console.WriteLine(teste);
        }

        
    }
}
