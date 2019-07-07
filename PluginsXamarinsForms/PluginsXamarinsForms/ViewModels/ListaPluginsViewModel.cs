using Prism.Navigation;
using Prism.Services;

namespace PluginsXamarinsForms.ViewModels
{
    public class ListaPluginsViewModel : BaseViewModel
    {
        protected ListaPluginsViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : 
            base(navigationService, pageDialogService)
        {
            this.Title = "Lista de Plugins";
        }
    }
}
