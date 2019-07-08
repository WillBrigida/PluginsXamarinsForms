using PluginsXamarinsForms.ViewModels;
using PluginsXamarinsForms.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace PluginsXamarinsForms
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("/NavigationPage/ListaPluginsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListaPluginsPage, ListaPluginsViewModel>();
            containerRegistry.RegisterForNavigation<BottomSheetPage, BottomSheetViewModel>();
        }
    }
}






//protected override void OnStart()
//{
//    // Handle when your app starts
//}

//protected override void OnSleep()
//{
//    // Handle when your app sleeps
//}

//protected override void OnResume()
//{
//    // Handle when your app resumes
//}
