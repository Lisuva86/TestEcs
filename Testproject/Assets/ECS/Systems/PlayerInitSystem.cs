using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            int playrEntity = world.NewEntity();

            GameObject playerGo = GameObject.FindGameObjectWithTag("Player");

            EcsPool<PlayerComponent> playerPool = world.GetPool<PlayerComponent>();
            playerPool.Add(playrEntity);
            ref PlayerComponent playerComp = ref playerPool.Get(playrEntity);
            // ref var playerComp = ref playerPool.Add(entity);
            playerComp.name = playerGo.name;

            EcsPool<ViewComponent> viewPool = world.GetPool<ViewComponent>();
            ref ViewComponent viewComp = ref viewPool.Add(playrEntity);
            viewComp.Rigidbody = playerGo.GetComponent<Rigidbody>();

            var movePool = world.GetPool<MoveComponent>();
            ref var moveComp = ref movePool.Add(playrEntity);
            moveComp.Speed = 10f;
        }
    }
}