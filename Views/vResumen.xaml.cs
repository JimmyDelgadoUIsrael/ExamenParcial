namespace jdelgadoExamen.Views;

public partial class vResumen : ContentPage
{
    public vResumen()
    {
        InitializeComponent();
    }

    public vResumen(string[] resumen)
    {
        InitializeComponent();

        lblNombre.Text = resumen[0];
        lblApellido.Text = resumen[1];
        lblVA.Text = resumen[2];
        lblCiudad.Text = resumen[3];
        lblFecha.Text = resumen[4];
        lblMontoI.Text = resumen[5];
        lblCuotaM.Text = resumen[6];


    }

    private void btnCerrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vLogin());
    }





}