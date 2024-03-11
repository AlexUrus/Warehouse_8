using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseJournal.Services;

namespace WarehouseJournal.ViewModel
{
    public partial class AddItemPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private int count;

        [RelayCommand]
        private async Task AddItem()
        {
            if(Name != string.Empty && Count > 0)
            {
                await App.DataBase.SaveItemAsync(new Model.Item
                {
                    Name = this.Name,
                    Count = this.Count
                });

                await Application.Current.MainPage.DisplayAlert("ОК", "Товар добавлен", "ОК");
                ClearFields();
                DataUpdater.InformAboutDataUpdateEvent();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля инфорации о товаре", "ОК");
            }
        }

        private void ClearFields()
        {
            Name = string.Empty;
            Count = 0;
        }
    }
}
