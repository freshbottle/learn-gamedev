using Godot;
using Scripts;
using Scripts.Resources.Items;
using System;

namespace Entities.Player.HUD;
public partial class WeaponSlot : Panel
{
    private TextureRect _weaponIcon;
    private Label _ammoLabel;

    public override void _Ready()
    {
        _weaponIcon = GetNode<TextureRect>("WeaponIcon");
        _ammoLabel = GetNode<Label>("AmmoLabel");

        SignalManager.Instance.WeaponDataUpdated += UpdateWeaponSlot;
    }

    private void UpdateWeaponSlot(EquippableItemResource weapon)
    {
        _weaponIcon.Texture = weapon.Image;
        _ammoLabel.Text = $"{weapon.CurrentAmmo} / {weapon.MaxAmmo}";
    }
}
