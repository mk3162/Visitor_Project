namespace IntimeVisitor.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(),
                        ExpireDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NotifiactionTypeId = c.Guid(),
                        NotifiactionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        NotificationTypeArchive_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificationTypeArchives", t => t.NotificationTypeArchive_Id)
                .Index(t => t.NotificationTypeArchive_Id);
            
            CreateTable(
                "dbo.NotificationTypeArchives",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NotificationTypeName = c.String(nullable: false, maxLength: 30),
                        ServerDescription = c.String(nullable: false, maxLength: 30),
                        ServerInfo = c.String(maxLength: 30),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationSends",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        WorkflowId = c.Guid(nullable: false),
                        IsSend = c.Boolean(nullable: false),
                        SendDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NotificationTypeId = c.Guid(),
                        NotificationMessageId = c.Guid(),
                        ServerIp = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        NotificationMessages_Id = c.Guid(),
                        NotificationTypeArchive_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificationMessages", t => t.NotificationMessages_Id)
                .ForeignKey("dbo.NotificationTypeArchives", t => t.NotificationTypeArchive_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Workflows", t => t.WorkflowId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkflowId)
                .Index(t => t.NotificationMessages_Id)
                .Index(t => t.NotificationTypeArchive_Id);
            
            CreateTable(
                "dbo.NotificationMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MessageName = c.String(nullable: false, maxLength: 50),
                        MessageDetails = c.String(nullable: false, maxLength: 500),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegisterNo = c.String(maxLength: 30),
                        TCNo = c.String(nullable: false, maxLength: 11),
                        Name = c.String(nullable: false, maxLength: 30),
                        SurName = c.String(nullable: false, maxLength: 30),
                        FatherName = c.String(maxLength: 30),
                        MotherName = c.String(maxLength: 30),
                        Gender = c.Boolean(nullable: false),
                        BirthPlace = c.String(),
                        BirthDate = c.String(),
                        Address = c.String(),
                        EPosta = c.String(),
                        EPostaKep = c.String(),
                        Phone = c.String(),
                        Password = c.String(maxLength: 30),
                        UserTypeId = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 30),
                        Status = c.Boolean(nullable: false),
                        RoleId = c.Guid(),
                        PlateNo = c.String(maxLength: 30),
                        TitleId = c.Guid(),
                        CompanyId = c.Guid(),
                        DepartmentId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        MediesIds = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        Media_Id = c.Guid(),
                        Roles_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .ForeignKey("dbo.UserRoles", t => t.Roles_Id)
                .ForeignKey("dbo.Titles", t => t.TitleId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId)
                .Index(t => t.TitleId)
                .Index(t => t.CompanyId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Media_Id)
                .Index(t => t.Roles_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        CompanyTypeId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        TaxAdministration = c.String(nullable: false, maxLength: 100),
                        TaxNo = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Fax = c.String(nullable: false, maxLength: 11),
                        AddressId = c.Guid(nullable: false),
                        EMail = c.String(nullable: false, maxLength: 100),
                        EMailKEP = c.String(nullable: false, maxLength: 100),
                        CompanyImageFile = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyTypeId, cascadeDelete: true)
                .Index(t => t.CompanyTypeId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Country = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        District = c.String(nullable: false, maxLength: 30),
                        PostalCode = c.String(nullable: false, maxLength: 15),
                        Openaddress = c.String(),
                        AdressLocation = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyId = c.Guid(),
                        BranchTypeId = c.Guid(nullable: false),
                        BranchName = c.String(nullable: false, maxLength: 30),
                        AddressId = c.Guid(nullable: false),
                        BranchPhoneNumber = c.String(nullable: false, maxLength: 11),
                        BranchEMail = c.String(nullable: false, maxLength: 100),
                        Location = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.BranchTypes", t => t.BranchTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.BranchTypeId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.BranchTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BranchTypeName = c.String(nullable: false, maxLength: 30),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 30),
                        BranchId = c.Guid(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.VisitPoints",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VisitPointName = c.String(nullable: false, maxLength: 30),
                        DepartmantId = c.Guid(nullable: false),
                        Color = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmantId, cascadeDelete: true)
                .Index(t => t.DepartmantId);
            
            CreateTable(
                "dbo.VisitDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StartTime = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false),
                        VisitId = c.Guid(),
                        VisitPointId = c.Guid(nullable: false),
                        UserId = c.Guid(),
                        LastVisitDetailId = c.Guid(),
                        Visit_UserId = c.Guid(),
                        VisitStatus = c.String(),
                        AllDay = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .ForeignKey("dbo.VisitPoints", t => t.VisitPointId, cascadeDelete: true)
                .Index(t => t.VisitId)
                .Index(t => t.VisitPointId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoteTitle = c.String(nullable: false, maxLength: 15),
                        NoteDetails = c.String(nullable: false, maxLength: 300),
                        VisitDetailId = c.Guid(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisitDetails", t => t.VisitDetailId)
                .Index(t => t.VisitDetailId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QRCodeId = c.Guid(),
                        VisitNotes = c.String(nullable: false),
                        UserId = c.Guid(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QRCodes", t => t.QRCodeId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.QRCodeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QRCodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Detail = c.String(maxLength: 150),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StopDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClarificationTexts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        CompanyId = c.Guid(),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyTypeName = c.String(nullable: false, maxLength: 30),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KvkkTexts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        CompanyId = c.Guid(),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilePath = c.String(nullable: false),
                        MediaTypeId = c.Guid(nullable: false),
                        Extension = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MediaTypes", t => t.MediaTypeId, cascadeDelete: true)
                .Index(t => t.MediaTypeId);
            
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MediaTypeName = c.String(nullable: false, maxLength: 30),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RolesName = c.String(nullable: false, maxLength: 30),
                        UsersIds = c.String(),
                        Description = c.String(nullable: false, maxLength: 150),
                        PermisionsIds = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TitleName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserTypeName = c.String(nullable: false, maxLength: 30),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workflows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WorkflowStepId = c.Guid(),
                        WorkflowName = c.String(),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        WorkflowSteps_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkflowSteps", t => t.WorkflowSteps_Id)
                .Index(t => t.WorkflowSteps_Id);
            
            CreateTable(
                "dbo.WorkflowSteps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WorkflowStepCode = c.String(nullable: false, maxLength: 30),
                        StepNumber = c.String(nullable: false, maxLength: 30),
                        StepDetails = c.String(nullable: false, maxLength: 30),
                        MessageId = c.Guid(nullable: false),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BasicSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BasicSettingName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalizationStrings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WordKey = c.String(maxLength: 30),
                        WordValue = c.String(maxLength: 30),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permisions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SytemSettingName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserSettingName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflows", "WorkflowSteps_Id", "dbo.WorkflowSteps");
            DropForeignKey("dbo.NotificationSends", "WorkflowId", "dbo.Workflows");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Users", "Roles_Id", "dbo.UserRoles");
            DropForeignKey("dbo.NotificationSends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Media", "MediaTypeId", "dbo.MediaTypes");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.KvkkTexts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyTypeId", "dbo.CompanyTypes");
            DropForeignKey("dbo.ClarificationTexts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.VisitPoints", "DepartmantId", "dbo.Departments");
            DropForeignKey("dbo.VisitDetails", "VisitPointId", "dbo.VisitPoints");
            DropForeignKey("dbo.VisitDetails", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Visits", "UserId", "dbo.Users");
            DropForeignKey("dbo.Visits", "QRCodeId", "dbo.QRCodes");
            DropForeignKey("dbo.VisitDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notes", "VisitDetailId", "dbo.VisitDetails");
            DropForeignKey("dbo.Departments", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Branches", "BranchTypeId", "dbo.BranchTypes");
            DropForeignKey("dbo.Branches", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.NotificationSends", "NotificationTypeArchive_Id", "dbo.NotificationTypeArchives");
            DropForeignKey("dbo.NotificationSends", "NotificationMessages_Id", "dbo.NotificationMessages");
            DropForeignKey("dbo.Activations", "NotificationTypeArchive_Id", "dbo.NotificationTypeArchives");
            DropIndex("dbo.Workflows", new[] { "WorkflowSteps_Id" });
            DropIndex("dbo.Media", new[] { "MediaTypeId" });
            DropIndex("dbo.KvkkTexts", new[] { "CompanyId" });
            DropIndex("dbo.ClarificationTexts", new[] { "CompanyId" });
            DropIndex("dbo.Visits", new[] { "UserId" });
            DropIndex("dbo.Visits", new[] { "QRCodeId" });
            DropIndex("dbo.Notes", new[] { "VisitDetailId" });
            DropIndex("dbo.VisitDetails", new[] { "UserId" });
            DropIndex("dbo.VisitDetails", new[] { "VisitPointId" });
            DropIndex("dbo.VisitDetails", new[] { "VisitId" });
            DropIndex("dbo.VisitPoints", new[] { "DepartmantId" });
            DropIndex("dbo.Departments", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "AddressId" });
            DropIndex("dbo.Branches", new[] { "BranchTypeId" });
            DropIndex("dbo.Branches", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "AddressId" });
            DropIndex("dbo.Companies", new[] { "CompanyTypeId" });
            DropIndex("dbo.Users", new[] { "Roles_Id" });
            DropIndex("dbo.Users", new[] { "Media_Id" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "TitleId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.NotificationSends", new[] { "NotificationTypeArchive_Id" });
            DropIndex("dbo.NotificationSends", new[] { "NotificationMessages_Id" });
            DropIndex("dbo.NotificationSends", new[] { "WorkflowId" });
            DropIndex("dbo.NotificationSends", new[] { "UserId" });
            DropIndex("dbo.Activations", new[] { "NotificationTypeArchive_Id" });
            DropTable("dbo.UserSettings");
            DropTable("dbo.SystemSettings");
            DropTable("dbo.Settings");
            DropTable("dbo.Permisions");
            DropTable("dbo.LocalizationStrings");
            DropTable("dbo.BasicSettings");
            DropTable("dbo.WorkflowSteps");
            DropTable("dbo.Workflows");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Titles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.MediaTypes");
            DropTable("dbo.Media");
            DropTable("dbo.KvkkTexts");
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.ClarificationTexts");
            DropTable("dbo.QRCodes");
            DropTable("dbo.Visits");
            DropTable("dbo.Notes");
            DropTable("dbo.VisitDetails");
            DropTable("dbo.VisitPoints");
            DropTable("dbo.Departments");
            DropTable("dbo.BranchTypes");
            DropTable("dbo.Branches");
            DropTable("dbo.Addresses");
            DropTable("dbo.Companies");
            DropTable("dbo.Users");
            DropTable("dbo.NotificationMessages");
            DropTable("dbo.NotificationSends");
            DropTable("dbo.NotificationTypeArchives");
            DropTable("dbo.Activations");
        }
    }
}
