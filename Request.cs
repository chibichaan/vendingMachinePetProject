using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class Request
    {
        //Описывает запрос к автомату
        public Request(string command, int[] values)
        {
            Command = command;
            Values = values;
        }

        public string Command { get; set; }
        public int[] Values { get; set; }

        /// <summary>
        /// Метод проверяет на некорректность значение 
        /// </summary>
        /// <param name="correct"></param>
        /// <returns></returns>
        public bool IsIncorrectValuesCount(int correct)
        {
            return correct != Values.Length;
        }
    }
}
