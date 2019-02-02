namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Words", newName: "tblWord");
            CreateTable(
                "dbo.tblConjugation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstPersonSingular = c.String(nullable: false, maxLength: 30),
                        SecondPersonSingular = c.String(nullable: false, maxLength: 30),
                        ThirdPersonSingular = c.String(nullable: false, maxLength: 30),
                        FirstPersonPlural = c.String(nullable: false, maxLength: 30),
                        SecondPersonPlural = c.String(nullable: false, maxLength: 30),
                        ThirdPersonPlural = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tblWord", "Conjugation_Id", c => c.Int());
            CreateIndex("dbo.tblWord", "Conjugation_Id");
            AddForeignKey("dbo.tblWord", "Conjugation_Id", "dbo.tblConjugation", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblWord", "Conjugation_Id", "dbo.tblConjugation");
            DropIndex("dbo.tblWord", new[] { "Conjugation_Id" });
            DropColumn("dbo.tblWord", "Conjugation_Id");
            DropTable("dbo.tblConjugation");
            RenameTable(name: "dbo.tblWord", newName: "Words");
        }
    }
}
