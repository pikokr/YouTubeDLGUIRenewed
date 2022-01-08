using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Logging;
using osuTK.Graphics;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI
{
    public class VideoListItem : RearrangeableListItem<Video>
    {
        public readonly Video Item;

        private readonly Bindable<string> title = new();
        private readonly Bindable<string> creator = new();

        public VideoListItem(Video video)
            : base(video)
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;

            Item = video;

            title.BindTo(video.Title);
            creator.BindTo(video.Creator);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Logger.Log("Content");
            InternalChildren = new Drawable[]
            {
                new GridContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Margin = new MarginPadding
                    {
                        Bottom = 10.0f
                    },
                    Content = new[]
                    {
                        new[]
                        {
                            new Box { Height = 100, RelativeSizeAxes = Axes.X, Alpha = 0},
                            createContent(),
                        }
                    },
                    ColumnDimensions = new[] { new Dimension(GridSizeMode.AutoSize) },
                    RowDimensions = new[] { new Dimension(GridSizeMode.AutoSize) },
                }
            };
        }

        private Drawable createContent()
        {
            return new Container
            {
                RelativeSizeAxes = Axes.X,
                Height = 100,
                Masking = true,
                CornerRadius = 10,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White,
                        Alpha = 0.1f
                    }
                }
            };
        }
    }
}
