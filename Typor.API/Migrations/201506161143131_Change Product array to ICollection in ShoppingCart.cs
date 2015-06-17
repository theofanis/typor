namespace Typor.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductarraytoICollectioninShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ShoppingCart_Id", c => c.Int());
            CreateIndex("dbo.Products", "ShoppingCart_Id");
            AddForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Products", new[] { "ShoppingCart_Id" });
            DropColumn("dbo.Products", "ShoppingCart_Id");
        }
    }
}
