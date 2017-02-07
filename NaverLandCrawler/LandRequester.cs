namespace NaverLandCrawler
{
    using NLog;
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    public class LandRequester
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private string landRequestUri = "http://land.naver.com/isale/isaleComplexList.nhn";

        public async Task<string> Request()
        {
            logger.Info("Request Start");
            try
            {
                var request = WebRequest.Create(landRequestUri) as HttpWebRequest;
                request.Method = "POST";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                var response = await request.GetResponseAsync();
                var stream = response.GetResponseStream();
                return await new StreamReader(stream).ReadToEndAsync();
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
            finally
            {
                logger.Info("Request Complete");
            }
            return null;
        }
    }
}