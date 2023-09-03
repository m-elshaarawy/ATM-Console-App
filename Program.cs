namespace ATM_Console_App
{
    internal class CardData
    {
        string name;
        string cardNum;
        int pin;
        double balance;
        public string Name {  
            get { return name; }
            //set { name = value; }
        }
        public string CardNum
        {
            get { return cardNum; }
            //set { cardNum = value; }
        }
        public int Pin
        {
            get { return pin; }
        }
        public double Balance
        {
            set { balance = value; }
            get { return balance; }
        }

        public CardData(string name, string cardNum, int pin, double balance)
        {
            this.name = name;
            this.cardNum = cardNum;
            this.pin = pin;
            this.balance = balance;    
        }

        static void Main(string[] args)
        {
            // displaying options 
            void printOptions()
            {
                Console.WriteLine("\nPlease choose one of the following options ... ");
                Console.WriteLine("1- Deposit ");
                Console.WriteLine("2- Withdraw ");
                Console.WriteLine("3- Show balance ");
                Console.WriteLine("4- Exit ");

            }
            // deposit money into account 
            void deposit(CardData user)
            {
                Console.WriteLine("\nEnter deposit amount :");
                Console.Write("->");
                double deposit = Double.Parse(Console.ReadLine());
                user.Balance += deposit;
                Console.WriteLine("\nthank you for your $$ your new balance is :"+user.Balance+" $");
            }

            // withdraw money from account
            void withdraw(CardData user)
            {
                Console.WriteLine("\nEnter withdraw amount :");
                Console.Write("->");
                double withdraw = Double.Parse(Console.ReadLine());
                if (withdraw > user.Balance)
                {
                    Console.WriteLine("\nInsufficient balance :(");
                }
                else { 
                    user.Balance -= withdraw;
                    Console.WriteLine("thank you :)  your new balance is :" + user.Balance+" $");
                }
            }

            // show balance
            void balance(CardData user)
            {
                Console.WriteLine($"\nCurrent balance is : {user.Balance} $");
            }

            // db for testing 
            List<CardData> accounts = new List<CardData>();
            accounts.Add(new CardData("mohamed", "5106585899565974", 1234, 1020.50));
            accounts.Add(new CardData("ahmed"  , "5969065590214487" , 9373, 500.30));
            accounts.Add(new CardData("jak"    , "6129177322929563" , 3344, 10000));
            accounts.Add(new CardData("soso"   , "7339438215733614" , 1245, 20000));

            // starting our App
            Console.WriteLine("Welcome to Simple ATM ^_^");
            Console.WriteLine("Please insert your debit card:");
            Console.Write("->");
            string debitCardNum = "";
            CardData User;

            // fetching card data from db + validation
            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // search for card data st db
                    User = accounts.FirstOrDefault(u => u.CardNum == debitCardNum);

                    if(User != null) { break; }
                    else { Console.WriteLine("\nCard not recognized . Please try again"); }
                }
                catch
                {
                    Console.WriteLine("\nCard not recognized . Please try again");
                }
            }

            Console.WriteLine("Please enter your pin :");
            Console.Write("->");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin =int.Parse(Console.ReadLine());
                    // validate Pin
                    if (User.Pin == userPin) { break; }
                    else { Console.WriteLine("\nInvalid Pin . Please try again"); }
                }
                catch
                {
                    Console.WriteLine("\nInvalid Pin . Please try again");
                }
            }

            Console.WriteLine($"Welcome {User.Name} ^_^");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch{ }
                if (option == 1) { deposit(User); }
                else if (option == 2) { withdraw(User); }
                else if (option == 3) { balance(User); }
                else if (option == 4) { break; }
                else { option = 0; }

            } while (option != 4);

            Console.WriteLine("Thank you . Have a nice day :)");
        }
    }
}