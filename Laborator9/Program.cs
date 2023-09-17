using System;

namespace Laborator9
{
    class Program
    {
        static void Main(string[] args)
        {
            Cont contCurent = new ContCurent();
            Cont contInvestitii = new ContInvestitii(23, 2);
            Cont contEconomii = new ContEconomii(10);

            contCurent.DepunereNumerar(1000);
            contInvestitii.DepunereNumerar(1000);
            contInvestitii.DepunereNumerar(700);
            contEconomii.DepunereNumerar(1000);
            contEconomii.DepunereNumerar(1000);
            contEconomii.DepunereNumerar(1000);
            contEconomii.DepunereNumerar(1000);
            Console.WriteLine();
            contCurent.ExtragereNumerar(1000);
            contCurent.ExtragereNumerar(1000);
            contCurent.ExtragereNumerar(1000);
            contCurent.ExtragereNumerar(1000);
            contCurent.ExtragereNumerar(1000);
            contCurent.ExtragereNumerar(1000); 
        }
    }

    abstract class Cont
    {
        protected decimal sold = 0.0m;

        public virtual void  DepunereNumerar(decimal suma)
        { 
            if (suma < 0)
            {
                Console.WriteLine("suma invalida");
                return;
            }
            sold += suma;
            return;

        }
        public abstract void ExtragereNumerar(decimal suma);
    }

    class ContCurent: Cont
    {
        public override void ExtragereNumerar(decimal suma)
        {
            if (suma < 0)
            {
                Console.WriteLine("suma invalida");
                return ;
            }

            if (suma > sold+500)
            {
                Console.WriteLine("suma prea mare");
                return;
            }
            sold -= suma;
        }
    }

    class ContEconomii : Cont
    {
        private int rata;
        public ContEconomii(int rataDobanzii)
        {
            this.rata = rataDobanzii;     
        }
        public override void ExtragereNumerar(decimal suma)
        {
            if (suma < 0)
            {
                Console.WriteLine("suma invalida");
                return;
            }

            if (suma > sold + 500)
            {
                Console.WriteLine("suma prea mare");
                return;
            }
            sold -= suma;

        }
        public override void DepunereNumerar(decimal suma)
        {
            if (suma <= 0)
            {
                Console.WriteLine("suma invalida");
                return;
            }
            sold += suma;
            sold = sold * (100.0m + rata) / 100.0m;
        }
    }

    class ContInvestitii: ContEconomii 
    {
        private int dayOfExtraction;
        public ContInvestitii(int rata, int dayOfExtraction) : base(rata)  
        {

        }
    public override void ExtragereNumerar(decimal suma)
    {
        if (DateTime.UtcNow.Day < dayOfExtraction)
        {
            Console.WriteLine("termenul de extractie nu a fost atins");
            return;
        }
        base.ExtragereNumerar(suma);
    }
    }

}
 