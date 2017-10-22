using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileApps
{
	public partial class Badge : ContentView
	{
		public Badge ()
		{
			InitializeComponent ();
		}
		/* CIRCLE */

		public static BindableProperty BadgeBackgroundColorProperty =
			BindableProperty.Create (
				nameof ( BadgeBackgroundColor ), 
				typeof ( Color ),
				typeof ( Badge ),
				defaultValue		: Color.Default,
				defaultBindingMode	: BindingMode.OneWay
			);

		public Color BadgeBackgroundColor {
			get { return ( Color )GetValue( BadgeBackgroundColorProperty ); }
			set { SetValue ( BadgeBackgroundColorProperty, value ); }
		}

		/* ICON */

		public static BindableProperty BadgeTextColorProperty =
			BindableProperty.Create (
				nameof( BadgeTextColor ), 
				typeof ( Color ),
				typeof ( Badge ),
				defaultValue		: Color.White,
				defaultBindingMode	: BindingMode.OneWay
			);

		public Color BadgeTextColor {
			get { return ( Color )GetValue( BadgeTextColorProperty ); }
			set { SetValue ( BadgeTextColorProperty, value ); }
		}

		public static BindableProperty BadgeTextProperty =
			BindableProperty.Create (
				nameof( BadgeText ),
				typeof ( string ),
				typeof ( Badge ),
				defaultValue		: "",
				defaultBindingMode	: BindingMode.OneWay
			);

		public string BadgeText {
			get { return ( string ) GetValue( BadgeTextProperty ); }
			set { SetValue ( BadgeTextProperty, value ); }
		}
	}
}

