using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using DoAn.Entities;

namespace DoAn.DataAccessLayer
{
    public static class CassandraConnection
    {
        private static Cluster cluster;
        private static ISession session;

        public static ISession GetSession()
        {
            if (session == null)
            {
                cluster = Cluster.Builder()
                          .AddContactPoint("127.0.0.1")  // Địa chỉ localhost
                          .WithPort(9042)                // Cổng 9042
                          .Build();
                session = cluster.Connect("demo"); // Kết nối tới keyspace "demo"
            }
            return session;
        }
    }
}
