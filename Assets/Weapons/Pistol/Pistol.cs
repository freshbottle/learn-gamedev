using System.Collections;
using Godot;
using Scripts;
using Scripts.InteractionSystem;
using Scripts.InventorySystem;
using Scripts.Resources.Items;

namespace Assets.Weapons;

[GlobalClass]
public partial class Pistol : Node3D
{
    [Export]
    public EquippableItemResource WeaponData;

    [Export]
    private InteractionArea _area;
    private MeshInstance3D _sphere;

    public override void _Ready()
    {
        _sphere = GetNode<MeshInstance3D>("Sphere");
        if (_area == null) GD.PushError("Pistol missing interaction area.");
        _area.Interacted += () => 
        {
            InventorySystem.Instance.AddWeapon(WeaponData);
            InventorySystem.Instance.PrintWeapons();
            var pistolScene = GD.Load<PackedScene>("res://Assets/Weapons/Pistol/Pistol.tscn");
            SignalManager.Instance.EmitSignal(nameof(SignalManager.EquippedWeapon), pistolScene);
            SignalManager.Instance.EmitSignal(nameof(SignalManager.IntroDoorOpened));
            QueueFree();
        };
    }

    public override void _Process(double delta)
    {
        _sphere.RotateY(0.5f * (float)delta);
        _sphere.RotateX(-0.5f * (float)delta);
        _sphere.RotateZ(0.5f * (float)delta);
    }
}
