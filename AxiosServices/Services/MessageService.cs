namespace DrobnyZivnostnik.Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AxiosServices.Services.Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public class MessageService : IMessageService
    {
        private readonly ILocalizationService _localizationService = DependencyService.Get<ILocalizationService>();

        /// <inheritdoc />
        public async Task ShowAsync(string messageKey, string titleKey)
        {
            await Application.Current.MainPage.DisplayAlert(_localizationService.GetResourceByKey(titleKey),
                _localizationService.GetResourceByKey(messageKey), "Axios.Views.Common.Ok");
        }

        /// <inheritdoc />
        public async Task ShowErrorsAsync(ICollection<ValidationResult> errors)
        {
            var finalMessage = new StringBuilder();
            errors.ForEach(error =>
            {
                finalMessage.Append(
                    $"{_localizationService.GetResourceByKey(error.ErrorMessage)} : {_localizationService.GetResourceByKey(error.MemberNames.First())} \n");
            });

            await Application.Current.MainPage.DisplayAlert(
                _localizationService.GetResourceByKey("Axios.Views.Common.Error"), finalMessage.ToString(), _localizationService.GetResourceByKey("Axios.Views.Common.Ok"));
        }
    }
}
