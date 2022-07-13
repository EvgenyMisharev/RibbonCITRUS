using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace RibbonCITRUS
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class App : IExternalApplication
    {
        public static string assemblyPath;
        public static string assemblyFolder;
        public static string ribbonPath;

        public Result OnStartup(UIControlledApplication application)
        {
            assemblyPath = typeof(App).Assembly.Location;
            assemblyFolder = Path.GetDirectoryName(assemblyPath);
            ribbonPath = Path.Combine(assemblyFolder, "RibbonCITRUSData");

            string tabName = "ЦИТRUS";
            try { application.CreateRibbonTab(tabName); } catch { }

            try
            {
                CreateArchitecturalRibbon(application, tabName);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ribbon Sample", ex.ToString());

                return Result.Failed;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private void CreateArchitecturalRibbon(UIControlledApplication uiApp, string tabName)
        {
            RibbonPanel arpanel = uiApp.CreateRibbonPanel(tabName, "АР");
            arpanel.AddItem(CreateButtonData("RefreshRoomFinishingMark", "RefreshRoomFinishingMarkCommand"));
            arpanel.AddItem(CreateButtonData("FloorCreator", "FloorCreatorCommand"));
            arpanel.AddItem(CreateButtonData("FloorFinishNumerator", "FloorFinishNumeratorCommand"));
            arpanel.AddItem(CreateButtonData("RoomFinishNumerator", "RoomFinishNumeratorCommand"));
            arpanel.AddItem(CreateButtonData("CeilingFinishNumerator", "CeilingFinishNumeratorCommand"));
            arpanel.AddSeparator();
            arpanel.AddItem(CreateButtonData("WallFinishCreator", "WallFinishCreatorCommand"));
            arpanel.AddSeparator();
            arpanel.AddItem(CreateButtonData("LintelCreator", "LintelCreatorCommand"));
            arpanel.AddItem(CreateButtonData("LintelSketch", "LintelSketchCommand"));
            arpanel.AddSeparator();
            arpanel.AddItem(CreateButtonData("RoomNumerator", "RoomNumeratorCommand"));
            arpanel.AddItem(CreateButtonData("ApartmentLayouts", "ApartmentLayoutsCommand"));
            arpanel.AddSeparator();

        }

        public PushButtonData CreateButtonData(string assemblyName, string className)
        {
            string dllPath = Path.Combine(ribbonPath, assemblyName, assemblyName + ".dll");
            string fullClassname = assemblyName + "." + className;
            string dataPath = Path.Combine(ribbonPath, assemblyName, "data");
            string largeIcon = Path.Combine(dataPath, className + "_large.png");
            string smallIcon = Path.Combine(dataPath, className + "_small.png");
            string textPath = Path.Combine(dataPath, className + ".txt");
            string[] text = File.ReadAllLines(textPath);
            string title = text[0].Replace("\\n", "\n");
            string tooltip = text[1];
            string url = text[2];

            PushButtonData data = new PushButtonData(fullClassname, title, dllPath, fullClassname);

            data.LargeImage = new BitmapImage(new Uri(largeIcon, UriKind.Absolute));
            data.Image = new BitmapImage(new Uri(smallIcon, UriKind.Absolute));

            data.ToolTip = text[1];

            ContextualHelp chelp = new ContextualHelp(ContextualHelpType.Url, url);
            data.SetContextualHelp(chelp);

            return data;
        }
    }
}
