﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BoardDBEntities : DbContext
    {
        public BoardDBEntities()
            : base("name=BoardDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Line> Line { get; set; }
        public virtual DbSet<StopType> StopType { get; set; }
        public virtual DbSet<SubLine> SubLine { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
