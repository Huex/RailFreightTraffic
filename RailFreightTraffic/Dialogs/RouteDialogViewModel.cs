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
    class RouteDialogViewModel : RouteData
    {
        public event Action Edited;

        public bool IsReadOnly { get; private set; }

        public bool CanDelete { get; private set; }

        public List<string> Stations { get; private set; }

        public DialogModes Mode { get; private set; }

        public RouteDialogViewModel(RouteData item, bool isReadOnly)
        {
            Mode = DialogModes.Edit;
            this.Начальная = item.Начальная;
            this.Конечная = item.Конечная;
            this.Цена = item.Цена;
            Stations = new List<string>();
            SetKey(item.GetKey());
            CanDelete = !isReadOnly;
            IsReadOnly = isReadOnly;
            List<StationData> station = UserClient.LoadStations().ToList();
            foreach(var stat in station)
            {
                Stations.Add(stat.Наименование);
            }
        }

        public RouteDialogViewModel()
        {
            Mode = DialogModes.New;
            CanDelete = false;
            IsReadOnly = false;
            Stations = new List<string>();
            List<StationData> station = UserClient.LoadStations().ToList();
            foreach (var stat in station)
            {
                Stations.Add(stat.Наименование);
            }
        }

        public void Edit()
        {
            switch (Mode)
            {
                case (DialogModes.New):
                    UserClient.AddRoute((RouteData)this);
                    Edited?.Invoke();
                    break;
                case (DialogModes.Edit):
                    UserClient.EditRoute((RouteData)this);
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
                    UserClient.DeleteRoute((RouteData)this);
                    Edited?.Invoke();
                    break;
            }
        }
    }
}
