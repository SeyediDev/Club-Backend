////using System;
////using System.Collections.Generic;
////using Microsoft.EntityFrameworkCore;

////namespace Club.Migration.Models;

////public partial class ClubDevContext : DbContext
////{
////    public ClubDevContext()
////    {
////    }

////    public ClubDevContext(DbContextOptions<ClubDevContext> options)
////        : base(options)
////    {
////    }

////    public virtual DbSet<Activity> Activities { get; set; }

////    public virtual DbSet<ActivityService> ActivityServices { get; set; }

////    public virtual DbSet<Answer> Answers { get; set; }

////    public virtual DbSet<Article> Articles { get; set; }

////    public virtual DbSet<Available> Availables { get; set; }

////    public virtual DbSet<Bank> Banks { get; set; }

////    public virtual DbSet<Chat> Chats { get; set; }

////    public virtual DbSet<ChatDetail> ChatDetails { get; set; }

////    public virtual DbSet<Commission> Commissions { get; set; }

////    public virtual DbSet<CultureTerm> CultureTerms { get; set; }

////    public virtual DbSet<Deposite> Deposites { get; set; }

////    public virtual DbSet<Device> Devices { get; set; }

////    public virtual DbSet<Document> Documents { get; set; }

////    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

////    public virtual DbSet<DocumentTypeCategory> DocumentTypeCategories { get; set; }

////    public virtual DbSet<Exam> Exams { get; set; }

////    public virtual DbSet<ExamResult> ExamResults { get; set; }

////    public virtual DbSet<ExamResultType> ExamResultTypes { get; set; }

////    public virtual DbSet<Faq> Faqs { get; set; }

////    public virtual DbSet<Field> Fields { get; set; }

////    public virtual DbSet<FieldDegree> FieldDegrees { get; set; }

////    public virtual DbSet<FieldType> FieldTypes { get; set; }

////    public virtual DbSet<FixedFee> FixedFees { get; set; }

////    public virtual DbSet<GenderType> GenderTypes { get; set; }

////    public virtual DbSet<Help> Helps { get; set; }

////    public virtual DbSet<Language> Languages { get; set; }

////    public virtual DbSet<Member> Members { get; set; }

////    public virtual DbSet<Notification> Notifications { get; set; }

////    public virtual DbSet<Payment> Payments { get; set; }

////    public virtual DbSet<Payment1> Payments1 { get; set; }

////    public virtual DbSet<PaymentTerminal> PaymentTerminals { get; set; }

////    public virtual DbSet<Plan> Plans { get; set; }

////    public virtual DbSet<PlanDetail> PlanDetails { get; set; }

////    public virtual DbSet<PrivacyAndPolicy> PrivacyAndPolicies { get; set; }

////    public virtual DbSet<Product> Products { get; set; }

////    public virtual DbSet<ProductType> ProductTypes { get; set; }

////    public virtual DbSet<Question> Questions { get; set; }

////    public virtual DbSet<Question1> Questions1 { get; set; }

////    public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }

////    public virtual DbSet<QuestionAnswer1> QuestionAnswers1 { get; set; }

////    public virtual DbSet<QuestionDetail> QuestionDetails { get; set; }

////    public virtual DbSet<Reminder> Reminders { get; set; }

////    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

////    public virtual DbSet<Settlement> Settlements { get; set; }

////    public virtual DbSet<Ticket> Tickets { get; set; }

////    public virtual DbSet<TicketDetail> TicketDetails { get; set; }

////    public virtual DbSet<TicketStatus> TicketStatuses { get; set; }

////    public virtual DbSet<TicketType> TicketTypes { get; set; }

////    public virtual DbSet<Transaction> Transactions { get; set; }

////    public virtual DbSet<Type> Types { get; set; }

////    public virtual DbSet<User> Users { get; set; }

////    public virtual DbSet<UserApp> UserApps { get; set; }

////    public virtual DbSet<UserAppDevice> UserAppDevices { get; set; }

////    public virtual DbSet<UserDoctor> UserDoctors { get; set; }

////    public virtual DbSet<UserOffice> UserOffices { get; set; }

////    public virtual DbSet<UserPlan> UserPlans { get; set; }

////    public virtual DbSet<UserType> UserTypes { get; set; }

////    public virtual DbSet<Version> Versions { get; set; }

////    public virtual DbSet<VisitLog> VisitLogs { get; set; }

////    public virtual DbSet<VisitRequest> VisitRequests { get; set; }

////    public virtual DbSet<VwFaq> VwFaqs { get; set; }

//    public virtual DbSet<VwGetDoctor> VwGetDoctors { get; set; }

//    public virtual DbSet<VwGetMemberActivity> VwGetMemberActivities { get; set; }

//    public virtual DbSet<VwGetPlan> VwGetPlans { get; set; }

////    public virtual DbSet<VwGetProductType> VwGetProductTypes { get; set; }

////    public virtual DbSet<VwGetProfile> VwGetProfiles { get; set; }

////    public virtual DbSet<VwGetReminder> VwGetReminders { get; set; }

////    public virtual DbSet<VwHelp> VwHelps { get; set; }

////    public virtual DbSet<VwPrivacyAndPolicy> VwPrivacyAndPolicies { get; set; }

////    public virtual DbSet<Wage> Wages { get; set; }

////    public virtual DbSet<Wallet> Wallets { get; set; }

////    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
////        => optionsBuilder.UseSqlServer("Data Source=194.48.198.25,15000;Initial Catalog=ClubDev;Persist Security Info=True;User ID=sa;Password=qwer@1234;TrustServerCertificate=True");

////    protected override void OnModelCreating(ModelBuilder modelBuilder)
////    {
////        modelBuilder.Entity<Activity>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_DoctorActivity");

////            entity.ToTable("Activity", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.User).WithMany(p => p.Activities)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Activity_User");
////        });

////        modelBuilder.Entity<ActivityService>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_DoctorActivityService");

////            entity.ToTable("ActivityService", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityServices)
////                .HasForeignKey(d => d.ActivityId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_ActivityService_Activity");

////            entity.HasOne(d => d.ServiceType).WithMany(p => p.ActivityServices)
////                .HasForeignKey(d => d.ServiceTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_ActivityService_ServiceType");
////        });

////        modelBuilder.Entity<Answer>(entity =>
////        {
////            entity.ToTable("Answer");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Value).HasMaxLength(300);

////            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
////                .HasForeignKey(d => d.QuestionId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Answer_Question");
////        });

////        modelBuilder.Entity<Article>(entity =>
////        {
////            entity.ToTable("Article", "App");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Link).HasMaxLength(200);
////            entity.Property(e => e.Title).HasMaxLength(200);
////        });

////        modelBuilder.Entity<Available>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_DoctoreAvailable");

////            entity.ToTable("Available", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.EndDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.StartDate).HasColumnType("datetime");
////        });

////        modelBuilder.Entity<Bank>(entity =>
////        {
////            entity.ToTable("Bank");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Chat>(entity =>
////        {
////            entity.ToTable("Chat");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.UserApp).WithMany(p => p.Chats)
////                .HasForeignKey(d => d.UserAppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Chat_UserApp");

////            entity.HasOne(d => d.UserDoctor).WithMany(p => p.Chats)
////                .HasForeignKey(d => d.UserDoctorId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Chat_UserDoctor");

////            entity.HasOne(d => d.VisitRequest).WithMany(p => p.Chats)
////                .HasForeignKey(d => d.VisitRequestId)
////                .HasConstraintName("FK_Chat_VisitRequest");
////        });

////        modelBuilder.Entity<ChatDetail>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_ChatDetails");

////            entity.ToTable("ChatDetail");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Text).HasMaxLength(300);

////            entity.HasOne(d => d.Chat).WithMany(p => p.ChatDetails)
////                .HasForeignKey(d => d.ChatId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_ChatDetail_Chat");

////            entity.HasOne(d => d.User).WithMany(p => p.ChatDetails)
////                .HasForeignKey(d => d.UserId)
////                .HasConstraintName("FK_ChatDetail_User");
////        });

////        modelBuilder.Entity<Commission>(entity =>
////        {
////            entity.ToTable("Commission", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.EndDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.StartDate).HasColumnType("datetime");

////            entity.HasOne(d => d.FieldType).WithMany(p => p.Commissions)
////                .HasForeignKey(d => d.FieldTypeId)
////                .HasConstraintName("FK_Commission_FieldType");
////        });

////        modelBuilder.Entity<CultureTerm>(entity =>
////        {
////            entity.ToTable("CultureTerm", "App");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.SubjectField)
////                .HasMaxLength(50)
////                .IsUnicode(false);
////            entity.Property(e => e.SubjectTitle).HasMaxLength(50);

////            entity.HasOne(d => d.App).WithMany(p => p.CultureTerms)
////                .HasForeignKey(d => d.AppId)
////                .HasConstraintName("FK_App_CultureTerm_App_Type");

////            entity.HasOne(d => d.Language).WithMany(p => p.CultureTerms)
////                .HasForeignKey(d => d.LanguageId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_CultureTerm_Language");
////        });

////        modelBuilder.Entity<Deposite>(entity =>
////        {
////            entity.ToTable("Deposite", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.Iban).HasMaxLength(50);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.Bank).WithMany(p => p.Deposites)
////                .HasForeignKey(d => d.BankId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_DoctorDeposite_Bank");
////        });

////        modelBuilder.Entity<Device>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKDevice");

////            entity.ToTable("Device");

////            entity.Property(e => e.Id).HasComment("دستگاه ها");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.MacId).HasMaxLength(12);
////            entity.Property(e => e.ProductTypeId).HasComment("نوع");

////            entity.HasOne(d => d.ProductType).WithMany(p => p.Devices)
////                .HasForeignKey(d => d.ProductTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Device_ProductType");
////        });

////        modelBuilder.Entity<Document>(entity =>
////        {
////            entity.ToTable("Document");

////            entity.Property(e => e.Checksum)
////                .HasMaxLength(50)
////                .IsUnicode(false);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.SubjectField).HasMaxLength(50);
////            entity.Property(e => e.SubjectTitle).HasMaxLength(50);

////            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
////                .HasForeignKey(d => d.DocumentTypeId)
////                .HasConstraintName("FK_Document_DocumentType");

////            entity.HasOne(d => d.Member).WithMany(p => p.Documents)
////                .HasForeignKey(d => d.MemberId)
////                .HasConstraintName("FK_Document_Member");

////            entity.HasOne(d => d.User).WithMany(p => p.Documents)
////                .HasForeignKey(d => d.UserId)
////                .HasConstraintName("FK_Document_User");
////        });

////        modelBuilder.Entity<DocumentType>(entity =>
////        {
////            entity.ToTable("DocumentType");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(200);

////            entity.HasOne(d => d.App).WithMany(p => p.DocumentTypes)
////                .HasForeignKey(d => d.AppId)
////                .HasConstraintName("FK_DocumentType_Type");
////        });

////        modelBuilder.Entity<DocumentTypeCategory>(entity =>
////        {
////            entity.ToTable("DocumentTypeCategory");

////            entity.Property(e => e.Category).HasMaxLength(50);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

////            entity.HasOne(d => d.DocumentType).WithMany(p => p.DocumentTypeCategories)
////                .HasForeignKey(d => d.DocumentTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_DocumentTypeCategory_DocumentTypeCategory");
////        });

////        modelBuilder.Entity<Exam>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_UserExam");

////            entity.ToTable("Exam");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasDefaultValue(1);

////            entity.HasOne(d => d.Member).WithMany(p => p.Exams)
////                .HasForeignKey(d => d.MemberId)
////                .HasConstraintName("FK_Exam_Member");

////            entity.HasOne(d => d.UserDevice).WithMany(p => p.Exams)
////                .HasForeignKey(d => d.UserDeviceId)
////                .HasConstraintName("FK_Exam_UserAppDevice");
////        });

////        modelBuilder.Entity<ExamResult>(entity =>
////        {
////            entity.ToTable("ExamResult");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
////            entity.Property(e => e.Result).HasMaxLength(2000);

////            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults)
////                .HasForeignKey(d => d.ExamId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_ExamResult_Exam");

////            entity.HasOne(d => d.File).WithMany(p => p.ExamResults)
////                .HasForeignKey(d => d.FileId)
////                .HasConstraintName("FK_ExamResult_Document");

////            entity.HasOne(d => d.ResultType).WithMany(p => p.ExamResults)
////                .HasForeignKey(d => d.ResultTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_ExamResult_ExamResultType");

////            entity.HasOne(d => d.UserPlan).WithMany(p => p.ExamResults)
////                .HasForeignKey(d => d.UserPlanId)
////                .HasConstraintName("FK_ExamResult_UserPlan");
////        });

////        modelBuilder.Entity<ExamResultType>(entity =>
////        {
////            entity.ToTable("ExamResultType");

////            entity.Property(e => e.Id).ValueGeneratedNever();
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Faq>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_FAQ");

////            entity.ToTable("Faq", "App");

////            entity.Property(e => e.Answer).HasMaxLength(500);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Question).HasMaxLength(500);

////            entity.HasOne(d => d.App).WithMany(p => p.Faqs)
////                .HasForeignKey(d => d.AppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_FAQ_Application");
////        });

////        modelBuilder.Entity<Field>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_UserDoctorExpertise");

////            entity.ToTable("Field", "Doctor");

////            entity.Property(e => e.ConfrirmDate).HasColumnType("datetime");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.FieldStartDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.FieldDegree).WithMany(p => p.Fields)
////                .HasForeignKey(d => d.FieldDegreeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Field_FieldDegree");

////            entity.HasOne(d => d.FieldType).WithMany(p => p.Fields)
////                .HasForeignKey(d => d.FieldTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Field_FieldType");
////        });

////        modelBuilder.Entity<FieldDegree>(entity =>
////        {
////            entity.ToTable("FieldDegree", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<FieldType>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_DoctorExpertiseType");

////            entity.ToTable("FieldType", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<FixedFee>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_FixedFee_1");

////            entity.ToTable("FixedFee", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.EndDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.StartDate).HasColumnType("datetime");
////        });

////        modelBuilder.Entity<GenderType>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_GenderTypeId");

////            entity.ToTable("GenderType");

////            entity.Property(e => e.Id).ValueGeneratedOnAdd();
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Help>(entity =>
////        {
////            entity.ToTable("Help", "App");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.App).WithMany(p => p.Helps)
////                .HasForeignKey(d => d.AppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Help_Type");
////        });

////        modelBuilder.Entity<Language>(entity =>
////        {
////            entity.ToTable("Language", "App");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(100);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Name).HasMaxLength(5);
////        });

////        modelBuilder.Entity<Member>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_UserMember");

////            entity.ToTable("Member");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.FirstName).HasMaxLength(50);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastName).HasMaxLength(50);

////            entity.HasOne(d => d.GenderType).WithMany(p => p.Members)
////                .HasForeignKey(d => d.GenderTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Member_GenderType");
////        });

////        modelBuilder.Entity<Notification>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_UsreNotification");

////            entity.ToTable("Notification");

//            entity.Property(e => e.CreateDate).HasColumnType("datetime");
//            entity.Property(e => e.Date).HasColumnType("datetime");
//            entity.Property(e => e.Description).HasMaxLength(500);
//            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
//            entity.Property(e => e.LastModified).HasColumnType("datetime");
//            entity.Property(e => e.Title).HasMaxLength(50);

//            entity.HasOne(d => d.App).WithMany(p => p.Notifications)
//                .HasForeignKey(d => d.AppId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UsreNotification_Application");

//            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UsreNotification_User");
//        });

////        modelBuilder.Entity<Payment>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK__Payments");

////            entity.ToTable("__Payments");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.Desciption).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasColumnType("datetime");
////        });

////        modelBuilder.Entity<Payment1>(entity =>
////        {
////            entity.ToTable("Payment");

////            entity.Property(e => e.CardNumber)
////                .HasMaxLength(300)
////                .IsUnicode(false);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.Iban)
////                .HasMaxLength(26)
////                .IsUnicode(false);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
////            entity.Property(e => e.Message).HasMaxLength(3000);
////            entity.Property(e => e.RefNum)
////                .HasMaxLength(50)
////                .IsUnicode(false);
////            entity.Property(e => e.Rrn)
////                .HasMaxLength(300)
////                .IsUnicode(false)
////                .HasColumnName("RRN");
////            entity.Property(e => e.State)
////                .HasMaxLength(50)
////                .IsUnicode(false);
////            entity.Property(e => e.TraceNo)
////                .HasMaxLength(300)
////                .IsUnicode(false);
////            entity.Property(e => e.VerifyDate).HasColumnType("datetime");

////            entity.HasOne(d => d.Terminal).WithMany(p => p.Payment1s)
////                .HasForeignKey(d => d.TerminalId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Payment_PaymentTerminal");

////            entity.HasOne(d => d.User).WithMany(p => p.Payment1s)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Payment_User");
////        });

////        modelBuilder.Entity<PaymentTerminal>(entity =>
////        {
////            entity.ToTable("PaymentTerminal");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
////            entity.Property(e => e.Link).HasMaxLength(500);
////            entity.Property(e => e.Name).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Plan>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKSubscription");

////            entity.ToTable("Plan");

////            entity.Property(e => e.Id).HasComment("اشتراک");
////            entity.Property(e => e.Aiinterpretation).HasColumnName("AIInterpretation");
////            entity.Property(e => e.BasePrice).HasComment("هزینه اشتراک");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.MemberCount).HasComment("تعداد بیمار");
////            entity.Property(e => e.Price).HasComment("هزینه اشتراک");
////            entity.Property(e => e.Title)
////                .HasMaxLength(50)
////                .HasComment("عنوان اشتراک");
////            entity.Property(e => e.ValidDays).HasComment("تعداد روز");
////        });

////        modelBuilder.Entity<PlanDetail>(entity =>
////        {
////            entity.ToTable("PlanDetail");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.Feature).HasMaxLength(200);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Status).HasMaxLength(200);

////            entity.HasOne(d => d.Plan).WithMany(p => p.PlanDetails)
////                .HasForeignKey(d => d.PlanId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_PlanDetail_Plan");
////        });

////        modelBuilder.Entity<PrivacyAndPolicy>(entity =>
////        {
////            entity.ToTable("PrivacyAndPolicy", "App");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Descripton).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.App).WithMany(p => p.PrivacyAndPolicies)
////                .HasForeignKey(d => d.AppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_PrivacyAndPolicy_Type");
////        });

////        modelBuilder.Entity<Product>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_Service");

////            entity.ToTable("Product");

////            entity.Property(e => e.CatalogueLink).HasMaxLength(200);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.SiteLink).HasMaxLength(200);
////            entity.Property(e => e.Title).HasMaxLength(50);
////            entity.Property(e => e.Version).HasMaxLength(50);

////            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
////                .HasForeignKey(d => d.ProductTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Product_ProductType");
////        });

////        modelBuilder.Entity<ProductType>(entity =>
////        {
////            entity.ToTable("ProductType");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Question>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_SelfExpressionQuestion");

////            entity.ToTable("_Question");

////            entity.Property(e => e.CreateDate)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.Items).HasMaxLength(2000);
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.Question1)
////                .HasMaxLength(500)
////                .HasColumnName("Question");
////            entity.Property(e => e.Type).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Question1>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKQuestion");

////            entity.ToTable("Question");

////            entity.Property(e => e.Id).HasComment("سوالات");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title)
////                .HasMaxLength(300)
////                .HasComment("شرح سوال");
////        });

////        modelBuilder.Entity<QuestionAnswer>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_SelfExpressionAnswer");

////            entity.ToTable("_QuestionAnswer");

////            entity.Property(e => e.Answer).HasMaxLength(200);
////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.Createdate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");

////            entity.HasOne(d => d.Question).WithMany(p => p.QuestionAnswers)
////                .HasForeignKey(d => d.QuestionId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_SelfExpressionAnswer_SelfExpressionQuestion");
////        });

////        modelBuilder.Entity<QuestionAnswer1>(entity =>
////        {
////            entity.ToTable("QuestionAnswer");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Value).HasMaxLength(50);

////            entity.HasOne(d => d.Answer).WithMany(p => p.QuestionAnswer1s)
////                .HasForeignKey(d => d.AnswerId)
////                .HasConstraintName("FK_QuestionAnswer_Answer");

////            entity.HasOne(d => d.Member).WithMany(p => p.QuestionAnswer1s)
////                .HasForeignKey(d => d.MemberId)
////                .HasConstraintName("FK_QuestionAnswer_Member");

////            entity.HasOne(d => d.Question).WithMany(p => p.QuestionAnswer1s)
////                .HasForeignKey(d => d.QuestionId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_QuestionAnswer_Question");

////            entity.HasOne(d => d.User).WithMany(p => p.QuestionAnswer1s)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_QuestionAnswer_User");
////        });

////        modelBuilder.Entity<QuestionDetail>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKDoctorAnswer");

////            entity.ToTable("QuestionDetail");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Value).HasMaxLength(300);

////            entity.HasOne(d => d.Question).WithMany(p => p.QuestionDetails)
////                .HasForeignKey(d => d.QuestionId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_QuestionDetail_Question");
////        });

////        modelBuilder.Entity<Reminder>(entity =>
////        {
////            entity.ToTable("Reminder");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.DueDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(500);

////            entity.HasOne(d => d.User).WithMany(p => p.Reminders)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Reminder_User");
////        });

////        modelBuilder.Entity<ServiceType>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_DoctorServiceType");

////            entity.ToTable("ServiceType", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Settlement>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_Settlement_1");

////            entity.ToTable("Settlement", "Fin");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.PayDate).HasColumnType("datetime");

////            entity.HasOne(d => d.User).WithMany(p => p.Settlements)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Settlement_User");
////        });

////        modelBuilder.Entity<Ticket>(entity =>
////        {
////            entity.ToTable("Ticket");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Subject).HasMaxLength(500);

////            entity.HasOne(d => d.App).WithMany(p => p.Tickets)
////                .HasForeignKey(d => d.AppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Ticket_Application");

////            entity.HasOne(d => d.TicketStatus).WithMany(p => p.Tickets)
////                .HasForeignKey(d => d.TicketStatusId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Ticket_TicketStatus");

////            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
////                .HasForeignKey(d => d.TicketTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Ticket_TicketType");

////            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Ticket_User");
////        });

////        modelBuilder.Entity<TicketDetail>(entity =>
////        {
////            entity.ToTable("TicketDetail");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketDetails)
////                .HasForeignKey(d => d.TicketId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_TicketDetail_Ticket");

////            entity.HasOne(d => d.User).WithMany(p => p.TicketDetails)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_TicketDetail_User");
////        });

////        modelBuilder.Entity<TicketStatus>(entity =>
////        {
////            entity.ToTable("TicketStatus");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<TicketType>(entity =>
////        {
////            entity.ToTable("TicketType");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);

////            entity.HasOne(d => d.App).WithMany(p => p.TicketTypes)
////                .HasForeignKey(d => d.AppId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_TicketType_Type");
////        });

////        modelBuilder.Entity<Transaction>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_WalletTransaction");

////            entity.ToTable("Transaction", "Fin");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(400);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.UserApp).WithMany(p => p.Transactions)
////                .HasForeignKey(d => d.UserAppId)
////                .HasConstraintName("FK_WalletTransaction_UserApp");

////            entity.HasOne(d => d.UserDoctor).WithMany(p => p.Transactions)
////                .HasForeignKey(d => d.UserDoctorId)
////                .HasConstraintName("FK_WalletTransaction_UserDoctor");

////            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_WalletTransaction_User");
////        });

////        modelBuilder.Entity<Type>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_Application");

////            entity.ToTable("Type", "App");

////            entity.Property(e => e.Id).ValueGeneratedNever();
////            entity.Property(e => e.CreateDate)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.Header).HasMaxLength(50);
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<User>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKUser");

////            entity.ToTable("User");

////            entity.Property(e => e.Id).HasComment("کاربران");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.Email).HasMaxLength(50);
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.Otpseed)
////                .HasMaxLength(50)
////                .IsFixedLength()
////                .HasColumnName("OTPSeed");
////        });

////        modelBuilder.Entity<UserApp>(entity =>
////        {
////            entity.ToTable("UserApp");

////            entity.HasIndex(e => e.Id, "IX_UserApp");

////            entity.Property(e => e.Id).HasComment("بیماران");
////            entity.Property(e => e.Address).HasMaxLength(200);
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.FirstName).HasMaxLength(50);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastName).HasMaxLength(50);
////            entity.Property(e => e.ZipCode).HasMaxLength(50);

////            entity.HasOne(d => d.GenderType).WithMany(p => p.UserApps)
////                .HasForeignKey(d => d.GenderTypeId)
////                .HasConstraintName("FK_UserApp_GenderType");

////            entity.HasOne(d => d.Image).WithMany(p => p.UserApps)
////                .HasForeignKey(d => d.ImageId)
////                .HasConstraintName("FK_UserApp_Document");

////            entity.HasOne(d => d.User).WithMany(p => p.UserApps)
////                .HasForeignKey(d => d.UserId)
////                .HasConstraintName("FK_User_App_User");
////        });

////        modelBuilder.Entity<UserAppDevice>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKDeviceAllocation");

////            entity.ToTable("UserAppDevice");

////            entity.Property(e => e.Id).HasComment("دستگاه های تخصیص یافته");
////            entity.Property(e => e.CreateDate)
////                .HasComment("تاریخ شروع به کار")
////                .HasColumnType("datetime");
////            entity.Property(e => e.DeviceId).HasComment("دستگاه");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.UserId).HasComment("کاربر");

////            entity.HasOne(d => d.Device).WithMany(p => p.UserAppDevices)
////                .HasForeignKey(d => d.DeviceId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_UserDevice_Device");

////            entity.HasOne(d => d.User).WithMany(p => p.UserAppDevices)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_UserDevice_User");
////        });

////        modelBuilder.Entity<UserDoctor>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKDoctor");

////            entity.ToTable("UserDoctor");

//            entity.Property(e => e.Id).HasComment("پزشکان");
//            entity.Property(e => e.BirthDate)
//                .HasComment("سن")
//                .HasColumnType("datetime");
//            entity.Property(e => e.ConfirmDate).HasColumnType("datetime");
//            entity.Property(e => e.CreateDate).HasColumnType("datetime");
//            entity.Property(e => e.ExpireDate)
//                .HasDefaultValueSql("((1))")
//                .HasColumnType("datetime");
//            entity.Property(e => e.FirstName)
//                .HasMaxLength(50)
//                .HasComment("نام");
//            entity.Property(e => e.GenderTypeId).HasComment("جنسیت");
//            entity.Property(e => e.LastModified)
//                .HasDefaultValueSql("(getdate())")
//                .HasColumnType("datetime");
//            entity.Property(e => e.LastModifiedBy).HasDefaultValue(1);
//            entity.Property(e => e.LastName)
//                .HasMaxLength(50)
//                .HasComment("نام خانوادگی");
//            entity.Property(e => e.MedicalCode).HasComment("کد نظام پزشکی");
//            entity.Property(e => e.NationalCode).HasComment("کد ملی");

////            entity.HasOne(d => d.GenderType).WithMany(p => p.UserDoctors)
////                .HasForeignKey(d => d.GenderTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_User_Doctor_GenderType");

////            entity.HasOne(d => d.Image).WithMany(p => p.UserDoctors)
////                .HasForeignKey(d => d.ImageId)
////                .HasConstraintName("FK_UserDoctor_Document");

////            entity.HasOne(d => d.User).WithMany(p => p.UserDoctors)
////                .HasForeignKey(d => d.UserId)
////                .HasConstraintName("FK_User_Doctor_User");
////        });

////        modelBuilder.Entity<UserOffice>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_User_BackOffice");

////            entity.ToTable("UserOffice");

////            entity.Property(e => e.BirthDate)
////                .HasComment("سن")
////                .HasColumnType("datetime");
////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.FirstName)
////                .HasMaxLength(50)
////                .HasComment("نام");
////            entity.Property(e => e.GenderTypeId).HasComment("جنسیت");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastName)
////                .HasMaxLength(50)
////                .HasComment("نام خانوادگی");
////            entity.Property(e => e.NationalCode).HasComment("کد ملی");

////            entity.HasOne(d => d.GenderType).WithMany(p => p.UserOffices)
////                .HasForeignKey(d => d.GenderTypeId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_User_Office_GenderType");

////            entity.HasOne(d => d.User).WithMany(p => p.UserOffices)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_User_Office_User");
////        });

////        modelBuilder.Entity<UserPlan>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PKSubsriptionHistory");

////            entity.ToTable("UserPlan");

////            entity.Property(e => e.Id).HasComment("تاریخچه خرید اشتراک");
////            entity.Property(e => e.CreateDate)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.EndDate)
////                .HasComment("زمان پایان")
////                .HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasColumnType("datetime");
////            entity.Property(e => e.MemberCount).HasComment("تعداد بیمار");
////            entity.Property(e => e.PlanId).HasComment("اشتراک");
////            entity.Property(e => e.StartDate)
////                .HasComment("زمان شروع")
////                .HasColumnType("datetime");
////            entity.Property(e => e.UserId).HasComment("کاربر");

////            entity.HasOne(d => d.Plan).WithMany(p => p.UserPlans)
////                .HasForeignKey(d => d.PlanId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_UserPlan_Plan");

////            entity.HasOne(d => d.User).WithMany(p => p.UserPlans)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_UserPlan_User");
////        });

////        modelBuilder.Entity<UserType>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_UserType");

////            entity.ToTable("__UserType");

////            entity.Property(e => e.CreateDate)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy).HasColumnType("datetime");
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<Version>(entity =>
////        {
////            entity.ToTable("Version", "App");

////            entity.Property(e => e.CreatedBy)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.Createdate).HasColumnType("datetime");
////            entity.Property(e => e.Description).HasMaxLength(500);
////            entity.Property(e => e.ExpireDate)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.Version1)
////                .HasMaxLength(50)
////                .HasColumnName("Version");
////        });

////        modelBuilder.Entity<VisitLog>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_ExamReviewStatus");

////            entity.ToTable("VisitLog");

////            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
////            entity.Property(e => e.Createdate).HasColumnType("datetime");
////            entity.Property(e => e.EndDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModified)
////                .HasDefaultValueSql("(getdate())")
////                .HasColumnType("datetime");
////            entity.Property(e => e.LastModifiedBy)
////                .HasDefaultValueSql("((1))")
////                .HasColumnType("datetime");
////            entity.Property(e => e.StartDate).HasColumnType("datetime");

////            entity.HasOne(d => d.Request).WithMany(p => p.VisitLogs)
////                .HasForeignKey(d => d.RequestId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_VisitLog_VisitRequest");
////        });

////        modelBuilder.Entity<VisitRequest>(entity =>
////        {
////            entity.HasKey(e => e.Id).HasName("PK_ExamReview");

////            entity.ToTable("VisitRequest");

//            entity.Property(e => e.CreateDate).HasColumnType("datetime");
//            entity.Property(e => e.Date).HasColumnType("datetime");
//            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
//            entity.Property(e => e.LastModified).HasColumnType("datetime");
//            entity.Property(e => e.Rating).HasColumnType("decimal(1, 1)");
//            entity.Property(e => e.Review).HasMaxLength(500);

//            entity.HasOne(d => d.Exam).WithMany(p => p.VisitRequests)
//                .HasForeignKey(d => d.ExamId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_VisitRequest_Exam");

////            entity.HasOne(d => d.ExamResult).WithMany(p => p.VisitRequests)
////                .HasForeignKey(d => d.ExamResultId)
////                .HasConstraintName("FK_VisitRequest_ExamResult");

////            entity.HasOne(d => d.Member).WithMany(p => p.VisitRequests)
////                .HasForeignKey(d => d.MemberId)
////                .HasConstraintName("FK_VisitRequest_Member");

//            entity.HasOne(d => d.UserApp).WithMany(p => p.VisitRequests)
//                .HasForeignKey(d => d.UserAppId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_VisitRequest_UserApp");

//            entity.HasOne(d => d.UserDoctor).WithMany(p => p.VisitRequests)
//                .HasForeignKey(d => d.UserDoctorId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_VisitRequest_UserDoctor");
//        });

////        modelBuilder.Entity<VwFaq>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_Faq");

////            entity.Property(e => e.Answer).HasMaxLength(500);
////            entity.Property(e => e.AppName).HasMaxLength(50);
////            entity.Property(e => e.Language).HasMaxLength(5);
////        });

//        modelBuilder.Entity<VwGetDoctor>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToView("vw_GetDoctors");

//            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
//            entity.Property(e => e.FieldTypeTitle).HasMaxLength(50);
//            entity.Property(e => e.FirstName).HasMaxLength(50);
//            entity.Property(e => e.LastName).HasMaxLength(50);
//            entity.Property(e => e.Rating).HasColumnType("decimal(1, 1)");
//        });

//        modelBuilder.Entity<VwGetMemberActivity>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToView("vw_GetMemberActivity");

//            entity.Property(e => e.CreateDate).HasColumnType("datetime");
//            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
//            entity.Property(e => e.FirstName).HasMaxLength(50);
//            entity.Property(e => e.LastName).HasMaxLength(50);
//            entity.Property(e => e.Title).HasMaxLength(50);
//        });

//        modelBuilder.Entity<VwGetPlan>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToView("vw_GetPlans");

////            entity.Property(e => e.Aiinterpretation).HasColumnName("AIInterpretation");
////            entity.Property(e => e.Id).ValueGeneratedOnAdd();
////            entity.Property(e => e.Title).HasMaxLength(50);
////        });

////        modelBuilder.Entity<VwGetProductType>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_GetProductType");

////            entity.Property(e => e.Language).HasMaxLength(5);
////        });

////        modelBuilder.Entity<VwGetProfile>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_GetProfile");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.FirstName).HasMaxLength(50);
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////            entity.Property(e => e.LastName).HasMaxLength(50);
////        });

////        modelBuilder.Entity<VwGetReminder>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_GetReminder");

////            entity.Property(e => e.DueDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.MemberExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.MemberFirstName).HasMaxLength(50);
////            entity.Property(e => e.MemberLastName).HasMaxLength(50);
////            entity.Property(e => e.Title).HasMaxLength(500);
////            entity.Property(e => e.UserFirstName).HasMaxLength(50);
////            entity.Property(e => e.UserLastName).HasMaxLength(50);
////        });

////        modelBuilder.Entity<VwHelp>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_Help");

////            entity.Property(e => e.AppName).HasMaxLength(50);
////            entity.Property(e => e.Language).HasMaxLength(5);
////        });

////        modelBuilder.Entity<VwPrivacyAndPolicy>(entity =>
////        {
////            entity
////                .HasNoKey()
////                .ToView("vw_PrivacyAndPolicy");

////            entity.Property(e => e.AppName).HasMaxLength(50);
////            entity.Property(e => e.Language).HasMaxLength(5);
////        });

////        modelBuilder.Entity<Wage>(entity =>
////        {
////            entity.ToTable("Wage", "Doctor");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");
////        });

////        modelBuilder.Entity<Wallet>(entity =>
////        {
////            entity.ToTable("Wallet", "Fin");

////            entity.Property(e => e.CreateDate).HasColumnType("datetime");
////            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
////            entity.Property(e => e.LastModified).HasColumnType("datetime");

////            entity.HasOne(d => d.UserApp).WithMany(p => p.Wallets)
////                .HasForeignKey(d => d.UserAppId)
////                .HasConstraintName("FK_Wallet_UserApp");

////            entity.HasOne(d => d.UserDoctor).WithMany(p => p.Wallets)
////                .HasForeignKey(d => d.UserDoctorId)
////                .HasConstraintName("FK_Wallet_UserDoctor");

////            entity.HasOne(d => d.User).WithMany(p => p.Wallets)
////                .HasForeignKey(d => d.UserId)
////                .OnDelete(DeleteBehavior.ClientSetNull)
////                .HasConstraintName("FK_Wallet_User");
////        });

////        OnModelCreatingPartial(modelBuilder);
////    }

////    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
////}
