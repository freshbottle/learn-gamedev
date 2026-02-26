using Godot;
using System;

namespace Scripts.Resources.Items;

[GlobalClass]
public partial class EquippableItemResource : ItemResource
{
    public enum WeaponType
    {
        Pistol
    }

    public enum WeaponTier
    {
        Low,
        Medium,
        High,
        Rare,
        Legendary
    }

    [Export]
    public WeaponType type;

    [Export]
    public WeaponTier Tier;

    [Export]
    public float Damage;

    [Export]
    public float ReloadSpeed;

    [Export]
    public float FireRate;

    [Export]
    public float Range;

    [Export]
    public int MaxAmmo;

    [Export]
    public int CurrentAmmo = 0;
}
