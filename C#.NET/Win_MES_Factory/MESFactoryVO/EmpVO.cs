using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryVO
{
    public class EmpVO
    {
        public string EmpID { get; set; } //직원 아이디(PK)
        public string EmpPW { get; set; }// 비밀번호
        public string EmpRFID { get; set; } //직원 RFID
        public string EmpNAME { get; set; } //직원 이름
        public string FacID { get; set; } //직원 소속 공장 FK
        public string FacName { get; set; }
        public string RankID { get; set; } //직원 권한 쿼한 테이블과 FK
        public string RankName { get; set; }
        //직원 정보 테이블 추가내용
        public string EmpUSE { get; set; }  //직원 사용여부
        public DateTime FirstTIME { get; set; } //최초등록시간
        public string FirstUSER { get; set; } //최초등록사원
        public DateTime LastTIME { get; set; } //최종등록시간
        public string LastUSER { get; set; } //최종등록사원
        public string EmpADD { get; set; } //비고사항

    }
}
