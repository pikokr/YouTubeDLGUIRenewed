using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI.Video
{
    public class VideoListContainer : RearrangeableListContainer<VideoItem>
    {
        public VideoListContainer()
        {
            RelativeSizeAxes = Axes.Both;
        }

        protected override ScrollContainer<Drawable> CreateScrollContainer() => new BasicScrollContainer();

        protected override RearrangeableListItem<VideoItem> CreateDrawable(VideoItem item) => new VideoListItem(item, this);
    }
}
