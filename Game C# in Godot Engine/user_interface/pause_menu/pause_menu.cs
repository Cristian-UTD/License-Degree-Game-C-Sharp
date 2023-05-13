using Godot;

public partial class pause_menu : Control
{
    // se apeleaza aceasta metoda de fiecare data cand
    // scriptul primeste semnal de la butonul Resume cand a fost apasat
    public void _on_resume_button_pressed()
    {
        // pune jocul sa ruleze
        GetTree().Paused = false;

        // stergerea meniul de pauza ca node
        QueueFree();
    }

    // se apeleaza aceasta metoda de fiecare data cand
    // scriptul primeste semnal de la butonul Back to Main Menu cand a fost apasat
    public void _on_back_button_pressed()
    {
        // pun jocul sa ruleze
        GetTree().Paused = false;

        // schimba scena pe Main Menu
        GetTree().ChangeSceneToFile("res://user_interface/main_menu/main_menu.tscn");
    }

    /*
    // cod vechi

    public override void _Input(InputEvent @event)
    {
        // verifica daca butonul de pauza a fost apasat
        if (Input.IsActionJustPressed("pause_menu"))
        {
            // pune jocul pe pauza
            GetTree().Paused = true;

            // faca vizibil node-ul cu meniul de pauza
            Visible = true;

            var pause_state = !GetTree().Paused;
            GetTree().Paused = pause_state;
            Visible = pause_state;

        }
    }

    */

}
