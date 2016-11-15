namespace FlammenwerferWinForms
{
    partial class Form1
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.rbFirstName = new System.Windows.Forms.RadioButton();
            this.rbLastName = new System.Windows.Forms.RadioButton();
            this.rbID = new System.Windows.Forms.RadioButton();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.lblCourseCompletion = new System.Windows.Forms.Label();
            this.lblCoreComp = new System.Windows.Forms.Label();
            this.lblGenEdComp = new System.Windows.Forms.Label();
            this.lblElectiveComp = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblDegreeCompletion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 157);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(12, 36);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(100, 20);
            this.tbQuery.TabIndex = 2;
            // 
            // lblInstruct
            // 
            this.lblInstruct.AutoSize = true;
            this.lblInstruct.Location = new System.Drawing.Point(9, 20);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(35, 13);
            this.lblInstruct.TabIndex = 3;
            this.lblInstruct.Text = "label1";
            this.lblInstruct.Visible = false;
            // 
            // rbFirstName
            // 
            this.rbFirstName.AutoSize = true;
            this.rbFirstName.Checked = true;
            this.rbFirstName.Location = new System.Drawing.Point(12, 73);
            this.rbFirstName.Name = "rbFirstName";
            this.rbFirstName.Size = new System.Drawing.Size(75, 17);
            this.rbFirstName.TabIndex = 4;
            this.rbFirstName.TabStop = true;
            this.rbFirstName.Text = "First Name";
            this.rbFirstName.UseVisualStyleBackColor = true;
            this.rbFirstName.CheckedChanged += new System.EventHandler(this.rbFirstName_CheckedChanged);
            // 
            // rbLastName
            // 
            this.rbLastName.AutoSize = true;
            this.rbLastName.Location = new System.Drawing.Point(12, 97);
            this.rbLastName.Name = "rbLastName";
            this.rbLastName.Size = new System.Drawing.Size(76, 17);
            this.rbLastName.TabIndex = 5;
            this.rbLastName.TabStop = true;
            this.rbLastName.Text = "Last Name";
            this.rbLastName.UseVisualStyleBackColor = true;
            this.rbLastName.CheckedChanged += new System.EventHandler(this.rbLastName_CheckedChanged);
            // 
            // rbID
            // 
            this.rbID.AutoSize = true;
            this.rbID.Location = new System.Drawing.Point(12, 121);
            this.rbID.Name = "rbID";
            this.rbID.Size = new System.Drawing.Size(82, 17);
            this.rbID.TabIndex = 6;
            this.rbID.TabStop = true;
            this.rbID.Text = "Student I.D.";
            this.rbID.UseVisualStyleBackColor = true;
            this.rbID.CheckedChanged += new System.EventHandler(this.rbID_CheckedChanged);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Location = new System.Drawing.Point(139, 20);
            this.tbDisplay.MaxLength = 50000;
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDisplay.Size = new System.Drawing.Size(325, 299);
            this.tbDisplay.TabIndex = 7;
            // 
            // lblCourseCompletion
            // 
            this.lblCourseCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCourseCompletion.AutoSize = true;
            this.lblCourseCompletion.Location = new System.Drawing.Point(492, 20);
            this.lblCourseCompletion.Name = "lblCourseCompletion";
            this.lblCourseCompletion.Size = new System.Drawing.Size(121, 26);
            this.lblCourseCompletion.TabIndex = 8;
            this.lblCourseCompletion.Text = "    Course Completion\r\n___________________\r\n";
            // 
            // lblCoreComp
            // 
            this.lblCoreComp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoreComp.AutoSize = true;
            this.lblCoreComp.Location = new System.Drawing.Point(483, 62);
            this.lblCoreComp.Name = "lblCoreComp";
            this.lblCoreComp.Size = new System.Drawing.Size(115, 13);
            this.lblCoreComp.TabIndex = 9;
            this.lblCoreComp.Text = "Core Class Completion:";
            // 
            // lblGenEdComp
            // 
            this.lblGenEdComp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenEdComp.AutoSize = true;
            this.lblGenEdComp.Location = new System.Drawing.Point(472, 86);
            this.lblGenEdComp.Name = "lblGenEdComp";
            this.lblGenEdComp.Size = new System.Drawing.Size(126, 13);
            this.lblGenEdComp.TabIndex = 10;
            this.lblGenEdComp.Text = "GenEd Class Completion:";
            // 
            // lblElectiveComp
            // 
            this.lblElectiveComp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElectiveComp.AutoSize = true;
            this.lblElectiveComp.Location = new System.Drawing.Point(467, 110);
            this.lblElectiveComp.Name = "lblElectiveComp";
            this.lblElectiveComp.Size = new System.Drawing.Size(131, 13);
            this.lblElectiveComp.TabIndex = 11;
            this.lblElectiveComp.Text = "Elective Class Completion:";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 186);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 23);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 215);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 23);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblDegreeCompletion
            // 
            this.lblDegreeCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDegreeCompletion.AutoSize = true;
            this.lblDegreeCompletion.Location = new System.Drawing.Point(467, 191);
            this.lblDegreeCompletion.Name = "lblDegreeCompletion";
            this.lblDegreeCompletion.Size = new System.Drawing.Size(126, 13);
            this.lblDegreeCompletion.TabIndex = 14;
            this.lblDegreeCompletion.Text = "Overall Class Completion:";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 331);
            this.Controls.Add(this.lblDegreeCompletion);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblElectiveComp);
            this.Controls.Add(this.lblGenEdComp);
            this.Controls.Add(this.lblCoreComp);
            this.Controls.Add(this.lblCourseCompletion);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.rbID);
            this.Controls.Add(this.rbLastName);
            this.Controls.Add(this.rbFirstName);
            this.Controls.Add(this.lblInstruct);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.btnSearch);
            this.MinimumSize = new System.Drawing.Size(651, 370);
            this.Name = "Form1";
            this.Text = "Student Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.RadioButton rbFirstName;
        private System.Windows.Forms.RadioButton rbLastName;
        private System.Windows.Forms.RadioButton rbID;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Label lblCourseCompletion;
        private System.Windows.Forms.Label lblCoreComp;
        private System.Windows.Forms.Label lblGenEdComp;
        private System.Windows.Forms.Label lblElectiveComp;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblDegreeCompletion;
    }
}

