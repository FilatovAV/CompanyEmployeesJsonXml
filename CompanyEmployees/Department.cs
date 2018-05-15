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
    public class Department : IEquatable<Department>, INotifyPropertyChanged
    {
        public Department()
        {
        }
        /// <summary>
        /// Сущность - отдел
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentName"></param>
        public Department(int departmentId, string departmentName)
        {
            Id = departmentId;
            Name = departmentName;
        }

        public int Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                OnPropertyChanged();
            }
        }
        int m_Id;
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
                OnPropertyChanged();
            }
        }
        string m_Name;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        bool IEquatable<Department>.Equals(Department other)
        {
            //return Id == other.Id &&
            //        Name == other.Name;
            return Id == other.Id && Name == other.Name;
        }
    }
    }
