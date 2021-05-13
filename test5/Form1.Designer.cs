
namespace test5
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nyanProgressBar1 = new NyanControls.NyanProgressBar();
			this.SuspendLayout();
			// 
			// nyanProgressBar1
			// 
			this.nyanProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nyanProgressBar1.Location = new System.Drawing.Point(0, 0);
			this.nyanProgressBar1.MarqueeAnimationSpeed = 555;
			this.nyanProgressBar1.Name = "nyanProgressBar1";
			this.nyanProgressBar1.Size = new System.Drawing.Size(800, 100);
			this.nyanProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.nyanProgressBar1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.nyanProgressBar1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private NyanControls.NyanProgressBar nyanProgressBar1;
	}
}

