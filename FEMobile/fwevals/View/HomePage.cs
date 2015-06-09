using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace fwevals
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{

			Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0);
			Title = "Conference Evaluation App";



			var buttonEnter = new Button { 
				Text = "View Session",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.FillAndExpand,
				BorderWidth = 1,
				BorderColor = Color.White,
				BackgroundColor = Color.Black

			};

			buttonEnter.Clicked += (sender, e) => {
				Navigation.PushAsync(new ShowSession());
			};
				
			Content = new StackLayout {

				Children = { buttonEnter
				}

			};


		}
	}
}

