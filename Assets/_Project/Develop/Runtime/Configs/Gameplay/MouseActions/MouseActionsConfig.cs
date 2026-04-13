using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.MouseActions
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/MouseActions/NewMouseActionsConfig", fileName = "MouseActionsConfig")]
    public class MouseActionsConfig : ScriptableObject
    {
        [field: SerializeField, Min(0)] public float TowerExplosionDamage { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float TowerExplosionRadius { get; private set; } = 5;
        
        [field: SerializeField] public LayerMask TowerExplosionDamageableLayerMask { get; private set; } 
            = LayerMask.GetMask("Characters");

        [field: SerializeField] public LayerMask GenericLayerMask { get; private set; } 
            = LayerMask.GetMask("ContactTrigger", "Floor", "Characters");
        
        [field: SerializeField] public int FloorLayerIndex { get; private set; } 
              = LayerMask.NameToLayer("Floor");
        
        [field: SerializeField, Min(0)] public float MouseRaycastDistance { get; private set; } = 1000;
        
        [field: SerializeField] public LayerMask ContactTriggerLayerMask { get; private set; } 
            = LayerMask.GetMask("ContactTrigger");
        
        [field: SerializeField] public Vector3 ContactTriggerStartPosition { get; private set; } 
            = new Vector3(0,0,-30);

    }
}