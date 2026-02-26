using Godot;
using Scripts.Resources.Items;

namespace Scripts;

[GlobalClass]
public partial class SignalManager : Node
{
	public static SignalManager Instance { get; private set; }

	// --- Items/Weapon signals ---
    [Signal]
    public delegate void SlotUpdatedEventHandler(ItemStack item);
    [Signal]
    public delegate void WeaponDataUpdatedEventHandler(EquippableItemResource weapon);
    [Signal]
    public delegate void EquippedWeaponEventHandler(PackedScene weaponNode);
    [Signal]
    public delegate void SetWeaponEventHandler();

    // --- Game state signals ---
    [Signal]
    public delegate void IntroDoorOpenedEventHandler();
    
    public override void _Ready()
    {
        Instance = this;
    }
}