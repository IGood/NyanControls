namespace test
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
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.nyanProgressBar4 = new NyanControls.NyanProgressBar();
			this.nyanProgressBar2 = new NyanControls.NyanProgressBar();
			this.nyanProgressBar3 = new NyanControls.NyanProgressBar();
			this.nyanProgressBar1 = new NyanControls.NyanProgressBar();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Left;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(272, 354);
			this.propertyGrid1.TabIndex = 2;
			// 
			// nyanProgressBar4
			// 
			this.nyanProgressBar4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nyanProgressBar4.CausesValidation = false;
			this.nyanProgressBar4.Location = new System.Drawing.Point(278, 166);
			this.nyanProgressBar4.MarqueeAnimationSpeed = 300;
			this.nyanProgressBar4.Name = "nyanProgressBar4";
			this.nyanProgressBar4.Size = new System.Drawing.Size(678, 71);
			this.nyanProgressBar4.Step = 1;
			this.nyanProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.nyanProgressBar4.TabIndex = 1;
			this.nyanProgressBar4.TabStop = false;
			this.nyanProgressBar4.Click += new System.EventHandler(this.nyanProgressBar3_Click);
			// 
			// nyanProgressBar2
			// 
			this.nyanProgressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nyanProgressBar2.CausesValidation = false;
			this.nyanProgressBar2.Location = new System.Drawing.Point(278, 243);
			this.nyanProgressBar2.MarqueeAnimationSpeed = 300;
			this.nyanProgressBar2.Name = "nyanProgressBar2";
			this.nyanProgressBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.nyanProgressBar2.RightToLeftLayout = true;
			this.nyanProgressBar2.Size = new System.Drawing.Size(678, 71);
			this.nyanProgressBar2.Step = 1;
			this.nyanProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.nyanProgressBar2.TabIndex = 1;
			this.nyanProgressBar2.TabStop = false;
			this.nyanProgressBar2.Click += new System.EventHandler(this.nyanProgressBar3_Click);
			// 
			// nyanProgressBar3
			// 
			this.nyanProgressBar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nyanProgressBar3.CausesValidation = false;
			this.nyanProgressBar3.Location = new System.Drawing.Point(278, 12);
			this.nyanProgressBar3.Name = "nyanProgressBar3";
			this.nyanProgressBar3.Size = new System.Drawing.Size(678, 71);
			this.nyanProgressBar3.Step = 1;
			this.nyanProgressBar3.TabIndex = 1;
			this.nyanProgressBar3.TabStop = false;
			this.nyanProgressBar3.Value = 4;
			this.nyanProgressBar3.Click += new System.EventHandler(this.nyanProgressBar3_Click);
			// 
			// nyanProgressBar1
			// 
			this.nyanProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nyanProgressBar1.CausesValidation = false;
			this.nyanProgressBar1.Location = new System.Drawing.Point(278, 89);
			this.nyanProgressBar1.Name = "nyanProgressBar1";
			this.nyanProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.nyanProgressBar1.RightToLeftLayout = true;
			this.nyanProgressBar1.Size = new System.Drawing.Size(678, 71);
			this.nyanProgressBar1.Step = 1;
			this.nyanProgressBar1.TabIndex = 1;
			this.nyanProgressBar1.TabStop = false;
			this.nyanProgressBar1.Value = 4;
			this.nyanProgressBar1.Click += new System.EventHandler(this.nyanProgressBar3_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(278, 320);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(678, 23);
			this.progressBar1.TabIndex = 3;
			this.progressBar1.Click += new System.EventHandler(this.nyanProgressBar3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(968, 354);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.nyanProgressBar4);
			this.Controls.Add(this.nyanProgressBar2);
			this.Controls.Add(this.nyanProgressBar3);
			this.Controls.Add(this.nyanProgressBar1);
			this.Name = "Form1";
			this.Text = "test";
			this.ResumeLayout(false);

		}

		#endregion

		private NyanControls.NyanProgressBar nyanProgressBar1;
		private NyanControls.NyanProgressBar nyanProgressBar2;
		private NyanControls.NyanProgressBar nyanProgressBar3;
		private NyanControls.NyanProgressBar nyanProgressBar4;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}