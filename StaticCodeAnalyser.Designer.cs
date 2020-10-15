using System;
using System.Management;
//FORM DESIGN
namespace StaticCodeAnalyser
{
    partial class StaticCodeAnalyser
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Management.EnumerationOptions enumerationOptions1 = new System.Management.EnumerationOptions();
            this.Search = new System.Management.ManagementObjectSearcher();
            this.sourceCodeTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cyclomaticButton = new System.Windows.Forms.Button();
            this.cyclomaticComplexityLabel = new System.Windows.Forms.Label();
            this.analyseHalsteadButton = new System.Windows.Forms.Button();
            this.totalNumberOfOperatorsLabel = new System.Windows.Forms.Label();
            this.numberOfDistinctOperatorsLabel = new System.Windows.Forms.Label();
            this.totalNumberOfOperandsLabel = new System.Windows.Forms.Label();
            this.numberOfDistinctOperandsLabel = new System.Windows.Forms.Label();
            this.theoreticalProgramVocabularyLabel = new System.Windows.Forms.Label();
            this.theoreticalProgramLengthLabel = new System.Windows.Forms.Label();
            this.theoreticalProgramVolumeLabel = new System.Windows.Forms.Label();
            this.levelOfProgrammingQualityLabel = new System.Windows.Forms.Label();
            this.MIDDLE_GP = new System.Windows.Forms.GroupBox();
            this.HAL_GP = new System.Windows.Forms.GroupBox();
            this.numberOfElementarySolutionsForULabel = new System.Windows.Forms.Label();
            this.numberOfElementarySolutionsForWLabel = new System.Windows.Forms.Label();
            this.levelOfProgramQualityWithoutTPVLabel = new System.Windows.Forms.Label();
            this.programVocabularyLabel = new System.Windows.Forms.Label();
            this.programLengthLabel = new System.Windows.Forms.Label();
            this.programVolumeLabel = new System.Windows.Forms.Label();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_Metrics = new System.Windows.Forms.TableLayoutPanel();
            this.maintainabilityIndexButton = new System.Windows.Forms.Button();
            this.TOP_GP = new System.Windows.Forms.GroupBox();
            this.indexOfCodeMaintainability = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.MIDDLE_GP.SuspendLayout();
            this.HAL_GP.SuspendLayout();
            this.TLP_Main.SuspendLayout();
            this.TLP_Metrics.SuspendLayout();
            this.TOP_GP.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search
            // 
            enumerationOptions1.BlockSize = 1;
            enumerationOptions1.DirectRead = false;
            enumerationOptions1.EnsureLocatable = false;
            enumerationOptions1.EnumerateDeep = false;
            enumerationOptions1.PrototypeOnly = false;
            enumerationOptions1.ReturnImmediately = true;
            enumerationOptions1.Rewindable = true;
            enumerationOptions1.Timeout = System.TimeSpan.Parse("10675199.02:48:05.4775807");
            enumerationOptions1.UseAmendedQualifiers = false;
            this.Search.Options = enumerationOptions1;
            this.Search.Query = new System.Management.ObjectQuery("Select * From Win32_ComputerSystem");
            this.Search.Scope = new System.Management.ManagementScope("\\\\.\\root\\cimv2");
            // 
            // sourceCodeTextBox
            // 
            this.sourceCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceCodeTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceCodeTextBox.Location = new System.Drawing.Point(1009, 0);
            this.sourceCodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.sourceCodeTextBox.MaxLength = 2147483647;
            this.sourceCodeTextBox.MinimumSize = new System.Drawing.Size(533, 0);
            this.sourceCodeTextBox.Multiline = true;
            this.sourceCodeTextBox.Name = "sourceCodeTextBox";
            this.TLP_Main.SetRowSpan(this.sourceCodeTextBox, 4);
            this.sourceCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sourceCodeTextBox.Size = new System.Drawing.Size(726, 761);
            this.sourceCodeTextBox.TabIndex = 1;
            this.sourceCodeTextBox.WordWrap = false;
            this.sourceCodeTextBox.TextChanged += new System.EventHandler(this.sourceCodeTextBox_TextChanged);
            this.sourceCodeTextBox.DoubleClick += new System.EventHandler(this.sourceCodeTextBox_DoubleClick);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemInfoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(1735, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "File";
            // 
            // systemInfoToolStripMenuItem
            // 
            this.systemInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCNAMEToolStripMenuItem,
            this.rAMToolStripMenuItem});
            this.systemInfoToolStripMenuItem.Name = "systemInfoToolStripMenuItem";
            this.systemInfoToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.systemInfoToolStripMenuItem.Text = "System Info";
            // 
            // pCNAMEToolStripMenuItem
            // 
            this.pCNAMEToolStripMenuItem.Name = "pCNAMEToolStripMenuItem";
            this.pCNAMEToolStripMenuItem.Size = new System.Drawing.Size(480, 26);
            this.pCNAMEToolStripMenuItem.Text = "PC NAMEDESKTOP-RV30RN8";
            // 
            // rAMToolStripMenuItem
            // 
            this.rAMToolStripMenuItem.Name = "rAMToolStripMenuItem";
            this.rAMToolStripMenuItem.Size = new System.Drawing.Size(480, 26);
            this.rAMToolStripMenuItem.Text = "RAM Intel64 Family 6 Model 158 Stepping 10, GenuineIntel";
            // 
            // cyclomaticButton
            // 
            this.cyclomaticButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cyclomaticButton.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cyclomaticButton.Location = new System.Drawing.Point(4, 4);
            this.cyclomaticButton.Margin = new System.Windows.Forms.Padding(4);
            this.cyclomaticButton.Name = "cyclomaticButton";
            this.cyclomaticButton.Size = new System.Drawing.Size(328, 70);
            this.cyclomaticButton.TabIndex = 3;
            this.cyclomaticButton.Text = "CycloMatric Complexity";
            this.cyclomaticButton.UseVisualStyleBackColor = true;
            this.cyclomaticButton.Click += new System.EventHandler(this.mcCabeButton_Click);
            // 
            // cyclomaticComplexityLabel
            // 
            this.cyclomaticComplexityLabel.AutoSize = true;
            this.cyclomaticComplexityLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.cyclomaticComplexityLabel.Location = new System.Drawing.Point(8, 49);
            this.cyclomaticComplexityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cyclomaticComplexityLabel.Name = "cyclomaticComplexityLabel";
            this.cyclomaticComplexityLabel.Size = new System.Drawing.Size(412, 22);
            this.cyclomaticComplexityLabel.TabIndex = 4;
            this.cyclomaticComplexityLabel.Text = "The cyclomatic complexity of a program: ";
            // 
            // analyseHalsteadButton
            // 
            this.analyseHalsteadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyseHalsteadButton.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyseHalsteadButton.Location = new System.Drawing.Point(340, 4);
            this.analyseHalsteadButton.Margin = new System.Windows.Forms.Padding(4);
            this.analyseHalsteadButton.Name = "analyseHalsteadButton";
            this.analyseHalsteadButton.Size = new System.Drawing.Size(328, 70);
            this.analyseHalsteadButton.TabIndex = 5;
            this.analyseHalsteadButton.Text = "Analyse Halstead";
            this.analyseHalsteadButton.UseVisualStyleBackColor = true;
            this.analyseHalsteadButton.Click += new System.EventHandler(this.halsteadButton_Click);
            // 
            // totalNumberOfOperatorsLabel
            // 
            this.totalNumberOfOperatorsLabel.AutoSize = true;
            this.totalNumberOfOperatorsLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.totalNumberOfOperatorsLabel.Location = new System.Drawing.Point(8, 94);
            this.totalNumberOfOperatorsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalNumberOfOperatorsLabel.Name = "totalNumberOfOperatorsLabel";
            this.totalNumberOfOperatorsLabel.Size = new System.Drawing.Size(316, 22);
            this.totalNumberOfOperatorsLabel.TabIndex = 6;
            this.totalNumberOfOperatorsLabel.Text = "The total number of operators: ";
            // 
            // numberOfDistinctOperatorsLabel
            // 
            this.numberOfDistinctOperatorsLabel.AutoSize = true;
            this.numberOfDistinctOperatorsLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.numberOfDistinctOperatorsLabel.Location = new System.Drawing.Point(8, 32);
            this.numberOfDistinctOperatorsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfDistinctOperatorsLabel.Name = "numberOfDistinctOperatorsLabel";
            this.numberOfDistinctOperatorsLabel.Size = new System.Drawing.Size(344, 22);
            this.numberOfDistinctOperatorsLabel.TabIndex = 7;
            this.numberOfDistinctOperatorsLabel.Text = "The number of distinct operators: ";
            // 
            // totalNumberOfOperandsLabel
            // 
            this.totalNumberOfOperandsLabel.AutoSize = true;
            this.totalNumberOfOperandsLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.totalNumberOfOperandsLabel.Location = new System.Drawing.Point(8, 118);
            this.totalNumberOfOperandsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalNumberOfOperandsLabel.Name = "totalNumberOfOperandsLabel";
            this.totalNumberOfOperandsLabel.Size = new System.Drawing.Size(306, 22);
            this.totalNumberOfOperandsLabel.TabIndex = 8;
            this.totalNumberOfOperandsLabel.Text = "The total number of operands:";
            // 
            // numberOfDistinctOperandsLabel
            // 
            this.numberOfDistinctOperandsLabel.AutoSize = true;
            this.numberOfDistinctOperandsLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.numberOfDistinctOperandsLabel.Location = new System.Drawing.Point(8, 57);
            this.numberOfDistinctOperandsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfDistinctOperandsLabel.Name = "numberOfDistinctOperandsLabel";
            this.numberOfDistinctOperandsLabel.Size = new System.Drawing.Size(340, 22);
            this.numberOfDistinctOperandsLabel.TabIndex = 9;
            this.numberOfDistinctOperandsLabel.Text = "The number of distinct operands: ";
            // 
            // theoreticalProgramVocabularyLabel
            // 
            this.theoreticalProgramVocabularyLabel.AutoSize = true;
            this.theoreticalProgramVocabularyLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.theoreticalProgramVocabularyLabel.Location = new System.Drawing.Point(8, 241);
            this.theoreticalProgramVocabularyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.theoreticalProgramVocabularyLabel.Name = "theoreticalProgramVocabularyLabel";
            this.theoreticalProgramVocabularyLabel.Size = new System.Drawing.Size(369, 22);
            this.theoreticalProgramVocabularyLabel.TabIndex = 10;
            this.theoreticalProgramVocabularyLabel.Text = "The theoretical program vocabulary: ";
            // 
            // theoreticalProgramLengthLabel
            // 
            this.theoreticalProgramLengthLabel.AutoSize = true;
            this.theoreticalProgramLengthLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.theoreticalProgramLengthLabel.Location = new System.Drawing.Point(8, 266);
            this.theoreticalProgramLengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.theoreticalProgramLengthLabel.Name = "theoreticalProgramLengthLabel";
            this.theoreticalProgramLengthLabel.Size = new System.Drawing.Size(323, 22);
            this.theoreticalProgramLengthLabel.TabIndex = 16;
            this.theoreticalProgramLengthLabel.Text = "The theoretical program length: ";
            // 
            // theoreticalProgramVolumeLabel
            // 
            this.theoreticalProgramVolumeLabel.AutoSize = true;
            this.theoreticalProgramVolumeLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.theoreticalProgramVolumeLabel.Location = new System.Drawing.Point(8, 290);
            this.theoreticalProgramVolumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.theoreticalProgramVolumeLabel.Name = "theoreticalProgramVolumeLabel";
            this.theoreticalProgramVolumeLabel.Size = new System.Drawing.Size(333, 22);
            this.theoreticalProgramVolumeLabel.TabIndex = 17;
            this.theoreticalProgramVolumeLabel.Text = "The theoretical program volume: ";
            // 
            // levelOfProgrammingQualityLabel
            // 
            this.levelOfProgrammingQualityLabel.AutoSize = true;
            this.levelOfProgrammingQualityLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.levelOfProgrammingQualityLabel.Location = new System.Drawing.Point(8, 327);
            this.levelOfProgrammingQualityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.levelOfProgrammingQualityLabel.Name = "levelOfProgrammingQualityLabel";
            this.levelOfProgrammingQualityLabel.Size = new System.Drawing.Size(344, 22);
            this.levelOfProgrammingQualityLabel.TabIndex = 18;
            this.levelOfProgrammingQualityLabel.Text = "The level of programming quality: ";
            // 
            // MIDDLE_GP
            // 
            this.MIDDLE_GP.BackColor = System.Drawing.Color.Aqua;
            this.MIDDLE_GP.Controls.Add(this.cyclomaticComplexityLabel);
            this.MIDDLE_GP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MIDDLE_GP.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIDDLE_GP.ForeColor = System.Drawing.Color.Navy;
            this.MIDDLE_GP.Location = new System.Drawing.Point(0, 0);
            this.MIDDLE_GP.Margin = new System.Windows.Forms.Padding(0);
            this.MIDDLE_GP.MaximumSize = new System.Drawing.Size(1009, 107);
            this.MIDDLE_GP.Name = "MIDDLE_GP";
            this.MIDDLE_GP.Padding = new System.Windows.Forms.Padding(4);
            this.MIDDLE_GP.Size = new System.Drawing.Size(1009, 107);
            this.MIDDLE_GP.TabIndex = 22;
            this.MIDDLE_GP.TabStop = false;
            this.MIDDLE_GP.Text = "CycloMatric Complexity:";
            this.MIDDLE_GP.Enter += new System.EventHandler(this.GB_MCM_Enter);
            // 
            // HAL_GP
            // 
            this.HAL_GP.BackColor = System.Drawing.Color.Aqua;
            this.HAL_GP.Controls.Add(this.numberOfDistinctOperatorsLabel);
            this.HAL_GP.Controls.Add(this.totalNumberOfOperatorsLabel);
            this.HAL_GP.Controls.Add(this.numberOfElementarySolutionsForULabel);
            this.HAL_GP.Controls.Add(this.totalNumberOfOperandsLabel);
            this.HAL_GP.Controls.Add(this.numberOfElementarySolutionsForWLabel);
            this.HAL_GP.Controls.Add(this.numberOfDistinctOperandsLabel);
            this.HAL_GP.Controls.Add(this.levelOfProgramQualityWithoutTPVLabel);
            this.HAL_GP.Controls.Add(this.theoreticalProgramVocabularyLabel);
            this.HAL_GP.Controls.Add(this.levelOfProgrammingQualityLabel);
            this.HAL_GP.Controls.Add(this.programVocabularyLabel);
            this.HAL_GP.Controls.Add(this.theoreticalProgramVolumeLabel);
            this.HAL_GP.Controls.Add(this.programLengthLabel);
            this.HAL_GP.Controls.Add(this.theoreticalProgramLengthLabel);
            this.HAL_GP.Controls.Add(this.programVolumeLabel);
            this.HAL_GP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HAL_GP.Font = new System.Drawing.Font("Lucida Fax", 14.25F);
            this.HAL_GP.ForeColor = System.Drawing.Color.Navy;
            this.HAL_GP.Location = new System.Drawing.Point(0, 107);
            this.HAL_GP.Margin = new System.Windows.Forms.Padding(0);
            this.HAL_GP.MaximumSize = new System.Drawing.Size(1009, 468);
            this.HAL_GP.Name = "HAL_GP";
            this.HAL_GP.Padding = new System.Windows.Forms.Padding(4);
            this.HAL_GP.Size = new System.Drawing.Size(1009, 468);
            this.HAL_GP.TabIndex = 23;
            this.HAL_GP.TabStop = false;
            this.HAL_GP.Text = "Analyse Halstead :";
            this.HAL_GP.Enter += new System.EventHandler(this.GB_HM_Enter);
            // 
            // numberOfElementarySolutionsForULabel
            // 
            this.numberOfElementarySolutionsForULabel.AutoSize = true;
            this.numberOfElementarySolutionsForULabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.numberOfElementarySolutionsForULabel.Location = new System.Drawing.Point(8, 414);
            this.numberOfElementarySolutionsForULabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfElementarySolutionsForULabel.Name = "numberOfElementarySolutionsForULabel";
            this.numberOfElementarySolutionsForULabel.Size = new System.Drawing.Size(769, 22);
            this.numberOfElementarySolutionsForULabel.TabIndex = 21;
            this.numberOfElementarySolutionsForULabel.Text = "The number of required elementary solutions for understanding the program: ";
            // 
            // numberOfElementarySolutionsForWLabel
            // 
            this.numberOfElementarySolutionsForWLabel.AutoSize = true;
            this.numberOfElementarySolutionsForWLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.numberOfElementarySolutionsForWLabel.Location = new System.Drawing.Point(8, 389);
            this.numberOfElementarySolutionsForWLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfElementarySolutionsForWLabel.Name = "numberOfElementarySolutionsForWLabel";
            this.numberOfElementarySolutionsForWLabel.Size = new System.Drawing.Size(678, 22);
            this.numberOfElementarySolutionsForWLabel.TabIndex = 20;
            this.numberOfElementarySolutionsForWLabel.Text = "The number of required elementary solutions for writing a program: ";
            // 
            // levelOfProgramQualityWithoutTPVLabel
            // 
            this.levelOfProgramQualityWithoutTPVLabel.AutoSize = true;
            this.levelOfProgramQualityWithoutTPVLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.levelOfProgramQualityWithoutTPVLabel.Location = new System.Drawing.Point(8, 352);
            this.levelOfProgramQualityWithoutTPVLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.levelOfProgramQualityWithoutTPVLabel.Name = "levelOfProgramQualityWithoutTPVLabel";
            this.levelOfProgramQualityWithoutTPVLabel.Size = new System.Drawing.Size(700, 22);
            this.levelOfProgramQualityWithoutTPVLabel.TabIndex = 19;
            this.levelOfProgramQualityWithoutTPVLabel.Text = "The level of programming quality without theoretical program volume: ";
            // 
            // programVocabularyLabel
            // 
            this.programVocabularyLabel.AutoSize = true;
            this.programVocabularyLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.programVocabularyLabel.Location = new System.Drawing.Point(8, 155);
            this.programVocabularyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.programVocabularyLabel.Name = "programVocabularyLabel";
            this.programVocabularyLabel.Size = new System.Drawing.Size(259, 22);
            this.programVocabularyLabel.TabIndex = 11;
            this.programVocabularyLabel.Text = "The program vocabulary: ";
            // 
            // programLengthLabel
            // 
            this.programLengthLabel.AutoSize = true;
            this.programLengthLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.programLengthLabel.Location = new System.Drawing.Point(8, 180);
            this.programLengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.programLengthLabel.Name = "programLengthLabel";
            this.programLengthLabel.Size = new System.Drawing.Size(213, 22);
            this.programLengthLabel.TabIndex = 12;
            this.programLengthLabel.Text = "The program length: ";
            // 
            // programVolumeLabel
            // 
            this.programVolumeLabel.AutoSize = true;
            this.programVolumeLabel.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.programVolumeLabel.Location = new System.Drawing.Point(8, 204);
            this.programVolumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.programVolumeLabel.Name = "programVolumeLabel";
            this.programVolumeLabel.Size = new System.Drawing.Size(223, 22);
            this.programVolumeLabel.TabIndex = 13;
            this.programVolumeLabel.Text = "The program volume: ";
            // 
            // TLP_Main
            // 
            this.TLP_Main.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TLP_Main.ColumnCount = 2;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1009F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.TLP_Metrics, 0, 3);
            this.TLP_Main.Controls.Add(this.TOP_GP, 0, 2);
            this.TLP_Main.Controls.Add(this.sourceCodeTextBox, 1, 0);
            this.TLP_Main.Controls.Add(this.HAL_GP, 0, 1);
            this.TLP_Main.Controls.Add(this.MIDDLE_GP, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 28);
            this.TLP_Main.Margin = new System.Windows.Forms.Padding(4);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 4;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(1735, 761);
            this.TLP_Main.TabIndex = 24;
            // 
            // TLP_Metrics
            // 
            this.TLP_Metrics.BackColor = System.Drawing.SystemColors.Window;
            this.TLP_Metrics.ColumnCount = 3;
            this.TLP_Metrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Metrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Metrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Metrics.Controls.Add(this.cyclomaticButton, 0, 0);
            this.TLP_Metrics.Controls.Add(this.analyseHalsteadButton, 1, 0);
            this.TLP_Metrics.Controls.Add(this.maintainabilityIndexButton, 2, 0);
            this.TLP_Metrics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLP_Metrics.Location = new System.Drawing.Point(0, 683);
            this.TLP_Metrics.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Metrics.MaximumSize = new System.Drawing.Size(1009, 78);
            this.TLP_Metrics.Name = "TLP_Metrics";
            this.TLP_Metrics.RowCount = 1;
            this.TLP_Metrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Metrics.Size = new System.Drawing.Size(1009, 78);
            this.TLP_Metrics.TabIndex = 25;
            // 
            // maintainabilityIndexButton
            // 
            this.maintainabilityIndexButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintainabilityIndexButton.Font = new System.Drawing.Font("Lucida Fax", 14.25F);
            this.maintainabilityIndexButton.Location = new System.Drawing.Point(676, 4);
            this.maintainabilityIndexButton.Margin = new System.Windows.Forms.Padding(4);
            this.maintainabilityIndexButton.Name = "maintainabilityIndexButton";
            this.maintainabilityIndexButton.Size = new System.Drawing.Size(329, 70);
            this.maintainabilityIndexButton.TabIndex = 6;
            this.maintainabilityIndexButton.Text = "Maintainability Index";
            this.maintainabilityIndexButton.UseVisualStyleBackColor = true;
            this.maintainabilityIndexButton.Click += new System.EventHandler(this.maintainabilityIndexButton_Click);
            // 
            // TOP_GP
            // 
            this.TOP_GP.BackColor = System.Drawing.Color.Aqua;
            this.TOP_GP.Controls.Add(this.indexOfCodeMaintainability);
            this.TOP_GP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TOP_GP.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOP_GP.ForeColor = System.Drawing.Color.Navy;
            this.TOP_GP.Location = new System.Drawing.Point(0, 575);
            this.TOP_GP.Margin = new System.Windows.Forms.Padding(0);
            this.TOP_GP.MaximumSize = new System.Drawing.Size(1009, 107);
            this.TOP_GP.Name = "TOP_GP";
            this.TOP_GP.Padding = new System.Windows.Forms.Padding(4);
            this.TOP_GP.Size = new System.Drawing.Size(1009, 107);
            this.TOP_GP.TabIndex = 25;
            this.TOP_GP.TabStop = false;
            this.TOP_GP.Text = "Code maintainability:";
            // 
            // indexOfCodeMaintainability
            // 
            this.indexOfCodeMaintainability.AutoSize = true;
            this.indexOfCodeMaintainability.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.indexOfCodeMaintainability.Location = new System.Drawing.Point(8, 49);
            this.indexOfCodeMaintainability.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indexOfCodeMaintainability.Name = "indexOfCodeMaintainability";
            this.indexOfCodeMaintainability.Size = new System.Drawing.Size(346, 22);
            this.indexOfCodeMaintainability.TabIndex = 4;
            this.indexOfCodeMaintainability.Text = "The index of code maintainability: ";
            // 
            // StaticCodeAnalyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 789);
            this.Controls.Add(this.TLP_Main);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1537, 826);
            this.Name = "StaticCodeAnalyser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Static Code Analyser";
            this.Load += new System.EventHandler(this.CodeAnalyser_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.MIDDLE_GP.ResumeLayout(false);
            this.MIDDLE_GP.PerformLayout();
            this.HAL_GP.ResumeLayout(false);
            this.HAL_GP.PerformLayout();
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            this.TLP_Metrics.ResumeLayout(false);
            this.TOP_GP.ResumeLayout(false);
            this.TOP_GP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceCodeTextBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button cyclomaticButton;
        private System.Windows.Forms.Label cyclomaticComplexityLabel;
        private System.Windows.Forms.Button analyseHalsteadButton;
        private System.Windows.Forms.Label totalNumberOfOperatorsLabel;
        private System.Windows.Forms.Label numberOfDistinctOperatorsLabel;
        private System.Windows.Forms.Label totalNumberOfOperandsLabel;
        private System.Windows.Forms.Label numberOfDistinctOperandsLabel;
        private System.Windows.Forms.Label theoreticalProgramVocabularyLabel;
        private System.Windows.Forms.Label theoreticalProgramLengthLabel;
        private System.Windows.Forms.Label theoreticalProgramVolumeLabel;
        private System.Windows.Forms.Label levelOfProgrammingQualityLabel;
        private System.Windows.Forms.GroupBox MIDDLE_GP;
        private System.Windows.Forms.GroupBox HAL_GP;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.TableLayoutPanel TLP_Metrics;
        private System.Windows.Forms.GroupBox TOP_GP;
        private System.Windows.Forms.Label indexOfCodeMaintainability;
        private System.Windows.Forms.Button maintainabilityIndexButton;
        private System.Windows.Forms.ToolStripMenuItem systemInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCNAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rAMToolStripMenuItem;
        private ManagementObjectSearcher Search;
        private System.Windows.Forms.Label numberOfElementarySolutionsForULabel;
        private System.Windows.Forms.Label numberOfElementarySolutionsForWLabel;
        private System.Windows.Forms.Label levelOfProgramQualityWithoutTPVLabel;
        private System.Windows.Forms.Label programVocabularyLabel;
        private System.Windows.Forms.Label programLengthLabel;
        private System.Windows.Forms.Label programVolumeLabel;
    }
}

