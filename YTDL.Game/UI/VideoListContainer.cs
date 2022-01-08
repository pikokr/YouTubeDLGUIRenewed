using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI
{
    public class VideoListContainer : RearrangeableListContainer<Video>
    {
        public VideoListContainer()
        {
            RelativeSizeAxes = Axes.Both;
        }

        protected override ScrollContainer<Drawable> CreateScrollContainer() => new BasicScrollContainer();

        protected override RearrangeableListItem<Video> CreateDrawable(Video item) => new VideoListItem(item);
    }
}
