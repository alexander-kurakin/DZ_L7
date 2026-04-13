using Assets._Project.Develop.Runtime.Meta.Features.Wallet;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class PeacefulClick
    {
        private readonly WalletService _walletService;

        public PeacefulClick(WalletService walletService)
        {
            _walletService = walletService;
        }

        public void TryPerformClick()
        {
            //TODO: config value for the Spend amount
            if (_walletService.Enough(CurrencyTypes.Gold, 50))
            {
                
                
                _walletService.Spend(CurrencyTypes.Gold, 50);
                //TODO: new service + method to spawn a mine
            }
        }
    }
}