using Godot;
using System;

public partial class WinMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnMainMenuButtonPressed()
    {
		GetNode<Global>("/root/Main").Won = false;
		Visible = false;
		GetTree().Paused = false;
		Save save = GetNode<Save>("/root/Save");
		if (save.DoesSaveExist()) DirAccess.RemoveAbsolute(save.SaveFilePath);
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://scenes/main_menu.tscn"));
	}

	public void OnQuitButtonPressed()
    {
		Visible = false;
		GetTree().Paused = false;
		GetTree().Quit();
	}
}
