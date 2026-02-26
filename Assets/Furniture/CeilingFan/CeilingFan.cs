using Godot;
using System;

public partial class CeilingFan : Node3D
{
    private MeshInstance3D _fan;

    public override void _Ready()
    {
        _fan = GetNode<MeshInstance3D>("Fan");
    }

    public override void _Process(double delta)
    {
        _fan.RotateY(1.2f * (float)delta);
    }
}