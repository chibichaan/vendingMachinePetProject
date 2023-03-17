using System;
namespace vendingMachinePetProject
{
    class Program
    {
        enum PaymentType { Coins, Card };
        static void Main(string[] args)
        {
            int balance = 0;
            int[] coinsValues = { 1, 2, 5, 10 }; //номинал монет
            int[] coinsQuantity = { 0, 0, 0, 0 }; //кол-во монет
            
        PaymentType payment = PaymentType.Card;

            string[] names = { "чипсы", "кола" };
            int[] prices = { 100, 60 }; //цена каждого товара
            int[] available = { 15, 10 }; //доступное кол-во товара

            #region Методы для товара
            //Возвращает имя товара
            void GetName()
            {
                return; 
            }
            //Возвращает цену товара
            void GetPrice()
            {
                return;
            }
            //Возвращает доступное кол-во товара
            void GetAvailableAmount()
            {
                return;
            }
            #endregion

            //string command = " ";

            // попытка в сокрытие метода
            //public new void GetName()
            //{
            //    return;
            //}

            // Метод снимает деньги с карты/ считывает номиналом кол-во монет
            void AddMoney()
            {
                //Console.WriteLine("Введите способ оплаты: Coins/Card");
                //string choosePaymentType = Console.ReadLine();

                switch (payment) //выбирает только "карту"
                {
                    case PaymentType.Coins:
                        for (int i = 0; i < coinsValues.Length; i++)
                        {
                            Console.WriteLine($"Сколько монет номиналом {coinsValues[i]} вы вносите?");
                            int count = 0;
                            coinsQuantity[i] += EnterNumbers(count);
                            balance = EnterNumbers(count) * coinsValues[i];
                        }
                        break;
                    case PaymentType.Card:
                        Console.WriteLine("Сколько внести с карты?");
                        int balanceDelto = 0;
                        balance += EnterNumbers(balanceDelto);
                        break;
                    default:
                        break;
                }
            }

            //Метод проверяет введённую сумму и возвращает полученное значение (если оно верно)
            int EnterNumbers(int balanceDeltoOrCard)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int newBalance))
                    {
                        Console.WriteLine($"Вы ввели число {newBalance}");
                        return newBalance;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
                    }
                }  
            }

            // Метод возвращает сдачу
            void GetChange()
            {
                balance = 0;
            }

            //Метод покупки товара
            void BuyGood()
            {
                Console.WriteLine("Покупка товара! Напишите номер товара и его кол-во");
                string[] rawData = Console.ReadLine().Split(' ');
                //string[] rawData = command.Substring("BuyGood ".Length).Split(' '); //\u002C
                if (rawData.Length != 2)
                {
                    Console.WriteLine("Некорректные аргументы команды");
                }
                int id = Convert.ToInt32(rawData[0]);
                int count = Convert.ToInt32(rawData[1]);

                if (id < 0 || id >= names.Length)
                {
                    Console.WriteLine("Товара нет с таким айди");
                }
                if (count < 0 || count > available[id])
                {
                    Console.WriteLine("Нет таково количества товара");
                }
                if (balance >= prices[id] * count)
                {
                    available[id] -= count;
                    balance -= prices[id] * count;
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"На данный момент ваш баланс: {balance}");
                AddMoney();
                BuyGood();

                
            }
            


        }
    }
}
