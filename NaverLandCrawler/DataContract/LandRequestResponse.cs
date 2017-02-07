namespace NaverLandCrawler.DataContract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LandRequestResponse
    {
        [DataMember(Name = "@type")]
        public string Type { get; set; }

        [DataMember(Name = "@service")]
        public string Service { get; set; }

        [DataMember(Name = "@version")]
        public string Version { get; set; }

        [DataMember(Name = "result")]
        public LandRequestResult Result { get; set; }
    }

    [DataContract]
    public class LandRequestResult
    {
        [DataMember(Name = "complexList")]
        public Complex[] ComplexList { get; set; }

        [DataMember(Name = "pagerInfo")]
        public Pager PagerInfo { get; set; }

        [DataMember(Name = "params")]
        public Parameters Params { get; set; }
    }

    [DataContract]
    public class Parameters
    {
        [DataMember(Name = "_PAGER_INFO_")]
        public PagerInfo _PAGER_INFO_ { get; set; }
    }

    [DataContract]
    public class PagerInfo
    {
        [DataMember(Name = "baseKey")]
        public string BaseKey { get; set; }

        [DataMember(Name = "startRownum")]
        public int StartRownum { get; set; }

        [DataMember(Name = "endRownum")]
        public int EndRownum { get; set; }

        [DataMember(Name = "indexSize")]
        public int IndexSize { get; set; }

        [DataMember(Name = "pageSize")]
        public int pageSize { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "rowCountInfo")]
        public string RowCountInfo { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "usablePage")]
        public bool UsablePage { get; set; }

        [DataMember(Name = "useCache")]
        public bool UseCache { get; set; }

        [DataMember(Name = "useCount")]
        public bool UseCount { get; set; }

        [DataMember(Name = "pagerInfo")]
        public Pager PagerInfo_ { get; set; }
    }

    [DataContract]
    public class Pager
    {
        [DataMember(Name = "startRownum")]
        public int StartRownum { get; set; }

        [DataMember(Name = "endRownum")]
        public int EndRownum { get; set; }

        [DataMember(Name = "indexSize")]
        public int IndexSize { get; set; }

        [DataMember(Name = "firstPage")]
        public int FirstPage { get; set; }

        [DataMember(Name = "lastPage")]
        public int LastPage { get; set; }

        [DataMember(Name = "pageSize")]
        public int pageSize { get; set; }

        [DataMember(Name = "prevPage")]
        public int PrevPage { get; set; }

        [DataMember(Name = "nextPage")]
        public int NextPage { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "totalPages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "totalRows")]
        public int TotalRows { get; set; }

        [DataMember(Name = "queryString")]
        public string QueryString { get; set; }

        [DataMember(Name = "requestMethod")]
        public string RequestMethod { get; set; }

        [DataMember(Name = "requestURI")]
        public string RequestUri { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class Complex
    {
        [DataMember(Name = "isale_hscp_no")]
        public int IsaleHscpNo { get; set; }

        [DataMember(Name = "isale_notif_seq")]
        public int IsaleNotifSeq { get; set; }

        [DataMember(Name = "prgr_stp_cd")]
        public string PrgrStpCd { get; set; }

        [DataMember(Name = "isale_hscp_type_cd")]
        public string IsaleHscpTypeCd { get; set; }

        [DataMember(Name = "isale_shape_cd")]
        public string IsaleShapeCd { get; set; }

        [DataMember(Name = "hscp_nm")]
        public string HscpNm { get; set; }

        [DataMember(Name = "city_nm")]
        public string CityNm { get; set; }

        [DataMember(Name = "dvsn_nm")]
        public string DvsnNm { get; set; }
        
        [DataMember(Name = "sec_nm")]
        public string SecNm { get; set; }

        [DataMember(Name = "dtl_addr")]
        public string DtlAddr { get; set; }

        [DataMember(Name = "min_isale_prc")]
        public int MinIsalePrc { get; set; }

        [DataMember(Name = "max_isale_prc")]
        public int MaxIsalePrc { get; set; }
        
        [DataMember(Name = "min_spc")]
        public int MinSpc { get; set; }

        [DataMember(Name = "max_spc")]
        public int MaxSpc { get; set; }

        [DataMember(Name = "tot_hseh_cnt")]
        public int TotHsehCnt { get; set; }

        [DataMember(Name = "gen_hseh_cnt")]
        public int GenHsehCnt { get; set; }

        [DataMember(Name = "lease_hseh_cnt")]
        public int LeaseHsehCnt { get; set; }

        [DataMember(Name = "ast_hseh_cnt")]
        public int AstHsehCnt { get; set; }

        [DataMember(Name = "isale_hseh_cnt")]
        public int IsaleHsehCnt { get; set; }

        [DataMember(Name = "isale_ymd")]
        public string IsaleYmd { get; set; }

        [DataMember(Name = "isale_ymd_info")]
        public string IsaleYmdInfo { get; set; }

        [DataMember(Name = "rep_img_url")]
        public string RepImgUrl { get; set; }

        [DataMember(Name = "rnum")]
        public int Rnum { get; set; }

        [DataMember(Name = "ss1")]
        public string Ss1 { get; set; }

        [DataMember(Name = "sx1")]
        public string Sx1 { get; set; }

        [DataMember(Name = "ss3")]
        public string Ss3 { get; set; }

        [DataMember(Name = "sx3")]
        public string Sx3 { get; set; }

        [DataMember(Name = "ss4")]
        public string Ss4 { get; set; }

        [DataMember(Name = "sx4")]
        public string Sx4 { get; set; }

        [DataMember(Name = "ss5")]
        public string Ss5 { get; set; }

        [DataMember(Name = "sx5")]
        public string Sx5 { get; set; }

        [DataMember(Name = "subway_info")]
        public string SubwayInfo { get; set; }

        [DataMember(Name = "cortar_no")]
        public string CortarNo { get; set; }

        [DataMember(Name = "dtl_prgr_stp_cd")]
        public string DtlPrgrStpCd { get; set; }

        [DataMember(Name = "regionName")]
        public string RegionName { get; set; }

        [DataMember(Name = "loc_info")]
        public string LocInfo { get; set; }

        [DataMember(Name = "size_desc")]
        public string SizeDesc { get; set; }


    }
}
