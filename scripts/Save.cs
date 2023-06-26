using Godot;
using System;

public partial class Save : Node
{

	public String SaveFilePath { get; private set; } = "user://save.dat";
	public int gold, coffee, baked, jelly, natto, chickpea;
	public PackedScene GameScene { get; private set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SaveData()
    {
		Global global = GetNode<Global>("/root/Main");

		

		GameScene = new PackedScene();
		GameScene.Pack(global);
		FileAccess SaveFile = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write);

		Godot.Collections.Dictionary<String, Variant> GameInfo = new Godot.Collections.Dictionary<String, Variant>
		{
			{ "GAME_SCENE", GD.VarToStr(GameScene)},
			{ "GOLD", global.BeansDictionary["gold"].Count},
			//{ "COFFEE", global.BeansDictionary["coffee"].Count },
			//{ "BAKED", global.BeansDictionary["baked"].Count},
			//{ "JELLY", global.BeansDictionary["jelly"].Count},
			//{ "NATTO", global.BeansDictionary["natto"].Count},
			//{ "CHICKPEA", global.BeansDictionary["chickpea"].Count}
		};
		

		SaveFile.StoreVar(GameInfo);
		SaveFile.Close();
    }

	public void LoadData()
    {
		FileAccess SaveFile = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read);
		if (FileAccess.FileExists(SaveFilePath))
        {
			Godot.Collections.Dictionary<String, Variant> GameInfo = (Godot.Collections.Dictionary<string, Variant>) SaveFile.GetVar();
			GameScene = (PackedScene)GD.StrToVar((String) GameInfo["GAME_SCENE"]);
			gold = (int)GameInfo["GOLD"];
			//coffee = (int)GameInfo["COFFEE"];
			//baked = (int)GameInfo["BAKED"];
			//jelly = (int)GameInfo["JELLY"];
			//natto = (int)GameInfo["NATTO"];
			//chickpea = (int)GameInfo["CHICKPEA"];
		}
		SaveFile.Close();
	}

	public bool DoesSaveExist()
    {
		return FileAccess.FileExists(SaveFilePath);
    }
}
