namespace FoodRecDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.choiceBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.recLabel = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.recList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // choiceBox
            // 
            this.choiceBox.FormattingEnabled = true;
            this.choiceBox.Items.AddRange(new object[] {
            "Brownie",
            "Chicken Dippers",
            "Apple",
            "Blueberry Muffin",
            "1/4 lb Big Bite",
            "3 Meat Pizza Slice",
            "Beef Taquito",
            "Starburst",
            "Laffy Taffy",
            "Powdered Mini-Donuts",
            "7-Select All Natural Beef and Bean Burrito",
            "Hot Chocolate",
            "Ice Cream Sandwich",
            "Big Gulp",
            "Chicken Taquito"});
            this.choiceBox.Location = new System.Drawing.Point(-1, 25);
            this.choiceBox.Name = "choiceBox";
            this.choiceBox.ScrollAlwaysVisible = true;
            this.choiceBox.Size = new System.Drawing.Size(243, 229);
            this.choiceBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select 5 Favorites from the list";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(34, 271);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(177, 35);
            this.submit.TabIndex = 2;
            this.submit.Text = "Get Recommendations!";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // recLabel
            // 
            this.recLabel.AutoSize = true;
            this.recLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recLabel.Location = new System.Drawing.Point(269, 14);
            this.recLabel.Name = "recLabel";
            this.recLabel.Size = new System.Drawing.Size(140, 13);
            this.recLabel.TabIndex = 3;
            this.recLabel.Text = "Top Recommendations:";
            this.recLabel.Visible = false;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(259, 271);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(83, 35);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(348, 271);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(83, 35);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // recList
            // 
            this.recList.AutoSize = true;
            this.recList.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recList.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.recList.Location = new System.Drawing.Point(269, 39);
            this.recList.Name = "recList";
            this.recList.Size = new System.Drawing.Size(0, 15);
            this.recList.TabIndex = 6;
            this.recList.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 318);
            this.Controls.Add(this.recList);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.recLabel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choiceBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Product Recommendation Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox choiceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label recLabel;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label recList;
    }
}

