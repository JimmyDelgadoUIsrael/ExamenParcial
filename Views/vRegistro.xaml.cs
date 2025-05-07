namespace jdelgadoExamen.Views;

public partial class vRegistro : ContentPage
{
    public vRegistro()
    {
        InitializeComponent();
    }
    public vRegistro(string user)
    {
        InitializeComponent();
        lblInfo.Text = "Usuario conectado: " + user;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {

        double montoInicial;
        if (!double.TryParse(txtMontoIni.Text, out montoInicial) || montoInicial <= 0)
        {
            lblInfo.Text = "Por favor ingrese un monto inicial válido.";
            return;
        }

        double costoUPS = 0;
        switch (pckVoltios.SelectedItem?.ToString())
        {
            case "200":
                costoUPS = 300;
                break;
            case "500":
                costoUPS = 500;
                break;
            case "1000":
                costoUPS = 1000;
                break;
            default:
                lblInfo.Text = "Por favor seleccione un voltaje válido.";
                return;
        }


        double pagoInicial = costoUPS * 0.15;

        if (montoInicial < pagoInicial)
        {
            lblInfo.Text = $"El monto inicial debe ser al menos ${pagoInicial}.";
            return;
        }


        double saldoRestante = costoUPS - montoInicial;


        double cuotaBase = saldoRestante / 3;
        double interesCuota = costoUPS * 0.05;
        double cuotaMensual = cuotaBase + interesCuota;


        txtCuotaMen.Text = cuotaMensual.ToString("C2");


        lblInfo.Text = string.Empty;
    }



    private async void btnResumen_Clicked(object sender, EventArgs e)
    {

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string voltaje = pckVoltios.SelectedItem?.ToString();
        string ciudad = pckCiudad.SelectedItem?.ToString();
        string fecha = dtpckFecha.Date.ToString("dd/MM/yyyy");
        string montoInicial = txtMontoIni.Text;
        string cuotaMensual = txtCuotaMen.Text;


        string[] resumen = new string[]
        {
        nombre + " " + apellido,
        apellido,
        voltaje + " VA",
        ciudad,
        fecha,
        montoInicial,
        cuotaMensual
        };
        await Navigation.PushAsync(new Views.vResumen(resumen));
    }

}


