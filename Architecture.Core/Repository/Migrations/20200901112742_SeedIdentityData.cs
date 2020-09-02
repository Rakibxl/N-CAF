﻿using Architecture.Core.Common.Constants;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Architecture.Core.Repository.Migrations
{
    public partial class SeedIdentityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var hashPassword = hasher.HashPassword(null, "12345");

            // Seed Role 
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id,Name,NormalizedName,Status,IsActive,IsDeleted,Created) VALUES ('" + Guid.NewGuid() + "','" +
                ConstantsValue.UserRoleName.SuperAdmin + "','" + ConstantsValue.UserRoleName.SuperAdmin.ToUpper() + "','" + (int)EnumApplicationRoleStatus.SuperAdmin + "','true','false','" + DateTime.Now + "')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id,Name,NormalizedName,Status,IsActive,IsDeleted,Created) VALUES ('" + Guid.NewGuid() + "','" +
                ConstantsValue.UserRoleName.Admin + "','" + ConstantsValue.UserRoleName.Admin.ToUpper() + "','" + (int)EnumApplicationRoleStatus.GeneralUser + "','true','false','" + DateTime.Now + "')");

            // Seed User
            migrationBuilder.Sql("INSERT INTO AspNetUsers (Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,PhoneNumberConfirmed,TwoFactorEnabled," +
                "LockoutEnabled,AccessFailedCount,FullName,PasswordChangedCount,Status,IsActive,IsDeleted,Created,SecurityStamp)" +
                " VALUES ('" + Guid.NewGuid() + "','admin@gmail.com','ADMIN@GMAIL.COM','admin@gmail.com','ADMIN@GMAIL.COM','false','" + hashPassword + "','false','false','false','0','Administrator','1','" +
                (int)EnumApplicationUserStatus.SuperAdmin + "','true','false','" + DateTime.Now + "','" + Guid.NewGuid() + "')");
            migrationBuilder.Sql("INSERT INTO AspNetUsers (Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,PhoneNumberConfirmed,TwoFactorEnabled," +
                "LockoutEnabled,AccessFailedCount,FullName,PasswordChangedCount,Status,IsActive,IsDeleted,Created,SecurityStamp)" +
                " VALUES ('" + Guid.NewGuid() + "','dev@gmail.com','DEV@GMAIL.COM','dev@gmail.com','DEV@GMAIL.COM','false','" + hashPassword + "','false','false','false','0','Development','1','" +
                (int)EnumApplicationUserStatus.SuperAdmin + "','true','false','" + DateTime.Now + "','" + Guid.NewGuid() + "')");

            // Seed UserRole
            migrationBuilder.Sql("INSERT INTO AspNetUserRoles (UserId,RoleId) VALUES ((SELECT Id FROM AspNetUsers WHERE UserName = 'admin@gmail.com')," +
                "(SELECT Id FROM AspNetRoles WHERE Name = '" + ConstantsValue.UserRoleName.SuperAdmin + "'))");
            migrationBuilder.Sql("INSERT INTO AspNetUserRoles (UserId,RoleId) VALUES ((SELECT Id FROM AspNetUsers WHERE UserName = 'dev@gmail.com')," +
                "(SELECT Id FROM AspNetRoles WHERE Name = '" + ConstantsValue.UserRoleName.SuperAdmin + "'))");

            // Seed Role Claim
            migrationBuilder.Sql("INSERT INTO AspNetRoleClaims (RoleId,ClaimType,ClaimValue) VALUES (" +
                "(SELECT Id FROM AspNetRoles WHERE Name = '" + ConstantsValue.UserRoleName.SuperAdmin + "')," +
                "'" + ConstantsValue.RolePermission.Type + "','" + ConstantsValue.RolePermission.Value + "')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoleClaims WHERE ClaimType = '" + ConstantsValue.RolePermission.Type + "'" +
                " AND ClaimValue = '" + ConstantsValue.RolePermission.Value + "'");
            migrationBuilder.Sql("DELETE FROM AspNetUsers WHERE UserName IN ('admin@gmail.com','dev@gmail.com')");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name IN ('" +
                ConstantsValue.UserRoleName.SuperAdmin + "','" +
                ConstantsValue.UserRoleName.Admin + "')");
        }
    }
}
