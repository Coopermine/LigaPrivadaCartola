using Android.App;
using System.Collections.Generic;
using Android.Widget;
using Android.OS;
using System.Drawing;
using System.Data;
using Syncfusion.SfDataGrid;
using Android.Views;
using System;
using Syncfusion.Data;
using SatelliteMenu;

namespace GettingStarted
{
	[Activity (Label = "Cartola Bar do Ney 2016", MainLauncher = true, Icon = "@drawable/bolaicon")]
	public class MainActivity : Activity

	{
		SfDataGrid sfGrid;

		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			ActionBar.SetDisplayShowHomeEnabled (false);

			RelativeLayout layout = (RelativeLayout)FindViewById (Resource.Id.Relative);


			sfGrid = new SfDataGrid (BaseContext);
            sfGrid.LoadMoreText = "Carregar mais times..";
            sfGrid.LoadMorePosition = LoadMoreViewPosition.Bottom;
            sfGrid.AllowLoadMore = true;


            AlertDialog.Builder alert = new AlertDialog.Builder(this);

          

            alert.SetPositiveButton("Good", (senderAlert, args) => {
                //change value write your own set of instructions
                //you can also create an event for the same in xamarin
                //instead of writing things here
            });

            alert.SetNegativeButton("Not doing great", (senderAlert, args) => {
                //perform your own task for this conditional button click
            });

            try
            {

               
            sfGrid.ItemsSource = (new ListaTotalRodada().OrderInfoCollection);


            }
            catch (Exception ex)
            {
                 alert.SetTitle(ex.ToString());
                RunOnUiThread(() => {
                    alert.Show();
                });
            }


            //  

            
            //run the alert in UI thread to display in the screen
         





            sfGrid.AllowPullToRefresh = true;
      

         //   sfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "Time" } );

          
      //     sfGrid.AutoGeneratingColumn += HandleAutoGeneratingColumn;

            var menu = FindViewById<SatelliteMenuButton>(Resource.Id.menu);
            var items = new List<SatelliteMenuButtonItem>();

            // just add one by one

            items.Add(new SatelliteMenuButtonItem((int)MenuItemType.cartoletas, Resource.Drawable.cartoleta2));
            items.Add(new SatelliteMenuButtonItem((int)MenuItemType.maisescalados, Resource.Drawable.person));
                   items.Add(new SatelliteMenuButtonItem((int)MenuItemType.pontape, Resource.Drawable.icolista));
            items.Add(new SatelliteMenuButtonItem((int)MenuItemType.rodada, Resource.Drawable.refre));
            items.Add(new SatelliteMenuButtonItem((int)MenuItemType.campeonato, Resource.Drawable.trofeu64));
            // now add all to the menus
            menu.AddItems(items.ToArray());




            menu.MenuItemClick += delegate (object sender, SatelliteMenuItemEventArgs e)
            {
                // parse the enum value from int back to the enum here
                MenuItemType mit = (MenuItemType)Enum.Parse(typeof(MenuItemType), e.MenuItem.Tag.ToString());

                // just show the menu item selected toast, in the app we would probably fire new activity or similar
                Toast.MakeText(this, string.Format("Carregando lista {0}", mit), ToastLength.Short).Show();

                string men = string.Format("{0}", mit);

                if (men.Equals("rodada"))
                {
                    sfGrid.ItemsSource = (new OrderInfoRepository().OrderInfoCollection);
                }
                else
                {
                    sfGrid.ItemsSource = (new ListaTotalRodada().OrderInfoCollection);
                }

            };


            //GridSummaryRow summaryRow = new GridSummaryRow();
            //summaryRow.Title = "{Key} - Total: {CaptionSummary}";
            //summaryRow.ShowSummaryInRow = true;
            //sfGrid.CaptionSummaryRow = summaryRow;

            //summaryRow.SummaryColumns.Add(
            //    new GridSummaryColumn()
            //    {
            //        Name = "CaptionSummary",
            //        MappingName = "Pontos",
            //        Format = "{Sum}",
            //        SummaryType = SummaryType.DoubleAggregate
            //    }
            //    );
            //sfGrid.CaptionSummaryRow = summaryRow;

            //   sfGrid.GroupCaptionTextFormat = "{ColumnName} : {Key} - {CaptionSummary} pontos";

            //  sfGrid.GridStyle = new Dark();





            layout.AddView (sfGrid);


		}

        //Custom style class
       

        void HandleAutoGeneratingColumn(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "Pontos")
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            else if (e.Column.MappingName == "Codigo")
                e.Cancel = true;
            else if (e.Column.MappingName == "Time")
                e.Cancel = true;
            else if (e.Column.MappingName == "Posicao")
                e.Cancel = true;
            else if (e.Column.MappingName == "Pontos")
                e.Column.TextAlignment = GravityFlags.CenterVertical;
        }

	}

}


