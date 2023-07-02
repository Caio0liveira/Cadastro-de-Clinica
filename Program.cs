// See https://aka.ms/new-console-template for more information

using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bem vindo a Clinica de Lucas");
        Dictionary<string, List<int>> Informacaopaciente = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> Listanome = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> Marcacao = new Dictionary<string, List<int>>();
        menu();
        ExecutarConsulta();

        void ResgistrarPaciente() // Metodo de Registrar o Paciente
        {
            Console.Clear();
            Console.WriteLine("Informe o Nome do paciente: ");
            string nomepaciente = Console.ReadLine()!;
            Informacaopaciente.Add(nomepaciente, new List<int>());
            Listanome.Add(nomepaciente, new List<int>());


            Console.WriteLine("Informe o seu numero de celular: ");
            string numero = Console.ReadLine()!;
            int.TryParse(numero, out int numeroPaciente);
            Informacaopaciente.Add(numero, new List<int>());


            Console.WriteLine("Informe o CPF: ");
            string cpf = Console.ReadLine()!;
            int.TryParse(cpf, out int cpfpaciente);
            Informacaopaciente.Add(cpf, new List<int>());
            Thread.Sleep(3000);
            Console.Clear();
            menu();

        }

        void Marcarconsulta() // Metodo para marcar consulta
        {
            int count = 1;
            int totalPacientes = Informacaopaciente.Keys.Count;

            foreach (string nomepaciente in Listanome.Keys)
            {
                Console.WriteLine($"Paciente {count} - Nome: {nomepaciente}");
                count++;
            }

            Console.WriteLine("Digite o número do paciente que você deseja marcar a consulta");
            string numero = Console.ReadLine()!;
                if (int.TryParse(numero, out int numeroPaciente))
                {
                        if (numeroPaciente == totalPacientes)
                        {
                            Console.WriteLine("Carregando agendamento do paciente...");
                            Thread.Sleep(1000);
                            // Executar a função com base no número do paciente selecionado
                            ExecutarConsulta();
                        }
                        else
                        {
                        Console.WriteLine("Número inválido de paciente.");
                        }
                }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }

            Console.Clear();
         


        }
        void ExecutarConsulta() //Agendar consulta
        {
            //Aplicando a biblioteca datatime
            Console.WriteLine("Informe a data que deseja agendar a consulta (no formato dd/mm/yyyy): ");
            string data = Console.ReadLine()!;
            Marcacao.Add(data, new List<int>());
            DateTime dataConsulta;

            if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataConsulta)) // Transformando string em referencia da biblioteca
            {
                // A data foi inserida corretamente e armazenada em dataConsulta
                Console.WriteLine("Data da consulta agendada: " + dataConsulta.ToShortDateString());
                Thread.Sleep(2000);
                menu();
                // Agora você pode usar a variável dataConsulta em outras partes do seu código

                if (dataConsulta <= DateTime.Today)
                {
                    Console.WriteLine("Insira outra data, pois essa já tem consulta");
                    Thread.Sleep(2000);
                    ExecutarConsulta();

                }
            }
            else
            {
                Console.WriteLine("Data inválida. Certifique-se de inserir a data no formato dd/mm/yyyy.");
                ExecutarConsulta();
            }
        }
        void Cancelamento() // Função para cancelar
        {
            Console.WriteLine("Essas são as consultas agendadas:");
            int agendamento = 1;
            int consultas = Marcacao.Keys.Count;

            // Exibir as consultas agendadas
            foreach (string dataConsulta in Marcacao.Keys)
            {
                Console.WriteLine($"Número {agendamento} - Data da consulta: {dataConsulta}");
                agendamento++;
            }

            Console.WriteLine("Digite o número do paciente cuja consulta deseja desmarcar:");
            string numero1 = Console.ReadLine()!;

            // Condição para Cancelar a consulta
           
            if (int.TryParse(numero1, out int numeroPaciente))
            {
                if (numeroPaciente >= 1 && numeroPaciente <= consultas)
                {
                    int index = numeroPaciente - 1;

                    // Obter as chaves do dicionário
                    string[] chaves = Marcacao.Keys.ToArray();

                    // Selecionar a chave correta com base no índice
                    string chave = chaves[index];

                    // Remover o item do dicionário usando a chave
                    Marcacao.Remove(chave);
                    Console.WriteLine("Consulta Removida!");
                    Thread.Sleep(2000);
                    menu();
                }
                else
                {
                    Console.WriteLine("Número de paciente inválido.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
        void Sair() // Metodo para Fechar o Programa
        {
            bool mensagem = true;

            if (mensagem == false)
            {
                Console.WriteLine("tchau");
            }
            else
            {
                Environment.Exit(1);
            }
        }
        void Mostrarlistas() // Ver lista
        {
            Console.WriteLine("Essa é a lista informação paciente:");

            foreach (var paciente in Informacaopaciente)
            {
                Console.WriteLine(paciente);
            }
        }




        void menu() // Menu principal
        {
            Console.WriteLine("Digite 1 para adicionar Paciente: ");
            Console.WriteLine("Digite 2 para Marcar Consulta: ");
            Console.WriteLine("Digite 3 para Cancelamento da Consulta: ");
            Console.WriteLine("Digite 4 para Sair: ");
            Console.WriteLine("Digite 5 para Mostrar as listas: ");

            Console.WriteLine("Digite sua Opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    ResgistrarPaciente();
                    break;
                case 2:
                    Marcarconsulta();
                    break;
                case 3:
                    Cancelamento();
                    break;
                case 4:
                    Sair();
                    break;
                case 5:
                    Mostrarlistas();
                    break;
            }

        }
        
    }
}
