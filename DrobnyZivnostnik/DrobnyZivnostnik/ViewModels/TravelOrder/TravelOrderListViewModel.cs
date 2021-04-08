namespace DrobnyZivnostnik.ViewModels.TravelOrder
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Common;
    using Models.TravelOrder;
    using Services.Interfaces;
    using Xamarin.Forms;

    class TravelOrderListViewModel : CommonListViewModel<TravelOrderFrontModel>
    {
        private readonly ITravelOrderService _travelOrderService = DependencyService.Get<ITravelOrderService>();

        public TravelOrderListViewModel()
        {
        }

        public override async Task<ObservableCollection<TravelOrderFrontModel>> GetDataAsync()
        {
            var data = await _travelOrderService.GetAsync();
            return  new ObservableCollection<TravelOrderFrontModel>(data);
        }
    }
}
