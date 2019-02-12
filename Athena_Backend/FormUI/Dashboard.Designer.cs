namespace FormUI
{
    partial class Dashboard
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
            this.PeopleFound_Listbox = new System.Windows.Forms.ListBox();
            this.Username_text = new System.Windows.Forms.TextBox();
            this.Username_label = new System.Windows.Forms.Label();
            this.Search_Button = new System.Windows.Forms.Button();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.NoMatchFound_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PeopleFound_Listbox
            // 
            this.PeopleFound_Listbox.FormattingEnabled = true;
            this.PeopleFound_Listbox.Location = new System.Drawing.Point(27, 120);
            this.PeopleFound_Listbox.Name = "PeopleFound_Listbox";
            this.PeopleFound_Listbox.Size = new System.Drawing.Size(272, 199);
            this.PeopleFound_Listbox.TabIndex = 0;
            // 
            // Username_text
            // 
            this.Username_text.Location = new System.Drawing.Point(71, 43);
            this.Username_text.Name = "Username_text";
            this.Username_text.Size = new System.Drawing.Size(100, 20);
            this.Username_text.TabIndex = 1;
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.Location = new System.Drawing.Point(13, 49);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(55, 13);
            this.Username_label.TabIndex = 2;
            this.Username_label.Text = "Username";
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(27, 79);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(75, 23);
            this.Search_Button.TabIndex = 3;
            this.Search_Button.Text = "Search";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // Password_text
            // 
            this.Password_text.Location = new System.Drawing.Point(285, 43);
            this.Password_text.Name = "Password_text";
            this.Password_text.Size = new System.Drawing.Size(112, 20);
            this.Password_text.TabIndex = 4;
            this.Password_text.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(226, 49);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(53, 13);
            this.Password_label.TabIndex = 5;
            this.Password_label.Text = "Password";
            // 
            // NoMatchFound_label
            // 
            this.NoMatchFound_label.AutoSize = true;
            this.NoMatchFound_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoMatchFound_label.Location = new System.Drawing.Point(339, 120);
            this.NoMatchFound_label.Name = "NoMatchFound_label";
            this.NoMatchFound_label.Size = new System.Drawing.Size(87, 13);
            this.NoMatchFound_label.TabIndex = 6;
            this.NoMatchFound_label.Text = "No Match Found";
            // 
            // Dashboard
            // 
            this.ClientSize = new System.Drawing.Size(571, 366);
            this.Controls.Add(this.NoMatchFound_label);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Password_text);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.Username_text);
            this.Controls.Add(this.PeopleFound_Listbox);
            this.Name = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PeopleFoundListbox;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox PeopleFound_Listbox;
        private System.Windows.Forms.TextBox Username_text;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.TextBox Password_text;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label NoMatchFound_label;
    }
}

