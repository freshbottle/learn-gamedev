using Godot;
using System;

namespace Scripts.Components;
public partial class HurtboxComponent : Area3D
{
    [Export]
    public HealthComponent HealthComponent;

    public override void _Ready()
    {
        if (HealthComponent == null)
        {
            GD.PushError("Missing health component. Add one.");
            return;
        }
    }

    public void TakeDamage(float amount)
    {
        HealthComponent.TakeDamage(amount);
    }
}
