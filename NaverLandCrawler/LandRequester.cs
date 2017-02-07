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
            return (await GetLandInfo(0)).Result.PagerInfo.TotalPages;
        }

        public async Task<LandRequestResponse> GetLandInfo(int page)
        {
            logger.Info("Request Start");
            try
            {
                var request = WebRequest.Create($"{landRequestUri}{page}") as HttpWebRequest;
                request.Method = "GET";

                var response = await request.GetResponseAsync();
                var stream = response.GetResponseStream();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LandRequestResponse));
                var obj = jsonSerializer.ReadObject(stream);
                return obj as LandRequestResponse;
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