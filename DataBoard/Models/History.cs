//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBoard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int SubLIneId { get; set; }
        public int StopTypeId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int UserInfoId { get; set; }
        public System.DateTime InsertDate { get; set; }
    
        public virtual Line Line { get; set; }
        public virtual StopType StopType { get; set; }
        public virtual SubLine SubLine { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
