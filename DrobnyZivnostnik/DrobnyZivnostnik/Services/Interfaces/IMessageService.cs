namespace DrobnyZivnostnik.Services.Interfaces
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        /// <summary>
        /// Shows the asynchronous.
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <param name="titleKey">The title key.</param>
        /// <returns></returns>
        Task ShowAsync(string messageKey, string titleKey = null);

        /// <summary>
        /// Shows the errors asynchronous.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        Task ShowErrorsAsync(ICollection<ValidationResult> errors);
    }
}
