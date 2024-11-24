

using System.Net;

namespace Idm.Infrastructure.Data
{
    internal class InitialData
    {
       public static IEnumerable<User> Users =>
       new List<User>
       {
           User.Create(UserId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),"Harihara","Narayanan","ITD", DateTime.Now.AddDays(-30),"Archana",EmployeeType.Staff),
           User.Create(UserId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "Indhumathi", "Murugasen","ITD", DateTime.Now,"Harihara",EmployeeType.Contractor)
       };

        public static IEnumerable<TargetSystem> TargetSystemsWithDetails
        {
            get
            {

                var cosmosdb = TargetSystem.Create(TargetSystemId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TargetSystemType.CosmosDb, "CosmosDb", "CosmosDb", "Azure Cosmos Database System");


                cosmosdb.Add(TargetSystemId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "EndPointUrl", "");
                cosmosdb.Add(TargetSystemId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "AccessKey", "");
                cosmosdb.Add(TargetSystemId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "DatabaseName", "");


                var mongodb = TargetSystem.Create(TargetSystemId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), TargetSystemType.MongoDb, "MongoDb", "MongoDb", "Mongo Database System");

                mongodb.Add(TargetSystemId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Username", "");
                mongodb.Add(TargetSystemId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Password", "");
                mongodb.Add(TargetSystemId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Hostname", "");
                mongodb.Add(TargetSystemId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "PortNo", "");

                return new List<TargetSystem> { cosmosdb, mongodb };
            }
        }
    }
}
