using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangularColumnsReinforcement
{
    public partial class RectangularColumnsReinforcementMainForm : System.Windows.Forms.Form
    {
        private Document doc;
        public RectangularColumnsReinforcementMainForm(Document Doc)
        {
            doc = Doc;
            InitializeComponent();
        }
    }
}
