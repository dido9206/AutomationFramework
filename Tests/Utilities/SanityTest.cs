using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class SanityTest
    {
        private TestContext testContext;
        private static string url;
        public static void setUrl(string address)
        {
            url = address;
        }
        public static string getUrl
        {
            get { return url; }
        }
        private static string refPath;
        public static void setRefPath(string address)
        {
            refPath = address;
        }
        public static string getRefPath
        {
            get { return refPath; }
        }

        private static string registrationOutputFile;
        public static void setRegOutPath(string address)
        {
            registrationOutputFile = address;
        }
        public static string getRegOutPath
        {
            get { return registrationOutputFile; }
        }

        private static string referatsOutputFile;
        public static void setRefOutPath(string address)
        {
            referatsOutputFile = address;
        }
        public static string getRefOutPath
        {
            get { return referatsOutputFile; }
        }
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
           // Driver.Close();
        }
    }
}
