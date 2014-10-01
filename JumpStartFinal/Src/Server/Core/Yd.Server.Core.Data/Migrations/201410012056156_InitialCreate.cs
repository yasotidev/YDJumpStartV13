namespace Yd.Server.Core.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressTypeId = c.Int(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.AddressType", t => t.AddressTypeId)
                .Index(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.AddressType",
                c => new
                    {
                        AddressTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.Calendar",
                c => new
                    {
                        CalendarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarId);
            
            CreateTable(
                "dbo.EmployeePicture",
                c => new
                    {
                        EmployeePictureId = c.Int(nullable: false, identity: true),
                        PictureType = c.Int(nullable: false),
                        Content = c.Binary(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeePictureId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        HireDate = c.DateTime(nullable: false),
                        JobTitleId = c.Int(),
                        TeamId = c.Int(),
                        AddressId = c.Int(),
                        Team_TeamId = c.Int(),
                        Team_TeamId1 = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.JobTitle", t => t.JobTitleId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Team", t => t.Team_TeamId)
                .ForeignKey("dbo.Team", t => t.Team_TeamId1)
                .Index(t => t.PersonId)
                .Index(t => t.JobTitleId)
                .Index(t => t.AddressId)
                .Index(t => t.Team_TeamId)
                .Index(t => t.Team_TeamId1);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.JobTitle",
                c => new
                    {
                        JobTitleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.JobTitleId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(),
                        Manager_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Employee", t => t.Manager_EmployeeId)
                .Index(t => t.Manager_EmployeeId);
            
            CreateTable(
                "dbo.Vaccation",
                c => new
                    {
                        VaccationId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        VaccationStatus = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VaccationId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.HolidayCalendar",
                c => new
                    {
                        HolidayCalendarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Day = c.DateTime(nullable: false),
                        CalendarId = c.Int(),
                    })
                .PrimaryKey(t => t.HolidayCalendarId)
                .ForeignKey("dbo.Calendar", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.IssuingAuthorityKey",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HolidayCalendar", "CalendarId", "dbo.Calendar");
            DropForeignKey("dbo.Vaccation", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Team_TeamId1", "dbo.Team");
            DropForeignKey("dbo.Team", "Manager_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.Employee", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Employee", "JobTitleId", "dbo.JobTitle");
            DropForeignKey("dbo.Expense", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeePicture", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Address", "AddressTypeId", "dbo.AddressType");
            DropIndex("dbo.HolidayCalendar", new[] { "CalendarId" });
            DropIndex("dbo.Vaccation", new[] { "EmployeeId" });
            DropIndex("dbo.Team", new[] { "Manager_EmployeeId" });
            DropIndex("dbo.Expense", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "Team_TeamId1" });
            DropIndex("dbo.Employee", new[] { "Team_TeamId" });
            DropIndex("dbo.Employee", new[] { "AddressId" });
            DropIndex("dbo.Employee", new[] { "JobTitleId" });
            DropIndex("dbo.Employee", new[] { "PersonId" });
            DropIndex("dbo.EmployeePicture", new[] { "EmployeeId" });
            DropIndex("dbo.Address", new[] { "AddressTypeId" });
            DropTable("dbo.Tenant");
            DropTable("dbo.IssuingAuthorityKey");
            DropTable("dbo.HolidayCalendar");
            DropTable("dbo.Vaccation");
            DropTable("dbo.Team");
            DropTable("dbo.Person");
            DropTable("dbo.JobTitle");
            DropTable("dbo.Expense");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeePicture");
            DropTable("dbo.Calendar");
            DropTable("dbo.AddressType");
            DropTable("dbo.Address");
        }
    }
}
