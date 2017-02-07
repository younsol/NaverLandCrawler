namespace NaverLandCrawler
{
    using System;
    using System.Threading;

    internal class Program
    {
        private static bool removeNotSeoul = false;
        private static bool removeNotGG = true;
        private static bool removeNotNearByRegion = true;
        private static bool removeFirstRegistPassed = true;
        private static bool removeFirstRegistDateNotSpecified = false;


        internal static void Main(string[] args)
        {
            var targetDate = DateTime.Now.ToShortDateString().Replace("-", "");
            Console.WriteLine($"기준일시<{targetDate}> 정보수집 시작");

            LandRequester webRequester = new LandRequester();

            Console.WriteLine($"Page 정보 수집중...");

            var GetTotalPagesTask = webRequester.GetTotalPages();
            GetTotalPagesTask.Wait();
            int totalPages = GetTotalPagesTask.Result;

            Console.WriteLine($"전체 Page 수: {totalPages}");

            for (int page = 0; page < totalPages; ++page)
            {
                Console.WriteLine($"Page[{page}] 수집중...");
                var GetLandInfoTask = webRequester.GetLandInfo(page);
                GetLandInfoTask.Wait();
                foreach (var complex in GetLandInfoTask.Result.Result.ComplexList)
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

                    Console.WriteLine($"====================================================================");
                    Console.WriteLine($"[{complex.RegionName}] {complex.HscpNm}");
                    Console.WriteLine($"{complex.IsaleYmdInfo} 공고 ");
                    Console.WriteLine($"{complex.Ss3} ~ {complex.Sx3} 접수 ");
                    Console.WriteLine($"{((float)complex.MinSpc / 3.3):f1} 평형 ~ {((float)complex.MaxSpc / 3.3):f1} 평형");
                    Console.WriteLine($"{((float)complex.MinIsalePrc / 10000.0):f2} 억원 ~ {((float)complex.MaxIsalePrc / 10000.0):f2} 억원");
                    Console.WriteLine($"{(int)(((float)(complex.MinIsalePrc + complex.MaxIsalePrc)) / ((float)(complex.MinSpc + complex.MaxSpc) / 3.3))} 만원/평");
                    Console.WriteLine($"====================================================================");
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
                Thread.Sleep(1000);
            }
            return;
        }
    }
}
