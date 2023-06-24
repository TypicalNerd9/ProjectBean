using Godot;
using System;

public partial class BeanList : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene BeanListItemScene = GD.Load<PackedScene>("res://bean_list_item.tscn");
		Global global = GetNode<Global>("/root/Global");


		foreach (var (id, bean) in global.BeansDictionary)
        {
			HBoxContainer BeanListItem = BeanListItemScene.Instantiate<HBoxContainer>();
			BeanListItem.GetNode<Label>("BeanName").Text = bean.Name;
			Label BeanCount = BeanListItem.GetNode<Label>("BeanCount");
			BeanCount.Text = "x" + bean.Count;
			AddChild(BeanListItem);
			bean.CounterLabel = BeanCount;

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
