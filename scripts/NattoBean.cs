using Godot;
using System;

public partial class NattoBean : Bean
{
    public NattoBean(String Name, Node MainNode, String TexturePath, int Count) : base(Name, MainNode, TexturePath, Count)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
