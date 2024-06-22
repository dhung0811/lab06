namespace lab06
{
    partial class WhiteboardClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnThickness;
        private System.Windows.Forms.TextBox thicknessTextBox;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Button btnInsertImage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnThickness = new System.Windows.Forms.Button();
            this.thicknessTextBox = new System.Windows.Forms.TextBox();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.btnInsertImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(713, 444);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(12, 444);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnThickness
            // 
            this.btnThickness.Location = new System.Drawing.Point(197, 444);
            this.btnThickness.Name = "btnThickness";
            this.btnThickness.Size = new System.Drawing.Size(75, 23);
            this.btnThickness.TabIndex = 3;
            this.btnThickness.Text = "Thickness";
            this.btnThickness.UseVisualStyleBackColor = true;
            this.btnThickness.Click += new System.EventHandler(this.btnThickness_Click);
            // 
            // thicknessTextBox
            // 
            this.thicknessTextBox.Location = new System.Drawing.Point(93, 444);
            this.thicknessTextBox.Name = "thicknessTextBox";
            this.thicknessTextBox.Size = new System.Drawing.Size(98, 20);
            this.thicknessTextBox.TabIndex = 4;
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(278, 446);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(349, 20);
            this.txtImageUrl.TabIndex = 5;
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Location = new System.Drawing.Point(633, 444);
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(75, 23);
            this.btnInsertImage.TabIndex = 6;
            this.btnInsertImage.Text = "Insert Image";
            this.btnInsertImage.UseVisualStyleBackColor = true;
            this.btnInsertImage.Click += new System.EventHandler(this.btnInsertImage_Click);
            // 
            // WhiteboardClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.btnInsertImage);
            this.Controls.Add(this.txtImageUrl);
            this.Controls.Add(this.thicknessTextBox);
            this.Controls.Add(this.btnThickness);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.panel1);
            this.Name = "WhiteboardClient";
            this.Text = "WhiteboardClient";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
