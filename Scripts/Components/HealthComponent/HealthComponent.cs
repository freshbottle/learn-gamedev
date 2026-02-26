using Godot;
using System;

namespace Scripts.Components;
public partial class HealthComponent : BaseComponent
{
    [Signal]
    public delegate void DestroyedEventHandler();

    [Export]
    public float Health;

    public void TakeDamage(float amount)
    {
        Health = Mathf.Max(Health - amount, 0);
        GD.Print(Health);
        
        if (IsDestroyed())
        {
            EmitSignal(SignalName.Destroyed);
            GetParent().QueueFree();
        }
    }

    public bool IsDestroyed()
    {
        return Health <= 0;
    }
}