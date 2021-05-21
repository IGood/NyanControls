/// Nyan Cat progress bar control
/// Ian Good 2012

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace NyanControls
{
	/// <summary>
	/// Represents a Windows progress bar control.
	/// </summary>
	[ToolboxBitmap(typeof(NyanProgressBar), "Properties.Resources.NyanProgressBar")]
	public class NyanProgressBar : ProgressBar
	{
		#region Internal Classes

		private class Star
		{
			public Point Location;
			public int Frame;

			public Star(int x, int y, int frame)
			{
				Location.X = x;
				Location.Y = y;
				Frame = frame;
			}
		}

		#endregion

		#region Constants / Static Immutables

		private static readonly Random Rand = new Random();

		private static readonly Color SkyColor = Color.FromArgb(00, 0x33, 0x66);

		private static readonly Image NyanImage = Properties.Resources.nyan;
		private static readonly Image RainbowImage = Properties.Resources.rainbow;
		private static readonly Image StarImage = Properties.Resources.star;

		const float NyanScale = 15;
		const int StarSize = 8;

		#endregion

		#region Instance Fields / Properties

		private bool m_Disposed;

		protected override Size DefaultSize { get { return new Size(100, 23); } }

		private ImageAttributes m_RainbowImgAttrs = new ImageAttributes();

		private bool m_AnimateWhenInactive = true;
		/// <summary>
		/// Gets or sets a value indicating whether the NyanControls.NyanProgressBar animates when there is no
		/// progress.
		/// </summary>
		[Category("Behavior")]
		[Description("Indicates whether this ProgressBar will animate when there is no progress to show.")]
		[DefaultValue(true)]
		public bool AnimateWhenInactive
		{
			get { return m_AnimateWhenInactive; }
			set { m_AnimateWhenInactive = value; }
		}

		private Timer m_AnimationTimer;

		private Timer m_MarqueeTimer;
		private Timer MarqueeTimer
		{
			get { return m_MarqueeTimer; }
			set
			{
				if (!Object.ReferenceEquals(m_MarqueeTimer, null))
				{
					m_MarqueeTimer.Dispose();
				}

				m_MarqueeTimer = value;
			}
		}

		private bool m_RainbowAnimate;

		private int m_StarFrameCount = 1;
		private List<Star> m_Stars = new List<Star>();

		private float m_MarqueeValue;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NyanControls.NyanProgressBar class.
		/// </summary>
		public NyanProgressBar()
		{
			SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw,
				true);

			m_RainbowImgAttrs.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);

			SetupAnimation();
		}

		#endregion

		protected override void Dispose(bool disposing)
		{
			if (!m_Disposed)
			{
				try
				{
					if (disposing)
					{
						m_RainbowImgAttrs.Dispose();
						m_AnimationTimer.Dispose();
						MarqueeTimer = null;
					}

					m_Disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		#region Setup

		private void SetupAnimation()
		{
			int nyanFrameCount = NyanImage.GetFrameCount(FrameDimension.Time);

			m_StarFrameCount = StarImage.GetFrameCount(FrameDimension.Time);

			m_AnimationTimer = new Timer()
			{
				Enabled = true,
				Interval = 70,
			};

			int nyanFrame = 0;
			int rainbowFrame = 0;

			m_AnimationTimer.Tick += (sender, e) =>
			{
				if (IsInactive())
				{
					return;
				}

				NyanImage.SelectActiveFrame(FrameDimension.Time, nyanFrame = (nyanFrame + 1) % nyanFrameCount);

				if ((++rainbowFrame & 0x01) == 1)
				{
					m_RainbowAnimate = !m_RainbowAnimate;
				}

				int clientWidth = ClientSize.Width;
				int clientHeight = ClientSize.Height;

				m_Stars.ForEach((star) =>
				{
					star.Frame = (star.Frame + 1) % m_StarFrameCount;
					if (star.Frame == 0)
					{
						star.Location.X = Rand.Next(clientWidth);
						star.Location.Y = Rand.Next(clientHeight);
					}
				});

				Invalidate();
			};
		}

		private void CreateStars()
		{
			int clientWidth = ClientSize.Width;
			int clientHeight = ClientSize.Height;

			const int MinStars = 2;
			const int MaxStars = 64;
			const int ATSRatio = 3000;
			int starCount = Math.Min(Math.Max(MinStars, (clientWidth * clientHeight) / ATSRatio), MaxStars);

			m_Stars.Clear();
			m_Stars.Capacity = starCount;

			for (int i = 0; i < starCount; ++i)
			{
				m_Stars.Add(new Star(
					Rand.Next(clientWidth) - StarSize / 2,
					Rand.Next(clientHeight) - StarSize / 2,
					Rand.Next(m_StarFrameCount)));
			}

			m_Stars.Sort((a, b) => a.Frame - b.Frame);
		}

		private void CreateMarqueeTimer()
		{
			MarqueeTimer = new Timer()
			{
				Enabled = true,
				Interval = 1000 / 30,
			};

			MarqueeTimer.Tick += (sender, e) =>
			{
				float speed = 1000f / MarqueeAnimationSpeed;
				float nyanHalfWidth = NyanImage.Width / (NyanScale * 2f);
				if ((m_MarqueeValue += speed) > (ClientSize.Width + nyanHalfWidth))
				{
					m_MarqueeValue = -nyanHalfWidth;
				}
			};
		}

		#endregion

		protected override void OnSizeChanged(EventArgs e)
		{
			CreateStars();
			base.OnSizeChanged(e);
		}

		private bool IsInactive()
		{
			return !AnimateWhenInactive && Style != ProgressBarStyle.Marquee && Value == Minimum;
		}

		#region Drawing

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			g.InterpolationMode = InterpolationMode.NearestNeighbor;

			g.Clear(SkyColor);

			if (!IsInactive())
			{
				DrawStars(g);

				if (Style == ProgressBarStyle.Marquee)
				{
					if (MarqueeTimer == null)
					{
						CreateMarqueeTimer();
					}

					DrawRainbow(g, 1);
					float nyanWidth = NyanImage.Width / NyanScale;
					DrawNyan(g, m_MarqueeValue / (ClientSize.Width + nyanWidth));
				}
				else
				{
					MarqueeTimer = null;

					int range = Maximum - Minimum;
					float percent = (range == 0) ? 0 : ((float)Value / range);

					if (percent > 0f)
					{
						DrawRainbow(g, percent);
						DrawNyan(g, percent);
					}
				}
			}

			g.DrawRectangle(Pens.Black, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

			base.OnPaint(e);
		}

		private void DrawNyan(Graphics g, float percent)
		{
			float clientWidth = ClientSize.Width;
			int clientHeight = ClientSize.Height;

			float nyanWidth = NyanImage.Width / NyanScale;
			int nyanHeight = (int)(NyanImage.Height / NyanScale);

			float halfNyan = nyanWidth / 2f;
			float width = (clientWidth + nyanWidth) * percent;

			float x = percent.Lerp(-halfNyan, clientWidth + halfNyan);

			Rectangle destRect = new Rectangle(
				(int)(x - halfNyan),
				Math.Abs(clientHeight - nyanHeight) / 2,
				(int)nyanWidth,
				nyanHeight);

			g.DrawImage(
				NyanImage,
				destRect,
				0,
				0,
				NyanImage.Width,
				NyanImage.Height,
				GraphicsUnit.Pixel);
		}

		private void DrawRainbow(Graphics g, float percent)
		{
			float nyanWidth = NyanImage.Width / NyanScale;
			float halfNyan = nyanWidth / 2f;
			float width = (ClientSize.Width + nyanWidth) * percent - 7;

			int rainbowWidth = RainbowImage.Width;
			int rainbowHeight = RainbowImage.Height;

			Rectangle destRect = new Rectangle(
				(int)-halfNyan,
				Math.Abs(ClientSize.Height - rainbowHeight) / 2,
				(int)width,
				rainbowHeight);

			g.DrawImage(
				RainbowImage,
				destRect,
				m_RainbowAnimate ? rainbowWidth / 2 : 0,
				0,
				destRect.Width,
				RainbowImage.Height,
				GraphicsUnit.Pixel,
				m_RainbowImgAttrs);
		}

		private void DrawStars(Graphics g)
		{
			int currentFrame = 0;

			m_Stars.ForEach((star) =>
			{
				if (star.Frame != currentFrame)
				{
					currentFrame = star.Frame;
					StarImage.SelectActiveFrame(FrameDimension.Time, currentFrame);
				}

				g.DrawImage(StarImage, star.Location.X, star.Location.Y, StarSize, StarSize);
			});
		}

		#endregion
	}

	internal static class Extensions
	{
		public static float Lerp(this float t, float a, float b)
		{
			return a + t * (b - a);
		}
	}
}
