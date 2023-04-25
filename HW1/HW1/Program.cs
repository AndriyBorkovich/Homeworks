namespace HW1
{
    internal class Program
    {
        static void Main()
        {
            try 
            {
                // task 1
                Console.WriteLine("Welcome to simple bank!");
                var simpleBank = new SimpleBank();
                Console.WriteLine("Please, enter deposit amount:");
                double depositAmount1 = Convert.ToDouble(Console.ReadLine());
                simpleBank.MakeDeposit(depositAmount1);
                Console.WriteLine(simpleBank);
                Console.WriteLine();

                // task 2
                Console.WriteLine("Welcome to upgraded bank!");
                Console.WriteLine("We give bonuses ;)");
                var upgradedBank = new UpgradedBank();
                Console.WriteLine("Please, enter deposit amount:");
                double depositAmount2 = Convert.ToDouble(Console.ReadLine());
                upgradedBank.MakeDeposit(depositAmount2);
                Console.WriteLine(upgradedBank);

                // task 3
                // код з прикладу виведе:
                // Bar.Quux(object), тому що спершу відбудеться boxing  
                // Baz.Quux (params T[]), тому що params пріорітетніше для компілятора
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}