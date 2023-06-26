using Godot;
using System;

public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OptionsButtonPressed()
    {
		settings_menu SettingsMenu = GetNode<settings_menu>("SettingsMenu");
		SettingsMenu.Visible = true;
		Control MainPauseMenu = GetNode<Control>("MainPauseMenu");
		MainPauseMenu.Visible = false;
		SettingsMenu.ParentControl = MainPauseMenu;

	}

	public void MainMenuButtonPressed()
    {
		Visible = false;
		GetTree().Paused = false;
		Save save = GetNode<Save>("/root/Save");
		save.SaveData();
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://scenes/main_menu.tscn"));
		
	}

	public void QuitButtonPressed()
    {
		Visible = false;
		GetTree().Paused = false;
		GetTree().Quit();
	}
}
