namespace BudgetManager.Expenses
{
    public class HomeLoan : Expense
    {
        private double homeLoanRepay = 0, balance = 0, totalAmount = 0;

        public HomeLoan(double purchacePrice, double totalDeposit, double interestRate, double months)
        {
            this.purchacePrice = purchacePrice;
            this.totalDeposit = totalDeposit;
            this.interestRate = interestRate;
            this.months = months;
        }

        public double purchacePrice { get; set; }
        public double totalDeposit { get; set; }
        public double interestRate { get; set; }
        public double months { get; set; }


        public override double costCalculation()
        {
            balance = purchacePrice - totalDeposit;

            //determines the price to be payed each month for the property
            //formula used A=P(1+in)
            totalAmount = balance * (1 + ((interestRate/100) * months/12));

            homeLoanRepay = totalAmount / months;

            return homeLoanRepay;
        }
    }
}
