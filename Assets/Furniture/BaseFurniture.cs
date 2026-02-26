using Godot;
using Scripts.InteractionSystem;
using System;

namespace Assets.Furniture;
[GlobalClass]
public abstract partial class BaseFurniture : StaticBody3D
{
    [Export]
    protected InteractionArea InteractArea;
}
