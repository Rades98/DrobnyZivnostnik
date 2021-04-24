namespace DrobnyZivnostnik.ViewModels.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms.Internals;

    public abstract class CommonDetailViewModel<TModel> : BaseViewModel where TModel : class
    {
        private TModel _model;

        public Dictionary<string, string> ErrorMessages { get; set; } = new Dictionary<string, string>();

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
            var validationResults = new List<ValidationResult>();

            ErrorMessages = new Dictionary<string, string>();

            Model.GetType().GetProperties().ForEach(prop =>
            {
                var validationContext = new ValidationContext(Model, null)
                {
                    MemberName = prop.Name
                };

                var isValid = Validator.TryValidateProperty(prop.GetValue(Model), validationContext, validationResults);

                if (isValid)
                {
                    ErrorMessages.Add(prop.Name, string.Empty);
                    return;
                }

                var errMsg = validationResults.First().ErrorMessage;
                ErrorMessages.Add(prop.Name, errMsg);

                validationResults.Clear();
            });

            OnPropertyChanged(nameof(ErrorMessages));

            return ErrorMessages.Count == 0;
        }
    }
}
