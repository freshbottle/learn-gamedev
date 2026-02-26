using Godot;
using System;

namespace Scripts.Resources.Items;
[GlobalClass]   
public partial class ItemStack : Resource
{
    [Export]
    public ItemResource Item;
    
    [Export]
    public ConsumableItemResource ConsumableItem;

    [Export]
    public int Amount;

    public ItemStack(ItemResource item, int amount = 1)
    {
        this.Item = item;
        Amount = amount;
    }

    public ItemStack(ConsumableItemResource consumable, int amount = 1)
    {
        this.ConsumableItem = consumable;
        this.Amount = amount;
    }
}
