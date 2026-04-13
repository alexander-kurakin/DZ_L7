using _Project.Develop.Runtime.Gameplay.Features.DealAreaDamage;
using _Project.Develop.Runtime.Gameplay.Features.Input;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class CombatClick
    {
        private const float _rayDistance = 1000f; //config?
        private readonly int _clickLayerMask = LayerMask.GetMask("ContactTrigger", "Floor", "Characters"); //config?
        private readonly int _damageableLayerMask = 1 <<  LayerMask.NameToLayer("Characters"); //config?
        
        private readonly AreaDamageService _areaDamageService;
        private readonly MouseInput _mouseInput;
        private readonly MouseRaycastService _mouseRaycastService;
        private readonly MainHeroHolderService _mainHeroHolderService;

        public CombatClick(
            AreaDamageService areaDamageService, 
            MouseInput mouseInput, 
            MouseRaycastService mouseRaycastService,
            MainHeroHolderService mainHeroHolderService)
        {
            _areaDamageService = areaDamageService;
            _mouseInput = mouseInput;
            _mouseRaycastService = mouseRaycastService;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public void TryPerformClick()
        {
            if (_mouseRaycastService.TryGetHit(_mouseInput.PointerScreenPosition, out RaycastHit hit, _rayDistance,
                    _clickLayerMask) == false)
                return;

            _areaDamageService.ApplySphereDamage(
                hit.point,
                5f, //config
                100f, //config
                _damageableLayerMask,
                _mainHeroHolderService.MainHero);
        }
    }
}