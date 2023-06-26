using Godot;
using System;

public partial class CoffeeBean : Bean
{
    public CoffeeBean(String Name, Node MainNode, String TexturePath, int Count) : base(Name, MainNode, TexturePath, Count)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
