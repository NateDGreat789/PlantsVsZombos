namespace pvz
{
    partial class MenuScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.endlessButton = new System.Windows.Forms.Button();
            this.storyButton = new System.Windows.Forms.Button();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 40.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1294, 249);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLANTS VS ZOMBOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endlessButton
            // 
            this.endlessButton.BackColor = System.Drawing.Color.SeaGreen;
            this.endlessButton.Font = new System.Drawing.Font("Goudy Stout", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endlessButton.ForeColor = System.Drawing.Color.White;
            this.endlessButton.Location = new System.Drawing.Point(435, 469);
            this.endlessButton.Name = "endlessButton";
            this.endlessButton.Size = new System.Drawing.Size(429, 132);
            this.endlessButton.TabIndex = 1;
            this.endlessButton.Text = "ENDLESS MODE";
            this.endlessButton.UseVisualStyleBackColor = false;
            this.endlessButton.Click += new System.EventHandler(this.endlessButton_Click);
            // 
            // storyButton
            // 
            this.storyButton.BackColor = System.Drawing.Color.SeaGreen;
            this.storyButton.Font = new System.Drawing.Font("Goudy Stout", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storyButton.ForeColor = System.Drawing.Color.White;
            this.storyButton.Location = new System.Drawing.Point(435, 331);
            this.storyButton.Name = "storyButton";
            this.storyButton.Size = new System.Drawing.Size(429, 132);
            this.storyButton.TabIndex = 2;
            this.storyButton.Text = "STORY MODE";
            this.storyButton.UseVisualStyleBackColor = false;
            this.storyButton.Click += new System.EventHandler(this.storyButton_Click);
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.Font = new System.Drawing.Font("Goudy Stout", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.Location = new System.Drawing.Point(3, 604);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(1294, 66);
            this.highscoreLabel.TabIndex = 3;
            this.highscoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.storyButton);
            this.Controls.Add(this.endlessButton);
            this.Controls.Add(this.label1);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1300, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endlessButton;
        private System.Windows.Forms.Button storyButton;
        private System.Windows.Forms.Label highscoreLabel;
    }
}
