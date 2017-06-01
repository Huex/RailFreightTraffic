using RailFreightTraffic.Models.App;
using RailFreightTraffic.ViewModels.Database;
using RailFreightTraffic.ViewModels.Dialogs;
using System;

namespace RailFreightTraffic.Dialogs
{
    public class UserDialogViewModel : UserData
    {
        public event Action Edited;

        public bool IsReadOnly { get; private set; }

        public bool CanDelete { get; private set; }

        public DialogModes Mode { get; private set; }

        public UserDialogViewModel(UserData item, bool isReadOnly)
        {
            Mode = DialogModes.Edit;
            this.Логин = item.Логин;
            this.Пароль = item.Пароль;
            this.Грузы = item.Грузы;
            this.Клиенты = item.Клиенты;
            this.Товары = item.Товары;
            this.Маршруты = item.Маршруты;
            this.Пользователи = item.Пользователи;
            this.Станции = item.Станции;
            SetKey(item.GetKey());
            CanDelete = !isReadOnly;
            IsReadOnly = isReadOnly;
        }

        public UserDialogViewModel()
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
                    UserClient.AddUser((UserData)this);
                    Edited?.Invoke();
                    break;
                case (DialogModes.Edit):
                    UserClient.EditUser((UserData)this);
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
                    UserClient.DeleteUser((UserData)this);
                    Edited?.Invoke();
                    break;
            }
        }
    }
}
