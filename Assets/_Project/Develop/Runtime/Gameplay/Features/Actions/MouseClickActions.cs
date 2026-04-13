using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.Actions
{
    public class MouseClickActions
    {
        private readonly GameplayActionSetService _actionSetService;
        private readonly CombatClick _combatClick;
        private readonly PeacefulClick _peacefulClick;
        private readonly MouseInput _mouseInput;

        public MouseClickActions(
            GameplayActionSetService actionSetService,
            CombatClick combatClick,
            PeacefulClick peacefulClick,
            MouseInput mouseInput)
        {
            _actionSetService = actionSetService;
            _combatClick = combatClick;
            _peacefulClick = peacefulClick;
            _mouseInput = mouseInput;
        }

        public void Update(float deltaTime)
        {
            ActionSet actionMode = _actionSetService.CurrentActionSet.Value;

            if (actionMode == ActionSet.Combat)
            {
                if (_mouseInput.FireButtonPressed)
                    _combatClick.TryPerformClick();
            }
            else
            {
                if (_mouseInput.FireButtonPressed)
                    _peacefulClick.TryPerformClick();
            }
        }
    }
}