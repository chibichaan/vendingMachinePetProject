using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class WendingMachine
    {
        //Мусорка
        private Good[] goods;
        
        public WendingMachine(int balance, params Good[] goods)
        {
            this.goods = goods;
            this.Balance = balance;
        }

        public int Balance { get; private set; }

        public void AddBalance(int delta)
        {
            if (delta < 0) throw new ArgumentOutOfRangeException("delta");
            Balance += delta;
        }

        public void ZeroingBalance()
        {
            Balance = 0;
        }
        public bool IsOrderPossible(IOrder order)
        {
            return order.IsAvailable && order.GetTotalPrice() <= Balance;
        }

        public bool TryProcessOrder(IOrder order)
        {
            if (IsOrderPossible(order))
            {
                Balance -= order.GetTotalPrice();
                order.Ship();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsContains(int id)
        {
            return id >= 0 && id < goods.Length;
        }

        public Good GetFromId(int id)
        {
            if(!IsContains(id)) throw new ArgumentOutOfRangeException("id");
            return goods[id];
        }
    }
}
