using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using _Project.Develop.Runtime.Gameplay.Features.Input;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public class PreparationTriggerService
    {
        private const float _rayDistance = 1000f;
        private readonly int _triggerLayerMask = 1 << LayerMask.NameToLayer("ContactTrigger");
        
        private ReactiveVariable<bool> _prepareTriggerClicked = new();

        private EntitiesFactory _entitiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;
        private IMouseInputService _mouseInputService;
        private IMouseRaycastService _mouseRaycastService;

        private Entity _nextStageTrigger;

        public PreparationTriggerService(
            EntitiesFactory entitiesFactory, 
            EntitiesLifeContext entitiesLifeContext,
            IMouseInputService mouseInputService,
            IMouseRaycastService mouseRaycastService)
        {
            _entitiesFactory = entitiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
            _mouseInputService = mouseInputService;
            _mouseRaycastService = mouseRaycastService;
        }

        public IReadOnlyVariable<bool> PrepareTriggerClicked => _prepareTriggerClicked;

        public void Create(Vector3 position)
        {
            if (_nextStageTrigger != null)
                throw new InvalidOperationException("Trigger already created");

            _nextStageTrigger = _entitiesFactory.CreateContactTrigger(position);
        }

        public void Update(float deltaTime)
        {
            if (_nextStageTrigger == null 
                || _mouseInputService.IsEnabled == false
                || _mouseInputService.FireButtonPressed == false
                || _mouseRaycastService.TryGetHit(_mouseInputService.PointerScreenPosition, out RaycastHit hit, _rayDistance, _triggerLayerMask) == false)
            
            {
                _prepareTriggerClicked.Value = false;
                return;
            }
            
            _prepareTriggerClicked.Value = hit.collider != null && hit.collider == _nextStageTrigger.BodyCollider;
        }

        public void Cleanup()
        {
            _entitiesLifeContext.Release(_nextStageTrigger);
            _prepareTriggerClicked.Value = false;
            _nextStageTrigger = null;
        }
    }
}
