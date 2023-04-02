using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class Login : ICommand
    {
        private Router state;
        public Login(Router state)
        {
            this.state = state;
        }

        /// <summary>
        /// Метод "выполнение" получается входит в автомат от имени "администратора"
        /// </summary>
        public void Execute()
        {
            state.Login();
        }
    }
}
