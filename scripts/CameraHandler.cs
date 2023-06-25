using Godot;
using System;

public partial class CameraHandler : Camera2D
{
	[Export]
	public int OffsetAmount;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void MoveCamera(bool up)
    {
		if (up)
        {
			Position -= new Vector2(0, OffsetAmount);
        } else
        {
			Position += new Vector2(0, OffsetAmount);
		}
    }
}
