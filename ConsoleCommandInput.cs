using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class ConsoleCommandInput : ICommandInput
    {
        //Считывает команду с консоли и преобразует её в команду с помощью роутера
        private Router router;

        public ConsoleCommandInput(Router router)
        {
            this.router = router;
        }

        public ICommand GetCommand()
        {
            string rawCommand = Console.ReadLine();
            Request request = ParseString(rawCommand);

            return router.CreateCommand(request);
        }

        private Request ParseString(string input)
        {
            string[] terms = input.Split(' ');
            int[] values = new int[0];

            if(terms.Length > 1)
            {
                values = new int[terms.Length - 1];
                for(int i=1; i< terms.Length; i++)
                {
                    values[i-1]= Convert.ToInt32(terms[i]);
                }
            }
            return new Request(terms[0], values);
        }
    }
}
