using Entities.Player.HUD;
using Godot;
using Scripts;
namespace Entities.Player;

[GlobalClass]
public partial class Hotbar : Control
{
    private HBoxContainer _hotbarContainer;

    public override void _Ready()
    {
        _hotbarContainer = GetNode<HBoxContainer>("%HBoxContainer");
        
        for (int i = 0; i < _hotbarContainer.GetChildCount(); i++)
        {
            var slot = _hotbarContainer.GetChild(i) as Slot;
            slot.SetNumber(i + 1);
        }

        SignalManager.Instance.SlotUpdated += item =>
        {
            foreach (var slot in _hotbarContainer.GetChildren())
            {
                if (slot is Slot s)
                {
                    if (s.Stack == null)
                    {
                        s.Stack = item;
                        s.SetItem();
                        break;
                    }
                    else if (s.Stack.ConsumableItem == item.ConsumableItem)
                    {
                        s.SetItem();
                        break;
                    }
                }
            }
        };
    }
}