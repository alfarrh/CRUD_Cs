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
        public ICommand SaveCommand { get; set; }

        public string TextName { get; set; }
        public string TextLastName { get; set; }
        public string TextDocument { get; set; }
        public string TextAge { get; set; }
        public string TextPhoneNumber { get; set; }
        public string TextAddress { get; set; }
        public DateTime TextBirthDate { get; set; }

        private PersonController _control;
        public InsertVM(PersonInsert personInsert)
        {
            this.personInsert = personInsert;
            SaveCommand = new DelegateCommand(Save);
            TextBirthDate = DateTime.Now;
            _control = new PersonController();
        }

        public void Save(object obj)
        {
            _control.Create(TextName, TextLastName, TextDocument, TextAddress, Int32.Parse(TextAge), TextPhoneNumber, TextBirthDate);
            personInsert.Close();
        }
    }
}
