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
using Crud_Cs.src.db;
using Crud_Cs.src.view;
using Crud_Cs.src.ViewModels;
using Crud_Cs.ViewModels;

namespace Crud_Cs.ViewModels
{
    class MainVM : BaseVM
    {

        public DataBase db;

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
        public Person SelectedRow { get; set; }
        public ObservableCollection<Person> Itens { get; set; }

        public static PersonController _control;
        public static bool update;

        public MainVM()
        {
            OpenSaveCommand = new DelegateCommand(OpenSave);
            OpenUpdateCommand = new DelegateCommand(OpenUpdate);

            FindCommand = new DelegateCommand(Find);
            DeleteCommand = new DelegateCommand(Delete);

            Itens = new ObservableCollection<Person>();
            _control = new PersonController();

            db = new DataBase();
            update = false;

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
            catch (Exception ex)
            {
                if (ex is FormatException || ex is ArgumentException)
                {
                    try
                    {
                        people = _control.List(TextSearch);
                    }
                    catch (Exception err)
                    {
                        Alert panel = new Alert(err.Message);
                        panel.Show();
                        people = null;
                    }
                }
                else
                {
                    Alert panel = new Alert(ex.Message);
                    panel.Show();
                    people = null;
                }
            }

            Itens.Clear();

            if (people != null) { foreach (Person person in people) Itens.Add(person); }

            TextSearch = null;
        }
        public void OpenSave(object obj)
        {
            PersonInsert insert = new PersonInsert();
            insert.Show();
        }

        public void OpenUpdate(object obj)
        {
            MainVM.update = true;

            if (SelectedRow != null)
            {
                InsertVM.id = SelectedRow.Id;

                PersonInsert update = new PersonInsert();
                update.Show();
            }
            else
            {
                Alert panel = new Alert("Selecione um registro.");
                panel.Show();
            }  
        }

        public void Delete(object obj)
        {
            if (SelectedRow != null)
            {
                Person person = SelectedRow;
                _control.Delete(person.Id);
            }
            else
            {
                Alert panel = new Alert("Selecione um registro.");
                panel.Show();
            }
            this.Find(new object { });
        } 
    }
}
