using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    [Serializable]
    public class Employee : IEquatable<Employee>, INotifyPropertyChanged
    {
        public Employee()
        {
        }
        /// <summary>
        /// Сущность - служащий
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeName"></param>
        /// <param name="employeeAge"></param>
        /// <param name="employeeSalary"></param>
        /// <param name="employeeDepartmentId"></param>
        public Employee(int employeeId, string employeeName, int employeeAge,
            double employeeSalary, int employeeDepartmentId, Department department)
        {
            Id = employeeId;
            Name = employeeName;
            Age = employeeAge;
            Salary = employeeSalary;
            DepartmentId = employeeDepartmentId;
            Department = department;
        }

        int m_Id;
        public int Id{ get { return m_Id; } set { m_Id = value; OnPropertyChanged(); } }
        string m_Name;
        public string Name { get { return m_Name; } set { m_Name = value; OnPropertyChanged(); } }

        int m_Age;
        public int Age { get { return m_Age; } set { m_Age = value; OnPropertyChanged(); } }

        double m_Salary;
        public double Salary { get { return m_Salary; } set { m_Salary = value; OnPropertyChanged(); } }

        int m_DepartmentId;
        public int DepartmentId
        {
            get
            {
                return m_DepartmentId;
            }
            set
            {
                m_DepartmentId = value;
                OnPropertyChanged();
            }
        }

        public Department Department
        {
            get
            {
                return m_Department;
            }
            set
            {
                m_Department = value;
                OnPropertyChanged();
            }
        }
        private Department m_Department;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        bool IEquatable<Employee>.Equals(Employee other)
        {
            return this.Id == other.Id;
        }
    }
    }
