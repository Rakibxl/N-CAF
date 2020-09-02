using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Extensions;

namespace Architecture.BLL.Services.Notification
{
    public class NotificationService : IHostedService
    {
        //    private readonly SqlDependencyEx listener1;
        //    private readonly SqlDependencyEx listener2;
        //private LMSDbContext lMSDbContext;
        //private readonly IServiceScopeFactory serviceScopeFactory;
        //private IServiceRequisitionService serviceRequisitionService;

        public NotificationService(IServiceScopeFactory serviceScopeFactory
            )
        {
            //this.serviceScopeFactory = serviceScopeFactory;
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
                //lMSDbContext = scope.ServiceProvider.GetService<LMSDbContext>();
                //var appdb = scope.ServiceProvider.GetService<ApplicationDbContext>().Database.GetDbConnection().ConnectionString;
                //var mapping1 = lMSDbContext.Model.FindEntityType(typeof(LeadApplicableCluster));
                //var mapping2 = lMSDbContext.Model.FindEntityType(typeof(LeadMstrDtl));
                //var mapping3 = lMSDbContext.Model.FindEntityType(typeof(LeadApplicableCluster));

                //listener1 = new SqlDependencyEx(
                //    lMSDbContext.Database.GetDbConnection().ConnectionString
                //    , lMSDbContext.Database.GetDbConnection().Database
                //    , mapping1.GetTableName(), listenerType: SqlDependencyEx.NotificationTypes.Insert, identity: 1);

                //listener2 = new SqlDependencyEx(
                //    lMSDbContext.Database.GetDbConnection().ConnectionString
                //    , lMSDbContext.Database.GetDbConnection().Database
                //    , mapping2.GetTableName(), listenerType: SqlDependencyEx.NotificationTypes.Update, identity: 2);

                //listener3 = new SqlDependencyEx(
                //    lMSDbContext.Database.GetDbConnection().ConnectionString
                //    , lMSDbContext.Database.GetDbConnection().Database
                //    , mapping3.GetTableName(), listenerType: SqlDependencyEx.NotificationTypes.Insert, identity: 3);
            //}
        }

        public void GetChanges()
        {
            //listener1.TableChanged += (o, e) =>
            //{
            //    SendNotification(e);
            //};
            //listener1.Start();

            //listener2.TableChanged += (o, e) =>
            //{
            //    UpdateUserLoyaltyPoint(e);
            //    UpdateLeadStatus(e);
            //};
            //listener2.Start();

            //listener3.TableChanged += (o, e) =>
            //{
            //    SendNotification(e);
            //};
            //listener3.Start();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //GetChanges();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //listener1.Stop();
            //listener2.Stop();
            //listener3.Stop();
            return Task.CompletedTask;
        }

        //private void SendNotification(SqlDependencyEx.TableChangedEventArgs e)
        //{
        //    //root
        //    foreach (var node in e.Data.Elements())
        //    {
        //        //inserted
        //        foreach (var node1 in node.Elements())
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(Row));
        //            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(node1.ToString()));
        //            Row resultingMessage = (Row)serializer.Deserialize(memStream);

        //            using (var scope = serviceScopeFactory.CreateScope())
        //            {
        //                serviceRequisitionService = scope.ServiceProvider.GetService<IServiceRequisitionService>();
        //                serviceRequisitionService.UpdateColorConsultant(resultingMessage.Lac_user_id, resultingMessage.Lac_lead_detail_id);

        //            }
        //        }
        //    }
        //}

        //private void UpdateLeadStatus(SqlDependencyEx.TableChangedEventArgs e)
        //{
        //    var insertedData = new Row();
        //    var deletedData = new Row();
        //    var isInsertedData = true;
        //    var isDeletedData = false;

        //    //root
        //    foreach (var node in e.Data.Elements())
        //    {
        //        //inserted/deleted
        //        foreach (var node1 in node.Elements())
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(Row));
        //            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(node1.ToString()));
        //            Row resultingMessage = (Row)serializer.Deserialize(memStream);
        //            if (isInsertedData)
        //            {
        //                isInsertedData = false;
        //                isDeletedData = true;
        //                insertedData = resultingMessage;
        //            }
        //            else if (isDeletedData)
        //            {
        //                isDeletedData = false;
        //                deletedData = resultingMessage;
        //            }
        //        }
        //    }

        //    if (insertedData.Ld_stage != deletedData.Ld_stage)
        //    {
        //        string message = "";
        //        using (var scope = serviceScopeFactory.CreateScope())
        //        {
        //            var serviceRequisitionService = scope.ServiceProvider.GetService<IServiceRequisitionService>();
        //            serviceRequisitionService.UpdateStatus(insertedData.Ld_lead_detail_id, insertedData.Ld_stage, out message);
        //            LoggerExtension.ToWriteLog(message);
        //        }
        //    }
        //}

        //private void UpdateUserLoyaltyPoint(SqlDependencyEx.TableChangedEventArgs e)
        //{
        //    var insertedData = new Row();
        //    var deletedData = new Row();
        //    var isInsertedData = true;
        //    var isDeletedData = false;

        //    //root
        //    foreach (var node in e.Data.Elements())
        //    {
        //        //inserted/deleted
        //        foreach (var node1 in node.Elements())
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(Row));
        //            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(node1.ToString()));
        //            Row resultingMessage = (Row)serializer.Deserialize(memStream);
        //            if (isInsertedData)
        //            {
        //                isInsertedData = false;
        //                isDeletedData = true;
        //                insertedData = resultingMessage;
        //            }
        //            else if (isDeletedData)
        //            {
        //                isDeletedData = false;
        //                deletedData = resultingMessage;
        //            }
        //        }
        //    }

        //    if (insertedData.Ld_stage != deletedData.Ld_stage && insertedData.Active == "Y" && insertedData.Ld_stage == "LS_05")
        //    {
        //        using (var scope = serviceScopeFactory.CreateScope())
        //        {
        //            var userLoyaltyProgramPointService = scope.ServiceProvider.GetService<IUserLoyaltyProgramPointService>();
        //            userLoyaltyProgramPointService.UpdateUserLoyaltyPoint(insertedData.Ld_lead_detail_guid);
        //        }
        //    }
        //}
    }

    [XmlRoot(ElementName = "row")]
    public class Row
    {
        [XmlElement(ElementName = "lac_id")]
        public string Lac_id { get; set; }
        [XmlElement(ElementName = "lac_lead_detail_guid")]
        public string Lac_lead_detail_guid { get; set; }
        [XmlElement(ElementName = "lac_lead_detail_id")]
        public string Lac_lead_detail_id { get; set; }
        [XmlElement(ElementName = "lac_cl_code")]
        public string Lac_cl_code { get; set; }
        [XmlElement(ElementName = "lac_group_id")]
        public string Lac_group_id { get; set; }
        [XmlElement(ElementName = "created_user")]
        public string Created_user { get; set; }
        [XmlElement(ElementName = "created_date")]
        public string Created_date { get; set; }
        [XmlElement(ElementName = "active")]
        public string Active { get; set; }
        [XmlElement(ElementName = "lac_activated_date")]
        public string Lac_activated_date { get; set; }
        [XmlElement(ElementName = "lac_user_id")]
        public string Lac_user_id { get; set; }

        //---------- Lead Mstr Dtl -----------
        [XmlElement(ElementName = "ld_lead_detail_guid")]
        public string Ld_lead_detail_guid { get; set; }
        [XmlElement(ElementName = "ld_stage")]
        public string Ld_stage { get; set; }
        [XmlElement(ElementName = "ld_lead_detail_id")]
        public string Ld_lead_detail_id { get; set; }
    }
}
