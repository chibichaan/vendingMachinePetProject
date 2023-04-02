using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class ShowCommands : ICommand
    {
        private string[] commands;
        public ShowCommands(params string[] commands)
        {
            commands = commands;
        }

        /// <summary>
        /// Метод "выполнение" показывает доступные команды
        /// </summary>
        public void Execute()
        {
            foreach (var command in commands)
            {
                Console.WriteLine(command);
            }
        }

    }
}
