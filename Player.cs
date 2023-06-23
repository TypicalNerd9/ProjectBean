using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;
	public AnimatedSprite2D animatedSprite;
	public Vector2 ScreenSize;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float velocityX = Input.GetActionStrength("move_left") - Input.GetActionStrength("move_right");
		if (Mathf.Abs(velocityX) > 0)
        {
			velocityX *= Speed;
			animatedSprite.Play();
        } else
        {
			animatedSprite.Stop();
        }

		Position += new Vector2(velocityX * (float)delta, Position.Y);
		Position = new Vector2(
			Mathf.Clamp(Position.X, 0, ScreenSize.X),
			Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);

	}
}
