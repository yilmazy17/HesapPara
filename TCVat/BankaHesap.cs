using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TCVat
{
    abstract class BankaHesap
    {
        public long HesapNo { get; set; }
        public int SubeKodu { get; set; }
        public string IBAN { get; set; }
        public decimal Bakiye { get; set; }

        public virtual string ParaCek(decimal tutar)
        {
            Bakiye -= tutar;
            return "Hesabınızdan " + tutar + " TL para cektiniz. Guncel Bakiyeniz: " + Bakiye; 
        }
        public virtual string ParaYatir(decimal tutar)
        {
            Bakiye += tutar;
            return "Hesabınıza " + tutar + " TL para yatirdiniz. Guncel Bakiyeniz: " + Bakiye;
        }
    }
    class VadesizHesap : BankaHesap
    {
        public override string ParaCek(decimal tutar)
        {
            if (Bakiye < tutar)
            {
                return "Yetersiz Bakiye";
            }

            else if (tutar % 5 == 0)
            {
                return base.ParaCek(tutar);

            }
            else
            {
                return " 5 ve 5'in katlarini cekebilirsiniz";
            }
        }

    }
    class VadeliHeesap : BankaHesap
    {
        public DateTime VadeBaslangicTarihi { get; set; }
        public int VadeGunSayisi { get; set; }

        public DateTime VadeSonuTarihi
        {
            get
            {
                return VadeBaslangicTarihi.AddDays(VadeGunSayisi);
            }
            
        }
        public override string ParaCek(decimal tutar)
        {
            if (DateTime.Today < VadeSonuTarihi.Date)
            {
                return "Vade Sonu Tarihini Bekleyiniz";
            }
            else if (Bakiye < tutar)
            {
                return "Yetersiz Bakiye";
            }
            else if (tutar % 5 == 0)
            {
                return base.ParaCek(tutar);
            }
            else
            {
                return "5 ve 5'in katlarini cekebilirsiniz.";
            }

        }
        public override string ParaYatir(decimal tutar)
        {
            if (DateTime.Today > VadeSonuTarihi.Date)
            {
                return base.ParaYatir(tutar);
            }
            else
            {
                return "Vade sonu tarihini bekleyiniz.";
            }

        }
    }
}
