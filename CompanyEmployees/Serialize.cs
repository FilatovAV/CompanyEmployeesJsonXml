using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    [Serializable]
    public class Serialize
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

        public Serialize()
        {
        }
        public Serialize(ObservableCollection<Employee> employees, ObservableCollection<Department> departments)
        {
            Employees = employees.ToList<Employee>();
            Departments = departments.ToList<Department>();
        }
    }
}
