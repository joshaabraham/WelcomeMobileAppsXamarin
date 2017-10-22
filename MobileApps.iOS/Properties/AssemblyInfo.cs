using System.Reflection;
using Xamarin.Forms;
using MobileApps;

[assembly: AssemblyTitle (AssemblyGlobal.ProductLine + " - " + "Grial Xamarin.Forms UIKit (iOS)")]
[assembly: AssemblyConfiguration (AssemblyGlobal.Configuration)]
[assembly: AssemblyCompany (AssemblyGlobal.Company)]
[assembly: AssemblyProduct (AssemblyGlobal.ProductLine + " - " + "Grial Xamarin.Forms UIKit (iOS)")]
[assembly: AssemblyCopyright (AssemblyGlobal.Copyright)]

[assembly: UXDivers.Artina.Shared.GrialVersion("2.0.52.0")]

// Custom renderer definition

[assembly: ExportRenderer(typeof(UXDivers.Artina.Shared.CircleImage), typeof(UXDivers.Artina.Shared.ImageCircleRenderer))]
[assembly: ExportRenderer(typeof(EntryCell), typeof(UXDivers.Artina.Shared.ArtinaEntryCellRenderer))]
[assembly: ExportRenderer(typeof(ImageCell), typeof(UXDivers.Artina.Shared.ArtinaImageCellRenderer))]
[assembly: ExportRenderer(typeof(SwitchCell), typeof(UXDivers.Artina.Shared.ArtinaSwitchCellRenderer))]
[assembly: ExportRenderer(typeof(TableView), typeof(UXDivers.Artina.Shared.ArtinaTableRenderer))]
[assembly: ExportRenderer(typeof(TextCell), typeof(UXDivers.Artina.Shared.ArtinaTextCellRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(UXDivers.Artina.Shared.ArtinaViewCellRenderer))]

[assembly: ExportRenderer(typeof(Entry), typeof(UXDivers.Artina.Shared.ArtinaEntryRenderer))]
[assembly: ExportRenderer(typeof(Picker), typeof(UXDivers.Artina.Shared.ArtinaPickerRenderer))]
[assembly: ExportRenderer(typeof(DatePicker), typeof(UXDivers.Artina.Shared.ArtinaDatePickerRenderer))]
[assembly: ExportRenderer(typeof(TimePicker), typeof(UXDivers.Artina.Shared.ArtinaTimePickerRenderer))]

#pragma warning disable 219
internal static class WorkaroundLoadingCustomRenderersFromExternalAssemblies {
	static WorkaroundLoadingCustomRenderersFromExternalAssemblies()
	{
		var a = new UXDivers.Artina.Shared.ArtinaEntryRenderer();
	}
}
#pragma warning restore 219
