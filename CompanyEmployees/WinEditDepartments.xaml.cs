using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для WinEditDepartments.xaml
    /// </summary>
    public partial class WinEditDepartments : Window
    {
        /// <summary>
        /// Инициализируем окно и передаемв в него типы обслуживания и коллекцию данных
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="helper"></param>
        public WinEditDepartments(Helper helper)
        {
            InitializeComponent();

            //Реакция контролов
            BtnRemoveDepartment.Click += (s, e) => { { helper.RemoveDepartment(DgDepartments.SelectedItem as Department); } };
            BtnAddNewDepartment.Click += (s, e) => { { helper.AddNewDepartment(); } };
            BtnOk.Click += (s, e) => { { DialogResult = true; } };
            //Реакция контролов

            //Заполнение контрорлов данными
            DgDepartments.ItemsSource = helper.GetDepartments();
            //Заполнение контрорлов данными
        }
    }
}
