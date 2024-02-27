using Crud_Cs.Services;
using Crud_Cs.src.control;
using Crud_Cs.src.view;
using Crud_Cs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crud_Cs.src.ViewModels
{
    class InsertVM : BaseVM
    {
        private PersonInsert personInsert;
        public static int id { get; set; }

        public ICommand SaveCommand { get; set; }

        public string TextName { get; set; }
        public string TextLastName { get; set; }
        public string TextDocument { get; set; }
        public string TextAge { get; set; }
        public string TextPhoneNumber { get; set; }
        public string TextAddress { get; set; }
        public DateTime TextBirthDate { get; set; }

        public string ButtonText { get; set; }

        private PersonController _control;

        public InsertVM(PersonInsert personInsert)
        {
            this.personInsert = personInsert;
            TextBirthDate = DateTime.Now;
            _control = MainVM._control;

            if (MainVM.update)
            {
                ButtonText = "Atualizar";
                SaveCommand = new DelegateCommand(Update);

                try {
                    Person pessoa = _control.Find(id);

                    TextName = pessoa.Name;
                    TextLastName = pessoa.LastName;
                    TextDocument = pessoa.Document;
                    TextAge = pessoa.Age.ToString();
                    TextPhoneNumber = pessoa.PhoneNumber;
                    TextAddress = pessoa.Address;
                    TextBirthDate = pessoa.BirthDate;
                }
                catch(Exception err)
                {
                    Alert panel = new Alert(err.Message);
                    panel.Show();
                }
            }
            else
            {
                ButtonText = "Salvar";
                SaveCommand = new DelegateCommand(Save);
            }
        }

        public void Save(object obj)
        {
            bool error = false;

            try
            {
                _control.Create(TextName, TextLastName, TextDocument, TextAddress, Int32.Parse(TextAge), TextPhoneNumber, TextBirthDate);
            }
            catch(Exception err)
            {
                Alert panel = new Alert(err.Message);
                panel.Show();
                error = true;
            }
            if(!error) personInsert.Close();
        }

        public void Update(object obj)
        {
            try
            { 
                _control.Update(id, TextName, TextLastName, TextDocument, TextAddress, Int32.Parse(TextAge), TextPhoneNumber, TextBirthDate);
                MainVM.update = false;
            }
            catch(Exception err)
            {
                Alert panel = new Alert(err.Message);
                panel.Show();
            }

            personInsert.Close();
        }
    }
}
