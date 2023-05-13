using Godot;
using System;

public partial class end_game : Control
{
	public void _on_back_to_main_menu_pressed()
	{
		// se schimba scena pe meniul principal
		GetTree().ChangeSceneToFile("res://user_interface/main_menu/main_menu.tscn");
	}
}
