using Godot;
using System;

public partial class settings_menu : Control
{
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("pause_menu"))
        {
            GetTree().ChangeSceneToFile("res://user_interface/main_menu/main_menu.tscn");
        }
    }
}
