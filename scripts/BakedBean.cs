using Godot;
using System;

public partial class BakedBean : Bean
{
    public BakedBean(String Name, Node MainNode, String TexturePath, int Count) : base(Name, MainNode, TexturePath, Count)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
