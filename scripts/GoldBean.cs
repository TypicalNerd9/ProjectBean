using Godot;
using System;

public partial class GoldBean : Bean
{
    private PackedScene _beanstalkScene;
    public GoldBean(String Name, Node MainNode, String TexturePath, int Count) : base(Name, MainNode, TexturePath, Count)
    {
    }

    public override void Init()
    {
        base.Init();
        
    }
    public override void OnUse(CharacterBody2D characterBody)
    {
        base.OnUse(characterBody);
        _beanstalkScene = GD.Load<PackedScene>("res://scenes/beanstalk.tscn");
        Node2D instance = _beanstalkScene.Instantiate<Node2D>();
        instance.Position = characterBody.Position + new Vector2(0, 30);
        characterBody.Owner.AddChild(instance);
        instance.Owner = characterBody.GetNode<Node>("/root/Main");
        instance.GetNode<AnimationPlayer>("AnimationPlayer").Play("grow");
        //characterBody.Owner.CallDeferred("add_child", instance);
    }
}
