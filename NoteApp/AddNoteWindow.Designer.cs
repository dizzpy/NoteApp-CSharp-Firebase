namespace NoteApp
{
    partial class AddNoteWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.NoteTitleText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NoteText = new System.Windows.Forms.RichTextBox();
            this.SaveNoteButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AddNoteDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.NoteTitleText);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 112);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Note Title";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // NoteTitleText
            // 
            this.NoteTitleText.Location = new System.Drawing.Point(16, 54);
            this.NoteTitleText.Name = "NoteTitleText";
            this.NoteTitleText.Size = new System.Drawing.Size(924, 27);
            this.NoteTitleText.TabIndex = 6;
            this.NoteTitleText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.NoteText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 475);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note";
            // 
            // NoteText
            // 
            this.NoteText.Location = new System.Drawing.Point(21, 55);
            this.NoteText.Name = "NoteText";
            this.NoteText.Size = new System.Drawing.Size(919, 399);
            this.NoteText.TabIndex = 1;
            this.NoteText.Text = "";
            // 
            // SaveNoteButton
            // 
            this.SaveNoteButton.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNoteButton.Location = new System.Drawing.Point(832, 626);
            this.SaveNoteButton.Name = "SaveNoteButton";
            this.SaveNoteButton.Size = new System.Drawing.Size(139, 47);
            this.SaveNoteButton.TabIndex = 8;
            this.SaveNoteButton.Text = "Save Note";
            this.SaveNoteButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(687, 626);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 47);
            this.button2.TabIndex = 9;
            this.button2.Text = "Discard";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddNoteDelete
            // 
            this.AddNoteDelete.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNoteDelete.Location = new System.Drawing.Point(12, 626);
            this.AddNoteDelete.Name = "AddNoteDelete";
            this.AddNoteDelete.Size = new System.Drawing.Size(139, 47);
            this.AddNoteDelete.TabIndex = 10;
            this.AddNoteDelete.Text = "Delete Note";
            this.AddNoteDelete.UseVisualStyleBackColor = true;
            // 
            // AddNoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 685);
            this.Controls.Add(this.AddNoteDelete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveNoteButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddNoteWindow";
            this.Text = "AddNoteWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NoteTitleText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox NoteText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveNoteButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddNoteDelete;
    }
}