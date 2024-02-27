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
    class AlertVM : BaseVM
    {
        public string Message { get; set; }

        public AlertVM(string message)
        {
            Message = message;
        }
    }
}