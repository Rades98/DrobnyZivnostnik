namespace AxiosControls.Controls
{
    using Xamarin.Forms;

    public interface IValidatableControll
    {
        BindableProperty ErrorCollectionProperty { get; set; }

        string ErrorCollection { get; set; }
    }
}
