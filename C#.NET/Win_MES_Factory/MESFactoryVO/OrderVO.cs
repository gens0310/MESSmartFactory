using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryVO
{
    public class OrderVO
    {
        public string OrdID { get; set; } // 작업지시 아이디
        public string EmpID { get; set; } // 직원 아이디
        public string EmpNAME { get; set; } // 직원 이름
        public string ItemID { get; set; } // 품목 아이디
        public string ItemNAME { get; set; } // 품목 이름
        public string ProID { get; set; } // 공정 아이디
        public string ProNAME { get; set; } // 공정 이름
        public string OrdNAME { get; set; } // 작업 지시 이름
        public DateTime OrdDATE { get; set; } // 작업 지시 일자
        public long OrdAMT { get; set; } // 작업 지시 수량
        public int OrdCPLT { get; set; } // 작업 완료 수량
        public int OrdFLT { get; set; } // 작업 불량 수량
        public DateTime WorkDATE { get; set; } // 작업 일자
        public DateTime StartTIME { get; set; } // 작업 시작 시간
        public DateTime EndTIME { get; set; } // 작업 종료 시간
        public string OrdSTATUS { get; set; } // 작업 지시 상태
        public DateTime FirstTIME { get; set; } //최초등록시간
        public string FirstUSER { get; set; } //최초등록사원
        public DateTime LastTIME { get; set; } //최종등록시간
        public string LastUSER { get; set; } //최종등록사원
        public string OrdADD { get; set; } // 작업 지시 비고
        public string LinID { get; set; } // 라인 아이디
        public string LinNAME { get; set; } // 라인 이름
        public string FacID { get; set; } // 공장 아이디
        public string FacNAME { get; set; } // 공장 이름

        public int ConID { get; set; } // 발주받은 번호
        public DateTime ConDATE { get; set; } // 아이템아이디랑 외래키로 묶였음
        public string ConUSE { get; set; } // 공장 이름
        public string ConADD { get; set; } // 공장 이름

        public string CommonNAME { get; set; } // 
        public long SumOrdCPLT { get; set; } // 작업 완료 수량
        public long SumOrdFLT { get; set; } // 작업 완료 수량

    }
}
