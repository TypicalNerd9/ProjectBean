using Godot;
using System;

public partial class BeanCollector : Area2D
{
	[Export]
	public bool IsHoldingSpecificBean = false;
	[Export]
	public String SpecificBean;

	private Bean _heldBean;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global global = GetNode<Global>("/root/Global");
		if (IsHoldingSpecificBean && global.BeansDictionary.ContainsKey(SpecificBean))
		{
			_heldBean = global.BeansDictionary[SpecificBean];
		}
		else
		{
			Bean[] BeanArray = new Bean[global.BeansDictionary.Count];
			global.BeansDictionary.Values.CopyTo(BeanArray, 0);
			_heldBean = BeanArray[GD.Randi() % global.BeansDictionary.Count];
		}
		if (!_heldBean.HasBeenInitialized) _heldBean.Init();
		Sprite2D beanSprite = GetNode<Sprite2D>("BeanSprite");
		beanSprite.Texture = (Texture2D) _heldBean.BeanTexture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBeanCollectorBodyEntered(PhysicsBody2D body)
    {
		if (body is CharacterBody2D)
		{
			_heldBean.IncrementCount();
			QueueFree();
		}


	}
}
