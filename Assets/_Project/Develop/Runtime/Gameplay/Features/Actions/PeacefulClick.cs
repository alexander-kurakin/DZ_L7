using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class PeacefulClick
    {
        private readonly WalletService _walletService;
        private readonly EntitiesFactory  _entitiesFactory;

        public PeacefulClick(
            WalletService walletService,
            EntitiesFactory entitiesFactory)
        {
            _walletService = walletService;
            _entitiesFactory = entitiesFactory;
        }

        public void TryPerformClick(RaycastHit raycastHit)
        {
            if (_walletService.Enough(CurrencyTypes.Gold, 50)) //config
            {
                _walletService.Spend(CurrencyTypes.Gold, 50); //config
                _entitiesFactory.CreateMine(raycastHit.point);
            }
        }
    }
}