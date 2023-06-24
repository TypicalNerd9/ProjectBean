using Godot;
using System;

public partial class GoldBean : Bean
{
    private PackedScene _beanstalkScene;
    public GoldBean(String Name, Node MainNode, String TexturePath) : base(Name, MainNode, TexturePath)
    {
    }

    public override void Init()
    {
        base.Init();
        _beanstalkScene = GD.Load<PackedScene>("res://beanstalk.tscn");
    }
    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
        Node2D instance = _beanstalkScene.Instantiate<Node2D>();

        instance.Position = characterBody.Position + new Vector2(0, 30);
        characterBody.Owner.AddChild(instance);
        //characterBody.Owner.CallDeferred("add_child", instance);
    }
}
