using Godot;
using System;

public partial class JellyBean : Bean
{
    public JellyBean(String Name, Node MainNode, String TexturePath, int Count) : base(Name, MainNode, TexturePath, Count)
    {
    }

    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
    }
}
