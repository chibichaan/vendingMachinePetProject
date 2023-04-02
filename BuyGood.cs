using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class BuyGood : ICommand
    {
        private WendingMachine machine;
        private IOrder order;

        public BuyGood(WendingMachine machine, IOrder order)
        {
            this.machine = machine;
            this.order = order;
        }

        /// <summary>
        /// Метод "выполнение" попробовать собрать заказ
        /// </summary>
        public void Execute()
        {
            machine.TryProcessOrder(order);
        }
    }
}
