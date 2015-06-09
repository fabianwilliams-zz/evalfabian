using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace fwevals
{
	public class SessionCell : ViewCell
	{
		public SessionCell ()
		{
			var SessionTitleLabel = new Label {

				Font = Font.SystemFontOfSize (NamedSize.Small)
			};
			SessionTitleLabel.SetBinding (Label.TextProperty, new Binding ("SessionTitle"));

			var SessionNumberLabel = new Label {
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				XAlign = TextAlignment.End,
				HorizontalOptions = LayoutOptions.FillAndExpand

			};
			SessionNumberLabel.SetBinding (Label.TextProperty, new Binding ("SessionNumber"));


			View = new StackLayout {
				Children = {SessionTitleLabel, SessionNumberLabel},
				Orientation = StackOrientation.Horizontal

			};
		}
	}
}

