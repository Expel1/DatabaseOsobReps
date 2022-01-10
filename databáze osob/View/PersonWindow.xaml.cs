using System.Windows;
using PersonDatabase.Model;
using PersonDatabase.ViewModel;
using PersonDatabase.View;

namespace PersonDatabase.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        
        public PersonWindowViewModel ViewModel { get; set; }
        public PersonWindow(Person toDisplay)
        {
            InitializeComponent();
            ViewModel = new PersonWindowViewModel(toDisplay);
            DataContext = ViewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCommand.Execute(sender);
            if (ViewModel.Clicked)
            {
                Close();
            }
        }
    }
}
