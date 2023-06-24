using Godot;
using System;

public partial class ChickpeaBean : Bean
{
    public ChickpeaBean(String Name, Node MainNode, String TexturePath) : base(Name, MainNode, TexturePath)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
