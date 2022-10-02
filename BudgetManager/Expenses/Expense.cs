namespace BudgetManager.Expenses
{
    interface ExpenseInterface
    {
        double costCalculation();
    }
    public abstract class Expense : ExpenseInterface
    {
        public abstract double costCalculation();
        
    }
}
