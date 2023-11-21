

namespace görselÖdevDeneme;

public partial class Kredi_Hesaplama : ContentPage
{
    public Kredi_Hesaplama()
    {
        InitializeComponent();
    }
    private void HesaplaButton_Clicked(object sender, EventArgs e)
    {

        string krediTuru = KrediTuruPicker.SelectedItem.ToString();

        double faizOrani = Convert.ToDouble(FaizOraniEntry.Text);
        double krediTutari = Convert.ToDouble(KrediTutariEntry.Text);
        int vadeSuresi = Convert.ToInt32(VadeSuresiEntry.Text);

        double bsmvOrani = 0;
        double kkdfOrani = 0;

        switch (krediTuru)
        {
            case "İhtiyaç Kredisi":
                bsmvOrani = 0.10;
                kkdfOrani = 0.15;
                break;
            case "Konut Kredisi":
                bsmvOrani = 0.00;
                kkdfOrani = 0.00;

                break;
            case "Taşıt Kredisi":
                bsmvOrani = 0.05;
                kkdfOrani = 0.15;
                break;
            case "Ticari Kredi":
                bsmvOrani = 0.05;
                kkdfOrani = 0.00;
                break;
        }

        double brutFaiz = ((faizOrani + (faizOrani * bsmvOrani) + (faizOrani * kkdfOrani)) / 100);
        double taksit = ((Math.Pow(1 + brutFaiz, vadeSuresi) * brutFaiz) / (Math.Pow(1 + brutFaiz, vadeSuresi) - 1)) * krediTutari;
        double toplam = taksit * vadeSuresi;

        SonucLabel.Text = $"Aylık Taksit: {taksit:C2}\nToplam Ödeme: {toplam:C2}\nToplam Faiz: {toplam - krediTutari:C2}";
    }
}



