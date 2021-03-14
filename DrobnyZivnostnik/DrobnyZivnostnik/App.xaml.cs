namespace DrobnyZivnostnik
{
    using Views;
    using Xamarin.Forms;
    using static Startup;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Initialized();

            MainPage = new MasterDetailPage()
            {
                BackgroundColor = Color.Transparent,
                Master = new MasterMenuView(),
                Detail = new MainDetailView()
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
