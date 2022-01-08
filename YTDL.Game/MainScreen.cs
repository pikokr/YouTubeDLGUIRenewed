using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using YtdlGui.Game.UI.Sidebar;
using YtdlGui.Game.UI.Toolbar;
using YtdlGui.Game.UI.Video;

namespace YtdlGui.Game
{
    public class MainScreen : Screen
    {
        public VideoListContainer VideoListContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Children = new Drawable[]
                    {
                        new TopBar(),
                        new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Children = new Drawable[]
                            {
                                new Sidebar(this),
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Padding = new MarginPadding
                                    {
                                        Right = 310,
                                        Left = 10,
                                        Top = 10,
                                        Bottom = 60
                                    },
                                    Child = VideoListContainer = new VideoListContainer()
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
