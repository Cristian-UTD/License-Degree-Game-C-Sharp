using Godot;
using System;

public partial class Main_Menu_Old : Control
{
	private void _on_Start_Button_pressed()
	{

	GetTree().ChangeSceneToFile("res://levels/begin_tutorial_level.tscn");


	}
	
	private void _on_Options_Button_pressed()
	{
	
	
	
	}
	
	private void _on_Quit_Button_pressed()
	{
	
	GetTree().Quit();
	
	}
	
	

}




