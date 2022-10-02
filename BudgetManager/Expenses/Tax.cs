namespace BudgetManager.Expenses
{
    public class Tax
    {
        public double tax { get; set; }

        public Tax(double monthlyTax)
        {
            this.tax = monthlyTax;
        }
    }
}
