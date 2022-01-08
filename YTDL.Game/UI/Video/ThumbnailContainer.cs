using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI.Video
{
    public class ThumbnailContainer : Container
    {
        private readonly VideoItem video;

        public ThumbnailContainer(VideoItem vid)
        {
            RelativeSizeAxes = Axes.Both;
            CornerRadius = 5f;
            Masking = true;
            video = vid;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            LoadComponentAsync(new Thumbnail(video), Add);
        }
    }
}
