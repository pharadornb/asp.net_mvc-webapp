namespace asp.net_mvc_webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateSQL : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1999-01-01' AS DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = CAST('1999-01-16' AS DATETIME) WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate = CAST('2005-01-02' AS DATETIME) WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
