using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Context
{
    public class IntimeVisitorContext : DbContext
    {
        public IntimeVisitorContext(): base("IntimeVisitorContext")
        {
            //this.Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer<IntimeVisitorContext>(new CreateDatabaseIfNotExists<IntimeVisitorContext>());
        }
        public DbSet<Activation> Activations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BasicSetting> BasicSettings { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LocalizationStrings> LocalizationStrings { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }

        public DbSet<Notes> Notes { get; set; }
        public DbSet<NotificationSend> NotificationSends { get; set; }
        public DbSet<NotificationMessages> NotificationMessages { get; set; }
        public DbSet<NotificationTypeArchive> NotificationTypeArchives { get; set; }
        public DbSet<Permision> Permisions { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<UserRoles> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitDetail> VisitDetails { get; set; }
        public DbSet<VisitPoint> VisitPoints { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowSteps> WorkflowSteps { get; set; }
        public DbSet<ClarificationText> ClarificationTexts { get; set; }
        public DbSet<KvkkText> kvkkTexts { get; set; }
       
        public class IntimeVisitorContextInitializer : CreateDatabaseIfNotExists<IntimeVisitorContext>
        {
            protected override void Seed(IntimeVisitorContext context)
            {
                base.Seed(context);
            }
        }
    }
}
