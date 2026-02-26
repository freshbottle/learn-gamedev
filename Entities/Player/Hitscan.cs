using Godot;
using Scripts;
using Scripts.Components;
using Scripts.InventorySystem;
using Scripts.Resources.Items;
using System;

namespace Entities.Player;
public partial class Hitscan : RayCast3D
{   
    /* 
        This script controls all the logic behind gun gameplay:
            - Which gun is currently active
            - Set all the properites of the current gun
            - Animation for shooting
    */

    [Export]
    private PlayerScript _player;

    // If this is null, nothing in will run.
    [Export]
    private WeaponHolder _weaponHolder;

    // Stores the data of the weapon in a global scope to access it everywhere.
    [Export]
    private EquippableItemResource _weaponData;

    private Timer _cooldown;
    private Timer _reload;
    private bool _readyToFire = true;

    public override void _Ready()
    {
        // --- Weapon's cooldown ---
        _cooldown = GetNode<Timer>("Cooldown");
        if (_cooldown == null) GD.PushError("Missing cooldown timer. Add one.");
        _cooldown.Timeout += () => 
        {
            _readyToFire = true;
            GD.Print($"Ready to fire? {_readyToFire}");
        };

        // --- Reload ---
        _reload = GetNode<Timer>("Reload");
        if (_reload == null) GD.PushError("Missing reload timer. Add one.");
        _reload.Timeout += () =>
        {
            _readyToFire = true;
            var weapon = InventorySystem.Instance.GetWeapon(EquippableItemResource.WeaponType.Pistol);
            weapon.CurrentAmmo = weapon.MaxAmmo;
            SignalManager.Instance.EmitSignal(nameof(SignalManager.WeaponDataUpdated), weapon);
        };


        // Only runs when a new weapon is added to the player.
        SignalManager.Instance.SetWeapon += () =>
        {
            // --- Set weapon properties to the timer
            var currentWeapon = _weaponHolder.CurrentWeapon.WeaponData;
            _cooldown.WaitTime = currentWeapon.FireRate;
            _cooldown.OneShot = true;
            _reload.WaitTime = currentWeapon.ReloadSpeed;
            _reload.OneShot = true;

            _weaponData = currentWeapon;
        };
    }


    public override void _Process(double delta)
    {   
        if (Input.IsActionJustPressed("Reload") && _weaponData != null)
        {
            Reload(_weaponData);
        }

        if (Input.IsActionJustPressed("LeftClick") && 
            _weaponHolder.CurrentWeapon != null && 
            _player.CanShoot && _readyToFire)
        {   
            _weaponData.CurrentAmmo--;

            if (_weaponData.CurrentAmmo <= 0)
            {
                Reload(_weaponData);
                return;
            }
            
            EnteredCooldown(_weaponData);

            if (IsColliding())
            {
                var collider = GetCollider();
                GD.Print(collider);
                if (collider is HurtboxComponent hurtbox)
                {
                    hurtbox.TakeDamage(_weaponHolder.CurrentWeapon.WeaponData.Damage);       
                }

            }
            else
            {
                GD.Print("Missed shots!");
            }
        }
    }
    
    private void EnteredCooldown(EquippableItemResource weapon)
    {
        _cooldown.Start();
        _readyToFire = false;
        SignalManager.Instance.EmitSignal(nameof(SignalManager.WeaponDataUpdated), weapon);
    }

    private void Reload(EquippableItemResource weapon)
    {
        _cooldown.Stop();
        _reload.Start();
        _readyToFire = false;
        weapon.CurrentAmmo = 0;
        SignalManager.Instance.EmitSignal(nameof(SignalManager.WeaponDataUpdated), weapon);
        GD.Print("Reloading...");
    }
}
