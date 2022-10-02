using BudgetManager.SavingsPlan;
using System.Windows;
using System.Windows.Controls;

namespace BudgetManager.Views
{
    /// <summary>
    /// Interaction logic for SavingPlanView.xaml
    /// </summary>
    public partial class SavingPlanView : Window
    {
        private static double userInput = 0;

        //object of the saving plan class found in the SavingsPlan folder 
        SavingPlan savingsPlan = new SavingPlan("", userInput, userInput, userInput);

        public SavingPlanView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //sets the data context for the textboxes when the window is loaded
            reasonTb.DataContext = savingsPlan;
            savingAmountTb.DataContext = savingsPlan;
            interestTb.DataContext = savingsPlan;
            yearTb.DataContext = savingsPlan;
        }


        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            //populates the output textblocks after the user has finished entering their information and when the button is clicked
            reasonOutTb.Text = "Reason for saving: " + savingsPlan.SavingsReason;
            amountOutTb.Text = "Amount to save: " + savingsPlan.Amount.ToString("C2");
            interestOutTb.Text = "Interest Rate: " + savingsPlan.SavingsIR + "%";
            yearsTb.Text = "Years to save over: " + savingsPlan.Years;
            savingOutputTb.Text = "Monthly Savings Needed: " + savingsPlan.MonthlySavings().ToString("C2");
        }
     
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the current view and opens the option view
            OptionView optionView = new OptionView();
            this.Close();
            optionView.Show();
        }

        private void NumberError(object sender, ValidationErrorEventArgs e)
        {
            //validates the user input --> makes sure a numerical value is entered and not a string value
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ToolTip = "Must be numerical";
            }
        }

    }
}
