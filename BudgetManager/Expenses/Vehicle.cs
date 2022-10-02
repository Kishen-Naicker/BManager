namespace BudgetManager.Expenses
{
    public class Vehicle : Expense
    {
        private double vehicleRepay, repayPeriod = 5, balance, totalAmount;

        public Vehicle(string modelMake, double purchasePrice, double totalDeposit, double interestRate, double estInsurance)
        {
            this.modelMake = modelMake;
            this.vehiclePurchasePrice = purchasePrice;
            this.vehicleTotalDeposit = totalDeposit;
            this.vehicleInterestRate = interestRate;
            this.estInsurance = estInsurance;
        }

        public string modelMake { get; set; }
        public double vehiclePurchasePrice { get; set; }
        public double vehicleTotalDeposit { get; set; }
        public double vehicleInterestRate { get; set; }
        public double estInsurance { get; set; }


        public override double costCalculation()
        {
            //balance after deposit have been made
            balance = vehiclePurchasePrice - vehicleTotalDeposit;

            //total amount --> balance + interest
            totalAmount = (balance * (vehicleInterestRate / 100)) + balance;

            //monthly repayment + estimated premium insurance
            vehicleRepay = (totalAmount / (repayPeriod * 12)) + estInsurance;

            return vehicleRepay;
        }
    }
}
