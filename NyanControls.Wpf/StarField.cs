namespace NyanControls.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    internal class StarField : Canvas
    {
        private const int StarSize = 8;

        private static readonly Random Rand = new Random();

        private readonly ImageSource bmpFrame;

        static StarField()
        {
            EventManager.RegisterClassHandler(typeof(StarField), SizeChangedEvent, new SizeChangedEventHandler(OnSizeChanged));
        }

        public StarField()
        {
            var info = Application.GetResourceStream(new Uri("/NyanControls.Wpf;component/Images/star.gif", UriKind.Relative));
            using (info.Stream)
            {
                this.bmpFrame = BitmapFrame.Create(info.Stream);
            }
        }

        private static void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            StarField starField = (StarField)sender;

            double clientWidth = starField.ActualWidth;
            double clientHeight = starField.ActualHeight;

            const int MinStars = 2;
            const int MaxStars = 64;
            const int ATSRatio = 3000;
            int desiredStarCount = Math.Min(Math.Max(MinStars, (int)(clientWidth * clientHeight) / ATSRatio), MaxStars);
            int currentStarCount = starField.Children.Count;

            if (currentStarCount == desiredStarCount)
            {
                return;
            }

            if (currentStarCount > desiredStarCount)
            {
                starField.Children.RemoveRange(desiredStarCount, currentStarCount - desiredStarCount);
                return;
            }

            starField.Children.Capacity = desiredStarCount;

            do
            {
                var starImage = new Image();
                starField.Children.Add(starImage);

                WpfAnimatedGif.ImageBehavior.AddAnimationLoadedHandler(starImage, starField.StarImage_OnAnimationLoaded);
                starImage.Width = StarSize;
                starImage.Height = StarSize;
                SetPosition(starImage, clientWidth, clientHeight);
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(starImage, starField.bmpFrame);
            } while (++currentStarCount < desiredStarCount);
        }

        private void StarImage_OnAnimationLoaded(object sender, EventArgs e)
        {
            var starImage = (Image)sender;

            SetPosition(starImage, this.ActualWidth, this.ActualHeight);

            if (DesignerProperties.GetIsInDesignMode(this) &&
                WpfAnimatedGif.ImageBehavior.GetAnimateInDesignMode(this) == false)
            {
                return;
            }

            var animController = WpfAnimatedGif.ImageBehavior.GetAnimationController(starImage);

            animController.CurrentFrameChanged += delegate
            {
                if (animController.CurrentFrame == -1)
                {
                    SetPosition(starImage, this.ActualWidth, this.ActualHeight);
                }
            };

            animController.GotoFrame(Rand.Next(animController.FrameCount));
        }

        private static void SetPosition(Image image, double clientWidth, double clientHeight)
        {
            Canvas.SetLeft(image, Rand.NextDouble() * clientWidth - StarSize / 2);
            Canvas.SetTop(image, Rand.NextDouble() * clientHeight - StarSize / 2);
        }
    }
}
