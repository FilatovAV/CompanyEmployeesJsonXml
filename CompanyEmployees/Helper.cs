using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Xml.Serialization;

namespace CompanyEmployees
{
    /// <summary>
    /// Класс обслуживания работает с классами данных и окнами приложения
    /// </summary>
    public class Helper
    {
        const string jsonExt = ".json";
        const string xmlExt = ".xml";

        vEmployee vEmployee;
        vDepartment vDepartment;

        /// <summary>
        /// Главное окно программы
        /// </summary>
        MainWindow win;
        /// <summary>
        /// Окно выбора департаментов
        /// </summary>
        WinSelDepartments winSelDep;

        /// <summary>
        /// Конструктор, принимает главное окно и классы обслуживающие коллекции сущностей
        /// </summary>
        /// <param name="winM"></param>
        /// <param name="employee"></param>
        /// <param name="department"></param>
        public Helper(MainWindow winM, vEmployee employee, vDepartment department)
        {
            vEmployee = employee;
            vDepartment = department;
            win = winM;
        }

        #region Добавление, удаление, редактирование и фильтрация данных (сущностей)
        /// <summary>
        /// Возвращаем действующую коллекцию отделов
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Department> GetDepartments()
        {
            return vDepartment.departments;
        }
        /// <summary>
        /// Добавление новой сущности сотрудник в коллекцию
        /// </summary>
        /// <param name="department"></param>
        public void AddNewEmployee(Department department)
        {
            //if (department == null) return;
            if (department == null)
            {
                WinSelDepartments selDep = new WinSelDepartments(this, null);
                selDep.ShowDialog();

                if (selDep.DialogResult==false) { return; }
                
                department = selDep.LbDepartments.SelectedItem as Department;
                if (department == null) { return; }
            }

            Employee nEmp = new Employee(vEmployee.employees.Count, "", 0, 0, department.Id, department);
            vEmployee.AddEmployee(nEmp);
            FilterEmployees(win.CbDepartment.SelectedItem as Department);
            win.DgEmployee.SelectedItem = nEmp;
        }
        /// <summary>
        /// Добавление сущности отдел в коллекцию
        /// </summary>
        public void AddNewDepartment()
        {
            vDepartment.AddDepartment(new Department(vDepartment.departments.Count, string.Empty));
        }
        /// <summary>
        /// Удаление сущности сотрудник из коллекции
        /// </summary>
        /// <param name="employee"></param>
        public void RemoveEmployee(Employee employee)
        {
            if (employee == null) return;
            Employee e = vEmployee.employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (e == null) return;
            vEmployee.employees.Remove(e);
            FilterEmployees(win.CbDepartment.SelectedItem as Department);
        }
        /// <summary>
        /// Удаление сущностей сотрудник из коллекции
        /// </summary>
        /// <param name="employee"></param>
        public void RemoveRangeEmployee(List<Employee> iEmployees)
        {
            if (iEmployees == null) return;
            vEmployee.RemoveRangeEmploees(iEmployees);
            FilterEmployees(win.CbDepartment.SelectedItem as Department);
        }
        /// <summary>
        /// Фильтрация сотрудников по отделам (парралельно производится сохранение изменений в массиве vEmployee.employees)
        /// </summary>
        public void FilterEmployees(Department department)
        {
            //Department department = win.CbDepartment.SelectedItem as Department;
            win.DgEmployee.ItemsSource = null;
            if (department == null) { win.DgEmployee.ItemsSource = vEmployee.employees; return; }
            win.DgEmployee.ItemsSource = vEmployee.employees.Where(x => x.DepartmentId == department.Id).ToList<Employee>();
        }
        /// <summary>
        /// Сброс фильтра
        /// </summary>
        public void ResetFilter()
        {
            win.CbDepartment.SelectedItem = null;
        }
        /// <summary>
        /// Удаление отдела из коллекции
        /// </summary>
        /// <param name="department"></param>
        public void RemoveDepartment(Department department)
        {
            if (department == null) return;
            List<Employee> eml = vEmployee.employees.Where(e => e.DepartmentId == department.Id).ToList<Employee>();
            for (int i = eml.Count-1; i >= 0; i--)
            {
                vEmployee.RemoveEmploee(eml[i]);
            }

            vDepartment.departments.Remove(department);
            FilterEmployees(win.CbDepartment.SelectedItem as Department);
        }
        /// <summary>
        /// Изменяем отдел в котором работает сотрудник
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="emps"></param>
        //public void SetDepartment(Department dep, Employee emp)
        //{
        //    if (dep == null || emp == null) { return; }
        //    if (emp.DepartmentId != dep.Id)
        //    {
        //        emp.DepartmentId = dep.Id;
        //        FilterEmployees(win.CbDepartment.SelectedItem as Department);
        //    }
        //}
        //public bool btnClick { get; set; }
        public void SetDepartment(Department dep, List<Employee> emps)
        {
            if (dep == null || emps == null) { return; }
            if (emps.Count == 0) { return; }
            if (emps[0].DepartmentId != dep.Id)
            {
                foreach (Employee item in emps)
                {
                    item.DepartmentId = dep.Id;
                    item.Department = dep;
                }
                FilterEmployees(win.CbDepartment.SelectedItem as Department);
            }
            win.CbDepartmentSet.SelectedItem = null;
        }
        #endregion

        #region Работа с окнами приложения
        /// <summary>
        /// Открытие окна редактирования отделов
        /// </summary>
        public void OpenWinEditDepartments()
        {
            WinEditDepartments wed = new WinEditDepartments(this) { Owner = win };
            wed.ShowDialog();
            FilterEmployees(win.CbDepartment.SelectedItem as Department);
        }
        /// <summary>
        /// Открытие окна выбора отдела для сотрудника
        /// </summary>
        /// <param name="employee"></param>
        public void OpenWinSelDepartments(Employee employee)
        {
            if (employee == null) { MessageBox.Show("Необходимо выбрать сотрудника!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation); return; }
            Department EmpDep = vDepartment.departments.Where(x => x.Id == employee.DepartmentId).FirstOrDefault();
            winSelDep = new WinSelDepartments(this, EmpDep) { Owner = win };
            winSelDep.ShowDialog();
            if (winSelDep.DialogResult == true)
            {
                Department department = winSelDep.SelDepartment;
                employee.DepartmentId = department.Id;
                FilterEmployees(win.CbDepartment.SelectedItem as Department);
            }
        }
        /// <summary>
        /// Выбор файла данных для загрузки
        /// </summary>
        /// <returns></returns>
        public string GetOpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = $"Формат XML|*{xmlExt}|Формат JSON|*{jsonExt}";
            openFile.FilterIndex = GetFilterIndex();
            openFile.FileName = Path.GetFileName(Properties.Settings.Default.FileName);
            openFile.InitialDirectory = System.IO.Path.GetDirectoryName(Properties.Settings.Default.FileName);
            Nullable<bool> result = openFile.ShowDialog();
            if (result == true)
            {
                return openFile.FileName;
            }
            return string.Empty;
        }
        /// <summary>
        /// Получение имени файла для сохранение данных
        /// </summary>
        /// <returns></returns>
        public string GetSaveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = $"Формат XML|*{xmlExt}|Формат JSON|*{jsonExt}";

            saveFile.FilterIndex = GetFilterIndex();

            saveFile.FileName = Path.GetFileName(Properties.Settings.Default.FileName);

            saveFile.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.FileName);
            Nullable<bool> result = saveFile.ShowDialog();
            if (result == true)
            {
                return saveFile.FileName;
            }
            return string.Empty;
        }
        /// <summary>
        /// Получаем индекс для фильтрации диалога
        /// </summary>
        /// <returns></returns>
        private static int GetFilterIndex()
        {
            switch (Path.GetExtension(Properties.Settings.Default.FileName.ToLower()))
            {
                case xmlExt:
                    return 1;
                case jsonExt:
                    return 2;
                default:
                    return 1;
            }
        }
        #endregion

        #region Сериализация данных
        /// <summary>
        /// Список для сериализации XML
        /// </summary>
        public List<Serialize> List { get; set; }
        /// <summary>
        /// Сохранение XML файла
        /// </summary>
        /// <param name="saveDefault"></param>
        public void SaveXML()
        {
            Serialize serialize = new Serialize(vEmployee.employees, vDepartment.departments);
            List = new List<Serialize>();
            List.Add(serialize);
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Serialize>));
            Stream fStream = new FileStream(Properties.Settings.Default.FileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, List);
            fStream.Close();
        }
        /// <summary>
        /// Загрузка XML файла
        /// </summary>
        public void LoadXML()
        {
            if (!System.IO.File.Exists(Properties.Settings.Default.FileName))
            {
                MessageBoxResult msr = MessageBox.Show($"Файл базы данных не найден!\nХотите указать местоположение файла?\n\n{Properties.Settings.Default.FileName}", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (msr== MessageBoxResult.Yes) { LoadDB(false); }
            }
            win.Title = $"XML база данных - {Path.GetFileName(Properties.Settings.Default.FileName)}";

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Serialize>));
            Stream fStream = new FileStream(Properties.Settings.Default.FileName, FileMode.Open, FileAccess.Read);
            List<Serialize> les = (List<Serialize>)xmlFormat.Deserialize(fStream);

            vDepartment.AddRangeDepartment(les[0].Departments, true);
            vEmployee.AddRangeEmployee(les[0].Employees, true);

            fStream.Close();
        }
        /// <summary>
        /// Загрузка базы данных с определением формата
        /// </summary>
        /// <param name="AsDefault"></param>
        public void LoadDB(bool AsDefault)
        {
            if (!AsDefault)
            {
                string pathToFile = GetOpenFile();
                if (string.IsNullOrEmpty(pathToFile)) { return; }
                Properties.Settings.Default.FileName = pathToFile;
                Properties.Settings.Default.Save();
            }

            if (System.IO.Path.GetExtension(Properties.Settings.Default.FileName).ToLower()==".xml")
            {
                LoadXML();
            }
            if (System.IO.Path.GetExtension(Properties.Settings.Default.FileName).ToLower() == ".json")
            {
                JSONDeSerialize();
            }
        }
        /// <summary>
        /// Сохранение с выбором формата данных
        /// </summary>
        /// <param name="AsDefault"></param>
        public void SaveDb(bool AsDefault)
        {
            if (!AsDefault)
            {
                string pathToFile = GetSaveFile();
                if (string.IsNullOrEmpty(pathToFile)) { return; }
                Properties.Settings.Default.FileName = pathToFile;
                Properties.Settings.Default.Save();
            }

            if (System.IO.Path.GetExtension(Properties.Settings.Default.FileName).ToLower() == ".xml")
            {
                SaveXML();
            }
            if (System.IO.Path.GetExtension(Properties.Settings.Default.FileName).ToLower() == ".json")
            {
                JSONSerialize();
            }
        }
        /// <summary>
        /// Сохранение JSON файла
        /// </summary>
        public void JSONSerialize()
        {
            Serialize serialize = new Serialize(vEmployee.employees, vDepartment.departments);
            List = new List<Serialize>();
            List.Add(serialize);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(List);

            //получить доступ к  существующему либо создать новый
            StreamWriter file = new StreamWriter(Properties.Settings.Default.FileName);
            //записать в него
            file.Write(json);
            //закрыть для сохранения данных
            file.Close();

            win.Title = $"JSON база данных - {Path.GetFileName(Properties.Settings.Default.FileName)}";
        }
        /// <summary>
        /// Открытие JSON файла
        /// </summary>
        /// <param name="loadDefault"></param>
        public void JSONDeSerialize()
        {
            win.Title = $"JSON база данных - {Path.GetFileName(Properties.Settings.Default.FileName)}";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            using (StreamReader sr = new StreamReader(Properties.Settings.Default.FileName))
            {
                string s = sr.ReadToEnd();
                List<Serialize> ser = serializer.Deserialize<List<Serialize>>(s);
                vDepartment.AddRangeDepartment(ser[0].Departments, true);
                vEmployee.AddRangeEmployee(ser[0].Employees, true);
            }
        }
        #endregion
    }
}
