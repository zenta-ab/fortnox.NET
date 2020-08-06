using FortnoxNET.Tests.Config;

namespace FortnoxNET.Tests
{
    public abstract class TestBase
    {
        protected readonly FortnoxConnectionSettings connectionSettings;

        protected TestBase()
        {
            this.connectionSettings = TestHelper.GetFortnoxConnectionSettings();
        }
    }
}
