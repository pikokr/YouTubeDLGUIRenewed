using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;
using osu.Framework.Screens;

namespace YtdlGui.Game
{
    public class YtdlGame : YtdlGameBase
    {
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Children = new Drawable[]
            {
                screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both },
                new CursorContainer()
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            screenStack.Push(new MainScreen());
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            host.Window.Title = "YouTube Downloader";
            host.Window.CursorState |= CursorState.Hidden;
        }
    }
}
