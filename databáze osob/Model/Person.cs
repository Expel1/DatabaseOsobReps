using PersonDatabase.ViewModel;
using System;
using System.Windows.Input;

namespace PersonDatabase.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PIN { get; set; }
        public DateTime BirthDate;
        public string BirthDateText { get; set; }
        public string BirthDateInText { get { return BirthDate.ToString(); } }
        public static Person Selected { get { return MainWindowViewModel.Selected; } set { MainWindowViewModel.Selected = value; } }
        public static ICommand EditCommand { get { return MainWindowViewModel.EditCommand; } }
        public static ICommand DeleteCommand { get { return MainWindowViewModel.DeleteCommand; } }
        public Person() { }
        public Person(string _Name, string _Surname, string _PIN, DateTime _BirthDate)
        {
            Name = _Name;
            Surname = _Surname;
            PIN = _PIN;
            BirthDate = _BirthDate;
        }
    }
}
