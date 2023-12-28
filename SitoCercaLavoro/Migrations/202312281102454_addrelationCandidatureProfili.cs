﻿namespace SitoCercaLavoro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationCandidatureProfili : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidature", "idProfili", c => c.Int(nullable: false));
            AddColumn("dbo.Profili", "Candidature_IdCandidatura", c => c.Int());
            CreateIndex("dbo.Profili", "Candidature_IdCandidatura");
            AddForeignKey("dbo.Profili", "Candidature_IdCandidatura", "dbo.Candidature", "IdCandidatura");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profili", "Candidature_IdCandidatura", "dbo.Candidature");
            DropIndex("dbo.Profili", new[] { "Candidature_IdCandidatura" });
            DropColumn("dbo.Profili", "Candidature_IdCandidatura");
            DropColumn("dbo.Candidature", "idProfili");
        }
    }
}
