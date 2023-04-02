using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    interface IOrder
    {
        bool IsAvailable { get; }
        int GetTotalPrice();
        void Ship();
    }
}
