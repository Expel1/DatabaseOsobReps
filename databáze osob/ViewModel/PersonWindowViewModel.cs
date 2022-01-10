using GalaSoft.MvvmLight.Command;
using PersonDatabase.Interfaces;
using PersonDatabase.Model;
using PersonDatabase.Validators;
using System;
using System.Windows;
using System.Windows.Input;

namespace PersonDatabase.ViewModel
{
    public class PersonWindowViewModel
    {
        public bool Clicked = false;
        public Person Displayed { get; set; }
        IStringValidator nameValidator = new NameValidator();
        IStringValidator surnameValidator = new SurnameValidator();
        IStringValidator pinValidator = new PINValidator();
        IDateTimeValidator dateOfBirthValidator = new DateOfBirthValidator();

        public string Name
        {
            get { return Displayed.Name; }
            set { Displayed.Name = value; }
        }
        public string Surname
        {
            get { return Displayed.Surname; }
            set { Displayed.Surname = value; }
        }
        public string PIN
        {
            get { return Displayed.PIN; }
            set { Displayed.PIN = value; }
        }
        public string BirthDateText
        {
            get { return Displayed.BirthDateText; }
            set { Displayed.BirthDateText = value; }
        }


        public PersonWindowViewModel(Person toDisplay, IStringValidator NameValidator, IStringValidator SurnameValidator, IStringValidator PinValidator, IDateTimeValidator DateOfBirthValidator)
        {
            Displayed = toDisplay;
            nameValidator = NameValidator;
            surnameValidator = SurnameValidator;
            pinValidator = PinValidator;
            dateOfBirthValidator = DateOfBirthValidator;
        }
        public PersonWindowViewModel(Person toDisplay)
        {
            Displayed = toDisplay;
        }
        private static ICommand addCommand;
        public ICommand AddCommand// Add button v PersonWin
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(
                        () =>
                        {
                            string sb = "";
                            if (!nameValidator.IsValid(Name)) { sb += "špatné jméno\n"; }
                            if (!surnameValidator.IsValid(Surname)) { sb += "špatné příjmení\n"; }
                            if (!pinValidator.IsValid(PIN)) { sb += "špatné rodné číslo\n"; }
                            if (!DateTime.TryParse(BirthDateText, out Displayed.BirthDate)) { sb += "nesprávný formát data narození\n"; }
                            else if (!dateOfBirthValidator.IsValid(Displayed.BirthDate)) { sb += "datum narození neodpovídá kritériím\n"; }
                            if (sb == "")
                            {
                                Clicked = true;
                            }
                            else
                            {
                                MessageBox.Show(sb);
                            }
                        });

                }
                return addCommand;
            }

        }
    }
}
