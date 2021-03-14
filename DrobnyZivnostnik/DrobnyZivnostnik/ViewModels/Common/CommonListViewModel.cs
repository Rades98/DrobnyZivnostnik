namespace DrobnyZivnostnik.ViewModels.Common
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public abstract class CommonListViewModel<TModel> : BaseViewModel where TModel : class
    {
        private ObservableCollection<TModel> _models;

        public ObservableCollection<TModel> Models
        {
            get => _models;
            set
            {
                _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        protected CommonListViewModel()
        {
            Initialized();
        }

        private void Initialized()
        {
            var task = GetDataAsync();
            task.Wait();
            _models = task.Result;
        }

        public abstract Task<ObservableCollection<TModel>> GetDataAsync();
    }
}
