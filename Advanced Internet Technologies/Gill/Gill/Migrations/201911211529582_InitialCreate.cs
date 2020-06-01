namespace Gill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airline",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Origin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        DestPlace = c.String(),
                        FlightDate = c.DateTime(nullable: false),
                        Airline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airline", t => t.Airline_Id)
                .Index(t => t.Airline_Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LName = c.String(),
                        FName = c.String(),
                        EnrolmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LName = c.String(),
                        FName = c.String(),
                        EmployedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientFlight",
                c => new
                    {
                        Client_Id = c.Int(nullable: false),
                        Flight_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Flight_Id })
                .ForeignKey("dbo.Client", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Flight", t => t.Flight_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Flight_Id);
            
            CreateTable(
                "dbo.StaffFlight",
                c => new
                    {
                        Staff_Id = c.Int(nullable: false),
                        Flight_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Staff_Id, t.Flight_Id })
                .ForeignKey("dbo.Staff", t => t.Staff_Id, cascadeDelete: true)
                .ForeignKey("dbo.Flight", t => t.Flight_Id, cascadeDelete: true)
                .Index(t => t.Staff_Id)
                .Index(t => t.Flight_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flight", "Airline_Id", "dbo.Airline");
            DropForeignKey("dbo.StaffFlight", "Flight_Id", "dbo.Flight");
            DropForeignKey("dbo.StaffFlight", "Staff_Id", "dbo.Staff");
            DropForeignKey("dbo.ClientFlight", "Flight_Id", "dbo.Flight");
            DropForeignKey("dbo.ClientFlight", "Client_Id", "dbo.Client");
            DropIndex("dbo.StaffFlight", new[] { "Flight_Id" });
            DropIndex("dbo.StaffFlight", new[] { "Staff_Id" });
            DropIndex("dbo.ClientFlight", new[] { "Flight_Id" });
            DropIndex("dbo.ClientFlight", new[] { "Client_Id" });
            DropIndex("dbo.Flight", new[] { "Airline_Id" });
            DropTable("dbo.StaffFlight");
            DropTable("dbo.ClientFlight");
            DropTable("dbo.Staff");
            DropTable("dbo.Client");
            DropTable("dbo.Flight");
            DropTable("dbo.Airline");
        }
    }
}
