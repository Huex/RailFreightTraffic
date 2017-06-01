using RailFreightTraffic.Models.App;
using RailFreightTraffic.ViewModels.Database;
using RailFreightTraffic.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Dialogs
{
    class CargoDialogViewModel : CargoData
    {
        public event Action Edited;

        public bool IsReadOnly { get; private set; }

        public bool CanDelete { get; private set; }

        public DateTime DateTime {
            get
            {
                if(Дата != null)
                {
                    string da = Дата.Split(' ')[0];
                    DateTime date = new DateTime(Convert.ToInt32(da.Split('/')[2]), Convert.ToInt32(da.Split('/')[1]), Convert.ToInt32(da.Split('/')[0]));
                    return date;
                }else
                {
                    return DateTime.Now;
                }
                
            }
            set
            {
                Дата = value.Day + "/" + value.Month + "/" + value.Year;
            }
        }

        public List<string> Routes { get; private set; }

        public List<string> Contents { get; private set; }

        public List<string> Clients { get; private set; }

        public DialogModes Mode { get; private set; }

        public CargoDialogViewModel(CargoData item, bool isReadOnly)
        {
            Mode = DialogModes.Edit;

            this.Клиент = item.Клиент;
            this.Товар = item.Товар;
            this.Дата = item.Дата;
            this.Маршрут = item.Маршрут;
            this.Дата = item.Дата;

            Routes = new List<string>();
            Contents = new List<string>();
            Clients = new List<string>();
            SetKey(item.GetKey());
            CanDelete = !isReadOnly;
            IsReadOnly = isReadOnly;

            List<RouteData> ro = UserClient.LoadRoutes().ToList();
            foreach(var r in ro)
            {
                Routes.Add(r.Начальная + "-" + r.Конечная);
            }

            List<ContentsData> co = UserClient.LoadContents().ToList();
            foreach (var c in co)
            {
                Contents.Add(c.Наименование);
            }

            List<ClientData> cl = UserClient.LoadClients().ToList();
            foreach (var c in cl)
            {
                Clients.Add(c.Имя +" " +c.Фамилия);
            }
        }

        public CargoDialogViewModel()
        {
            Mode = DialogModes.New;
            CanDelete = false;
            IsReadOnly = false;

            Routes = new List<string>();
            Contents = new List<string>();
            Clients = new List<string>();

            List<RouteData> ro = UserClient.LoadRoutes().ToList();
            foreach (var r in ro)
            {
                Routes.Add(r.Начальная + "-" + r.Конечная);
            }

            List<ContentsData> co = UserClient.LoadContents().ToList();
            foreach (var c in co)
            {
                Contents.Add(c.Наименование);
            }

            List<ClientData> cl = UserClient.LoadClients().ToList();
            foreach (var c in cl)
            {
                Clients.Add(c.Имя + " " + c.Фамилия);
            }
        }

        public void Edit()
        {
            switch (Mode)
            {
                case (DialogModes.New):
                    UserClient.AddCargo((CargoData)this);
                    Edited?.Invoke();
                    break;
                case (DialogModes.Edit):
                    UserClient.EditCargo((CargoData)this);
                    Edited?.Invoke();
                    break;
            }
        }

        public void Delete()
        {
            switch (Mode)
            {
                case (DialogModes.New):
                    break;
                case (DialogModes.Edit):
                    UserClient.DeleteCargo((CargoData)this);
                    Edited?.Invoke();
                    break;
            }
        }
    }
}
