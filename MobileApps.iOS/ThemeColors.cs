using System.Collections.Generic;
using Xamarin.Forms;
using UXDivers.Artina.Shared;

namespace MobileApps.iOS
 {
	internal class ThemeColors : ThemeColorsBase
	{
		private readonly static Dictionary<string, Color> _themeColors = new Dictionary<string, Color>
		{
			{ "AccentColor", Color.FromHex("#EE3244") },
			{ "BaseTextColor", Color.FromHex("#FFFFFF") },
			{ "InverseTextColor", Color.White },
			{ "BrandColor", Color.FromHex("#ad1457") },
			{ "BrandNameColor", Color.FromHex("#FFFFFF") },
			{ "BaseLightTextColor", Color.FromHex("#7b7b7b") },
			{ "OverImageTextColor", Color.FromHex("#FFFFFF") },
			{ "EcommercePromoTextColor", Color.FromHex("#FFFFFF") },
			{ "SocialHeaderTextColor", Color.FromHex("#666666") },
			{ "ArticleHeaderBackgroundColor", Color.FromHex("#F1F3F5") },
			{ "CustomNavBarTextColor", Color.FromHex("#FFFFFF") },
			{ "CustomNavBarBrandColor", Color.FromHex("#FFFFFF") },
			{ "ListViewItemTextColor", Color.FromHex("#FFFFFF") },
			{ "AboutHeaderBackgroundColor", Color.FromHex("#FFFFFF") },
			{ "BasePageColor", Color.FromHex("#FFFFFF") },
			{ "BaseTabbedPageColor", Color.FromHex("#fafafa") },
			{ "MainWrapperBackgroundColor", Color.FromHex("#EFEFEF") },
			{ "CategoriesListIconColor", Color.FromHex("#FFFFFF") },
			{ "DashboardIconColor", Color.FromHex("#FFFFFF") },
			{ "ComplementColor", Color.FromHex("#525ABB") },
			{ "TranslucidBlack", Color.FromHex("#44000000") },
			{ "TranslucidWhite", Color.FromHex("#22ffffff") },
			{ "OkColor", Color.FromHex("#22c064") },
			{ "ErrorColor", Color.Red },
			{ "WarningColor", Color.FromHex("#ffc107") },
			{ "NotificationColor", Color.FromHex("#1274d1") },
			{ "SaveButtonColor", Color.FromHex("#22c064") },
			{ "DeleteButtonColor", Color.FromHex("#D50000") },
			{ "LabelButtonColor", Color.FromHex("#ffffff") },
			{ "PlaceholderColor", Color.FromHex("#22ffffff") },
			{ "PlaceholderColorEntry", Color.FromHex("#FFFFFF") },
			{ "RoundedLabelBackgroundColor", Color.FromHex("#525ABB") },
			{ "MainMenuHeaderBackgroundColor", Color.FromHex("#384F63") },
			{ "MainMenuBackgroundColor", Color.FromHex("#F1F3F5") },
			{ "MainMenuSeparatorColor", Color.Transparent },
			{ "MainMenuTextColor", Color.FromHex("#FFFFFF") },
			{ "MainMenuIconColor", Color.FromHex("#FFFFFF") },
			{ "ListViewSeparatorColor", Color.FromHex("#D3D3D3") },
			{ "BaseSeparatorColor", Color.FromHex("#7b7b7b") },
			{ "ChatRightBalloonBackgroundColor", Color.FromHex("#525ABB") },
			{ "ChatBalloonFooterTextColor", Color.FromHex("#FFFFFF") },
			{ "ChatRightTextColor", Color.FromHex("#FFFFFF") },
			{ "ChatLeftTextColor", Color.FromHex("#FFFFFF") }
		};
		public ThemeColors() : base(_themeColors) {}
	}
}
