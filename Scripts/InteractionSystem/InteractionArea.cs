using Godot;
using System;

namespace Scripts.InteractionSystem;

[GlobalClass]
public partial class InteractionArea : Area3D
{
    [Signal]
    public delegate void InteractedEventHandler();

    public void Interact()
    {   
        EmitSignal(SignalName.Interacted);
    } 
}
