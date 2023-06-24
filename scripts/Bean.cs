using Godot;
using System;

public abstract partial class Bean : GodotObject
{
    private String Name;
    protected Node MainNode;
    private String TexturePath;
    public Texture BeanTexture { get; private set; }

    public Bean(String Name, Node MainNode, String TexturePath)
    {
        this.Name = Name;
        this.MainNode = MainNode;
        this.TexturePath = TexturePath;
    }

    public virtual void Init()
    {
        BeanTexture = GD.Load<Texture>(TexturePath);
    }
    public abstract void OnUse(CharacterBody2D characterBody);
}
