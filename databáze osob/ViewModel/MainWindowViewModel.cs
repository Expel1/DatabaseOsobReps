using GalaSoft.MvvmLight.Command;
using PersonDatabase.Model;
using PersonDatabase.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonDatabase.ViewModel
{
    public class MainWindowViewModel
    {
        public static ObservableCollection<Person> PersonList
        {
            get;
            set;
        } = new ObservableCollection<Person>();
        public MainWindowViewModel()
        {
            PersonList.Add(new Person("Pavel", "Novák", "789456/1232", new DateTime(1999, 5, 16)));
            PersonList.Add(new Person("Marek", "Apríl", "123456/9845", new DateTime(2011, 4, 1)));
        }
        private static ICommand addCommand;
        public ICommand AddCommand// Add button v MainWindow
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(
                        () =>
                        {
                            PersonWindow newPersonWin = new PersonWindow(new Person());
                            newPersonWin.ShowDialog();
                            if (newPersonWin.ViewModel.Clicked)
                            {
                                PersonList.Add(newPersonWin.ViewModel.Displayed);
                            }
                        });

                }
                return addCommand;
            }

        }
        private static ICommand editCommand;
        public static Person Selected { get; set; }
        public static ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(
                        () =>
                        {
                            PersonWindow newPersonWin = new PersonWindow(Selected);
                            newPersonWin.ShowDialog();
                            if (newPersonWin.ViewModel.Clicked)
                            {
                                PersonList[PersonList.IndexOf(Selected)] = newPersonWin.ViewModel.Displayed;
                            }
                        });

                }
                return editCommand;
            }

        }
        private static ICommand deleteCommand;
        public static ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        () =>
                        {
                            PersonList.Remove(Selected);
                        });

                }
                return deleteCommand;
            }

        }
    }
}
