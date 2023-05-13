using Godot;
using System;

public partial class teleport : Area2D
{
    // metoda e apelata pentru fiecare cadru delta in timp scurs de la cadru precedent
    public override void _Process(double delta)
    {
        // se ia locatia node-ului si o impunem intr-o variabila
        var path_node = GetPath();
        // se converteste in string si o impunem in alta variabila
        var path_converted = Convert.ToString(path_node);
        // se sterge 9 caractere pentru ca locatia sa fie in node-ul nivelului
        var path_updated = path_converted.Remove(path_converted.Length - 9);
        // se adauga locatie node-ului in string
        var HUD_Player_path = path_updated + "/Derpy/HUD_Player";
        // se ia node-ul din variabila path pentru locatie
        var total_bugs_level = GetNode<HUD_Player>(HUD_Player_path);
        // se ia totalul de bug-uri in nivel
        var total_bugs = total_bugs_level.bugs_total;
        // se ia totalul de bug-uri colectate
        var collected = total_bugs_level.bugs_collected;

        // se verifica daca totalul de puncte este egal cu puncte colectate
        // daca sunt egale teleportul apare in scena
        if (total_bugs == collected)
        {
            // node se face vizibil in scena
            Visible = true;
        }

    }

    // metoda este apelata cand jucatorul/corpul intra in area gandacului 
    public void _on_body_entered(CharacterBody2D body2D)
	{
        // se ia numele nivelului sau a node-ului
        string current_level = GetTree().CurrentScene.Name;

        // se verifica in ce nivel se afla jucatorul si daca visibilitatea node-ului e visibil
        // trimite jucatorul spre urmatorul nivel
        // daca este la ultimul nivel, trimite jucatorul spre ecranul de terminare a jocului
        if (current_level == "Level 2" && Visible == true)
        {
            // se schimba scena spre ecranul de terminare a jocului
            GetTree().ChangeSceneToFile("res://user_interface/end_game/end_game.tscn");
        }
        else if (current_level == "begin_tutorial" && Visible == true)
        {
            // se schimba scena spre alt nivel
            GetTree().ChangeSceneToFile("res://levels/level_1.tscn");
        }
        else if (current_level == "Level 1" && Visible == true)
        {
            // se schimba scena spre alt nivel
            GetTree().ChangeSceneToFile("res://levels/level_2.tscn");
        }
    }

}
