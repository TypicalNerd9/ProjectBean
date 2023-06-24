using Godot;
using System;

public abstract partial class Bean : GodotObject
{
    public String Name { get; private set; }
    protected Node MainNode;
    private String TexturePath;
    public int Count { get; private set; }
    public Texture BeanTexture { get; private set; }
    public bool HasBeenInitialized { get; private set; }

    public Label CounterLabel { get; set; }

    public Bean(String Name, Node MainNode, String TexturePath)
    {
        this.Name = Name;
        this.MainNode = MainNode;
        this.TexturePath = TexturePath;
        this.Count = 0;
    }

    public virtual void Init()
    {
        BeanTexture = GD.Load<Texture>(TexturePath);
        HasBeenInitialized = true;
    }
    public virtual void OnUse(CharacterBody2D characterBody)
    {
        DecrementCount();
    }

    public void IncrementCount()
    {
        Count++;
        CounterLabel.Text = "x" + Count;
    }

    public void DecrementCount() { 
        Count--;
        CounterLabel.Text = "x" + Count;
    }
}
