using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    /// <summary>
    /// Класс данных, обслуживает коллекцию отделов
    /// </summary>
    public class vDepartment
    {
        /// <summary>
        /// Коллекция отделов, служит заполнением контролов
        /// </summary>
        public ObservableCollection<Department> departments { get; set; }
        /// <summary>
        /// Конструктор инициализации коллекции отделов
        /// </summary>
        public vDepartment()
        {
            departments = new ObservableCollection<Department>();
        }
        /// <summary>
        /// Добавление отдела
        /// </summary>
        /// <param name="department"></param>
        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }
        public void AddRangeDepartment(List<Department> departmentsAdd, bool clear)
        {
            if (clear) { departments.Clear(); }
            foreach (Department item in departmentsAdd)
            {
                AddDepartment(item);
            }
        }
        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="department"></param>
        public void RemoveDepartment(Department department)
        {
            departments.Remove(department);
        }
        /// <summary>
        /// Сравнение отделов (не используется)
        /// </summary>
        /// <param name="department"></param>
        public void RenameDepartment(Department department)
        {
            Department dp = departments.Where(x => x.Id == department.Id).FirstOrDefault();
            if (dp != null) { dp.Name = department.Name; }
        }

    }
}
