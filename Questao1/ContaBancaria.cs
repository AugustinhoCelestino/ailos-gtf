using System;

namespace Questao1
{
    class ContaBancaria
    {
        public ContaBancaria(int accountNumber, string accountOwner, double depositoinicial)
        {
            this.Balance = depositoinicial;
            this.AccountNumber = accountNumber; 
            this.AccountOwner = accountOwner;
        }
        public ContaBancaria(int accountNumber, string accountOwner)
        {
            this.AccountNumber = accountNumber;
            this.AccountOwner = accountOwner;
            this.Balance = 0;
        }

        public int AccountNumber { get; set; } = 0;
        public string AccountOwner { get; set; } = string.Empty;
        protected double Balance { get; set; } = 0;
        protected double WithdrawTax { get; set; } = 3.50;

        public void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.Balance -= this.WithdrawTax;
        }

        public string ShowAccountInfo()
        {
            string accountInfo = $"Conta {this.AccountNumber}, Titular {this.AccountOwner}, Saldo: {this.Balance:C}";

            return accountInfo;
        }
    }
}
