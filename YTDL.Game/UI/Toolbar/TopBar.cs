using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace YtdlGui.Game.UI.Toolbar
{
    public class TopBar : Container
    {
        public TopBar()
        {
            Height = 50;
            RelativeSizeAxes = Axes.X;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(52, 97, 235, 255) },
                new FillFlowContainer
                {
                    Origin = Anchor.CentreLeft,
                    Anchor = Anchor.CentreLeft,
                    Direction = FillDirection.Horizontal,
                    Padding = new MarginPadding
                    {
                        Left = 10
                    },
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Text = "YouTube Downloader",
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            Font = FontUsage.Default.With(size: 24, weight: "Bold")
                        }
                    }
                }
            };
        }
    }
}
