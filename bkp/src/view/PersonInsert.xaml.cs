using Crud_Cs.src.ViewModels;
using Crud_Cs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crud_Cs.src.view
{
    /// <summary>
    /// Interaction logic for PersonInsert.xaml
    /// </summary>
    public partial class PersonInsert : Window
    {
        public PersonInsert()
        {
            InitializeComponent();
            this.DataContext = new InsertVM(this);
        }
    }
}
