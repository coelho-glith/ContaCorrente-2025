namespace Conta_Corrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(2, 1000, 2000);

            conta1.transacoes = new List<string>();

            conta1.Depositar(400);

            conta1.Depositar(500);

            conta1.Sacar(200);

            conta1.Sacar(200);

            ContaCorrente conta2 = new ContaCorrente(3, 300, 3000);

            conta1.transacoes = new List<string>();

            conta1.TransferirPara(conta2, 400);

            conta1.ExibirExtrato();

            conta1.MostrarSaldoFinal();

            Console.WriteLine();

            conta2.ExibirExtrato();

            conta2.MostrarSaldoFinal();
        }
    }
}
