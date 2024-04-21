namespace NoteApp
{
    partial class SingleNoteCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleNoteCard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoteDescription = new System.Windows.Forms.Label();
            this.NoteTitle = new System.Windows.Forms.Label();
            this.NoteDeleteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.NoteDeleteButton);
            this.panel1.Controls.Add(this.NoteDescription);
            this.panel1.Controls.Add(this.NoteTitle);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 182);
            this.panel1.TabIndex = 5;
            // 
            // NoteDescription
            // 
            this.NoteDescription.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteDescription.Location = new System.Drawing.Point(12, 48);
            this.NoteDescription.Name = "NoteDescription";
            this.NoteDescription.Size = new System.Drawing.Size(411, 119);
            this.NoteDescription.TabIndex = 1;
            this.NoteDescription.Text = resources.GetString("NoteDescription.Text");
            // 
            // NoteTitle
            // 
            this.NoteTitle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteTitle.Location = new System.Drawing.Point(12, 14);
            this.NoteTitle.Name = "NoteTitle";
            this.NoteTitle.Size = new System.Drawing.Size(333, 23);
            this.NoteTitle.TabIndex = 0;
            this.NoteTitle.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam viverra urna id " +
    "mauris semper, sed vehicula eros convallis. Aliquam imperdiet sem felis, sed lao" +
    "reet nunc rutrum et.";
            // 
            // NoteDeleteButton
            // 
            this.NoteDeleteButton.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteDeleteButton.Location = new System.Drawing.Point(383, 14);
            this.NoteDeleteButton.Name = "NoteDeleteButton";
            this.NoteDeleteButton.Size = new System.Drawing.Size(40, 31);
            this.NoteDeleteButton.TabIndex = 2;
            this.NoteDeleteButton.Text = "X";
            this.NoteDeleteButton.UseVisualStyleBackColor = true;
            // 
            // SingleNoteCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "SingleNoteCard";
            this.Size = new System.Drawing.Size(442, 189);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NoteDescription;
        private System.Windows.Forms.Label NoteTitle;
        private System.Windows.Forms.Button NoteDeleteButton;
    }
}
