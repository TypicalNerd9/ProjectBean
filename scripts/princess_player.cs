using Godot;
using System;

public partial class princess_player : CharacterBody2D
{
	[Export]
	public float Speed = 300.0f;
	[Export]
	public float JumpForceFalloff = 0.7f;
	[Export]
	public float JumpHorizontalVelocity = 200.0f;
	[Export]
	public float JumpVerticalVelocity = 400.0f;
	[Export]
	public int MaxJumpChargeTime = 5;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private double JumpChargeTime = 0;
	private bool IsChargingJump = false;
	private bool IsFacingRight = true;
	private AnimatedSprite2D animatedSprite2D;

    public override void _Ready()
    {
        base._Ready();
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }


	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("use_bean1"))
        {
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["gold"];
			if (bean != null && bean.Count > 0)
            {
				bean.OnUse((CharacterBody2D)this);
			}
		}

		if (Input.IsActionJustPressed("use_bean2"))
		{
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["coffee"];
			if (bean != null && bean.Count > 0)
			{
				bean.OnUse((CharacterBody2D)this);
			}
		}

		if (Input.IsActionJustPressed("use_bean3"))
		{
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["baked"];
			if (bean != null && bean.Count > 0)
			{
				bean.OnUse((CharacterBody2D)this);
			}
		}

		if (Input.IsActionJustPressed("use_bean4"))
		{
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["jelly"];
			if (bean != null && bean.Count > 0)
			{
				bean.OnUse((CharacterBody2D)this);
			}
		}

		if (Input.IsActionJustPressed("use_bean5"))
		{
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["natto"];
			if (bean != null && bean.Count > 0)
			{
				bean.OnUse((CharacterBody2D)this);
			}
		}

		if (Input.IsActionJustPressed("use_bean6"))
		{
			Global global = GetNode<Global>("/root/Global");
			Bean bean = global.BeansDictionary["chickpea"];
			if (bean != null && bean.Count > 0)
			{
				bean.OnUse((CharacterBody2D)this);
			}
		}


		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.

		if (Input.IsActionJustPressed("jump") && IsOnFloor() && !IsChargingJump)
		{
			IsChargingJump = true;
			Velocity = Vector2.Zero;

			MoveAndSlide();
			return;
		}

		if (!IsOnFloor() && IsChargingJump)
		{
			IsChargingJump = false;
			JumpChargeTime = 0;
		}

		if (Input.IsActionJustReleased("jump") && IsOnFloor() && IsChargingJump)
		{
			GD.Print(JumpChargeTime);
			IsChargingJump = false;
			velocity.Y -= (JumpVerticalVelocity * (float)Mathf.Clamp(JumpChargeTime, 0, MaxJumpChargeTime));
			velocity.X += (IsFacingRight ? 1 : -1) * (JumpHorizontalVelocity * (float)Mathf.Clamp(JumpChargeTime, 0, MaxJumpChargeTime));
			JumpChargeTime = 0;
		}

		if (IsChargingJump && JumpChargeTime < 2)
		{
			JumpChargeTime += delta;
		}

		
		// Get the horizontal input direction and handle the movement/deceleration.
		float velocityX = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		
		if (velocity.Y >= 0 && IsOnFloor() && !IsOnWallOnly() && !IsChargingJump)
		{
			if (velocityX != 0)
			{
				velocity.X = velocityX * Speed;
				animatedSprite2D.FlipH = velocity.X < 0;
				IsFacingRight = velocity.X >= 0;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		}

		Velocity = velocity;
		
		MoveAndSlide();
		if (IsOnWallOnly() && !IsOnFloor())

		{
			Velocity = velocity.Bounce(GetWallNormal()) * 0.7f;
		}
	}
}
