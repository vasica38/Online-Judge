namespace Judge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        MemoryLimitKb = c.Int(nullable: false),
                        TymeLimitMs = c.Int(nullable: false),
                        In = c.String(nullable: false),
                        Out = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProblemEntities", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProblemEntities", new[] { "ApplicationUserId" });
            DropTable("dbo.ProblemEntities");
        }
    }
}
