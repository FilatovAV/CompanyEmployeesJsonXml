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
    /// Логика взаимодействия для WinSelDepartments.xaml
    /// </summary>
    public partial class WinSelDepartments : Window
    {
        public Department SelDepartment { get; set; }

        public WinSelDepartments(Helper helper, Department curDepartment)
        {
            InitializeComponent();

            //Заполнение контролов данными
            LbDepartments.ItemsSource = helper.GetDepartments();
            LbDepartments.SelectedItem = curDepartment;
            //Заполнение контролов данными

            //Реакция контролов
            BtnOk.Click += BtnOk_Click;
            BtnCancel.Click += (s, e) => { { DialogResult = false; } };
            //Реакция контролов
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            SelDepartment = LbDepartments.SelectedItem as Department;
            DialogResult = true;
        }
    }
}
