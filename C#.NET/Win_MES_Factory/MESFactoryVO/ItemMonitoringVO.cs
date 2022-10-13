namespace MESFactoryVO
{
    public class ItemMonitoringVO
    {
        public string itemID { get; set; }        // 품목 아이디
        public string itemNAME { get; set; }      // 품목 이름
        public string ordID { get; set; }         // 작업 지시 아이디
        public string ordNAME { get; set; }       // 작업 지시 이름
        public string ordAMT { get; set; }        // 작업 지시 수량
        public string faultID { get; set; }       // 불량 아이디
        public string faulttypeID { get; set; }   // 불량 유형
        public string faulttypeNAME { get; set; } // 불량 유형 이름
    }
}