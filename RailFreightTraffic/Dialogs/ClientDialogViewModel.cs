using RailFreightTraffic.Commands;
using RailFreightTraffic.Models.App;
using RailFreightTraffic.ViewModels.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RailFreightTraffic.ViewModels.Dialogs
{
    public class ClientDialogViewModel : ClientData
    {
        public event Action Edited;

        public bool IsReadOnly { get; private set; }

        public bool CanDelete { get; private set; }

        public DialogModes Mode { get; private set; }

        public ClientDialogViewModel(ClientData item, bool isReadOnly)
        {
            Mode = DialogModes.Edit;
            this.Имя = item.Имя;
            this.Фамилия = item.Фамилия;
            this.Компания = item.Компания;
            SetKey(item.GetKey());
            CanDelete = !isReadOnly;
            IsReadOnly = isReadOnly;
        }

        public ClientDialogViewModel()
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
                    UserClient.AddClient((ClientData)this);
                    Edited?.Invoke();
                    break;
                case (DialogModes.Edit):
                    UserClient.EditClient((ClientData)this);
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
                    UserClient.DeleteClient((ClientData)this);
                    Edited?.Invoke();
                    break;
            }
        }
    }
}
