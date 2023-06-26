using Godot;
using System;

public partial class BeanCollector : Area2D
{
	[Export]
	public bool IsHoldingSpecificBean = false;
	[Export]
	public String SpecificBean;

	private Bean _heldBean;
	private GpuParticles2D _particles;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
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
			body.GetNode<AudioStreamPlayer2D>("PickupSFX").Play();
			QueueFree();
		}


	}

	public void OnLoadTimerElapsed()
    {
		Global global = GetNode<Global>("/root/Main");
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
		beanSprite.Texture = (Texture2D)_heldBean.BeanTexture;

		_particles = GetNode<GpuParticles2D>("GPUParticles2D");
		Vector2I BeanTextureSize = beanSprite.Texture.GetImage().GetSize();
		Color BeanTextureColor = beanSprite.Texture.GetImage().GetPixelv(BeanTextureSize / 2);
		_particles.ProcessMaterial.Set("color", BeanTextureColor);
	}
}
