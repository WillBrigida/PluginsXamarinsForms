using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluginsXamarinsForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomSheetPage : ContentPage
    {
        public BottomSheetPage()
        {
            InitializeComponent();
        }

        void Handle_IngredientSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            dismissBottomSheet();
        }


        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var ingredients = IngredientsData.IngredientsList;

            if (e.NewTextValue != string.Empty)
            {
                //only show the grid view when no text is displayed
                //GridFilter.IsVisible = false;

                //var filteredIngredients = new List<Ingredient>();
                //foreach (var ingredient in ingredients)
                //{
                //    if (ingredient.Name.StartsWith(e.NewTextValue, StringComparison.Ordinal))
                //    {
                //        filteredIngredients.Add(ingredient);
                //    }
                //}
                //IngredientsListView.ItemsSource = filteredIngredients;
                return;
            }

            //IngredientsListView.ItemsSource = ingredients;
           // GridFilter.IsVisible = true;
        }


        // Important Code Lives Below
        double x, y;


        void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            //GridFilter.IsVisible = true;
            openBottomSheet();
        }


        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            // Handle the pan
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't y + e.TotalY pan beyond the wrapped user interface element bounds.
                    var translateY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs((Height * .5) - Height));
                    bottomSheet.TranslateTo(bottomSheet.X, translateY, 50);


                   
                    break;


                 



                    case GestureStatus.Completed:
                        // Store the translation applied during the pan
                        y = bottomSheet.TranslationY;

                        //at the end of the event - snap to the closest location
                        var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getClosestLockState(e.TotalY + y)));

                        //depending on Swipe Up or Down - change the snapping animation
                        if (isSwipeUp(e))
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 400, Easing.SpringIn);
                        }
                        else
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 400, Easing.SpringOut);
                        }

                        //dismiss the keyboard after a transition
                        //SearchBox.Unfocus();
                        y = bottomSheet.TranslationY;

                        break;

            }

        }

        public bool isSwipeUp(PanUpdatedEventArgs e)
        {
            if (e.TotalY < 0)
            {
                return true;
            }
            return false;
        }

        //TO-DO: Make this cleaner
        public double getClosestLockState(double TranslationY)
        {
            //Play with these values to adjust the locking motions - this will change depending on the amount of content ona  apge
            var lockStates = new double[] { 0, .85 };

            //get the current proportion of the sheet in relation to the screen
            var distance = Math.Abs(TranslationY);
            var currentProportion = distance / Height;

            //calculate which lockstate it's the closest to
            var smallestDistance = 1000.0;
            var closestIndex = 0;
            for (var i = 0; i < lockStates.Length; i++)
            {
                var state = lockStates[i];
                var absoluteDistance = Math.Abs(state - currentProportion);
                if (absoluteDistance < smallestDistance)
                {
                    smallestDistance = absoluteDistance;
                    closestIndex = i;
                }

            }

            var selectedLockState = lockStates[closestIndex];
            var TranslateToLockState = getProportionCoordinate(selectedLockState);

            return TranslateToLockState;
        }

        public double getProportionCoordinate(double proportion)
        {
            return proportion * Height;
        }

        void dismissBottomSheet()
        {

            //SearchBox.Unfocus();
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(0)));
            bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 150, Easing.SpringOut);
            //SearchBox.Text = string.Empty;
        }

        void openBottomSheet()
        {
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.85)));
            bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 150, Easing.SpringIn);
        }

    }
}