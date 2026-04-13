using _Project.Develop.Runtime.Gameplay.Features.Input;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class MouseClickActions
    {
        private const float RayDistance = 1000f; //config?
        private readonly int _combatLayerMask = LayerMask.GetMask("ContactTrigger", "Floor", "Characters"); //config?
        private readonly int _peacefulLayerMask = LayerMask.GetMask("Floor");
        
        
        private readonly GameplayActionSetService _actionSetService;
        private readonly CombatClick _combatClick;
        private readonly PeacefulClick _peacefulClick;
        private readonly MouseInput _mouseInput;
        private readonly MouseRaycastService _mouseRaycastService;

        private int _clickLayerMask;
        private RaycastHit _raycastHit;


        public MouseClickActions(
            GameplayActionSetService actionSetService,
            CombatClick combatClick,
            PeacefulClick peacefulClick,
            MouseInput mouseInput,
            MouseRaycastService mouseRaycastService)
        {
            _actionSetService = actionSetService;
            _combatClick = combatClick;
            _peacefulClick = peacefulClick;
            _mouseInput = mouseInput;
            _mouseRaycastService = mouseRaycastService;
        }

        public void Update(float deltaTime)
        {
            ActionSet actionMode = _actionSetService.CurrentActionSet.Value;
            
            _clickLayerMask = actionMode==ActionSet.Peaceful ? _peacefulLayerMask : _combatLayerMask;
            
            if (TryGetClick(_clickLayerMask))
            {
                if (actionMode == ActionSet.Combat)
                {
                    if (_mouseInput.FireButtonPressed)
                        _combatClick.TryPerformClick(_raycastHit);
                }
                else
                {
                    if (_mouseInput.FireButtonPressed)
                        _peacefulClick.TryPerformClick(_raycastHit);
                }
            }
        }

        private bool TryGetClick(LayerMask clickLayerMask)
        {
            if (_mouseRaycastService.TryGetHit(
                    _mouseInput.PointerScreenPosition, 
                    out RaycastHit hit, 
                    RayDistance,
                    clickLayerMask))
            {
                _raycastHit = hit;
                return true;
            }

            return false;
        }
    }
}