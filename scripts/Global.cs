using Godot;
using Godot.Collections;
using System;

public partial class Global : Node
{
	public Dictionary<String, Bean> BeansDictionary;
	public Bean[] BeanInventory;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node MainNode = Owner;
		BeansDictionary = new Dictionary<string, Bean>();
		BeansDictionary.Add("gold", new GoldBean("Gold Bean", MainNode, "res://assets/GoldBean.png"));
		BeansDictionary.Add("coffee", new CoffeeBean("Coffee Bean", MainNode, "res://assets/GoldBean.png"));
		BeansDictionary.Add("baked", new BakedBean("Baked Bean", MainNode, "res://assets/GoldBean.png"));
		BeansDictionary.Add("jelly", new JellyBean("Jelly Bean", MainNode, "res://assets/GoldBean.png"));
		BeansDictionary.Add("natto", new NattoBean("Natto Soybean", MainNode, "res://assets/GoldBean.png"));
		BeansDictionary.Add("chickpea", new ChickpeaBean("Chickpea", MainNode, "res://assets/GoldBean.png"));

		BeanInventory = new Bean[3];

		GD.Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
