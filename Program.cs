Hesap hesabim = new Hesap();

bool calisiyor = true;

while (calisiyor)
{
    Console.WriteLine("\n=== Banka Hesabi Simulasyonu ===");
    Console.WriteLine("1. Para Yatir");
    Console.WriteLine("2. Para Cek");
    Console.WriteLine("3. Bakiye Goruntule");
    Console.WriteLine("4. İslem Gecmisi");
    Console.WriteLine("5. Cikis");
    Console.WriteLine("Secim: ");

    string secim = Console.ReadLine() ?? "";

    switch (secim)
    {
        case "1":
            Console.WriteLine("Yatirilacak Tutar: ");
            double yatirilacak = Convert.ToDouble(Console.ReadLine());
            hesabim.ParaYatir(yatirilacak);
            Console.WriteLine($"Yeni Bakiye: {hesabim.Bakiye} TL");
            break;
        
        case "2":
            Console.WriteLine("Cekilecek Tutar: ");
            double cekilecek = Convert.ToDouble(Console.ReadLine());
            hesabim.ParaCek(cekilecek);
            Console.WriteLine($"Yeni Bakiye: {hesabim.Bakiye} TL");
            break;
        
        case "3":
            Console.WriteLine($"Bakiye: {hesabim.Bakiye} TL");
            break;

        case "4":
            hesabim.GecmisGoster();
            break;

        case "5":
            Console.WriteLine("Cikis Yapiliyor...");
            calisiyor = false;
            break;

        default:
            Console.WriteLine("Gecersiz Secim!");
            break;
    }
}

hesabim.ParaYatir(500);
Console.WriteLine($"500 TL yatirildi. Yeni Bakiye : {hesabim.Bakiye}");

hesabim.ParaCek(250);
Console.WriteLine($"200 TL cekildi. Yeni Bakiyeniz: {hesabim.Bakiye}");

hesabim.GecmisGoster();
class Hesap
{
    public double Bakiye = 0;
    public List<string> Islemler = new List<string>();

    public void ParaYatir(double tutar)
    {
        Bakiye = Bakiye + tutar;
        Islemler.Add($"{tutar} TL yatirildi.");
    }

    public void ParaCek(double tutar)
    {
        if (tutar > Bakiye)
        {
            Console.WriteLine("Yetersiz bakiye!");
            return;
        }

        Bakiye = Bakiye - tutar;
        Islemler.Add($"{tutar} TL cekildi");
    }

    public void GecmisGoster()
    {
        Console.WriteLine("İslem Gecmisi: ");
        foreach (string islem in Islemler)
        {
            Console.WriteLine($"- {islem}");
        }
    }
}