namespace NaverLandCrawler
{
    using NLog;
    using System;
    using System.IO;
    using System.Threading;

    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static bool removeNotSeoul = false;
        private static bool removeNotGG = false;
        private static bool removeNotNearByRegion = true;
        private static bool removeFirstRegistPassed = true;
        private static bool removeFirstRegistDateNotSpecified = true;


        internal static void Main(string[] args)
        {
            var targetDate = DateTime.Now.ToShortDateString().Replace("-", "");
            logger.Info($"[기준일시<{targetDate}> 정보수집 시작]");
            logger.Info("");
            logger.Info($"==========================검색 옵션===================================");
            logger.Info($"[서울만?: {removeNotSeoul}]");
            logger.Info($"[경기만?: {removeNotGG}]");
            logger.Info($"[서울 또는 경기만?: {removeNotNearByRegion}]");
            logger.Info($"[1차 접수 기간이 지나지 않은것들만?: {removeFirstRegistPassed}]");
            logger.Info($"[1차 접수 기간이 공고 난 것들만?: {removeFirstRegistDateNotSpecified}]");
            logger.Info($"====================================================================");
            logger.Info("");

            LandRequester webRequester = new LandRequester();

            logger.Trace($"Page 정보 수집중...");

            var GetTotalPagesTask = webRequester.GetTotalPages();
            GetTotalPagesTask.Wait();
            int totalPages = GetTotalPagesTask.Result;

            logger.Trace($"전체 Page 수: {totalPages}");

            for (int page = 0; page < totalPages; ++page)
            {
                logger.Trace($"Page[{page}] 수집중...");
                var GetLandInfoTask = webRequester.GetLandInfo(page);
                GetLandInfoTask.Wait();
                foreach (var complex in GetLandInfoTask.Result.ComplexList)
                {
                    bool firstRegistDateNotSpecified = string.IsNullOrEmpty(complex.Ss3);
                    bool notSeoul = !complex.RegionName.Contains("서울시");
                    bool notGG = !complex.RegionName.Contains("경기도");
                    bool notNearByRegion = notSeoul && notGG;
                    bool firstRegistPassed = !string.IsNullOrEmpty(complex.Ss3) && string.Compare(complex.Sx3, targetDate) < 0;

                    if ( (removeFirstRegistDateNotSpecified && firstRegistDateNotSpecified)
                        || (removeNotSeoul && notSeoul)
                        || (removeNotGG && notGG)
                        || (removeNotNearByRegion && notNearByRegion)
                        || (removeFirstRegistPassed && firstRegistPassed))
                    {
                        continue;
                    }

                    logger.Info($"====================================================================");
                    logger.Info($"[{complex.RegionName}] {complex.HscpNm}");
                    logger.Info($"{complex.IsaleYmdInfo} 공고 ");
                    logger.Info($"{complex.Ss3} ~ {complex.Sx3} 접수 ");
                    logger.Info($"{((float)complex.MinSpc / 3.3):f1} 평형 ~ {((float)complex.MaxSpc / 3.3):f1} 평형");
                    logger.Info($"{((float)complex.MinIsalePrc / 10000.0):f2} 억원 ~ {((float)complex.MaxIsalePrc / 10000.0):f2} 억원");
                    logger.Info($"{(int)(((float)(complex.MinIsalePrc + complex.MaxIsalePrc)) / ((float)(complex.MinSpc + complex.MaxSpc) / 3.3))} 만원/평");
                    logger.Info($"====================================================================");
                    logger.Info("");
                    Thread.Sleep(500);
                }
            }

            logger.Info($"[정보 수집 완료]");
            Thread.Sleep(3000);
            File.Delete("\\\\NAS_for_younsol\\web\\index.html");
            File.Move("index.html", "\\\\NAS_for_younsol\\web\\index.html");
        }
    }
}
