namespace LinksState.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        BaseUrl = c.String(),
                        NestingLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LinkStates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        StatusCode = c.Int(nullable: false),
                        CheckRequest_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CheckRequests", t => t.CheckRequest_ID)
                .Index(t => t.CheckRequest_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinkStates", "CheckRequest_ID", "dbo.CheckRequests");
            DropIndex("dbo.LinkStates", new[] { "CheckRequest_ID" });
            DropTable("dbo.LinkStates");
            DropTable("dbo.CheckRequests");
        }
    }
}
