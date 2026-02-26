using Godot;
using Scripts.Resources.Items;

namespace Scripts;

[GlobalClass]
public partial class SignalManager : Node
{
	public static SignalManager Instance { get; private set; }

	// --- Signals ---
    [Signal]
    public delegate void SlotUpdatedEventHandler(ItemStack item);

    [Signal]
    public delegate void WeaponDataUpdatedEventHandler(EquippableItemResource weapon);

    [Signal]
    public delegate void EquippedWeaponEventHandler(PackedScene weaponNode);

    [Signal]
    public delegate void SetWeaponEventHandler();
    
    public override void _Ready()
    {
        Instance = this;
    }
}