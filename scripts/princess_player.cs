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
	[Export]
	public Vector2 JumpPowerLevel1 = new Vector2(0.1f, 0.1f);
	[Export]
	public Vector2 JumpPowerLevel2 = new Vector2(0.25f, 0.25f);
	[Export]
	public Vector2 JumpPowerLevel3 = new Vector2(0.45f, 0.60f);
	[Export]
	public Vector2 JumpPowerLevel4 = new Vector2(0.6f, 0.80f);
	[Export]
	public Vector2 JumpPowerLevel5 = new Vector2(0.75f, 1f);
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private double JumpChargeTime = 0;
	private bool IsChargingJump = false;
	private bool IsFacingRight = true;
	private bool IsJumping = false;
	private AnimatedSprite2D animatedSprite2D;
	private AudioStreamPlayer2D jumpSFXPlayer, bounceSFXPlayer, fallSFXPlayer;

    public override void _Ready()
    {
        base._Ready();
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		jumpSFXPlayer = GetNode<AudioStreamPlayer2D>("JumpSFXPlayer");
		bounceSFXPlayer = GetNode<AudioStreamPlayer2D>("BounceSFXPlayer");
		fallSFXPlayer = GetNode<AudioStreamPlayer2D>("FallSFXPlayer");
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
			animatedSprite2D.Play("charge_jump");
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
			IsJumping = true;
			animatedSprite2D.Play("jump");
			float JumpChargeTimeSegment = MaxJumpChargeTime / 5.0f;
			float ActualJumpVerticalVelocity = JumpVerticalVelocity;
			float ActualJumpHorizontalVelocity = JumpHorizontalVelocity;
			if (JumpChargeTime > 0 && JumpChargeTime < JumpChargeTimeSegment)
            {
				GD.Print("POWER LEVEL 1");
				ActualJumpHorizontalVelocity *= JumpPowerLevel1.X;
				ActualJumpVerticalVelocity *= JumpPowerLevel1.Y;
            } else if (JumpChargeTime > JumpChargeTimeSegment && JumpChargeTime < JumpChargeTimeSegment*2)
			{
				GD.Print("POWER LEVEL 2");
				ActualJumpHorizontalVelocity *= JumpPowerLevel2.X;
				ActualJumpVerticalVelocity *= JumpPowerLevel2.Y;
			}
			else if (JumpChargeTime > JumpChargeTimeSegment * 2 && JumpChargeTime < JumpChargeTimeSegment * 3)
			{
				GD.Print("POWER LEVEL 3");
				ActualJumpHorizontalVelocity *= JumpPowerLevel3.X;
				ActualJumpVerticalVelocity *= JumpPowerLevel3.Y;
			}
			else if (JumpChargeTime > JumpChargeTimeSegment * 3 && JumpChargeTime < JumpChargeTimeSegment * 4)
			{
				GD.Print("POWER LEVEL 4");
				ActualJumpHorizontalVelocity *= JumpPowerLevel4.X;
				ActualJumpVerticalVelocity *= JumpPowerLevel4.Y;
			}
			else if (JumpChargeTime > JumpChargeTimeSegment * 4 && JumpChargeTime < JumpChargeTimeSegment * 5)
			{
				GD.Print("POWER LEVEL 5");
				ActualJumpHorizontalVelocity *= JumpPowerLevel5.X;
				ActualJumpVerticalVelocity *= JumpPowerLevel5.Y;
			}
			velocity.Y -= ActualJumpVerticalVelocity;
			velocity.X += (IsFacingRight ? 1 : -1) * (ActualJumpHorizontalVelocity);
			//velocity.Y -= (JumpVerticalVelocity * (float)Mathf.Clamp(JumpChargeTime, 0, MaxJumpChargeTime));
			//velocity.X += (IsFacingRight ? 1 : -1) * (JumpHorizontalVelocity * (float)Mathf.Clamp(JumpChargeTime, 0, MaxJumpChargeTime));
			JumpChargeTime = 0;
			jumpSFXPlayer.Play();
		}

		if (IsChargingJump && JumpChargeTime < MaxJumpChargeTime)
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
			GD.Print(GetWallNormal());
			if (GetWallNormal().Y > -0.4f && GetWallNormal().Y < 0.4f)
			{
				Velocity = velocity.Bounce(GetWallNormal()) * 0.7f;
				bounceSFXPlayer.Play();
			}
		}
		if (IsOnFloor() && IsJumping)
		{
			animatedSprite2D.Play("idle");
			IsJumping = false;
			if (velocity.Y > 675) fallSFXPlayer.Play();
		}
	}

	public void OnLeaveCamera()
    {
		CameraHandler CameraHandler = GetNode<CameraHandler>("/root/Main/Camera2D");
		if (CameraHandler != null)
        {
			GD.Print("Camera: " + CameraHandler.Position);
			GD.Print("Character: " + Position);
			if (CameraHandler.Position.Y < Position.Y)
            {
				CameraHandler.MoveCamera(false);

			} else
            {
				CameraHandler.MoveCamera(true);
			}
        }
    }
}
