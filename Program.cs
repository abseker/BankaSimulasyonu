Musteri musterim = new Musteri("Berk");
musterim.HesapAc("Berk");
Hesap hesabim = musterim.Hesaplar[0];

bool calisiyor = true;

while (calisiyor)
{
    Console.WriteLine("\n=== Banka Hesabi Simulasyonu ===");
    Console.WriteLine("1. Para Yatir");
    Console.WriteLine("2. Para Cek");
    Console.WriteLine("3. Bakiye Goruntule");
    Console.WriteLine("4. İslem Gecmisi");
    Console.WriteLine("5. Cikis");
    Console.WriteLine("6. Yeni Hesap Ac");
    Console.WriteLine("7. Tum Hesaplari Goster");
    Console.WriteLine("Secim: ");

    string secim = Console.ReadLine() ?? "";

    switch (secim)
    {
        case "1":
            Console.WriteLine("Yatirilacak Tutar: ");
            double yatirilacak = Convert.ToDouble(Console.ReadLine());
            hesabim.ParaYatir(yatirilacak);
            Console.WriteLine($"Yeni Bakiye: {hesabim.BakiyeGoster()} TL");
            break;

        case "2":
            Console.WriteLine("Cekilecek Tutar: ");
            double cekilecek = Convert.ToDouble(Console.ReadLine());
            hesabim.ParaCek(cekilecek);
            Console.WriteLine($"Yeni Bakiye: {hesabim.BakiyeGoster()} TL");
            break;

        case "3":
            Console.WriteLine($"Bakiye: {hesabim.BakiyeGoster()} TL");
            break;

        case "4":
            hesabim.GecmisGoster();
            break;

        case "5":
            Console.WriteLine("Cikis Yapiliyor...");
            calisiyor = false;
            break;

        case "6":
            Console.WriteLine("Yeni hesap sahibinin adi:");
            string yeniSahip = Console.ReadLine() ?? "";
            musterim.HesapAc(yeniSahip);
            break;

        case "7":
            musterim.TumHesaplariGoster();
            break;

        default:
            Console.WriteLine("Gecersiz Secim!");
            break;
    }
}

class Hesap
{
    private double bakiye = 0;
    public List<string> Islemler = new List<string>();
    public string SahipAdi;

    public Hesap(string sahipAdi)
    {
        SahipAdi = sahipAdi;
        Console.WriteLine($"{sahipAdi} adina hesap acildi.");
    }

    public double BakiyeGoster()
    {
        return bakiye;
    }

    public void ParaYatir(double tutar)
    {
        bakiye = bakiye + tutar;
        Islemler.Add($"{tutar} TL yatirildi.");
    }

    public void ParaCek(double tutar)
    {
        if (tutar > bakiye)
        {
            Console.WriteLine("Yetersiz bakiye!");
            return;
        }

        bakiye = bakiye - tutar;
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
class Musteri
{
    public string Ad;
    public List<Hesap> Hesaplar = new List<Hesap>();

    public Musteri(string ad)
    {
        Ad = ad;
    }

    public void HesapAc(string sahipAdi)
    {
        Hesap yeniHesap = new Hesap(sahipAdi);
        Hesaplar.Add(yeniHesap);
    }

    public void TumHesaplariGoster()
    {
        Console.WriteLine($"{Ad} adli musterinin hesaplari: ");
        foreach (Hesap hesap in Hesaplar)
        {
            Console.WriteLine($"- {hesap.SahipAdi}: {hesap.BakiyeGoster()} TL");
        }
    }
}