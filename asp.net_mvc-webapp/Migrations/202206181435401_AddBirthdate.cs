﻿namespace asp.net_mvc_webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 255));
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
