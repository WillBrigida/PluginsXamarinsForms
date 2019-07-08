using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PluginsXamarinsForms.ViewModels
{
    public class ListaPluginsViewModel : BaseViewModel
    {
        #region PROPRIEDADES

        #endregion

        #region CONSTRUTOR
        protected ListaPluginsViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
           base(navigationService, pageDialogService)
        {
            this.Title = "Lista de Plugins";
        }
        #endregion

        #region COMMANDS
        public DelegateCommand BottomSheetCommand => new DelegateCommand(async ()=> await OnBottomSheet());
        #endregion

        #region MÉTODOS
        private async Task OnBottomSheet() => await NavigationService.NavigateAsync("/NavigationPage/ListaPluginsPage/BottomSheetPage");
        #endregion
       

        
    }
}
