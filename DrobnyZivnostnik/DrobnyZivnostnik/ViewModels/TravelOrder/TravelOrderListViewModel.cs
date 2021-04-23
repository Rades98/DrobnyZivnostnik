namespace DrobnyZivnostnik.ViewModels.TravelOrder
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Application.Models.TravelOrder;
    using Application.Services.Interfaces;
    using Common;
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
