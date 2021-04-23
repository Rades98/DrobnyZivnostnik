namespace AxiosControls.Controls
{
    using Axios.Extensions;
    using Xamarin.Forms;

    public class AxiosStackLayout : StackLayout
    {
        public AxiosStackLayout()
        {
            SetBackground();
        }

        private void SetBackground()
        {
            if (AxiosBackgroundView.IsNotNull())
            {
                Children.Add(AxiosBackgroundView);
            }
        }

        public static readonly BindableProperty AxiosBackgroundViewProperty =
            BindableProperty.Create(
                nameof(AxiosBackgroundView),
                typeof(object),
                typeof(View));

        public View AxiosBackgroundView
        {
            get => (View)GetValue(AxiosBackgroundViewProperty);
            set => SetValue(AxiosBackgroundViewProperty, value);
        }
    }
}