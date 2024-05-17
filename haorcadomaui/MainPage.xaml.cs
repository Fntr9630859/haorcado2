namespace haorcadomaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            record.Text= "Record = " + data.Datos.record.ToString();
        }

        int num1 = 0;
        int num2 = 0;
        int res = 0;
        int perd = 0;
        int reftiempo = 60;
        int tiempo = 60;
        int punt = 0;
        int dificultad = 1;
        bool continua = false;
        int enperd = 0;

        private async void Iniciar_juego(object sender, EventArgs e)
        {
            Continuar.Text = "continuar";

            if (perd == 6)
            {
                perd = 0;
                punt = 0;
                puntaje.Text = "Puntaje = 0";
                personaje.Source = "escenario.png";
            }
            Continuar.IsEnabled = false;
            cambiodificultad.IsEnabled = false;
            cambiopersonaje.IsEnabled = false;
            verificardif();
            numero1.Text = num1.ToString();
            numero2.Text = num2.ToString();
            respuestau.IsEnabled = true;
            respuestau.Text = "";
            continua = true;

            while (continua)
            {
                tiempo--;
                tiempol.Text = "Tiempo = "+ tiempo.ToString();
                await Task.Delay(1000);
                if (tiempo <= 0)
                {
                    tiempol.Text = "Tiempo = 0";
                    respuestau.Text = "0";
                    perder();
                }
            }

        }



        private void verificardif()
        {
            Random random = new Random();
            num1 = random.Next(1, 13);
            num2 = random.Next(1, 13);
            res = num1 * num2;
            if (punt != 0)
            {
                if (enperd == 0)
                {
                if (dificultad == 0 && reftiempo > 2)
                {
                    if (punt % 5 == 0)
                    {
                        reftiempo -= 5;
                    }
                }
                else if (dificultad == 1 && reftiempo > 32)
                {
                    if (punt % 5 == 0)
                    {
                        reftiempo -= 5;
                    }
                }
                else if (dificultad == 2 && reftiempo > 32)
                {
                    if (punt % 5 == 0)
                    {
                        reftiempo -= 5;
                    }
                }

                }

            }
            else
            {
                if (dificultad == 0)
                {
                    reftiempo = 60;

                } else if (dificultad == 1)
                {
                    reftiempo = 40;

                } else if (dificultad == 2)
                {
                    reftiempo = 20;

                }
            }
            tiempo = reftiempo + 1;
        }

        public void Comprobarc(object sender, EventArgs e)
        {
            verificarr();
        }

        private void verificarr()
        {
            if (int.TryParse(respuestau.Text, out int resu))
            {
                if (resu == res)
                {
                    enperd = 0;
                    DisplayAlert("Ganaste", " ", "OK");
                    Continuar.IsEnabled = true;
                    respuestau.IsEnabled = false;
                    continua = false;
                    punt++;
                    puntaje.Text = "Puntaje = " + punt;
                }
                else
                {
                    perder();
                }
            }
        }

        private void perder()
        {
            enperd = 1;
            DisplayAlert("Perdiste", " La respuesta correcta es " + res, "OK");
            perd++;
            Continuar.IsEnabled = true ;
            respuestau.IsEnabled= false ;
            continua = false ;
            if (perd == 1)
            {
                personaje.Source = data.Datos.seleccionju.ToString() + "_ca.png";

            }else if (perd == 2)
            {
                personaje.Source = data.Datos.seleccionju.ToString() + "_cu.png";

            }
            else if (perd == 3)
            {
                personaje.Source = data.Datos.seleccionju.ToString() + "_nb.png";

            }
            else if (perd == 4)
            {
                personaje.Source = data.Datos.seleccionju.ToString() + "_np.png";

            }
            else if (perd == 5)
            {
                personaje.Source = data.Datos.seleccionju.ToString() + "_pie.png";

            }
            else if (perd == 6)
            {   
                if (data.Datos.record < punt)
                {

                    data.Datos.record = punt;

                }
                record.Text = "Record = " + data.Datos.record.ToString();
                personaje.Source = data.Datos.seleccionju.ToString() + "_com.png";
                Continuar.IsEnabled= true;
                cambiodificultad.IsEnabled= true ;
                cambiopersonaje.IsEnabled = true;
                Continuar.Text = "Reiniciar";

            }
        }

        public void cambiardi(object sender, EventArgs e)
        {
            dificultad++;
            if (dificultad == 1)
            {
                cambiodificultad.Text = "Dificultad:Normal";
            }
            else  if (dificultad == 2)
            {
                cambiodificultad.Text = "Dificultad:Dificil";
            }
            else
            {
                dificultad = 0;
                cambiodificultad.Text = "Dificultad:Facil";
            }
        }

        public async void cambiarper(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Personajes());
        }


    }

}
