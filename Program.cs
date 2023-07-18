// See https://aka.ms/new-console-template for more information

using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem vindo a Clinica de Lucas");
        Dictionary<string, List<int>> Informacaopaciente = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> Listanome = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> Marcacao = new Dictionary<string, List<int>>();
        menu();

        void ResgistrarPaciente() // Metodo de Registrar o Paciente
        {
            Console.Clear();
            //Codigo para Cadastro completo
            Console.WriteLine("Voce deseja realizar Cadastro por completo? SIM ou NÃO");

            string resposta = Console.ReadLine()!;

            if (resposta == "SIM")
            {

                Console.WriteLine("Informe o nome: ");
                string nomepaciente1 = Console.ReadLine()!;
                Listanome.Add(nomepaciente1, new List<int>());
                Informacaopaciente.Add(nomepaciente1, new List<int>());
                //Tratamento de nome desse caso
                if(nomepaciente1 == "")
                {
                    Console.WriteLine("Informe um nome válido ");
                }
                Console.WriteLine("Informe o numero de telefone: ");
                string numero1 = Console.ReadLine()!;
                Informacaopaciente.Add(numero1, new List<int>());
                //Tratamento de nome desse caso
                try
                {
                    if (numero1.Length == 0 || numero1.Length < 10)
                    {
                        Console.WriteLine("Informe um numero válido");
                        Console.ReadLine();
                    }
                }

                catch (ArgumentException)
                {
                    Console.WriteLine("Voce tentou colocar um numero com caracteres menor que 0 e 9");

                }

                Console.WriteLine("Informe o CPF: ");
                string cpf1 = Console.ReadLine()!;
                Informacaopaciente.Add(cpf1, new List<int>());
                // Tratamento de CPF
                if (cpf1.Length == 0 || cpf1.Length < 9)
                {
                    Console.WriteLine("Informe um CPF válido");
                    Console.ReadLine();
                }
                Console.WriteLine("Informe o Endereco: ");
                string endereco1 = Console.ReadLine()!;
                Informacaopaciente.Add(endereco1, new List<int>());
                Console.WriteLine("Informe a Cidade: ");
                String cidade1 = Console.ReadLine()!;
                Informacaopaciente.Add(cidade1, new List<int>());
                Console.WriteLine("Paciente Adicionado com sucesso");
                Thread.Sleep(3000);
                Console.Clear();
                menu();

                /*Armazenando no dicionario
                List<string> informacoes = new List<string>();

                informacoes.Add(nomepaciente1.numero);
                informacoes.Add(nomepaciente1.cpf);
                informacoes.Add(nomepaciente1.endereco);
                informacoes.Add(nomepaciente1.Cidade);

                Informacaopaciente.TryAdd(informacoes);
                */
            }



            //Cadastro Simplificado

            Console.WriteLine("Informe o Nome do paciente: ");
            string nomepaciente = Console.ReadLine()!;
            Informacaopaciente.Add(nomepaciente, new List<int>());
            Listanome.Add(nomepaciente, new List<int>());

            // Tratamento de nome

            if (nomepaciente == "")
            {
                Console.WriteLine("Por favor informe um nome válido: ");
                Console.ReadLine();
            }


            Console.WriteLine("Informe o seu numero de celular: ");
            string numero = Console.ReadLine()!;
            int.TryParse(numero, out int numeroPaciente);
            Informacaopaciente.Add(numero, new List<int>());

            //Tratamento de Numero

            try
            {
                if (numero.Length == 0 || numero.Length < 10)
                {
                    Console.WriteLine("Informe um numero válido");
                    Console.ReadLine();
                }
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Voce tentou colocar um numero com caracteres menor que 0 e 9");

            }



            Console.WriteLine("Informe o CPF: ");
            string cpf = Console.ReadLine()!;


            // Tratamento de CPF
            if (cpf.Length == 0 || cpf.Length < 9)
            {
                Console.WriteLine("Informe um CPF válido");
                Console.ReadLine();
            }

                int.TryParse(cpf, out int cpfpaciente);
                Informacaopaciente.Add(cpf, new List<int>());
                Thread.Sleep(3000);
                Console.Clear();
                menu();

        }

        void PlanoSaude()
        {
            int valor_consulta;
            {
                int count = 1;
                int totalPacientes = Listanome.Keys.Count;

                foreach (string nomepaciente in Listanome.Keys)
                {
                    Console.WriteLine($"Paciente {count} - Nome: {nomepaciente} possui convênio? ");
                    count++;
                }
                string convenio = Console.ReadLine()!;

                
                if (convenio == "NÃO")
                {
                    valor_consulta = 250;
                    Console.WriteLine("O paciente vai Pagar valor cheio");
                }
                else
                {
                    valor_consulta = 200;
                    Console.WriteLine("Paciente vai ter desconto de 50 reias"); ;
                }
            }
        }

            void Marcarconsulta() // Metodo para marcar consulta
            {

                int count = 1;
                int totalPacientes = Listanome.Keys.Count;

                foreach (string nomepaciente in Listanome.Keys)
                {
                    Console.WriteLine($"Paciente {count} - Nome: {nomepaciente}");
                    count++;
                }

                Console.WriteLine("Digite o número do paciente que você deseja marcar a consulta");
                string numero = Console.ReadLine();
                if (int.TryParse(numero, out int numeroPaciente))
                {
                    if (numeroPaciente <= totalPacientes && numeroPaciente > 0)
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
                Console.WriteLine("Informe a data que deseja agendar a consulta (no formato 00/00/0000): ");
                string data = Console.ReadLine()!;
                Marcacao.Add(data, new List<int>());
                DateTime dataConsulta;

                if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataConsulta)) // Transformando string em referencia da biblioteca
                {
                    // A data foi inserida corretamente e armazenada em dataConsulta
                    Console.WriteLine("Data da consulta agendada: " + dataConsulta.ToShortDateString());
                    PlanoSaude();
                    Thread.Sleep(2000);
                    Console.Clear();
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
                        Console.Clear();
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
                    Console.WriteLine($"Nome do paciente: {paciente.Key}");

                    Console.WriteLine("Informações adicionais:");

                    foreach (var info in paciente.Value)
                    {
                        Console.WriteLine($"- {info}");
                    }

                    Console.WriteLine(); // Linha em branco para separar cada paciente
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
