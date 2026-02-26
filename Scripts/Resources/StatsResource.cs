using Godot;
using System;

namespace Scripts.Resources;

[GlobalClass]
public partial class StatsResource : Resource
{
    [Export]
    public float Strength = 0f;

    [Export]
    public float Agility = 0f;

    [Export]
    public float Stamina = 0f;

    [Export]
    public float MoveSpeed = 0f;

    [Export]
    public float JumpForce = 0f;

}
