namespace HolyJapan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "HolyJapan", Width = 565, Height = 1224 };
        }
    }
}
