using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachinePetProject
{
    class Router
    {
        //Преобразуем запрос в команду и собирает заказ
        private WendingMachine machine;
        private RouterState state;

        public Router(WendingMachine machine)
        {
            machine = machine;
            this.state = new DefaultState(this);
        }
        public ICommand CreateCommand(Request request)
        {
            switch (request.Command) 
            {
                case "AddMoney":
                    if (request.IsIncorrectValuesCount(1)) return null;
                    return new AddMoney(machine, request.Values[0]);

                case "GetChange":
                    if (request.IsIncorrectValuesCount(0)) return null;
                    return new GetChange(machine);

                case "BuyGood":
                    if (request.IsIncorrectValuesCount(2)) return null;
                    return new BuyGood(machine, state.MakeOrder(request));

                case "ShowCommands":
                    if (request.IsIncorrectValuesCount(0)) return null;
                    return new ShowCommands("AddMoney", "GetChange", "BuyGood", "ShowCommands");

                case "Login":
                    if (request.IsIncorrectValuesCount(0)) return null;
                    return new Login(this);
                default:
                    return null;
            }
        }

        public void Login()
        {
            state = new AdminState(this);
        }

        public void Logout()
        {
            state = new DefaultState(this);
        }

        abstract class RouterState
        {
            protected readonly Router Router;
            public RouterState(Router router)
            {
                Router = router;
            }

            public abstract IOrder MakeOrder(Request request);
        }

        class DefaultState : RouterState
        {
            public DefaultState(Router router) : base(router)
            {

            }
            public override IOrder MakeOrder(Request request)
            {
                return new Order(Router.machine.GetFromId(request.Values[0]), request.Values[1]);
            }
        }

        class AdminState: RouterState
        {
            public AdminState(Router router):
                 base(router)
            {

            }

            public override IOrder MakeOrder(Request request)
            {
               return new FreeOrder(Router.machine.GetFromId(request.Values[0]), request.Values[1]);
            }
        }
    }
}
