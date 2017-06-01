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
    public class StationDialogViewModel : StationData
    {
        public event Action Edited;

        public bool IsReadOnly { get; private set; }

        public bool CanDelete { get; private set; }

        public DialogModes Mode { get; private set; }

        public StationDialogViewModel(StationData item, bool isReadOnly)
        {
            Mode = DialogModes.Edit;
            this.Наименование = item.Наименование;
            SetKey(item.GetKey());
            CanDelete = !isReadOnly;
            IsReadOnly = isReadOnly;
        }

        public StationDialogViewModel()
        {
            Mode = DialogModes.New;
            CanDelete = false;
            IsReadOnly = false;
        }

        public void Edit()
        {
            switch (Mode)
            {
                case (DialogModes.New):
                    UserClient.AddStation((StationData)this);
                    Edited?.Invoke();
                    break;
                case (DialogModes.Edit):
                    UserClient.EditStation((StationData)this);
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
                    UserClient.DeleteStation((StationData)this);
                    Edited?.Invoke();
                    break;
            }
        }
    }
}
