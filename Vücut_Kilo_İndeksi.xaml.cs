namespace görselÖdevDeneme;

public partial class Vücut_Kilo_İndeksi : ContentPage
{
	public Vücut_Kilo_İndeksi()
	{
		InitializeComponent();

	}
    private void CalculateBMI(object sender, EventArgs e)
    {
        if (double.TryParse(txtWeight.Text, out double weight) && double.TryParse(txtHeight.Text, out double height))
        {

            height = height / 100.0;


            double bmi = weight / (height * height);


            string category = GetBMICategory(bmi);

            lblResult.Text = $"VKI: {bmi:F2}\nKategori: {category}";
        }
        else
        {
            lblResult.Text = "Geçerli kilo ve boy değerleri girin.";
        }
    }

    private string GetBMICategory(double bmi)
    {
        if (bmi < 16)
            return "İleri düzeyde zayıf";
        else if (bmi >= 16 && bmi < 16.99)
            return "Orta düzeyde zayıf";
        else if (bmi >= 17 && bmi < 18.49)
            return "Hafif düzeyde zayıf ";
        else if (bmi >= 18.50 && bmi < 27.9)
            return "Normal kilolu";
        else if (bmi >= 25 && bmi < 29.99)
            return "Hafif şişman ";
        else if (bmi >= 30 && bmi < 34.99)
            return "Birinci derecede obez";
        else if (bmi >= 35 && bmi < 39.99)
            return "İkinci derecede obez";
        else
            return "Üçüncü dereceden obez ";
    }
}
