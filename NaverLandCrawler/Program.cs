namespace NaverLandCrawler
{
    using System.Threading;

    class Program
    {
        private static LandRequester webRequester;

        static void Main(string[] args)
        {
            webRequester = new LandRequester();
            var response = webRequester.Request();
            while(!response.IsCompleted)
            {
                Thread.Sleep(100);
            }
            
            return;
        }
    }
}
