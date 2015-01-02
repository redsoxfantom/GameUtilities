using GameUtilities.Framework.DataContracts;
using System;
using GameUtilities.Worlds;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Framework;
using System.Collections.Generic;

namespace GameUtilitiesRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityData entityData = new EntityData("Entity1Type", "GameUtilities.Entities.BaseEntity,GameUtilities");
            List<EntityData> entityDataSet = new List<EntityData>();
            entityDataSet.Add(entityData);
            WorldData worldData = new WorldData("TEST WORLD", "GameUtilities.Worlds.BaseWorld,GameUtilities",entityDataSet);
            BaseWorld world = new BaseWorld(worldData);
            ExecutableContext mContext = new ExecutableContext(".\\Config");

            world.Init(mContext);
            Console.ReadKey();
        }
    }
}
