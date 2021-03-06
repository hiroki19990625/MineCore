﻿using MineCore.Languages;
using MineCore.Utils;

namespace MineCore.Net.Impl
{
    public class ServerListData : IServerListData
    {
        public string Platform { get; } = StringManager.GetString("minecore.list.platform");

        public string ServerName { get; set; }

        public int ProtocolNumber { get; }

        public string Version { get; }

        public int JoinedPlayer { get; set; } = 0;

        public int MaxPlayer { get; set; } = 20;

        public string SystemName { get; } = StringManager.GetString("minecore.list.systemName");

        public string ServerSubName { get; set; }

        public ServerListData(IMineCraftProtocol protocol)
        {
            protocol.ThrownOnArgNull(nameof(protocol));

            ProtocolNumber = protocol.ProtocolNumber;
            Version = protocol.Version;
        }

        public string GetString()
        {
            return
                $"{Platform};{ServerName};{ProtocolNumber};{Version};{JoinedPlayer};{MaxPlayer};{SystemName};{ServerSubName}";
        }
    }
}