using BudgetManager.Expenses;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetManager.Views
{
    /// <summary>
    /// Interaction logic for BudgetView.xaml
    /// </summary>

    /*Delegate used to:
     *  --> notifies the user when expenses exceed 75% of the income
     *  --> notifies the user that the approval of the home loan is unlikely if its 1/3 of the income
     */
    public delegate string NotificationDelegate(string expenseNotificaton);

    public partial class BudgetView : Window
    {
        private static double userInput = 0, totalExpense = 0, incomeBalance;

        //objects of all classes found in the expense folder
        //all classes hold properties for their respective purposes
        Income income = new Income(userInput);
        Tax tax = new Tax(userInput);
        GeneralExpenses generalExpenses = new GeneralExpenses(userInput, userInput, userInput, userInput, userInput);
        Rent rent = new Rent(userInput);
        HomeLoan homeLoan = new HomeLoan(userInput, userInput, userInput, userInput);
        Vehicle vehicle = new Vehicle("", userInput, userInput, userInput, userInput);

        public BudgetView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //senting the data content to the textboxes according to their respective class variables
            //sets the data context the moment the window is loaded (opened)

            incomeTb.DataContext = income;

            taxtTb.DataContext = tax;

            groceriesTb.DataContext = generalExpenses;
            waterAndLightsTb.DataContext = generalExpenses;
            travelTb.DataContext = generalExpenses;
            cellularTb.DataContext = generalExpenses;
            otherTb.DataContext = generalExpenses;

        }



        #region Checkbuttons --> Checked and Unchecked events
        private void rentCb_Checked(object sender, RoutedEventArgs e)
        {
            rentingTb.IsEnabled = true;
            propertyCb.IsChecked = false;
            rentingTb.DataContext = rent;
        }

        private void rentCb_Unchecked(object sender, RoutedEventArgs e)
        {
            rentingTb.Clear();
            rentingTb.IsEnabled = false;
            propertyCb.IsChecked = false;
            propertyCb.IsEnabled = true;
        }

        private void propertyCb_Checked(object sender, RoutedEventArgs e)
        {
            rentingTb.Clear();
            rentCb.IsChecked = false;
            propertyCb.IsChecked = true;
            purchasePriceTb.IsEnabled = true;
            depositTb.IsEnabled = true;
            interestRateTb.IsEnabled = true;
            monthsTb.IsEnabled = true;

            purchasePriceTb.DataContext = homeLoan;
            depositTb.DataContext = homeLoan;
            interestRateTb.DataContext = homeLoan;
            monthsTb.DataContext = homeLoan;
        }

        private void propertyCb_Unchecked(object sender, RoutedEventArgs e)
        {
            //clears the textboxes
            purchasePriceTb.Clear();
            depositTb.Clear();
            interestRateTb.Clear();
            monthsTb.Clear();

            //disables the textboxes
            purchasePriceTb.IsEnabled = false;
            depositTb.IsEnabled = false;
            interestRateTb.IsEnabled = false;
            monthsTb.IsEnabled = false;

            /*sets the datacontext:
             *      reason is when the property checkbox is unchecked and the user entered amounts in those textboxes,
             *      the datacontext remains as those falses and does not reset
             */
            //purchasePriceTb.DataContext = homeLoan;
            //depositTb.DataContext = homeLoan;
            //interestRateTb.DataContext = homeLoan;
            //monthsTb.DataContext = homeLoan;

        }

        private void vehicleCb_Checked(object sender, RoutedEventArgs e)
        {
            //enables the textboxes
            modelMakeTb.IsEnabled = true;
            vehiclePriceTb.IsEnabled = true;
            vehicleDepositTb.IsEnabled = true;
            vehicleInterestRateTb.IsEnabled = true;
            insuranceTb.IsEnabled = true;

            //sets the datacontent for the vehicle textboxes and variables
            modelMakeTb.DataContext = vehicle;
            vehiclePriceTb.DataContext = vehicle;
            vehicleDepositTb.DataContext = vehicle;
            vehicleInterestRateTb.DataContext = vehicle;
            insuranceTb.DataContext = vehicle;
        }

        private void vehicleCb_Unchecked(object sender, RoutedEventArgs e)
        {
            //clears the textboxes
            modelMakeTb.Clear();
            vehiclePriceTb.Clear();
            vehicleDepositTb.Clear();
            vehicleInterestRateTb.Clear();
            insuranceTb.Clear();

            //disables the textboxes
            modelMakeTb.IsEnabled = false;
            vehiclePriceTb.IsEnabled = false;
            vehicleDepositTb.IsEnabled = false;
            vehicleInterestRateTb.IsEnabled = false;
            insuranceTb.IsEnabled = false;

        }
        #endregion

        private void proceedBtn_Click(object sender, RoutedEventArgs e)
        {
            NotificationDelegate end = new NotificationDelegate(Notification);
            
            if (rentCb.IsChecked == true)
            {
                totalExpense = tax.tax + generalExpenses.costCalculation() + rent.costCalculation();
            }
            else if (propertyCb.IsChecked == true)
            {
                totalExpense = tax.tax + generalExpenses.costCalculation() + homeLoan.costCalculation();
            }
            else
            {
                totalExpense = tax.tax + generalExpenses.costCalculation();
            }

            if (vehicleCb.IsChecked == true)
            {
                totalExpense = totalExpense + vehicle.costCalculation();
            }

            incomeBalance = income.income - totalExpense;

            totalExpTb.Text = totalExpense.ToString("C2");

            incomeBalTb.Text = incomeBalance.ToString("C2");

            if (rentCb.IsChecked == true && totalExpense > (0.75 * income.income))
            {
                expenseDelegateTb.Text = end("*** Your total expenses, including your monthly rent and tax have exceeded 75% of your total gross monthly income ***");
            }
            else if (propertyCb.IsChecked == true && totalExpense > (0.75 * income.income))
            {
                expenseDelegateTb.Text = end("*** Your total expenses, including loan repayments have exceeded 75% of your total gross monthly income ***");
            }
            else if (totalExpense > (0.75 * income.income))
            {
                expenseDelegateTb.Text = end("*** Your total expenses plus tax have exceeded 75% of your total gross monthly income ***");
            }

            if (homeLoan.costCalculation() > (income.income/3))
            {
                hlNotifyTb.Text = end("*** Sorry to say that the approval of the home loan is unlikely since it exceeds a third of your total gross monthly income ***");
            }

        }

        private void NumberError(object sender, ValidationErrorEventArgs e)
        {
            //validates the user input --> makes sure a numberical value is entered and not a string value
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ToolTip = "Must be numerical";
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the current view and opens the option view window
            OptionView optionView = new OptionView();
            this.Close();
            optionView.Show();
        }

        private void overviewBtn_Click(object sender, RoutedEventArgs e)
        {
            //this button sets the texblocks in the BudgetOverview window to the amounts entered in the budget manager window
            //sets them according to the user's input and choices

            BudgetOverviewView budgetOverviewView = new BudgetOverviewView();

            budgetOverviewView.incomeTb.Text = "Income: " + income.income.ToString("C2");
            budgetOverviewView.dateTb.Text = "Date: " + DateTime.Now.ToLongDateString();

            budgetOverviewView.taxTb.Text = "Monthly Tax";
            budgetOverviewView.taxAmt.Text = tax.tax.ToString("C2");

            budgetOverviewView.groceriesTb.Text = "Groceries";
            budgetOverviewView.groceriesAmt.Text = generalExpenses.groceries.ToString("C2");

            budgetOverviewView.waterLightsTb.Text = "Water and Lights";
            budgetOverviewView.waterLightsAmt.Text = generalExpenses.waterLights.ToString("C2");

            budgetOverviewView.travelTb.Text = "Travel";
            budgetOverviewView.travelAmt.Text = generalExpenses.travel.ToString("C2");

            budgetOverviewView.cellularTb.Text = "Cellphone and Telephone";
            budgetOverviewView.cellularAmt.Text = generalExpenses.cellular.ToString("C2");

            budgetOverviewView.otherExpenseTb.Text = "Other Expenses";
            budgetOverviewView.otherExpenseAmt.Text = generalExpenses.otherExpense.ToString("C2");

            if (rentCb.IsChecked == true)
            {
                budgetOverviewView.accomodationTb.Text = "Monthly Rent";
                budgetOverviewView.accomodationAmt.Text = rent.rent.ToString("C2");
            }
            else if (propertyCb.IsChecked == true)
            {
                budgetOverviewView.accomodationTb.Text = "Monthly Home Loan Repayment";
                budgetOverviewView.accomodationAmt.Text = homeLoan.costCalculation().ToString("C2");
            }

            if (vehicleCb.IsChecked == true)
            {
                budgetOverviewView.vehicleTb.Text = "Monthly Vehicle Repayment for " + vehicle.modelMake;
                budgetOverviewView.vehicleAmt.Text = vehicle.costCalculation().ToString("C2");
            }

            budgetOverviewView.totalExpTb.Text = "Total Expenses";
            budgetOverviewView.totalExpAmt.Text = totalExpense.ToString("C2");

            budgetOverviewView.incomeBalTb.Text = "Income Balnce";
            budgetOverviewView.incomeBalAmt.Text = incomeBalance.ToString("C2");

            budgetOverviewView.Show();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            //shuts down the application when the user clicks the exit button
            App.Current.Shutdown();
        }

        private void reloadBtn_Click(object sender, RoutedEventArgs e)
        {
            BudgetView budgetView = new BudgetView();
            budgetView.Show();
            this.Close();
        }

        private void calculatorBtn_Click(object sender, RoutedEventArgs e)
        {
            //opens the calculator
            SimpleCalculatorView simpleCalculatorView = new SimpleCalculatorView();
            simpleCalculatorView.Show();
        }

        //method used for the delagate
        public static string Notification(string notify)
        {
            return notify;
        }
    }
}
