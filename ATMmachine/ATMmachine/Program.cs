using System;


public class cardHolder
{
    String cardNumber;
    int pin;
    String firstName;
    String lastName;
    double balance;


    //constructor
    public cardHolder(String cardNumber, int pin, String firstName, String lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //getter and setters

    //getter functions
    public String GetCardNumber()
    {
        return cardNumber;
    }

    public int GetPin()
    {
        return pin;
    }

    public String GetFirstName()
    {
        return firstName;
    }

    public String GetLastName()
    {
        return lastName;
    }

    public double GetBalance()
    {
        return balance;
    }

    //setter functions
    public void SetCardNumber(String newCardNumber)
    {
        cardNumber = newCardNumber;
    }
    public void SetPin(int newPin)
    {
        pin = newPin;
    }
    public void SetFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void SetLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void SetBalance(double newBalance)
    {
        balance = newBalance;
    }

    //main function
    public static void Main(String[] args)
    {
        //display atm menu
        void printOptions()
        {
            Console.WriteLine("Choose an option from the available options: ");
            Console.WriteLine("1: Deposit your hard earned money.");
            Console.WriteLine("2: Withdraw money.");
            Console.WriteLine("3: Show balance.");
            Console.WriteLine("4: Exit");
        }

        //deposit function
        void deposit(cardHolder userX)
        {
            Console.WriteLine("How much do you want to deposit, bro?");
            double depositedValue = Double.Parse(Console.ReadLine());
            if (depositedValue>0)
            {
                double updatedBalance = depositedValue + userX.balance;
                userX.SetBalance(updatedBalance);
                Console.WriteLine("Thanks for depositing money in our bank. Your new balance is: "+userX.GetBalance());
            }
            else
            {
                Console.WriteLine("Kindly enter the right amount!");
                deposit(userX);
            }
        }

        //withdraw money
        void withdraw(cardHolder userX)
        {
            Console.WriteLine("How much money do you want to withdraw, bro?");
            double withdrawalDesire = Double.Parse(Console.ReadLine());
            if (userX.GetBalance() < withdrawalDesire)
            {
                Console.WriteLine("You have insufficient funds. :(");
            }
            else
            {
                userX.SetBalance(userX.GetBalance() - withdrawalDesire);
                Console.WriteLine("Thanks for banking with us.");
        
            }
        }

        //balance
        void balance(cardHolder userX)
        {
            Console.WriteLine("Bro, you have " + userX.GetBalance() + " $ left in your bank account.");
        }

        List<cardHolder> cardHolderDetails = new List<cardHolder>();
        cardHolderDetails.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolderDetails.Add(new cardHolder("4532761841325802", 4321, "Ashley", "Jones", 321.13));
        cardHolderDetails.Add(new cardHolder("5128381368581872", 9999, "Frida ", "Dickerson", 105.59));
        cardHolderDetails.Add(new cardHolder("6011188364697109", 2468, "Muneeb", "Harding", 851.84));
        cardHolderDetails.Add(new cardHolder("3490693153147110", 4826, "Dawn", "Smith", 54.27));

        //prompt the user
        Console.WriteLine("Welcome to the ATM. Kindly enter your debit card number to proceed further: ");
        String debitCardNumber = "";
        cardHolder userX;

        while (true)
        {
            try
            {
                debitCardNumber = Console.ReadLine();
                userX = cardHolderDetails.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                if (userX != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("debit card number invalid.");
                }
            }
            catch
            {
                Console.WriteLine("debit card number invalid.");
            }
        }


        //pin
        Console.WriteLine("Thanks for the valid debit card number. Kindly enter your pin to proceed: ");
        int pin = 0;

        while (true)
        {
            try
            {
                pin = int.Parse(Console.ReadLine());
                if (userX.GetPin() == pin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong pin. try again!");
                }
            }
            catch
            {
                Console.WriteLine("wrong pin. try again!");
            }
        }

        Console.WriteLine("Welcome " + userX.GetFirstName() + " "+ userX.GetLastName() + ".");
        int option = 0;
        printOptions();
        do
        {
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                deposit(userX);
                printOptions();
            }
            else if (option == 2)
            {
                withdraw(userX);
                printOptions();
            }
            else if(option == 3)
            {
                balance(userX);
                printOptions();
            }
            else
            {
                option = 0;
            }
        } while (option != 4);
    }

}

