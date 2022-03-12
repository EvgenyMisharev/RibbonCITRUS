
namespace RectangularColumnsReinforcement
{
    partial class RectangularColumnsReinforcementMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabControl tabControl_Settings;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            tabControl_Settings = new System.Windows.Forms.TabControl();
            tabControl_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Settings
            // 
            tabControl_Settings.Controls.Add(this.tabPage1);
            tabControl_Settings.Controls.Add(this.tabPage2);
            tabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl_Settings.ItemSize = new System.Drawing.Size(64, 18);
            tabControl_Settings.Location = new System.Drawing.Point(0, 0);
            tabControl_Settings.Name = "tabControl_Settings";
            tabControl_Settings.SelectedIndex = 0;
            tabControl_Settings.Size = new System.Drawing.Size(815, 450);
            tabControl_Settings.TabIndex = 52;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(807, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Дополнительные";
            // 
            // RectangularColumnsReinforcementMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 450);
            this.Controls.Add(tabControl_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RectangularColumnsReinforcementMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Свойства армирования";
            tabControl_Settings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}