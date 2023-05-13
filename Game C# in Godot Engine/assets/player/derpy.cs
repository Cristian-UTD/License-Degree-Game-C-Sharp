using Godot;
using System;

public partial class derpy : CharacterBody2D
{
    // definirea variabilelor globale pentru viteza de deplasare, saritura mica si mare
	public const float speed = 300.0f;
    public const float low_jump = -500.0f;
    public const float high_jump = -650.0f;

    // luam gravitatia din setarile proiectului sa fie sincronizate cu RigidBody node
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    // definirea unei variabile globale ca node AnimationPlayer
    private AnimationPlayer animation_derpy;

    // definirea variabilelor globale ca node-uri Sprite2D pentru sprite-urile de animatii
    private Sprite2D sprite_idle;
    private Sprite2D sprite_run;
    private Sprite2D sprite_jump;
    private Sprite2D sprite_fall;

    // metoda e apelata de fiecare data cand un proces fizic se intampla in frame-uri care sincronizat fizic
	public override void _PhysicsProcess(double delta)
	{
        // declaram velocitatea ca vector2 pentru pozitia paianjenului in spatiu 2D din joc
        Vector2 velocity = Velocity;

        // adaugam gravitatie cand player nu se afla pe podea
        if (!IsOnFloor())
        {
            // velocitatea pe axa Y creste cu valoarea gravitatiei inmultita cu delta,
            // delta fiind timpul scurs de la cadru precedent
            velocity.Y += gravity * (float)delta;
        }

        // verificam daca jucatorul apasa pe Space ca sa sara si daca se afla pe podea
        // daca jucatorul apasa pe Space, atunci velocitatea pe coordonate Y va creste
        if (Input.IsActionJustPressed("player_jump") && !Input.IsActionPressed("player_jump_high") && IsOnFloor())
        {
            // velocitatea pe axa Y creste cu valorea sarituri mici 
            velocity.Y += low_jump;
        }

        // verificam daca jucatorul apasa pe Space si tine CTRL in acelasi timp ca sa sara si daca se afla pe podea
        // daca jucatorul apasa pe Space, atunci velocitatea de coordonate Y va creste
        if (Input.IsActionJustPressed("player_jump") && Input.IsActionPressed("player_jump_high") && IsOnFloor())
        {
            // velocitatea pe axa Y creste cu valorea sarituri mari
            velocity.Y += high_jump;
        }

        // luarea tastelor pentru directia paianjenului si gestioneaza miscarile paianjenului 
        Vector2 direction = Input.GetVector("player_left", "player_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
            // velocitatea pe axa X va creste cu directia X fiind pozitiva sau negativa depinzand
            // tasta pe care jucatorul a apasat inmultit cu viteza paianjenului
			velocity.X = direction.X * speed;
		}
		else
		{
            // cand velocitatea pe axa X este zero, paianjenul se opreste
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
		}

        // velocitatea ia din valorile din Vector2
		Velocity = velocity;
        // functie pentru node-ul CharacterBody2D in care daca corpul face coliziune cu alt corp precum Rigid Body
        // aceasta va aluneca pe corp si isi continua miscarea 
		MoveAndSlide();
    }

    // metoda e apelata pentru fiecare cadru delta in timp scurs de la cadru precedent
    public override void _Process(double delta)
    {
        // declaram velocitatea
        Vector2 velocity = Velocity;

        // luam node-urile in variabile globale
        animation_derpy = GetNode<AnimationPlayer>("AnimationPlayer");
        sprite_idle = GetNode<Sprite2D>("sprites/sprite_derpy_idle");
        sprite_run = GetNode<Sprite2D>("sprites/sprite_derpy_run");
        sprite_jump = GetNode<Sprite2D>("sprites/sprite_derpy_jump");
        sprite_fall = GetNode<Sprite2D>("sprites/sprite_derpy_fall");

        // daca paianjenul e pe podea, animatiile pentru saritura si cadere sunt invizible
        if (IsOnFloor())
        {
            // vizibilitatea node-urilor se fac invisible
            sprite_jump.Visible = false;
            sprite_fall.Visible = false;
        }

        // daca paianjenul are velocitatea zero (nu se misca) si e podea, sprite-ul de idle
        // este visibila si se incepe animatia  
        if (velocity == Vector2.Zero && IsOnFloor())
        {
            // visibilitatea pentru miscare este invisibila
            sprite_run.Visible = false;

            // visibilitatea pentru idle este visibla
            sprite_idle.Visible = true;
            // animatia de idle incepe sa ruleze
            animation_derpy.Play("derpy_idle");
        }

        // daca jucatorul apasa pe tasta A sau sageata stanga, sprite-urile de cadere si saritura
        // se inverseaza pe orizontal
        if (Input.IsActionPressed("player_left"))
        {
            // se inverseaza sprite de cadere orizontal
            sprite_fall.FlipH = true;
            // se inverseaza sprite de saritura orizontal
            sprite_jump.FlipH = true;
        }
        else
        {
            // se anuleaza inversarea sprite de cadere 
            sprite_jump.FlipH = false;
            // se anuleaza inversarea sprite de saritura 
            sprite_fall.FlipH = false;
        }

        // daca jucatorul apasa pe Space pentru a sari si nu este pe podea animatia de saritura incepe sa ruleze
        if (Input.IsActionPressed("player_jump") && !IsOnFloor())
        {
            // se fac invizibile sprite-urile de miscare, idle si cadere
            sprite_run.Visible = false;
            sprite_idle.Visible = false;
            sprite_fall.Visible = false;
            // se face vizibil sprite-ul de saritura
            sprite_jump.Visible = true;
            // animatia de saritura incepe sa ruleze
            animation_derpy.Play("derpy_jump");
        }

        // daca jucatorul apasa pe tasta A sau sageata stanga si este pe podea, animatia de miscare se inverseaza
        // si incepe sa ruleze
        if (Input.IsActionPressed("player_left") && IsOnFloor())
        {
            // se face invizibil sprite-ul de idel
            sprite_idle.Visible = false;

            // sprite-ul de miscare se face visibil si se inverseaza
            sprite_run.Visible = true;
            sprite_run.FlipH = true;
            // animatia de miscare incepe sa ruleze
            animation_derpy.Play("derpy_move");
        }

        // daca jucatorul apasa pe tasta D sau sageata dreapta si este pe podea, animatia de miscare se anuleaza
        // inverseaza si incepe sa ruleze
        if (Input.IsActionPressed("player_right") && IsOnFloor())
        {
            // se face invizibil sprite-ul de idel
            sprite_idle.Visible = false;

            // sprite-ul de miscare se face visibil si se anuleaza inverseaza
            sprite_run.Visible = true;
            sprite_run.FlipH = false;
            // animatia de miscare incepe sa ruleze
            animation_derpy.Play("derpy_move");
        }

        // daca velocitatea pe axa Y este mai mica de 0 si paianjenul nu e pe podea
        // sprite-ul de cadere se face vizibil
        if (velocity.Y > 0 && !IsOnFloor())
        {
            // se fac invizibile sprite-urile de miscare, idle si saritura
            sprite_run.Visible = false;
            sprite_idle.Visible = false;
            sprite_jump.Visible = false;

            // se face vizibil sprite-ul de cadere
            sprite_fall.Visible = true;
        }
    }

    // aceasta metoda se apeleaza de fiecare data cand se introduce un input sau s-a apasat
    // un buton de la jucator si se adauga meniul de pauza node ca child node la paianjen
    public override void _Input(InputEvent @event)
    {
        // verifica daca butonul apasat de la jucator a fost butonul de pauza ESC
        if (Input.IsActionJustPressed("pause_menu"))
        {
            // se incarca meniul de pauza, zicand unde se afla scena in joc
            var pause_menu = GD.Load<PackedScene>("res://user_interface/pause_menu/pause_menu.tscn");
            // se initializeaza node-ul si se adauga ca child node 
            AddChild(pause_menu.Instantiate());
            // se pune jocul pe pauza
            GetTree().Paused = true;
        }
    }
}