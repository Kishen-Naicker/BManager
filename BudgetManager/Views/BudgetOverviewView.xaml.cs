using System.Windows;
using System.Windows.Controls;

namespace BudgetManager.Views
{
    /// <summary>
    /// Interaction logic for BudgetOverviewView.xaml
    /// </summary>
    public partial class BudgetOverviewView : Window
    {
        public BudgetOverviewView()
        {
            InitializeComponent();
        }

        private void printTb_Click(object sender, RoutedEventArgs e)
        {
            //allows the user to print out their overview and/or save it as a pdf file
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(print, "Budget Overview");
            }
        }
    }
}
