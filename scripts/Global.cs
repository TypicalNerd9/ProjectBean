using Godot;
using Godot.Collections;
using System;

public partial class Global : Node
{
	public Dictionary<String, Bean> BeansDictionary;
	public bool IsPaused = false;
	public bool Won = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BeansDictionary = new Dictionary<String, Bean>();
		Save save = GetNode<Save>("/root/Save");
		if (save.DoesSaveExist())
		{
			BeansDictionary.Add("gold", new GoldBean("Gold Bean", this, "res://assets/GoldBean.png", save.gold));
			/*BeansDictionary.Add("coffee", new CoffeeBean("Coffee Bean", this, "res://assets/GoldBean.png", save.coffee));
			BeansDictionary.Add("baked", new BakedBean("Baked Bean", this, "res://assets/GoldBean.png", save.baked));
			BeansDictionary.Add("jelly", new JellyBean("Jelly Bean", this, "res://assets/GoldBean.png", save.jelly));
			BeansDictionary.Add("natto", new NattoBean("Natto Soybean", this, "res://assets/GoldBean.png", save.natto));
			BeansDictionary.Add("chickpea", new ChickpeaBean("Chickpea", this, "res://assets/GoldBean.png", save.chickpea));*/
		}
		else
		{
			BeansDictionary.Add("gold", new GoldBean("Gold Bean", this, "res://assets/GoldBean.png", 0));
			/*BeansDictionary.Add("coffee", new CoffeeBean("Coffee Bean", this, "res://assets/GoldBean.png", 0));
			BeansDictionary.Add("baked", new BakedBean("Baked Bean", this, "res://assets/GoldBean.png", 0));
			BeansDictionary.Add("jelly", new JellyBean("Jelly Bean", this, "res://assets/GoldBean.png", 0));
			BeansDictionary.Add("natto", new NattoBean("Natto Soybean", this, "res://assets/GoldBean.png", 0));
			BeansDictionary.Add("chickpea", new ChickpeaBean("Chickpea", this, "res://assets/GoldBean.png", 0));*/

		}
		GD.Randomize();

		GetNode<BeanList>("CanvasLayer/UI/BeanList").LoadBeanList();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Notification(int what)
    {
        if (what == NotificationWMCloseRequest)
        {
			Save save = GetNode<Save>("/root/Save");
			if (Won)
			{
				Won = false;
				if (save.DoesSaveExist()) DirAccess.RemoveAbsolute(save.SaveFilePath);
			}
			else
			{
				save.SaveData();
			}
		}
    }
}
