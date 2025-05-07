namespace jdelgadoExamen.Views;

public partial class vLogin : ContentPage
{
    public vLogin()
    {
        InitializeComponent();
    }

    string[,] matrizUser = new string[3, 2]
    { { "estudiante2025", "moviles" },
        { "uisrael", "2025" },
        { "sistemas", "2025_1" } };

    string usuariof = "";
    string contrasenaf = "";
    public vLogin(string usuario, string contrasena)
    {
        InitializeComponent();
        this.usuariof = usuario;
        this.contrasenaf = contrasena;
    }

    public void limpiar()
    {
        txtUsuario.Text = "";
        txtContrasena.Text = "";
    }
    private void btnIniciarSesion_Clicked(object sender, EventArgs e)
    {

        if (txtUsuario.Text == "" || txtContrasena.Text == "")
        {
            DisplayAlert("Error", "Ingrese usuario y contraseña", "Aceptar");
            return;
        }

        for (int i = 0; i < matrizUser.GetLength(0); i++)
        {
            if (txtUsuario.Text == matrizUser[i, 0] && txtContrasena.Text == matrizUser[i, 1])
            {
                Navigation.PushAsync(new Views.vRegistro(txtUsuario.Text));
                limpiar();
                return;
            }
        }
        DisplayAlert("Error", "Usuario / Contraseña incorrectos", "Aceptar");

    }



    private void btnAcercade_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Views.vInfo());
    }
}