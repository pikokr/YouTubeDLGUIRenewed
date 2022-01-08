using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI
{
    public class ThumbnailContainer : Container
    {
        private readonly Video video;

        public ThumbnailContainer(Video vid)
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
