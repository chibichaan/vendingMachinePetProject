using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class Order : IOrder
    {
        //Описывает товар
        private Good good;
        private int count;

        public Order(Good good, int count)
        {
            this.good = good;
            this.count = count;
        }

        public bool IsAvailable
        {
            get
            {
                return count <= good.Count;
            }
        }

        /// <summary>
        /// Метод возвращает полную сумму заказа
        /// </summary>
        /// <returns></returns>
        public int GetTotalPrice()
        {
            return good.Price * count;
        }

        /// <summary>
        /// Метод уменьшает количество доступных товаров в автомате 
        /// </summary>
        public void Ship()
        {
            good.Count -= count;
        }
    }
}
