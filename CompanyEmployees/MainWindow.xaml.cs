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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        vEmployee vEmployee = new vEmployee();
        vDepartment vDepartment = new vDepartment();

        public MainWindow()
        {
            InitializeComponent();

            //Загрузка классов обслуживания
            Helper helper = new Helper(this, vEmployee, vDepartment);
            //helper.LoadXML(true);
            helper.LoadDB(true);
            //Загрузка классов обслуживания

            //Команды контролов
            CbDepartment.SelectionChanged += (s, e) => { helper.FilterEmployees(CbDepartment.SelectedItem as Department); };
            CbDepartmentSet.SelectionChanged += (s, e) => { helper.SetDepartment(CbDepartmentSet.SelectedItem as Department, DgEmployee.SelectedItems.Cast<Employee>().ToList<Employee>()); };

            BtnAddNewEmployee.Click += (s, e) => { helper.AddNewEmployee(CbDepartment.SelectedItem as Department); };
            BtnRemoveEmployee.Click += (s, e) => { helper.RemoveRangeEmployee(DgEmployee.SelectedItems.Cast<Employee>().ToList<Employee>()); };
            BtnSelectDepartment.Click += (s, e) => { helper.OpenWinSelDepartments(DgEmployee.SelectedItem as Employee); };
            BtnDepartmentsEdit.Click += (s, e) => { helper.OpenWinEditDepartments(); };
            BtnSaveDB.Click += (s, e) => { helper.SaveDb(false); };
            BtnSaveCurDB.Click += (s, e) => { helper.SaveDb(true); };
            BtnSerializeOpenDB.Click += (s, e) => { helper.LoadDB(false); };
            //ActionSaveAndLoadDB
            BtnResetFilter.Click += (s, e) => { helper.ResetFilter(); };
            //Команды контролов

            //Реакция главного окна
            this.Closing += (s, e) => { { helper.SaveDb(true); } };
            //Реакция главного окна

            //Заполнение контролов главного окна
            CbDepartment.ItemsSource = vDepartment.departments;
            helper.FilterEmployees(null);
            //if (vDepartment.departments.Count != 0) { CbDepartment.SelectedIndex = 0; }
            CbDepartmentSet.ItemsSource = vDepartment.departments;
            //Заполнение контролов главного окна
             
        }
    }
}
