using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
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

        private TextFlowContainer titleText;
        private TextFlowContainer creatorText;

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

            title.BindValueChanged(_ => Scheduler.AddOnce(refresh));
            creator.BindValueChanged(_ => Scheduler.AddOnce(refresh));

            refresh();
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
                            new Box { Height = 100, RelativeSizeAxes = Axes.X, Alpha = 0 },
                            createContent(),
                        }
                    },
                    ColumnDimensions = new[] { new Dimension(GridSizeMode.AutoSize) },
                    RowDimensions = new[] { new Dimension(GridSizeMode.AutoSize) },
                }
            };
        }

        private void refresh()
        {
            titleText.Clear();

            titleText.AddText(title.Value);

            creatorText.Clear();

            creatorText.AddText(creator.Value);
        }

        private Drawable createContent()
        {
            Action<SpriteText> fontParameters = s => s.Font = FontUsage.Default.With(size: 32, weight: "Bold", family: "NanumSquareRound");

            return new Container
            {
                RelativeSizeAxes = Axes.X,
                Height = 110,
                CornerRadius = 5,
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White,
                        Alpha = 0.1f
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.AutoSize),
                            new Dimension(),
                            new Dimension(GridSizeMode.AutoSize),
                            new Dimension(GridSizeMode.AutoSize)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new FillFlowContainer
                                {
                                    Padding = new MarginPadding(10f),
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    AutoSizeAxes = Axes.Y,
                                    RelativeSizeAxes = Axes.X,
                                    Direction = FillDirection.Vertical,
                                    Children = new Drawable[]
                                    {
                                        new FillFlowContainer
                                        {
                                            Anchor = Anchor.CentreLeft,
                                            Origin = Anchor.CentreLeft,
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X,
                                            Direction = FillDirection.Horizontal,
                                            Children = new Drawable[]
                                            {
                                                new FillFlowContainer
                                                {
                                                    Anchor = Anchor.CentreLeft,
                                                    Origin = Anchor.CentreLeft,
                                                    Width = 160,
                                                    Height = 90,
                                                    Direction = FillDirection.Vertical,
                                                    Children = new Drawable[]
                                                    {
                                                        new ThumbnailContainer(Item)
                                                    }
                                                },
                                                new FillFlowContainer
                                                {
                                                    Margin = new MarginPadding { Left = 10 },
                                                    Anchor = Anchor.CentreLeft,
                                                    Origin = Anchor.CentreLeft,
                                                    AutoSizeAxes = Axes.Y,
                                                    Direction = FillDirection.Vertical,
                                                    Children = new Drawable[]
                                                    {
                                                        titleText = new TextFlowContainer(fontParameters)
                                                        {
                                                            RelativeSizeAxes = Axes.X,
                                                            AutoSizeAxes = Axes.Y,
                                                        },
                                                        creatorText = new TextFlowContainer(text =>
                                                        {
                                                            fontParameters(text);
                                                            text.Font = text.Font.With(size: 24);
                                                        })
                                                        {
                                                            RelativeSizeAxes = Axes.X,
                                                            AutoSizeAxes = Axes.Y,
                                                        },
                                                    }
                                                }
                                            },
                                        },
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
