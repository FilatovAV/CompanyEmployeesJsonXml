using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    /// <summary>
    /// Класс данных, обслуживает коллекцию сотрудников
    /// </summary>
    public class vEmployee
    {
        /// <summary>
        /// Коллекция сотрудников, служит для заполнения контролов (в том числе для фильтрации)
        /// </summary>
        public ObservableCollection<Employee> employees { get; set; }
        /// <summary>
        /// Конструктор инициализации коллекции сотрудников
        /// </summary>
        public vEmployee()
        {
            employees = new ObservableCollection<Employee>();
        }
        /// <summary>
        /// Добавление сотрудника в коллекцию
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void AddRangeEmployee(List<Employee> emps, bool clear)
        {
            if (clear) { employees.Clear(); }
            foreach (Employee item in emps)
            {
                AddEmployee(item);
            }
        }
        /// <summary>
        /// Удаление сотрудника из коллекции
        /// </summary>
        /// <param name="employee"></param>
        public void RemoveEmploee(Employee employee)
        {
            employees.Remove(employee);
        }
        /// <summary>
        /// Удаление списка сотрудников из коллекции
        /// </summary>
        /// <param name="employee"></param>
        public void RemoveRangeEmploees(IList<Employee> emps)
        {
            foreach (Employee item in emps)
            {
                RemoveEmploee(item);
            }
        }
        /// <summary>
        /// Сравнение сотрудников (не задействовано)
        /// </summary>
        /// <param name="employee"></param>
        public void RenameEmploee(Employee employee)
        {
            Employee emp = employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (emp!=null) { emp.Name = employee.Name; }
        }
    }
}
