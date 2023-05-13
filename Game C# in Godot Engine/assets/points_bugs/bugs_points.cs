using Godot;
using System;

public partial class bugs_points : Area2D
{
    // am declarat o variabila globala
    public int points_collected = 0;

    // metoda e apelata cand node-ul intra prima data in scena
    public override void _Ready()
    {
        // se ia node-ul si il punem intr-o variabila
        var animated_bug = GetNode<AnimatedSprite2D>("animated_sprite");
        // incepem animatia bug-ului
        animated_bug.Play("bugs_idle_animation");
    }

    // metoda este apelata cand jucatorul/corpul intra in area gandacului 
    public void _on_body_entered(CharacterBody2D body2D)
	{
        // se ia locatia node-ului si o impunem intr-o variabila
        var path_node = GetPath();
        // se converteste in string si o impunem in alta variabila
        var path_converted = Convert.ToString(path_node);
        // se sterge 21 caractere pentru ca locatia sa fie in node-ul nivelului
        var path_updated = path_converted.Remove(path_converted.Length - 21);
        // se adauga locatie in string
        var path = path_updated + "/Derpy/HUD_Player";
        // se ia node-ul label din locatie anterioara 
        var points = GetNode<HUD_Player>(path);
        // se adauga un punct in variabila globala din scriptul HUD_Player
        points.bugs_collected += 1;

        // stergea node-ului cand player-ul atinge bug-ul si dupa luare punctului
		QueueFree();
	}
}
