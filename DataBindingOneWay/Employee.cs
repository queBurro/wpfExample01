using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneWay
{
    class Employee : INotifyPropertyChanged
    {
        private string _employee;
        public string EmployeeNameProperty {
            get { return _employee; }
            set { _employee = value; OnPropertyChanged("EmployeeNameProperty"); }
        }

        private string _title;
        public string TitleProp {
            get { return _title; }
            set { _title = value; OnPropertyChanged("TitleProp"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            var ev = PropertyChanged;
            if (ev != null) ev(this, new PropertyChangedEventArgs(name));
        }

        public static Employee GetEmployee()
        {//get an instance from somewhere from db or webservice
            var emp = new Employee()
            {
                EmployeeNameProperty = "Tom",
                TitleProp = "developer"
            };

            return emp;
        }
    }
}
