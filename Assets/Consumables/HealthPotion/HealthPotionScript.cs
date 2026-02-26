using Godot;
using Scripts.InteractionSystem;
using Scripts.InventorySystem;
using Scripts.Resources.Items;

namespace Assets.Consumables;

public partial class HealthPotionScript : RigidBody3D
{
    [Export]
    private InteractionArea interactionArea;

    [Export]
    private ConsumableItemResource _itemData;

    public override void _Ready()
    {
        if (interactionArea == null)
        {
            GD.PushError("Missing interaction area.");
            return;  
        }

        interactionArea.Interacted += PickUp;
    }

    private void PickUp()
    {
        InventorySystem.Instance.AddConsumable(_itemData);
        QueueFree();
    }
}
