using _Project.Develop.Runtime.Configs.Gameplay.MouseActions;
using _Project.Develop.Runtime.Gameplay.Features.Actions;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class PreparationState : State, IUpdatableState
    {
        private readonly PreparationTriggerService _preparationTriggerService;
        private readonly GameplayActionSetService _actionSetService;
        private readonly MouseActionsConfig _mouseActionsConfig;

        public PreparationState(
            PreparationTriggerService preparationTriggerService, 
            GameplayActionSetService actionSetService,
            ConfigsProviderService  configsProviderService)
        {
            _preparationTriggerService = preparationTriggerService;
            _actionSetService = actionSetService;
            _mouseActionsConfig = configsProviderService.GetConfig<MouseActionsConfig>();
        }

        public override void Enter()
        {
            base.Enter();
            
            _actionSetService.SetActionSet(ActionSet.Peaceful);

            _preparationTriggerService.Create(_mouseActionsConfig.ContactTriggerStartPosition);
        }

        public void Update(float deltaTime)
        {
            _preparationTriggerService.Update(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _preparationTriggerService.Cleanup();
        }
    }
}
