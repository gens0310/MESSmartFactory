namespace MESFactoryVO
{
    public class LinMonitoringVO
    {
        public string linID { get; set; }         // 라인 아이디
        public string linNAME { get; set; }       // 라인 이름
        public string linNUM { get; set; }        // 라인 순번
        public string linUSE { get; set; }        // 라인 상태
        public string linADD { get; set; }        // 라인 비고
        public string itemNUM { get; set; }       // 제품 순번
        public string itemNAME { get; set; }      // 제품 이름
        public string empID { get; set; }         // 직원 아이디
        public string empNUM { get; set; }        // 직원 순번
        public string empNAME { get; set; }       // 직원 이름
        public string nonopID { get; set; }       // 비가동 아이디
        public string nonoptypeID { get; set; }   // 비가동 유형 아이디
        public string nonoptypeNAME { get; set; } // 비가동 유형 이름
        public string nonopTIME { get; set; }     // 비가동 시간 계산 적용
    }
}