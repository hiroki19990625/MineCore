﻿namespace MineCore.Entities.Impl
{
    public class Entity : IEntity
    {
        public long EntityId { get; }
        public long EntityRuntimeId { get; }
        public void Close()
        {
            throw new System.NotImplementedException();
        }
    }
}