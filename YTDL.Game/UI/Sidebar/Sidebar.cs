using System;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Logging;
using osuTK;
using osuTK.Graphics;
using YoutubeExplode;
using YtdlGui.Game.Structs;
using YtdlGui.Game.UI.Components;

namespace YtdlGui.Game.UI.Sidebar
{
    public class Sidebar : Container
    {
        private VideoAddButton videoAddButton;

        private UrlTextBox urlTextBox;

        private YoutubeClient yt;

        private MainScreen mainScreen;

        public Sidebar(MainScreen screen)
        {
            mainScreen = screen;
            Width = 300;
            RelativeSizeAxes = Axes.Y;
        }

        private void OnAdd()
        {
            if (urlTextBox.Text.Length == 0)
            {
                return;
            }

            var text = urlTextBox.Text.Trim();

            Task.Run(async () =>
            {
                try
                {
                    var video = await yt.Videos.GetAsync(text);

                    mainScreen.VideoListContainer.Items.Add(new VideoItem
                    {
                        Video = video,
                    });
                }
                catch (Exception e)
                {
                    Logger.Log(e.Message);
                    return;
                }
            });

            urlTextBox.Text = string.Empty;
        }

        [BackgroundDependencyLoader]
        private void load(YoutubeClient youtubeClient)
        {
            yt = youtubeClient;
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = new Color4(52, 88, 235, 255),
                    RelativeSizeAxes = Axes.Both,
                },
                new BasicScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = new FillFlowContainer
                    {
                        Padding = new MarginPadding(10),
                        AutoSizeAxes = Axes.Y,
                        RelativeSizeAxes = Axes.X,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(0, 10),
                        Children = new Drawable[]
                        {
                            urlTextBox = new UrlTextBox
                            {
                                PlaceholderText = "영상 URL 입력",
                                RelativeSizeAxes = Axes.X,
                                Height = 40,
                                Action = OnAdd
                            },
                            videoAddButton = new VideoAddButton(OnAdd)
                        }
                    }
                }
            };
        }
    }
}
