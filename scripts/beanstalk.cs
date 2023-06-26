using Godot;
using System;

public partial class beanstalk : Node2D
{
	private AnimationPlayer animationPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBeanstalkCollision(Rid bodyRID, Node2D body, int bodyShapeIndex, int localShapeIndex)
    {
		Area2D area = GetNode<Area2D>("Area2D");
		if (body is TileMap)
		{
			TileMap tileMap = (TileMap)body;
			TileData tileData = tileMap.GetCellTileData(1, tileMap.GetCoordsForBodyRid(bodyRID));
			tileData.SetCollisionPolygonOneWay(0, 0, true);
		}
    }
}
