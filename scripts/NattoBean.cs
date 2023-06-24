using Godot;
using System;

public partial class NattoBean : Bean
{
    public NattoBean(String Name, Node MainNode, String TexturePath) : base(Name, MainNode, TexturePath)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
