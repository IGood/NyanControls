using System.Windows.Forms;

namespace test
{
	public partial class Form1 : Form
	{
		Timer m_fakeProgress;

		public Form1()
		{
			InitializeComponent();

			m_fakeProgress = new Timer()
			{
				Enabled = true,
				Interval = 1000 / 1,
			};

			m_fakeProgress.Tick += (sender, e) =>
			{
				nyanProgressBar1.PerformStep();
				if (nyanProgressBar1.Value >= nyanProgressBar1.Maximum)
				{
					nyanProgressBar1.Value = 0;
				}

				nyanProgressBar3.PerformStep();
				if (nyanProgressBar3.Value >= nyanProgressBar3.Maximum)
				{
					nyanProgressBar3.Value = 0;
				}
			};
		}

		private void nyanProgressBar3_Click(object sender, System.EventArgs e)
		{
			propertyGrid1.SelectedObject = sender;
		}
	}
}
