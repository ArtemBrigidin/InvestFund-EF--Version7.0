using in_memory_InvestFund.DataBase.Tables;

namespace in_memory_InvestFund;

public class DbManager : IDisposable
{
    private const string HorizontalLine = @"/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\";
    private DataBaseInvestFund _database = new DataBaseInvestFund();
    public void Menu()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Вывести список клиентов.");
            Console.WriteLine("2. Добавить нового клиента.");
            Console.WriteLine("3. Вывести список инвестиций.");
            Console.WriteLine("4. Добавить новую инвестицию.");
            Console.WriteLine("5. Вывести список транзакций.");
            Console.WriteLine("6. Добавить новую транзакцию.");
            Console.WriteLine("0. Выйти.");
            Console.Write("Ввод >> ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    GetClients();
                    break;
                case 2:
                    Console.Clear();
                    SetClient();
                    break;
                case 3:
                    Console.Clear();
                    GetInvestments();
                    break;
                case 4:
                    Console.Clear();
                    SetInvestments();
                    break;
                case 5:
                    Console.Clear();
                    GetTransactions();
                    break;
                case 6:
                    Console.Clear();
                    SetTransactions();
                    break;
                default:
                    break;
            }
        }
    }
    public void GetClients()
    {
        var clients = _database.Clients.ToList();
        Console.WriteLine("Список клиентов: ");
        foreach (var c in clients)
        {
            Console.WriteLine($"| ClientId = {c.ClientId} |\t| " +
                              $"Name = {c.Name} |\t| " +
                              $"Surname = {c.Surname} |\t| " +
                              $"Birthday = {c.BirthDay} |\t| " +
                              $"Account = {c.Amount}");
        }
    }

    public void GetInvestments()
    {
        var investments = _database.Investments.ToList();
        Console.WriteLine("Список инвестиций: ");
        foreach (var i in investments)
        {
            Console.WriteLine($"| InvestmentId = {i.InvestmentId} |\t| " +
                              $"ClientId = {i.ClientId} |\t| " +
                              $"InvestmentType = {i.InvestmentType} |\t| " +
                              $"InvestmentAmount = {i.InvestmentAmount} |\t| " +
                              $"PurchaseDate = {i.PurchaseDate}");
        }
    }

    public void GetTransactions()
    {
        var transactions = _database.Transactions.ToList();
        Console.WriteLine("Список транзакций: ");
        foreach (var t in transactions)
        {
            Console.WriteLine($"| TransactionId = {t.TransactionId} |\t| " +
                              $"ClientId = {t.ClientId} |\t| " +
                              $"InvestmentId = {t.InvestmentId} |\t| " +
                              $"InvestmentType = {t.InvestmentType} |\t| " +
                              $"TransactionDate = {t.TransactionDate} |\t| " +
                              $"TransactionAmount = {t.TransactionAmount}");
        }
    }

    public void SetClient()
    {
        Console.WriteLine(HorizontalLine);
        Console.WriteLine("Заполните данными нового клиента [Client]:");
        InsertClient();
        Console.WriteLine("Заполнение таблицы[Client] завершено");
        Console.WriteLine(HorizontalLine);
        Console.WriteLine("Нажмите любую клавишу что бы вернуться в меню.");
        Console.ReadKey();
    }

    public void SetInvestments()
    {
        Console.WriteLine(HorizontalLine);
        Console.WriteLine("Заполните данными нового клиента [Investments]:");
        InsertInvestments();
        Console.WriteLine("Заполнение таблицы[Investments] завершено");
        Console.WriteLine(HorizontalLine);
    }

    public void SetTransactions()
    {
        Console.WriteLine(HorizontalLine);
        Console.WriteLine("Заполните данными нового клиента [Transactions]:");
        InsertTransactions();
        Console.WriteLine("Заполнение таблицы[Transactions] завершено");
        Console.WriteLine(HorizontalLine);
    }

    public void InsertClient()
    {
        Console.WriteLine("Заполненние данных о клиенте");
        var client = new Client();

        Console.WriteLine("Введите имя >>");
        var name = Console.ReadLine();
        Console.WriteLine("Введите фамилию >>");
        var surname = Console.ReadLine();
        Console.WriteLine("Введите дату рождения >>");
        var birthday = Console.ReadLine();
        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(birthday))
        {

        }
        else
        {
            client.Name = name;
            client.Surname = surname;
            client.BirthDay = birthday;
            client.Amount = 0;
            _database.Clients.Add(client);
        }
    }

    public void InsertInvestments()
    {
        Console.WriteLine("Заполнение данных о инвестиции");
        var investments = new Investments();

        Console.WriteLine("Введите ID клиента >> ");
        var clientId = Console.Read();
        Console.WriteLine("Введите тип инвестиций (покупка ценных бумаг/акции и тп...) >> ");
        var investmentType = Console.ReadLine();
        Console.WriteLine("Введите сумму сделки >> ");
        var investmentAmount = Console.Read();
        Console.WriteLine("Введите дату покупки >> ");
        var purchaseDate = Console.ReadLine();

        if (string.IsNullOrEmpty(clientId.ToString()) && string.IsNullOrEmpty(investmentType) && string.IsNullOrEmpty(investmentAmount.ToString()) && string.IsNullOrEmpty(purchaseDate))
        {

        }
        else
        {
            investments.ClientId = clientId;
            investments.InvestmentType = investmentType;
            investments.InvestmentAmount = investmentAmount;
            investments.PurchaseDate = purchaseDate;
            investments.IsBuy = true;
            _database.Investments.Add(investments);
        }
    }
    public void InsertTransactions()
    {
        Console.WriteLine("Заполнение даных о транзакции");
        var transactions = new Transactions();

        Console.WriteLine("Введите ID клиента >> ");
        var clientId = Console.Read();
        Console.WriteLine("Введите ID инвестиции >> ");
        var investmentId = Console.Read();
        Console.WriteLine("Введите тип инвестиции >> ");
        var investmentType = Console.ReadLine();
        Console.WriteLine("Введите дату транзакции >> ");
        var transactionDate = Console.ReadLine();
        Console.WriteLine("Введите сумму транзакции >> ");
        var transactionAmount = Console.Read();

        if (string.IsNullOrEmpty(clientId.ToString()) && string.IsNullOrEmpty(investmentId.ToString()) && string.IsNullOrEmpty(investmentType) && string.IsNullOrEmpty(transactionDate) && string.IsNullOrEmpty(transactionAmount.ToString()))
        {

        }
        else
        {
            transactions.ClientId = clientId;
            transactions.InvestmentId = investmentId;
            transactions.InvestmentType = investmentType;
            transactions.TransactionDate = transactionDate;
            transactions.TransactionAmount = transactionAmount;
            _database.Transactions.Add(transactions);
        }
    }


    public void Dispose()
    {
    }
}