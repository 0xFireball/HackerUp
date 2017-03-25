using HackerUp.Server.Configuration.Access;
using LiteDB;
using OsmiumSubstrate.Configuration;

namespace HackerUp.Server.Configuration
{
    public class HUServerContext : IHUServerContext
    {
        public HUServerParameters Parameters { get; }

        public LiteDatabase Database { get; private set; }

        public HUServerContext(HUServerParameters serverParameters)
        {
            Parameters = serverParameters;
        }

         // Persistent State
        public HUServerState ServerState { get; internal set; }

        ISubstrateServerState<HUAccessKey, HUApiAccessScope> ISubstrateServerContext<HUAccessKey, HUApiAccessScope>.SubstrateServerState => ServerState;

        public void ConnectDatabase()
        {
            Database = new LiteDatabase(Parameters.DatabaseConfiguration.FileName);
        }
    }
}