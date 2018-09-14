﻿using IMS.Service.Entity;
using System.Data.Entity.ModelConfiguration;

namespace IMS.Service.Config
{
    class UserConfig : EntityTypeConfiguration<UserEntity>
    {
        public UserConfig()
        {
            ToTable("tb_users");
            Property(p => p.Mobile).HasMaxLength(50).IsRequired();
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Code).HasMaxLength(50);
            Property(p => p.TrueName).HasMaxLength(50);
            Property(p => p.NickName).HasMaxLength(50);
            Property(p => p.Description).HasMaxLength(100);
            Property(p => p.HeadPic).HasMaxLength(256);
            Property(p => p.Salt).HasMaxLength(30);
            Property(p => p.Password).HasMaxLength(50);
            Property(p => p.TradePassword).HasMaxLength(50);
            Property(p => p.WechatPayCode).HasMaxLength(250);
            Property(p => p.AliPayCode).HasMaxLength(250);
            Property(p => p.AccountHolder).HasMaxLength(50);
            Property(p => p.BankName).HasMaxLength(50);
            Property(p => p.BankAccount).HasMaxLength(250);
            //HasRequired(p => p.Level).WithMany().HasForeignKey(p => p.LevelId).WillCascadeOnDelete(false);
        }
    }
}
