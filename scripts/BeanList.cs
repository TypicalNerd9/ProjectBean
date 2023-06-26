using Godot;
using System;

public partial class BeanList : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void LoadBeanList()
    {
		PackedScene BeanListItemScene = GD.Load<PackedScene>("res://scenes/bean_list_item.tscn");
		Global main = GetNode<Global>("/root/Main");
		foreach (var (id, bean) in main.BeansDictionary)
		{
			HBoxContainer BeanListItem = BeanListItemScene.Instantiate<HBoxContainer>();
			BeanListItem.GetNode<TextureRect>("BeanIcon").Texture = (Texture2D)bean.BeanTexture;
			Label BeanCount = BeanListItem.GetNode<Label>("BeanCount");
			BeanCount.Text = "x" + bean.Count;
			AddChild(BeanListItem);
			bean.CounterLabel = BeanCount;

		}
	}
}
