using Godot;
using Scripts;
using System;
namespace Scenes;

[GlobalClass]
public partial class Main : Node3D
{
    public CsgCylinder3D Door;

    public override void _Ready()
    {
        Door = GetNode<CsgCylinder3D>("%Door");
        if (Door == null) GD.PushError("Missing door in intro scene.");

        SignalManager.Instance.IntroDoorOpened += () =>
        {
          Door.Operation = CsgShape3D.OperationEnum.Subtraction;
        };

    }
}
