using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArrayFuncties_3___Medewerkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] employees = new string[3] { "Kristof", "Sander", "Koen" };
        string[] employeeNumbers = new string[3] { "M01", "M02", "M03" };
        decimal[] salaries = new decimal[3] { 0, 0, 0 };

        public MainWindow()
        {
            InitializeComponent();
            Output();
        }

        private void Output()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employeesListBox.Items.Add($"{employeeNumbers[i]} - {employees[i]} - {salaries[i]:C}");
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SalaryTextBox.Text, out int salaris))
            {
                salaries[employeesListBox.SelectedIndex] = salaris;
                SalaryTextBox.IsEnabled = false;
                updateButton.IsEnabled = false;
                errorLabel.Content = "Geen error";
                errorLabel.Foreground = Brushes.Black;
                //Ofwel Uitvoer() terug oproepen
                //Uitvoer();
                //Ofwel huidige rij overschrijven
                employeesListBox.Items[employeesListBox.SelectedIndex] = $"{employeeNumbers[employeesListBox.SelectedIndex]} - {employees[employeesListBox.SelectedIndex]} - {salaries[employeesListBox.SelectedIndex]:C2}";
                //En dan nog beter een aparte method maken die ook in Uitvoer() kan gebruikt worden
            }
            else
            {
                errorLabel.Content = "Kan tekst niet omzetten naar salaris";
                //errorLabel.Foreground = Brushes.Red;
            }
        }

        private void employeesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeesListBox.SelectedIndex != -1)
            {
                //Eerst tonen zonder Currency formatting
                SalaryTextBox.Text = salaries[employeesListBox.SelectedIndex].ToString("C");
                SalaryTextBox.IsEnabled = true;
                updateButton.IsEnabled = true;
                //Optioneel
                SalaryTextBox.Focus();
            }
        }

        //Optioneel
        private void SalaryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SalaryTextBox.SelectAll();
        }
    }
}
