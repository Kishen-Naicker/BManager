namespace BudgetManager.SavingsPlan
{
    public class SavingPlan
    {

        private double monthlySavings = 0, accumAmount = 0;
        public string SavingsReason { get; set; }
        public double Amount { get; set; }
        public double SavingsIR { get; set; }
        public double Years { get; set; }

        public SavingPlan(string savingsReason, double amount, double savingsIR, double  years)
        {
            this.SavingsReason = savingsReason;
            this.Amount = amount;
            this.SavingsIR = savingsIR;
            this.Years = years;
        }

        public double MonthlySavings()
        {
            //formula used: A=P(1+in) --> simple interest
            //then divide by the total months to get monthly savings

            accumAmount = Amount * (1 + (SavingsIR/100 * Years));

            monthlySavings = accumAmount / (Years * 12);

            return monthlySavings;
        }

        
    }
}
