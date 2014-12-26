using GameUtilities.Framework.DataContracts;
using System;
using GameUtilities.Worlds;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Entities.DataContracts;

namespace GameUtilitiesRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityData entityData = new EntityData("UnknownType", "GameUtilities.Entities.BaseEntity,GameUtilities");
            EntityDataSet entityDataSet = new EntityDataSet();
            entityDataSet.Add(entityData);
            WorldData worldData = new WorldData("TEST WORLD", "GameUtilities.Worlds.BaseWorld,GameUtilities",entityDataSet);
            BaseWorld world = new BaseWorld(worldData);
            world.Init();
            Console.ReadKey();
        }
    }
}
