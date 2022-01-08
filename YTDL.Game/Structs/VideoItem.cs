using osu.Framework.Bindables;
using YoutubeExplode.Videos;

namespace YtdlGui.Game.Structs
{
    public class VideoItem
    {
        public Video Video;
        public Bindable<bool> IsDownloading = new();
    }
}
