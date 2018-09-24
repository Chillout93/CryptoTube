namespace CryptoTube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Video_ID", c => c.Int());
            CreateIndex("dbo.Videos", "Video_ID");
            AddForeignKey("dbo.Videos", "Video_ID", "dbo.Videos", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Video_ID", "dbo.Videos");
            DropIndex("dbo.Videos", new[] { "Video_ID" });
            DropColumn("dbo.Videos", "Video_ID");
        }
    }
}
