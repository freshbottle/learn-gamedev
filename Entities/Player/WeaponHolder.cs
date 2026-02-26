using Assets.Weapons;
using Godot;
using Scripts;
using Scripts.Resources.Items;
using System;

namespace Entities.Player;

[GlobalClass]
public partial class WeaponHolder : Node3D
{
    [Export]
    public PlayerScript Player;

    [Export]
    public Pistol CurrentWeapon = null;

    public override void _Ready()
    {
        SignalManager.Instance.EquippedWeapon += weapon =>
        {
          Player.HasWeapon = true;
          AddChild(weapon.Instantiate());
          CurrentWeapon = GetChild(0) as Pistol;
          SignalManager.Instance.EmitSignal(nameof(SignalManager.SetWeapon));
        };
    }
}
