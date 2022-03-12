using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangularColumnsReinforcement
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class RectangularColumnsReinforcementCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            Selection sel = commandData.Application.ActiveUIDocument.Selection;

            List<FamilyInstance> columnsList = new List<FamilyInstance>();
            columnsList = GetColumnsFromCurrentSelection(doc, sel);
            if (columnsList.Count == 0)
            {
                columnsList = GetColumnsFromSelection(doc, sel);
            }

            RectangularColumnsReinforcementMainForm rectangularColumnsReinforcementMainForm = new RectangularColumnsReinforcementMainForm(doc);
            rectangularColumnsReinforcementMainForm.ShowDialog();
            if (rectangularColumnsReinforcementMainForm.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return Result.Cancelled;
            }

            return Result.Succeeded;
        }
        private static List<FamilyInstance> GetColumnsFromCurrentSelection(Document doc, Selection sel)
        {
            ICollection<ElementId> selectedIds = sel.GetElementIds();
            List<FamilyInstance> tempColumnsList = new List<FamilyInstance>();
            foreach (ElementId columnId in selectedIds)
            {
                if (doc.GetElement(columnId) is FamilyInstance && null != doc.GetElement(columnId).Category && doc.GetElement(columnId).Category.Id.IntegerValue.Equals((int)BuiltInCategory.OST_StructuralColumns))
                {
                    tempColumnsList.Add(doc.GetElement(columnId) as FamilyInstance);
                }
            }
            return tempColumnsList;
        }
        public static List<FamilyInstance> GetColumnsFromSelection(Document doc, Selection sel)
        {
            ColumnSelectionFilter columnSelFilter = new ColumnSelectionFilter();
            IList<Reference> selColumns = sel.PickObjects(ObjectType.Element, columnSelFilter, "Выберите колонны!");
            List<FamilyInstance> tempColumnsList = new List<FamilyInstance>();
            foreach (Reference columnRef in selColumns)
            {
                tempColumnsList.Add(doc.GetElement(columnRef) as FamilyInstance);
            }
            return tempColumnsList;
        }
    }
}
