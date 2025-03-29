namespace Questao1
{
    class ContaBancaria
    {
        public ContaBancaria(int numero, string titular, double depositoinicial)
        {
            this.Saldo = depositoinicial;
            this.Numero = numero; 
            this.Titular = titular;
        }
        public ContaBancaria(int numero, string titular)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = 0;
        }

        public int Numero { get; set; } = 0;
        public string Titular { get; set; } = string.Empty;
        public double Saldo { get; set; } = 0;

        public void Deposito(double quantia)
        {
            this.Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            this.Saldo -= quantia;
        }
    }
}
