using NEOApp.Models;
using NEOApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using NEOApp;

namespace NEOApp.ViewModels
{
  public class ItemsViewModel : BaseViewModel
  {
    private Item _selectedItem;

    public Command LoadItemsCommand { get; }
    public Command<Item> ItemTapped { get; }

    public ItemsViewModel()
    {
      Title = "Browse";
      //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
      ItemTapped = new Command<Item>(OnItemSelected);
    }

    //async Task ExecuteLoadItemsCommand()
    //{
    //  IsBusy = true;

    //  try
    //  {
    //    Items.Clear();
    //    var items = await DataStore.GetItemsAsync(true);
    //    foreach (var item in items)
    //    {
    //      Items.Add(item);
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    Debug.WriteLine(ex);
    //  }
    //  finally
    //  {
    //    IsBusy = false;
    //  }
    //}

    public void OnAppearing()
    {
      IsBusy = true;
      SelectedItem = null;
    }

    public Item SelectedItem
    {
      get => _selectedItem;
      set
      {
        SetProperty(ref _selectedItem, value);
        OnItemSelected(value);
      }
    }

    async void OnItemSelected(Item item)
    {
      if (item == null)
        return;

      // This will push the ItemDetailPage onto the navigation stack
      await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
    }
  }
}