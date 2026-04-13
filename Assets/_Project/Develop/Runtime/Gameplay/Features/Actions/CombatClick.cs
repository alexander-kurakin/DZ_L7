using _Project.Develop.Runtime.Gameplay.Features.DealAreaDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class CombatClick
    {
        private readonly int _damageableLayerMask = LayerMask.GetMask("Characters");
        
        private readonly AreaDamageService _areaDamageService;
        private readonly MainHeroHolderService _mainHeroHolderService;

        public CombatClick(
            AreaDamageService areaDamageService, 
            MainHeroHolderService mainHeroHolderService)
        {
            _areaDamageService = areaDamageService;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public void TryPerformClick(RaycastHit hit)
        {
            _areaDamageService.ApplySphereDamage(
                hit.point,
                5f, //config
                100f, //config
                _damageableLayerMask,
                _mainHeroHolderService.MainHero);
        }
    }
}