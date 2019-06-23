using Microsoft.EntityFrameworkCore;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class OLS_MiddlewareDBContext : DbContext
    {
        public OLS_MiddlewareDBContext()
        {
        }

        public OLS_MiddlewareDBContext(DbContextOptions<OLS_MiddlewareDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiConfig> ApiConfig { get; set; }
        public virtual DbSet<ApiDebugConfig> ApiDebugConfig { get; set; }
        public virtual DbSet<ApiParameters> ApiParameters { get; set; }
        public virtual DbSet<ApiStatistics> ApiStatistics { get; set; }
        public virtual DbSet<AppUserYearReport2018Log> AppUserYearReport2018Log { get; set; }
        public virtual DbSet<CommonCityWeather> CommonCityWeather { get; set; }
        public virtual DbSet<CrmConfig> CrmConfig { get; set; }
        public virtual DbSet<CrmDebugConfig> CrmDebugConfig { get; set; }
        public virtual DbSet<CrmParameters> CrmParameters { get; set; }
        public virtual DbSet<DmConfig> DmConfig { get; set; }
        public virtual DbSet<FsCategory> FsCategory { get; set; }
        public virtual DbSet<FsResources> FsResources { get; set; }
        public virtual DbSet<GlobalConfig> GlobalConfig { get; set; }
        public virtual DbSet<IntegralUntreatedRecord> IntegralUntreatedRecord { get; set; }
        public virtual DbSet<MqAppPushNotify> MqAppPushNotify { get; set; }
        public virtual DbSet<MqAppPushNotify1> MqAppPushNotify1 { get; set; }
        public virtual DbSet<MqCmsmessageNotify> MqCmsmessageNotify { get; set; }
        public virtual DbSet<MqShortMessageNotify> MqShortMessageNotify { get; set; }
        public virtual DbSet<MqWechatKfmessageNotify> MqWechatKfmessageNotify { get; set; }
        public virtual DbSet<MqWechatTemplateMessageNotify> MqWechatTemplateMessageNotify { get; set; }
        public virtual DbSet<MqWechatTemplateMessageNotifyLog> MqWechatTemplateMessageNotifyLog { get; set; }
        public virtual DbSet<SsoLogonLog> SsoLogonLog { get; set; }
        public virtual DbSet<SsoWechatConfig> SsoWechatConfig { get; set; }
        public virtual DbSet<StatsRedirectConfig> StatsRedirectConfig { get; set; }
        public virtual DbSet<StatsRedirectLog> StatsRedirectLog { get; set; }
        public virtual DbSet<WebShortUrl> WebShortUrl { get; set; }
        public virtual DbSet<WebShortUrlLog> WebShortUrlLog { get; set; }
        public virtual DbSet<WebiIpadApplyLog> WebiIpadApplyLog { get; set; }
        public virtual DbSet<WebiPageStatisticsLog> WebiPageStatisticsLog { get; set; }
        public virtual DbSet<WechatAdminUser> WechatAdminUser { get; set; }
        public virtual DbSet<WechatAppAutoReply> WechatAppAutoReply { get; set; }
        public virtual DbSet<WechatAppConfig> WechatAppConfig { get; set; }
        public virtual DbSet<WechatAppMaterial> WechatAppMaterial { get; set; }
        public virtual DbSet<WechatAppQrscene> WechatAppQrscene { get; set; }
        public virtual DbSet<WechatAppUser> WechatAppUser { get; set; }
        public virtual DbSet<WechatAuthorization> WechatAuthorization { get; set; }
        public virtual DbSet<WechatAutoReply> WechatAutoReply { get; set; }
        public virtual DbSet<WechatAutoReplyItems> WechatAutoReplyItems { get; set; }
        public virtual DbSet<WechatConfig> WechatConfig { get; set; }
        public virtual DbSet<WechatEeappConfig> WechatEeappConfig { get; set; }
        public virtual DbSet<WechatEeappUser> WechatEeappUser { get; set; }
        public virtual DbSet<WechatEventReply> WechatEventReply { get; set; }
        public virtual DbSet<WechatFocusReply> WechatFocusReply { get; set; }
        public virtual DbSet<WechatKeywordReply> WechatKeywordReply { get; set; }
        public virtual DbSet<WechatMaterial> WechatMaterial { get; set; }
        public virtual DbSet<WechatOrderNotify> WechatOrderNotify { get; set; }
        public virtual DbSet<WechatOrders> WechatOrders { get; set; }
        public virtual DbSet<WechatPrivateTemplate> WechatPrivateTemplate { get; set; }
        public virtual DbSet<WechatQrlimitScene> WechatQrlimitScene { get; set; }
        public virtual DbSet<WechatQrscene> WechatQrscene { get; set; }
        public virtual DbSet<WechatQrscene1> WechatQrscene1 { get; set; }
        public virtual DbSet<WechatQrsceneScanRecord> WechatQrsceneScanRecord { get; set; }
        public virtual DbSet<WechatScanReply> WechatScanReply { get; set; }
        public virtual DbSet<WechatTemplateMessage> WechatTemplateMessage { get; set; }
        public virtual DbSet<WechatUser> WechatUser { get; set; }
        public virtual DbSet<WorkFlow> WorkFlow { get; set; }
        public virtual DbSet<WorkFlowUser> WorkFlowUser { get; set; }
        public virtual DbSet<WorkFlowUserExecute> WorkFlowUserExecute { get; set; }
        public virtual DbSet<WrokFlowModule> WrokFlowModule { get; set; }
        public virtual DbSet<WsTaskConfig> WsTaskConfig { get; set; }
        public virtual DbSet<WsTaskLog> WsTaskLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = 10.0.0.130;Initial Catalog = OLS_MiddlewareDB;User Id = ols_alldb;Password = ols_alldb123,;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<ApiConfig>(entity =>
            {
                entity.ToTable("API_Config");

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppSecret)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remark).HasMaxLength(50);
            });

            modelBuilder.Entity<ApiDebugConfig>(entity =>
            {
                entity.ToTable("API_DebugConfig");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApiUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Summary).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('onlineschool')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApiParameters>(entity =>
            {
                entity.ToTable("API_Parameters");

                entity.Property(e => e.ApiDebugConfigId).HasColumnName("Api_DebugConfigId");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsMd5)
                    .HasColumnName("IsMD5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsNecessary).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParameterInfo)
                    .HasColumnName("parameterInfo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasColumnName("parameterName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterType)
                    .HasColumnName("parameterType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('string')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApiStatistics>(entity =>
            {
                entity.ToTable("API_Statistics");

                entity.Property(e => e.Apiurl)
                    .HasColumnName("APIUrl")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KeyId)
                    .HasColumnName("KeyID")
                    .HasMaxLength(50);

                entity.Property(e => e.Parameter).HasMaxLength(2000);
            });

            modelBuilder.Entity<AppUserYearReport2018Log>(entity =>
            {
                entity.HasKey(e => e.ContractGuid)
                    .HasName("PK_AppUserYearReport2018Log_1");

                entity.Property(e => e.ContractGuid)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppCreateTime).HasMaxLength(50);

                entity.Property(e => e.BestLearningConstellation).HasMaxLength(50);

                entity.Property(e => e.EslearningDescription)
                    .HasColumnName("ESLearningDescription")
                    .HasMaxLength(200);

                entity.Property(e => e.LatestLearningConstellation).HasMaxLength(50);

                entity.Property(e => e.LoveLearningConstellation).HasMaxLength(50);

                entity.Property(e => e.LoveWorkingConstellation).HasMaxLength(50);

                entity.Property(e => e.MostSalonDate).HasMaxLength(50);

                entity.Property(e => e.MyClockLatestDate).HasMaxLength(50);

                entity.Property(e => e.MyClockLatestTime).HasMaxLength(50);

                entity.Property(e => e.ShareImageUrl).HasMaxLength(200);

                entity.Property(e => e.TeacherDistance).HasMaxLength(200);

                entity.Property(e => e.TeacherMostCommentWords).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<CommonCityWeather>(entity =>
            {
                entity.ToTable("Common_CityWeather");

                entity.Property(e => e.CityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Weather).HasMaxLength(10);
            });

            modelBuilder.Entity<CrmConfig>(entity =>
            {
                entity.ToTable("CRM_Config");

                entity.Property(e => e.AppId).HasMaxLength(100);

                entity.Property(e => e.AppSecret).HasMaxLength(100);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CrmDebugConfig>(entity =>
            {
                entity.ToTable("CRM_DebugConfig");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApiUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Summary).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('onlineschool')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CrmParameters>(entity =>
            {
                entity.ToTable("CRM_Parameters");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApiDebugConfigId).HasColumnName("Api_DebugConfigId");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsMd5)
                    .HasColumnName("IsMD5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsNecessary).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParameterInfo)
                    .HasColumnName("parameterInfo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasColumnName("parameterName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterType)
                    .HasColumnName("parameterType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('string')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DmConfig>(entity =>
            {
                entity.ToTable("DM_Config");

                entity.Property(e => e.AccessToken).HasMaxLength(300);

                entity.Property(e => e.AppId).HasMaxLength(100);

                entity.Property(e => e.AppSecret).HasMaxLength(100);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiresTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<FsCategory>(entity =>
            {
                entity.ToTable("FS_Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FsResources>(entity =>
            {
                entity.HasKey(e => e.ResourceId)
                    .HasName("PK_FS_FileList");

                entity.ToTable("FS_Resources");

                entity.HasIndex(e => e.CreateTime)
                    .HasName("index_time");

                entity.HasIndex(e => e.ModuleType)
                    .HasName("index_type");

                entity.Property(e => e.ResourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HashMd5)
                    .HasColumnName("HashMD5")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.ResourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SmallPath)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GlobalConfig>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("Global_Config");

                entity.Property(e => e.Key)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModuleType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<IntegralUntreatedRecord>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.AppUserId).HasMaxLength(50);

                entity.Property(e => e.BehaviorType).HasMaxLength(50);

                entity.Property(e => e.ContractActualMoney).HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CrmcontractGuid)
                    .HasColumnName("CRMContractGuid")
                    .HasMaxLength(50);

                entity.Property(e => e.CrmleadGuid)
                    .HasColumnName("CRMLeadGuid")
                    .HasMaxLength(50);

                entity.Property(e => e.CrmplanClassDetailGuid).HasColumnName("CRMPlanClassDetailGuid");

                entity.Property(e => e.Reason).HasMaxLength(50);

                entity.Property(e => e.UserType).HasMaxLength(50);
            });

            modelBuilder.Entity<MqAppPushNotify>(entity =>
            {
                entity.ToTable("MQ_AppPushNotify");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_MQ_AppPushNotify_4");

                entity.HasIndex(e => e.PlanTime)
                    .HasName("IX_MQ_AppPushNotify_3");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceToken)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ostype)
                    .HasColumnName("OSType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<MqAppPushNotify1>(entity =>
            {
                entity.ToTable("MQ_AppPushNotify1");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_MQ_AppPushNotify1_2");

                entity.HasIndex(e => e.MessageType)
                    .HasName("IX_MQ_AppPushNotify1_1");

                entity.HasIndex(e => e.PlanTime)
                    .HasName("IX_MQ_AppPushNotify1");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceToken)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ostype)
                    .HasColumnName("OSType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<MqCmsmessageNotify>(entity =>
            {
                entity.ToTable("MQ_CMSMessageNotify");

                entity.Property(e => e.AppId).HasMaxLength(50);

                entity.Property(e => e.BusinessUnitId).HasMaxLength(50);

                entity.Property(e => e.BusinessUnitName).HasMaxLength(50);

                entity.Property(e => e.Contents).HasMaxLength(2000);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromAppUserId).HasMaxLength(50);

                entity.Property(e => e.KeyId).HasMaxLength(50);

                entity.Property(e => e.MessageType).HasMaxLength(50);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.ToAppType).HasMaxLength(50);

                entity.Property(e => e.ToModuleType).HasMaxLength(50);
            });

            modelBuilder.Entity<MqShortMessageNotify>(entity =>
            {
                entity.ToTable("MQ_ShortMessageNotify");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_MQ_ShortMessageNotify_1");

                entity.HasIndex(e => e.MessageType)
                    .HasName("IX_MQ_ShortMessageNotify_2");

                entity.HasIndex(e => e.Mobile)
                    .HasName("IX_MQ_ShortMessageNotify");

                entity.HasIndex(e => e.PlanTime)
                    .HasName("IX_MQ_ShortMessageNotify_3");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.ValiCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MqWechatKfmessageNotify>(entity =>
            {
                entity.ToTable("MQ_WechatKFMessageNotify");

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contents).HasMaxLength(2000);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MqWechatTemplateMessageNotify>(entity =>
            {
                entity.ToTable("MQ_WechatTemplateMessageNotify");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_MQ_WechatTemplateMessageNotify");

                entity.HasIndex(e => e.IsEnabled)
                    .HasName("IX_MQ_WechatTemplateMessageNotify_3");

                entity.HasIndex(e => e.PlanTime)
                    .HasName("IX_MQ_WechatTemplateMessageNotify_2");

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.WxmessageId)
                    .HasColumnName("WXMessageId")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MqWechatTemplateMessageNotifyLog>(entity =>
            {
                entity.ToTable("MQ_WechatTemplateMessageNotifyLog");

                entity.HasIndex(e => e.MessageType)
                    .HasName("IX_MQ_WechatTemplateMessageNotifyLog1_2");

                entity.HasIndex(e => e.SendTime)
                    .HasName("IX_MQ_WechatTemplateMessageNotifyLog1");

                entity.HasIndex(e => e.WxmessageId)
                    .HasName("IX_MQ_WechatTemplateMessageNotifyLog1_1");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTime).HasColumnType("datetime");

                entity.Property(e => e.SendResult)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.WxmessageId)
                    .HasColumnName("WXMessageId")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SsoLogonLog>(entity =>
            {
                entity.ToTable("SSO_LogonLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.OpenId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SsoWechatConfig>(entity =>
            {
                entity.ToTable("SSO_WechatConfig");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppSecret)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EncodingAeskey)
                    .HasColumnName("EncodingAESKey")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TokenUpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<StatsRedirectConfig>(entity =>
            {
                entity.ToTable("Stats_RedirectConfig");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RedirectUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatsRedirectLog>(entity =>
            {
                entity.ToTable("Stats_RedirectLog");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpenId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebShortUrl>(entity =>
            {
                entity.ToTable("Web_ShortUrl");

                entity.HasIndex(e => e.CreateTime)
                    .HasName("IX_Web_ShortUrl");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ExpTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebShortUrlLog>(entity =>
            {
                entity.ToTable("Web_ShortUrlLog");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebiIpadApplyLog>(entity =>
            {
                entity.ToTable("WebiIPadApplyLog");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WebiPageStatisticsLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(50);

                entity.Property(e => e.RequestUrl).HasMaxLength(2000);
            });

            modelBuilder.Entity<WechatAdminUser>(entity =>
            {
                entity.ToTable("Wechat_AdminUser");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastLogonIp)
                    .HasColumnName("LastLogonIP")
                    .HasMaxLength(50);

                entity.Property(e => e.LastLogonTime).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WechatId).HasColumnName("WechatID");
            });

            modelBuilder.Entity<WechatAppAutoReply>(entity =>
            {
                entity.ToTable("Wechat_AppAutoReply");

                entity.Property(e => e.Contents).HasMaxLength(1000);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Keywords).HasMaxLength(50);

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatAppConfig>(entity =>
            {
                entity.ToTable("Wechat_AppConfig");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppSecret)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EncodingAeskey)
                    .HasColumnName("EncodingAESKey")
                    .HasMaxLength(50);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalId).HasMaxLength(50);

                entity.Property(e => e.PayKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayMchId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayNotifyUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUrl).HasMaxLength(200);

                entity.Property(e => e.Token).HasMaxLength(50);

                entity.Property(e => e.TokenUpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<WechatAppMaterial>(entity =>
            {
                entity.ToTable("Wechat_AppMaterial");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.MediaId)
                    .IsRequired()
                    .HasColumnName("media_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WechatAppQrscene>(entity =>
            {
                entity.HasKey(e => new { e.Scene, e.WxAppId })
                    .HasName("PK_Wechat_MiniappQRScene");

                entity.ToTable("Wechat_AppQRScene");

                entity.Property(e => e.Scene)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CouponId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LineColor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Page)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QrcodeUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatAppUser>(entity =>
            {
                entity.HasKey(e => new { e.WxAppId, e.OpenId })
                    .HasName("PK_Wechat_MiniappUser_1");

                entity.ToTable("Wechat_AppUser");

                entity.Property(e => e.OpenId)
                    .HasColumnName("OpenID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sessionkey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unionid)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatAuthorization>(entity =>
            {
                entity.ToTable("Wechat_Authorization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<WechatAutoReply>(entity =>
            {
                entity.ToTable("Wechat_AutoReply");

                entity.Property(e => e.ArticleCount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contents).HasMaxLength(1000);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HqmusicUrl)
                    .HasColumnName("HQMusicUrl")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.MusicDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MusicTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MusicUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OrderBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VideoDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VideoMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VideoTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VoiceMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatAutoReplyItems>(entity =>
            {
                entity.ToTable("Wechat_AutoReplyItems");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PicUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatConfig>(entity =>
            {
                entity.ToTable("Wechat_Config");

                entity.HasIndex(e => e.Guid)
                    .HasName("IX_Wechat_Config")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessToken).HasMaxLength(200);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppSecret)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EncodingAeskey)
                    .HasColumnName("EncodingAESKey")
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(replace(newid(),'-',''))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.JssdkTicket)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JssdkTicketUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServerUrl).HasMaxLength(200);

                entity.Property(e => e.Token).HasMaxLength(50);

                entity.Property(e => e.TokenUpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<WechatEeappConfig>(entity =>
            {
                entity.ToTable("Wechat_EEAppConfig");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessToken)
                    .HasColumnName("access_token")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AgentId).HasColumnName("agent_id");

                entity.Property(e => e.AuthDomain)
                    .HasColumnName("auth_domain")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorpId)
                    .IsRequired()
                    .HasColumnName("corp_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomePage)
                    .HasColumnName("home_page")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JssdkDomain)
                    .HasColumnName("jssdk_domain")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JssdkTicket)
                    .HasColumnName("jssdk_ticket")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JssdkTicketExpireTime)
                    .HasColumnName("jssdk_ticket_expire_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MessageDomain)
                    .HasColumnName("message_domain")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Secret)
                    .HasColumnName("secret")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TokenExpireTime)
                    .HasColumnName("token_expire_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<WechatEeappUser>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Wechat_EEAppUser");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("device_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Openid)
                    .HasColumnName("openid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.QrCode)
                    .HasColumnName("qr_code")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WxeeId).HasColumnName("wxee_id");
            });

            modelBuilder.Entity<WechatEventReply>(entity =>
            {
                entity.ToTable("Wechat_EventReply");

                entity.Property(e => e.ArticleCount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contents).HasMaxLength(300);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HqmusicUrl)
                    .HasColumnName("HQMusicUrl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageMediaId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.MusicDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MusicTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MusicUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbMediaId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoMediaId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoiceMediaId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatFocusReply>(entity =>
            {
                entity.ToTable("Wechat_FocusReply");

                entity.Property(e => e.ArticleCount).HasMaxLength(10);

                entity.Property(e => e.Contents).HasMaxLength(300);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HqmusicUrl)
                    .HasColumnName("HQMusicUrl")
                    .HasMaxLength(10);

                entity.Property(e => e.ImageMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.MusicDescription).HasMaxLength(10);

                entity.Property(e => e.MusicTitle).HasMaxLength(10);

                entity.Property(e => e.MusicUrl).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoDescription).HasMaxLength(10);

                entity.Property(e => e.VideoMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoTitle).HasMaxLength(10);

                entity.Property(e => e.VoiceMediaId).HasMaxLength(10);
            });

            modelBuilder.Entity<WechatKeywordReply>(entity =>
            {
                entity.ToTable("Wechat_KeywordReply");

                entity.Property(e => e.ArticleCount).HasMaxLength(10);

                entity.Property(e => e.Contents).HasMaxLength(300);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HqmusicUrl)
                    .HasColumnName("HQMusicUrl")
                    .HasMaxLength(10);

                entity.Property(e => e.ImageMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Keyword).HasMaxLength(50);

                entity.Property(e => e.MusicDescription).HasMaxLength(10);

                entity.Property(e => e.MusicTitle).HasMaxLength(10);

                entity.Property(e => e.MusicUrl).HasMaxLength(10);

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoDescription).HasMaxLength(10);

                entity.Property(e => e.VideoMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoTitle).HasMaxLength(10);

                entity.Property(e => e.VoiceMediaId).HasMaxLength(10);
            });

            modelBuilder.Entity<WechatMaterial>(entity =>
            {
                entity.ToTable("Wechat_Material");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(50);

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.ContentSourceUrl)
                    .HasColumnName("content_source_url")
                    .HasMaxLength(300);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Digest)
                    .HasColumnName("digest")
                    .HasMaxLength(50);

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasMaxLength(100);

                entity.Property(e => e.ShowCoverPic)
                    .HasColumnName("show_cover_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.ThumbMediaId)
                    .HasColumnName("thumb_media_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<WechatOrderNotify>(entity =>
            {
                entity.ToTable("Wechat_OrderNotify");

                entity.Property(e => e.Appid)
                    .HasColumnName("appid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ErrCode)
                    .HasColumnName("err_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCodeDes)
                    .HasColumnName("err_code_des")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsSubscribe).HasColumnName("is_subscribe");

                entity.Property(e => e.MchId)
                    .HasColumnName("mch_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyXml)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Openid)
                    .HasColumnName("openid")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasColumnName("out_trade_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCode)
                    .HasColumnName("result_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .HasColumnName("sign")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFee).HasColumnName("total_fee");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<WechatOrders>(entity =>
            {
                entity.HasKey(e => e.OutTradeNo)
                    .HasName("PK_Wecvhat_Orders");

                entity.ToTable("Wechat_Orders");

                entity.Property(e => e.OutTradeNo)
                    .HasColumnName("out_trade_no")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Appid)
                    .HasColumnName("appid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FailMessage)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MchId)
                    .HasColumnName("mch_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Openid)
                    .HasColumnName("openid")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PaySign)
                    .HasColumnName("paySign")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostXml)
                    .HasMaxLength(6000)
                    .IsUnicode(false);

                entity.Property(e => e.PrepayId)
                    .HasColumnName("prepay_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RetErrCode)
                    .HasColumnName("ret_err_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RetErrCodeDes)
                    .HasColumnName("ret_err_code_des")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RetResultCode)
                    .HasColumnName("ret_result_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnXml)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .HasColumnName("sign")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFee).HasColumnName("total_fee");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatPrivateTemplate>(entity =>
            {
                entity.ToTable("Wechat_Private_Template");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(800);

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeputyIndustry)
                    .HasColumnName("deputy_industry")
                    .HasMaxLength(50);

                entity.Property(e => e.Example)
                    .HasColumnName("example")
                    .HasMaxLength(800);

                entity.Property(e => e.PrimaryIndustry)
                    .HasColumnName("primary_industry")
                    .HasMaxLength(50);

                entity.Property(e => e.TemplateId)
                    .HasColumnName("template_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WechatQrlimitScene>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.WechatId });

                entity.ToTable("Wechat_QRLimitScene");

                entity.Property(e => e.BusinessId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SceneId).ValueGeneratedOnAdd();

                entity.Property(e => e.Ticket)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatQrscene>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.WechatId, e.ModuleType });

                entity.ToTable("Wechat_QRScene");

                entity.Property(e => e.BusinessId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ExpireTime).HasColumnType("datetime");

                entity.Property(e => e.SceneId).ValueGeneratedOnAdd();

                entity.Property(e => e.Ticket)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatQrscene1>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.WechatId });

                entity.ToTable("Wechat_QRScene1");

                entity.Property(e => e.BusinessId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ExpireTime).HasColumnType("datetime");

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ticket)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatQrsceneScanRecord>(entity =>
            {
                entity.ToTable("Wechat_QRSceneScanRecord");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatScanReply>(entity =>
            {
                entity.ToTable("Wechat_ScanReply");

                entity.Property(e => e.ArticleCount).HasMaxLength(10);

                entity.Property(e => e.Contents).HasMaxLength(300);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HqmusicUrl)
                    .HasColumnName("HQMusicUrl")
                    .HasMaxLength(10);

                entity.Property(e => e.ImageMediaId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.MusicDescription).HasMaxLength(10);

                entity.Property(e => e.MusicTitle).HasMaxLength(10);

                entity.Property(e => e.MusicUrl).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ReplyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoDescription).HasMaxLength(10);

                entity.Property(e => e.VideoMediaId).HasMaxLength(10);

                entity.Property(e => e.VideoTitle).HasMaxLength(10);

                entity.Property(e => e.VoiceMediaId).HasMaxLength(10);
            });

            modelBuilder.Entity<WechatTemplateMessage>(entity =>
            {
                entity.ToTable("Wechat_TemplateMessage");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(800);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeputyIndustry)
                    .HasColumnName("deputy_industry")
                    .HasMaxLength(50);

                entity.Property(e => e.Example)
                    .HasColumnName("example")
                    .HasMaxLength(800);

                entity.Property(e => e.PrimaryIndustry)
                    .HasColumnName("primary_industry")
                    .HasMaxLength(50);

                entity.Property(e => e.TemplateId)
                    .IsRequired()
                    .HasColumnName("template_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WechatUser>(entity =>
            {
                entity.ToTable("Wechat_User");

                entity.HasIndex(e => e.OpenId)
                    .HasName("IX_Wechat_User");

                entity.Property(e => e.AppUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.HeadImgUrl).HasMaxLength(300);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasColumnName("OpenID")
                    .HasMaxLength(100);

                entity.Property(e => e.Privilege).HasMaxLength(300);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(300);

                entity.Property(e => e.SubscribeTime).HasColumnType("datetime");

                entity.Property(e => e.UnionId).HasMaxLength(150);
            });

            modelBuilder.Entity<WorkFlow>(entity =>
            {
                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WorkFlowUser>(entity =>
            {
                entity.ToTable("WorkFlow_User");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WorkFlowUserExecute>(entity =>
            {
                entity.ToTable("WorkFlow_UserExecute");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WrokFlowModule>(entity =>
            {
                entity.ToTable("WrokFlow_Module");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(800);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WsTaskConfig>(entity =>
            {
                entity.HasKey(e => e.TaskName);

                entity.ToTable("WS_TaskConfig");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CycleMinute).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.Summary).HasMaxLength(50);

                entity.Property(e => e.TaskModel).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaskSpace)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WsTaskLog>(entity =>
            {
                entity.ToTable("WS_TaskLog");

                entity.HasIndex(e => e.TaskId)
                    .HasName("IX_WS_TaskLog");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.TaskLog).HasMaxLength(1000);

                entity.Property(e => e.TaskName).HasMaxLength(50);

                entity.Property(e => e.TaskTime).HasColumnType("datetime");
            });
        }
    }
}