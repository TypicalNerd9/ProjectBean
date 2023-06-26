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

    public Bean(String Name, Node MainNode, String TexturePath, int Count)
    {
        this.Name = Name;
        this.MainNode = MainNode;
        this.TexturePath = TexturePath;
        this.Count = Count;
        BeanTexture = GD.Load<Texture>(TexturePath);
    }

    public virtual void Init()
    {
        
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
