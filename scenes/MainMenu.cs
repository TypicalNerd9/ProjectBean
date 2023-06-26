using Godot;
using System;

public partial class MainMenu : Control
{
	private Button ContinueButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ContinueButton = GetNode<Button>("MarginContainer/VBoxContainer2/MarginContainer2/VBoxContainer/ContinueButton");
		Save save = GetNode<Save>("/root/Save");
		ContinueButton.Visible = false;
		if (save.DoesSaveExist())
        {
			ContinueButton.Visible = true;
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnContinueButtonPressed()
	{
		Save save = GetNode<Save>("/root/Save");
		save.LoadData();
		GetTree().ChangeSceneToPacked(save.GameScene);
	}

	public void OnNewGameButtonPressed()
    {
		Save save = GetNode<Save>("/root/Save");
		if (save.DoesSaveExist())
		{
			DirAccess.RemoveAbsolute(save.SaveFilePath);
		}
			GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://scenes/main.tscn"));
    }

	public void OnOptionsButtonPressed()
	{
	}

	public void OnExitButtonPressed()
	{
		GetTree().Quit();
	}
}
