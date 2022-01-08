using osu.Framework;
using osu.Framework.Platform;
using YtdlGui.Game;

namespace YtdlGui.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"YouTubeDownloader"))
            using (osu.Framework.Game game = new YtdlGame())
                host.Run(game);
        }
    }
}
