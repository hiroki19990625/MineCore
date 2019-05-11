﻿using System;
using System.Net;
using MineCore.Net;
using MineCore.Net.Protocols;
using MineCore.Net.Protocols.Defaults;
using MineCore.Utils;
using NLog;

namespace MineCore.Entities.Impl
{
    public class Player : IPlayer
    {
        public IPEndPoint EndPoint { get; private set; }

        public long EntityId { get; }
        public long EntityRuntimeId { get; }

        public void HandleDataPacket(DataPacket packet)
        {
            packet.ThrownOnArgNull(nameof(packet));

            if (packet is LoginPacket loginPacket)
            {
                LogManager.GetCurrentClassLogger().Info(loginPacket.Protocol);
            }
        }

        public void Dispose()
        {
        }
    }
}