namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            RenameColumn(table: "dbo.Post", name: "Author_Id", newName: "UserId");
            RenameIndex(table: "dbo.Post", name: "IX_Author_Id", newName: "IX_UserId");
            DropPrimaryKey("dbo.Post");
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ReplyId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_Id = c.Guid(),
                        CommentPost_Id = c.Int(),
                        Name_Id = c.Guid(),
                        ReplyComment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.User", t => t.Author_Id)
                .ForeignKey("dbo.Post", t => t.CommentPost_Id)
                .ForeignKey("dbo.User", t => t.Name_Id)
                .ForeignKey("dbo.Comment", t => t.ReplyComment_CommentId)
                .Index(t => t.Author_Id)
                .Index(t => t.CommentPost_Id)
                .Index(t => t.Name_Id)
                .Index(t => t.ReplyComment_CommentId);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        LikedPost_Id = c.Int(),
                        Liker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Post", t => t.LikedPost_Id)
                .ForeignKey("dbo.User", t => t.Liker_Id)
                .Index(t => t.LikedPost_Id)
                .Index(t => t.Liker_Id);
            
            AddColumn("dbo.Post", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Post", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false, maxLength: 240));
            AddPrimaryKey("dbo.Post", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "Liker_Id", "dbo.User");
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Name_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Author_Id", "dbo.User");
            DropIndex("dbo.Like", new[] { "Liker_Id" });
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            DropIndex("dbo.Comment", new[] { "ReplyComment_CommentId" });
            DropIndex("dbo.Comment", new[] { "Name_Id" });
            DropIndex("dbo.Comment", new[] { "CommentPost_Id" });
            DropIndex("dbo.Comment", new[] { "Author_Id" });
            DropPrimaryKey("dbo.Post");
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Post", "CreatedUtc");
            DropTable("dbo.Like");
            DropTable("dbo.Comment");
            AddPrimaryKey("dbo.Post", "Id");
            RenameIndex(table: "dbo.Post", name: "IX_UserId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Post", name: "UserId", newName: "Author_Id");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post", "Id");
        }
    }
}
