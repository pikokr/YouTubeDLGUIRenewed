using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Testing;
using YtdlGui.Game.Structs;
using YtdlGui.Game.UI;

namespace YtdlGui.Game.Tests.Visual.UI
{
    public class TestVideoList : TestScene
    {
        private VideoListContainer listContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new Container
            {
                Child = listContainer = new VideoListContainer(),
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding(10)
            });

            AddStep("Add", () =>
                listContainer.Items.Add(new Video()));
        }
    }
}
