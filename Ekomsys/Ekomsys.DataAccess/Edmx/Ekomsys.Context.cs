﻿

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Ekomsys.DataAccess.Edmx
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DevSamplesEntities : DbContext
{
    public DevSamplesEntities()
        : base("name=DevSamplesEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<tb_News> tb_News { get; set; }

}

}

