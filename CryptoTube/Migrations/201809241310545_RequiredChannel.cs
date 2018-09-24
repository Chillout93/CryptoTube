namespace CryptoTube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredChannel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Channel_Name", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "Channel_Name" });
            AlterColumn("dbo.Videos", "Channel_Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Videos", "Channel_Name");
            AddForeignKey("dbo.Videos", "Channel_Name", "dbo.Channels", "Name", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Channel_Name", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "Channel_Name" });
            AlterColumn("dbo.Videos", "Channel_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Videos", "Channel_Name");
            AddForeignKey("dbo.Videos", "Channel_Name", "dbo.Channels", "Name");
        }
    }
}
