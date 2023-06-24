using Godot;
using System;

public partial class CoffeeBean : Bean
{
    public CoffeeBean(String Name, Node MainNode, String TexturePath) : base(Name, MainNode, TexturePath)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
