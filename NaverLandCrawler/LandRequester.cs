namespace NaverLandCrawler
{
    using NaverLandCrawler.DataContract;
    using NLog;
    using System;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;

    public class LandRequester
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private string landRequestUri = "http://land.naver.com/isale/isaleComplexList.nhn?page=";

        public async Task<int> GetTotalPages()
        {
            return (await GetLandInfo(0)).PagerInfo.TotalPages;
        }

        public async Task<LandRequestResult> GetLandInfo(int page)
        {
            logger.Trace("Request Start");
            try
            {
                var request = WebRequest.Create($"{landRequestUri}{page}") as HttpWebRequest;
                request.Method = "GET";

                var response = await request.GetResponseAsync();
                var stream = response.GetResponseStream();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LandRequestResponse));
                var obj = jsonSerializer.ReadObject(stream);
                return (obj as LandRequestResponse).Result;
            }
            catch (Exception e)
            {
                logger.Error($"Request page[{page}] Incomplete");
                logger.Error(e.StackTrace);
            }
            finally
            {
                logger.Trace("Request Complete");
            }
            return null;
        }
    }
}