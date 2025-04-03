namespace Conta_Corrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int Numero { get; set; }

        public double Saldo { get; set; }

        public double Limite { get; set; }

        public List<string> transacoes;

        public ContaCorrente(int numero, double saldoInicial, double limite)
        {
            if (saldoInicial < 0 || limite < 0)
            {
                Console.WriteLine("Saldo inicial ou limite inválido");
            }
            Numero = numero;
            Saldo = saldoInicial;
            Limite = limite;
            transacoes = new List<string>();
            Console.WriteLine($"Conta {Numero} criada. Saldo inicial: R${Saldo:F2}, Limite disponível: R${Limite:F2}\n");
        }

        public bool Sacar(double valor, bool exibirMensagem = true)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para saque.\n");
                return false;
            }

            if (Saldo - valor < -Limite)
            {
                Console.WriteLine("Saldo insuficiente! Não é possível ultrapassar o limite.\n");
                return false;
            }
            Saldo -= valor;
            transacoes.Add($"Saque: -R${valor:F2}");
            if (exibirMensagem)
                Console.WriteLine($"Saque de R${valor:F2} realizado com sucesso\n");

            return true;
        }

        public void Depositar(double valor, bool exibirMensagem = true)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para depósito.\n");
            }
                Saldo += valor;
                transacoes.Add($"Depósito: +R${valor:F2}");
            if (exibirMensagem)
                Console.WriteLine($"Depósito de R${valor:F2} realizado com sucesso\n");
        }

        public bool TransferirPara(ContaCorrente destino, double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para transferência.\n");
                return false;
            }

            if (Saldo - valor < -Limite)
            {
                Console.WriteLine("Saldo insuficiente para transferência.\n");
                return false;
            }

            Sacar(valor, false);
            destino.Depositar(valor, false);
            transacoes.Add($"Transferência enviada: R${valor:F2} para conta {destino.Numero}");
            destino.transacoes.Add($"Transferência recebida: +R${valor:F2} de conta {Numero}");

            Console.WriteLine($"Transferência de R${valor:F2} para conta {destino.Numero} realizada com sucesso\n");
            return true;
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"\nExtrato da conta {Numero}:");
            if (transacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação realizada.");
            }
            else
            {
                foreach (var item in transacoes)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Saldo atual: R${Saldo:F2}\n");
            }
        }

        public void MostrarSaldo()
        {
            Console.WriteLine($"Saldo da conta {Numero}: R${Saldo:F2}\n");
        }
    }
}
