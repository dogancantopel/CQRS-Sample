using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Helper
{
    public class MongoDbSettings
    {
        public class RemPeopleMongoDbSettings : IRemPeopleMongoDbSettings
        {
            string IRemPeopleMongoDbSettings.ProjectsCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            string IRemPeopleMongoDbSettings.ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            string IRemPeopleMongoDbSettings.DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
        public interface IRemPeopleMongoDbSettings
        {
            string ProjectsCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
    }
}
