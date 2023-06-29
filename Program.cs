// See https://aka.ms/new-console-template for more information

using System.Globalization;

Console.WriteLine("Bem vindo a Clinica de Lucas");
Dictionary<string,List<int>>Informacaopaciente = new Dictionary<string,List<int>>();
Dictionary<string, List<int>> Marcacaodia = new Dictionary<string, List<int>>();

void ResgistrarPaciente()
{
    Console.Clear();
    Console.WriteLine("Informe o Nome do paciente: ");
    string nomepaciente = Console.ReadLine()!;
    Informacaopaciente.Add(nomepaciente, new List<int>());
    Console.WriteLine("Informe o seu numero de celular: ");
    string numero = Console.ReadLine()!;
    //Informacaopaciente.Add(numero, new List<int>());
    Console.WriteLine("Informe o CPF: ");
    string cpf = Console.ReadLine()!;
    //Informacaopaciente.Add(cpf, new List<int>());
    Thread.Sleep(3000);
    Console.Clear();
    menu();

}

void Marcarconsulta() // Função para marcar consulta
{
    int count = 1;
    int totalPacientes = Informacaopaciente.Keys.Count;

    foreach (string nomepaciente in Informacaopaciente.Keys)
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
    menu();


}
void ExecutarConsulta() //Agendar consulta
{
    Console.WriteLine("Informe a data que deseja agendar a consulta (no formato dd/mm/yyyy): ");
    string data = Console.ReadLine();
    DateTime dataConsulta;

    if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataConsulta))
    {
        // A data foi inserida corretamente e armazenada em dataConsulta
        Console.WriteLine("Data da consulta agendada: " + dataConsulta.ToShortDateString());

        // Agora você pode usar a variável dataConsulta em outras partes do seu código
    }
    else
    {
        Console.WriteLine("Data inválida. Certifique-se de inserir a data no formato dd/mm/yyyy.");
    }

    if (dataConsulta == DateTime.MinValue)
    {
        Console.WriteLine("Essa data já possui consulta");
    }
    else
    {
        return;
    }
}


void menu() // Menu principal
{
    Console.WriteLine("Digite 1 para adicionar Paciente: ");
    Console.WriteLine("Digite 2 para Marcar Consulta: ");
    Console.WriteLine("Digite 3 para Cancelamento da Consulta: ");
    Console.WriteLine("Digite 4 para Sair: ");

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
    }
   
}
//menu();
ExecutarConsulta();
