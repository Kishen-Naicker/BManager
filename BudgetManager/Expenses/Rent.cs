namespace BudgetManager.Expenses
{
    public class Rent : Expense
    {
        public double rent { get; set; }

        public Rent(double monthlyRent)
        {
            this.rent = monthlyRent;
        }

        public override double costCalculation()
        {
            return rent;
        }
    }
}
