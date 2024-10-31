using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
                // Adicionado Regex para validar o formato da placa
                string padrãoPlaca = @"^[A-Z,a-z]{3}-\d{4}$";
                if (Regex.IsMatch(placa, padrãoPlaca))
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo com placa {placa.ToUpper()} adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Placa inválida. A placa deve seguir o formato AAA-1111.");
                }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    // Cálculo do valor total
                    decimal valorTotal = precoInicial + (precoPorHora * horas);

                    
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, insira um número inteiro não negativo.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string item in veiculos)
                {
                    Console.WriteLine(item.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
