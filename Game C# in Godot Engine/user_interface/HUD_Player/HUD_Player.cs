using Godot;
using System;

public partial class HUD_Player : Control
{
    // am declarat variabile globale
    public int bugs_total = 0;
    public int bugs_collected = 0;

    // metoda e apelata cand node-ul intra prima data in scena
	public override void _Ready()
	{
        // se ia locatia node-ului si o impunem intr-o variabila
        var path_node = GetPath();
        // se converteste in string si o impunem in alta variabila
        var path_converted = Convert.ToString(path_node);
        // se sterge 16 caractere pentru ca locatia sa fie in node-ul nivelului
        var path_updated = path_converted.Remove(path_converted.Length - 16);
        // se adauga cuvantul bugs in string pentru locatie node-ului
        var path = path_updated + "bugs";
        // se ia node-ul din variabila path pentru locatie
        var bugs_total_path = GetNode<Node2D>(path);
        // se ia node-ul label 
        var label_total = GetNode<Label>("bugs_total");
        // se numara cate gandaci puncte sunt pe nivel si se pune numarul de gandaci puncte in variabila globala
        bugs_total = bugs_total_path.GetChildCount();
        // dupa aflarea cate gandaci puncte sunt, se editeaza textul si afiseaza totalul de gandaci puncte la HUD jucatorului
		label_total.Text = "/" + Convert.ToString(bugs_total);
    }

    // metoda e apelata pentru fiecare cadru delta in timp scurs de la cadru precedent
    public override void _Process(double delta)
    {
        // se ia node-ul bug puncte curent
        var label_points = GetNode<Label>("bugs_points");
        // se modifica textul din Label si se converteste punctele colectate in string
        label_points.Text = Convert.ToString(bugs_collected);
        // luam textul si o transformam in int32 si o punem intr-o variabila
        var points_collected = Convert.ToInt32(label_points.Text);
        // se punea valorea in variabila globala
        bugs_collected = points_collected;
    }
}
