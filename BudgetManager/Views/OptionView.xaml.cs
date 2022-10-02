using System.Windows;

namespace BudgetManager.Views
{
    /// <summary>
    /// Interaction logic for OptionView.xaml
    /// </summary>
    public partial class OptionView : Window
    {
        public OptionView()
        {
            InitializeComponent();
        }

        private void BudgetBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the option view and opens the budget view when the button is clicked
            BudgetView budgetView = new BudgetView();
            this.Close();
            budgetView.Show();
        }

        private void SavingPlanBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the option view and opens the savings plan view when the button is clicked
            SavingPlanView savingPlanView = new SavingPlanView();
            this.Close();
            savingPlanView.Show();
        }
    }
}
