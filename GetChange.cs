using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class GetChange : ICommand
    {
        private WendingMachine machine;
        private int money = 0;

        public GetChange(WendingMachine machine)
        {
            this.machine = machine;
        }
        
        /// <summary>
        /// Метод "выполнение" тк он отдает сдачу, то общий баланс становится снова нулём
        /// </summary>
        public void Execute()
        {
            machine.ZeroingBalance();
        }
    }
}
