namespace AxiosControls.Controls.LayoutControls
{
    using System;
    using Xamarin.Forms;

    public class AxiosExpandableView : ContentView
    {
        private readonly TapGestureRecognizer _tapGestureRecognizer = new TapGestureRecognizer();

        private StackLayout _summary;
        private StackLayout _details;

        public AxiosExpandableView()
        {
            _summary.GestureRecognizers.Add(_tapGestureRecognizer);
            _tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
        }

        public virtual StackLayout Summary
        {
            get => _summary;
            set
            {
                _summary = value;
                _summary.Children.Add(_summary);
                OnPropertyChanged();
            }
        }

        public virtual StackLayout Details
        {
            get => _details;
            set
            {
                _details = value;
                _details.Children.Add(_details);
                OnPropertyChanged();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            _details.IsVisible = !_details.IsVisible;
        }
    }
}
