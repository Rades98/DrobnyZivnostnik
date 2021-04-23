namespace DrobnyZivnostnik.ViewModels.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms.Internals;

    public abstract class CommonDetailViewModel<TModel> : BaseViewModel where TModel : class
    {
        private TModel _model;

        public ICollection<ValidationResult> Errors { get; set; } = new List<ValidationResult>();

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
        }

        public void RefreshAsyncSource()
        {
            var task = GetDataAsync();
            task.Wait();
            _model = task.Result;

            CustomRefresh();
        }

        public virtual Task<TModel> GetDataAsync() => (Task<TModel>)Task.CompletedTask;

        public virtual Task CustomRefresh() => (Task<TModel>)Task.CompletedTask; 

        protected bool ValidateModel()
        {
            var ValidationResults = new List<ValidationResult>();

            Model.GetType().GetProperties().ForEach(prop =>
            {
                var validationContext = new ValidationContext(Model, null)
                {
                    MemberName = prop.Name
                };

                var isValid = Validator.TryValidateProperty(prop.GetValue(Model), validationContext, ValidationResults);

                if (isValid)
                {
                    return;
                }

                var errMsg = ValidationResults.First().ErrorMessage;
                var errProp = LocalizationService.GetLocalizationKeyFromPropertyInfo(prop);

                Errors.Add(new ValidationResult(errMsg, new List<string>() { errProp}));

                ValidationResults.Clear();
            });


            return Errors.Count == 0;
        }
    }
}
