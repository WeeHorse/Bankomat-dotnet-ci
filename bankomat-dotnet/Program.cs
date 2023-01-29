using System;
namespace banko;

class Program
{
    static void Main(string[] args)
    {
        Bankomat bankomat = new Bankomat();
        Account account = new Account();
        Card card = new Card(account);

        // Sätt in ett kort i bankomaten => “Card inserted”
        bankomat.insertCard(card);
        Console.WriteLine(bankomat.getMessage());

        // Om kortet är nytt = > “Create new pin code”
        Console.WriteLine(bankomat.getMessage());
        bankomat.createPin("0123");
        // “Pin created. You can start using your card.”
        Console.WriteLine(bankomat.getMessage());



        // Om kortet har en pinkod => “Enter your pin code”
        Console.WriteLine(bankomat.getMessage());



        bankomat.enterPin("1234");
        Console.WriteLine(bankomat.getMessage());
        bankomat.enterPin("0123");
        Console.WriteLine(bankomat.getMessage());
        bankomat.withdraw(15000);
        Console.WriteLine(bankomat.getMessage());
        bankomat.withdraw(8000);
        Console.WriteLine(bankomat.getMessage());
        bankomat.withdraw(3000);
        Console.WriteLine(bankomat.getMessage());
        bankomat.ejectCard();
        Console.WriteLine(bankomat.getMessage());
        bankomat.withdraw(100);
        Console.WriteLine(bankomat.getMessage());
        bankomat.insertCard(card);
        Console.WriteLine(bankomat.getMessage());
        bankomat.enterPin("0123");
        Console.WriteLine(bankomat.getMessage());
        bankomat.withdraw(1000);
        Console.WriteLine(bankomat.getMessage());
        bankomat.ejectCard();
    }
}
