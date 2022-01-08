using osu.Framework.Testing;

namespace YouTubeDLGUIRenewed.Game.Tests.Visual
{
    public class YouTubeDLGUIRenewedTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new YouTubeDLGUIRenewedTestSceneTestRunner();

        private class YouTubeDLGUIRenewedTestSceneTestRunner : YouTubeDLGUIRenewedGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
