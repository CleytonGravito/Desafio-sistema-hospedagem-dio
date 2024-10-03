namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Método para cadastrar hóspedes na reserva
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Caso a capacidade seja menor, lançar uma exceção
                throw new Exception("O número de hóspedes excede a capacidade da suíte.");
            }
        }

        // Método para cadastrar a suíte da reserva
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Método para obter a quantidade de hóspedes cadastrados
        public int ObterQuantidadeHospedes()
        {
            // Retorna o número de hóspedes cadastrados na propriedade 'Hospedes'
            return Hospedes.Count;
        }

        // Método para calcular o valor total da diária
        public decimal CalcularValorDiaria()
        {
            // Cálculo básico: quantidade de dias reservados X valor da diária da suíte
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplicar um desconto de 10% caso os dias reservados sejam maiores ou iguais a 10
            if (DiasReservados >= 10)
            {
                valorTotal *= 0.90m; // Aplica o desconto de 10%
            }

            return valorTotal;
        }
    }
}
