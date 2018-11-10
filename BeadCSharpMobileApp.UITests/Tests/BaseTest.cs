using NUnit.Framework;
using Xamarin.UITest;

namespace BeadCSharpMobileApp.UITests{

    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]

    public abstract class BaseTest{

        protected IApp app;
        protected Platform platform;

        protected BeadsPage ItemsPage;
        protected NewBeadPage NewItemPage;

        protected BaseTest(Platform platform){
            this.platform = platform;
        }

        [SetUp]
        virtual public void BeforeEachTest(){
            app = AppInitializer.StartApp(platform);
            app.Screenshot("App Initialized");

            ItemsPage = new BeadsPage(app, platform);
            NewItemPage = new NewBeadPage(app, platform);
        }
    }
}