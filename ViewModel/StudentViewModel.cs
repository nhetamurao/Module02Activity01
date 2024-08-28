using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    
    public class StudentViewModel :INotifyPropertyChanged
    {
        //Role of ViewModel 
        private Student _student;

        //variable for data conversion
        private string _fullname;

        //will represent the entire Model
        public StudentViewModel()
        {
            //Initializing a sample student model. Coordination with Model
            _student = new Student { FirstName = "John", LastName = "Cena", Age = 23 };

            //UI THREAD MANAGEMENT
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());


            Students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Jane", LastName = "Smith", Age = 23},
                new Student {FirstName = "James", LastName = "Bond", Age = 18},
                new Student {FirstName = "Alice", LastName = "Guo", Age = 25}
            };
        }

        //setting collection in public
        public ObservableCollection<Student> Students { get; set; }

        //Two-Way DATA BINDING
        public string FullName
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI THREAD MANAGEMENT
        public ICommand LoadStudentDataCommand { get; }

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); //I/0 operation

            FullName = $"{_student.FirstName} {_student.LastName}"; ///Data Conversion
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
