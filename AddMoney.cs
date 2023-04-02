using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class AddMoney : ICommand
    {
        private WendingMachine machine;
        private int money;

        public AddMoney(WendingMachine machine, int money)
        {
            this.machine = machine;
            this.money = money;
        }

        /// <summary>
        /// Метод "выполнение" пополнение баланса в автомате
        /// </summary>
        public void Execute()
        {
            machine.AddBalance(money);
        }
    }
}
