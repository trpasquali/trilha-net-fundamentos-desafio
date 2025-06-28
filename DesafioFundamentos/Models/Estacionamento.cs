using System;
using System.Collections.Generic;
using System.Linq;
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

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            placa = placa.Trim().ToUpper();

            string padraoAntigo = @"^[A-Z]{3}[0-9]{4}$";         // Exemplo: ABC1234
            string padraoMercosul = @"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$"; // Exemplo: ABC1D23

            return Regex.IsMatch(placa, padraoAntigo) || Regex.IsMatch(placa, padraoMercosul);
        }
        public void AdicionarVeiculo()
        {
            //Implementado!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine("Veículo adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Formatos válidos: ABC1234 ou ABC1D23.");
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
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
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
                foreach (var v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
