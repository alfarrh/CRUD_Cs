using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Crud_Cs.Services;
using Crud_Cs.ViewModels;

namespace Crud_Cs.ViewModels
{
    class MainVM : BaseVM
    {
        public MainVM()
        {
            SaveCommand = new DelegateCommand(Save, CanSave);
        }

        private bool CanSave(object arg)
        {
            if (string.IsNullOrEmpty(WritedText))
            {
                return false;
            }
            return true;
        }

        private void Save(object obj)
        {
            WritedText = "Save ok";
            OnPropertyChanged(nameof(WritedText));
        }

        public ICommand SaveCommand { get; set; }

        public bool IsChecked { get; set; }

        public string WritedText { get; set; }
    }
}
