using System.ComponentModel.DataAnnotations;
using System;

namespace Calculator.Models
{
    public class MonthlyPaymentModel
    {
        [Required(ErrorMessage = "Please enter your mortgage's principal.")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Monthly investment amount must be between 1 and infinity.")]
        public double? MortgagePrincipal { get; set; }

        [Required(ErrorMessage = "Please enter an annual interest rate.")]
        [Range(0.1, 10.0, ErrorMessage = "Annual interest rate must be between 0.1 and 10.0.")]
        public double? AnnualInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        public double? Years { get; set; }

        public double Calculate()
        {
            const double MONTHSINYEAR = 12;

            double mortgagePrincipal = MortgagePrincipal.Value;
            double numberOfPayments = Years.Value * MONTHSINYEAR;
            double monthlyInterestRate = AnnualInterestRate.Value / 12 / 100;

            double monthlyMortgagePayment = (mortgagePrincipal * (monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), numberOfPayments))) /
                (Math.Pow((1 + monthlyInterestRate), numberOfPayments) - 1);

            return monthlyMortgagePayment;
        }
    }
}
