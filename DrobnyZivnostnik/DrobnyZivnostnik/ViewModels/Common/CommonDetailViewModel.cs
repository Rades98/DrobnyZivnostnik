namespace DrobnyZivnostnik.ViewModels.Common
{
    using System.Threading.Tasks;

    public abstract class CommonDetailViewModel<TModel> : BaseViewModel where TModel : class
    {
        private TModel _model;

        public TModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        protected CommonDetailViewModel()
        {
            RefreshAsyncSource();
        }

        public void RefreshAsyncSource()
        {
            var task = GetDataAsync();
            task.Wait();
            _model = task.Result;

            CustomRefresh();
        }

        public abstract Task<TModel> GetDataAsync();

        public abstract Task CustomRefresh();
    }
}
