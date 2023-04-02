using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class FreeOrder : IOrder
    {
        //Описание товара, за который не нужно платить
        private Good good;
        private int count;

        public FreeOrder(Good good, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException();

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

        public int GetTotalPrice()
        {
            return 0;
        }

        public void Ship()
        {
            good.Count -= count;
        }
    }
}
