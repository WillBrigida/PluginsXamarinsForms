using PluginsXamarinsForms.Models;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PluginsXamarinsForms.ViewModels
{


    public class BottomSheetViewModel : BaseViewModel
    {
        #region PROPRIEDADES
        public ObservableCollection<Produto> ListaProdutos { get; set; }
        #endregion

        #region CONSTRUTOR
        protected BottomSheetViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService, pageDialogService)
        {
            this.Title = "Bottom Sheet";
            ListaProdutos = new ObservableCollection<Produto>();
            ListaFake();

        }
        #endregion


        private void ListaFake()
        {
            var lista = new List<Produto>()
            {
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
                new Produto {Nome = "Arroz", Valor = "R$5,00" },
            };
            foreach (var item in lista)
            {
                ListaProdutos.Add(item);
            }
        }

    }

}


