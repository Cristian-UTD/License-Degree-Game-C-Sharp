using Godot;

public partial class main_menu : Control
{
    // se apeleaza aceasta metoda de fiecare data cand
    // scriptul primeste semnal de la butonul Play cand a fost apasat
    public void _on_play_button_pressed()
    {
        // se schimba scena la tutorial, zicand de locatia sa in fisierele jocului
        GetTree().ChangeSceneToFile("res://levels/begin_tutorial_r.tscn");
    }

    // se apeleaza aceasta metoda de fiecare data cand
    // scriptul primeste semnal de la butonul Quit cand a fost apasat
    public void _on_quit_button_pressed()
    {
        // iesirea din joc
        GetTree().Quit();
    }
}
