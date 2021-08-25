using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedFilters;
using UnityEngine;

namespace Client
{
    sealed class PlayerMoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilterExt<PlayerComponent, ViewComponent, MoveComponent> _ecsFilter;

        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
            _ecsFilter.Validate(world);
        } 

        public void Run(EcsSystems systems)
        {
            foreach (var entity in _ecsFilter.Filter())
            {
                ref var viewComp = ref _ecsFilter.Inc2().Get(entity);
                ref var moveComp = ref _ecsFilter.Inc3().Get(entity);

                moveComp.Direction = Vector3.zero;

                if (Input.GetKey(KeyCode.W))
                {
                    moveComp.Direction = Vector3.forward;
                }

                viewComp.Rigidbody.velocity = moveComp.Direction * moveComp.Speed;
            }
        }
    }
}