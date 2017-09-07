﻿using CoTech.Bi.Loader;
using CoTech.Bi.Modules.Wer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoTech.Bi.Modules.Wer
{
    public class WerModule: IModule
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //throw new System.NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<WeekRepository>();
        }

        public void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekEntity>().ToTable("Wer_Weeks");

            modelBuilder.Entity<ReportEntity>().ToTable("Wer_Reports")
                .HasOne(r => r.Company)
                .WithMany(c => null).HasForeignKey(r => r.CompanyId)
                .HasConstraintName("FK_Reports_Companies");
            
            modelBuilder.Entity<ReportEntity>().ToTable("Wer_Reports")
                .HasOne(r => r.Week)
                .WithMany(w => null).HasForeignKey(r => r.WeekId)
                .HasConstraintName("FK_Reports_Weeks");
        }
    }
}