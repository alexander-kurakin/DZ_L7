using _Project.Develop.Runtime.Gameplay.Features.Input;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class MouseClickActions
    {
        private readonly GameplayActionSetService _actionSetService;
        private readonly CombatClick _combatClick;
        private readonly PeacefulClick _peacefulClick;

        public MouseClickActions(
            GameplayActionSetService actionSetService,
            CombatClick combatClick,
            PeacefulClick peacefulClick)
        {
            _actionSetService = actionSetService;
            _combatClick = combatClick;
            _peacefulClick = peacefulClick;
        }

        public void Update(float deltaTime)
        {
            ActionSet actionMode = _actionSetService.CurrentActionSet.Value;

            if (actionMode == ActionSet.Combat)
            {
                _peacefulClick.TryPerformClick();
            }
            else
            {
                _combatClick.TryPerformClick();

            }
        }
    }
}