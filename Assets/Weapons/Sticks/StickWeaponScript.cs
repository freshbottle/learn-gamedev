using Godot;
using Scripts.InteractionSystem;
using Scripts.InventorySystem;
using Scripts.Resources.Items;
using System;

namespace Assets.Weapons;
public partial class StickWeaponScript : StaticBody3D
{
    [Export]
    private EquippableItemResource _itemData;

    [Export]
    private InteractionArea _interactionArea;


    public override void _Ready()
    {
        _interactionArea.Interacted += PickUp;
    }

    private void PickUp()
    {
        InventorySystem.Instance.AddWeapon(_itemData);
        QueueFree();
    }
}
