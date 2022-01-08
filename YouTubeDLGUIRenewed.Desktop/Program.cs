using osu.Framework.Platform;
using osu.Framework;
using YouTubeDLGUIRenewed.Game;

namespace YouTubeDLGUIRenewed.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"YouTubeDLGUIRenewed"))
            using (osu.Framework.Game game = new YouTubeDLGUIRenewedGame())
                host.Run(game);
        }
    }
}
