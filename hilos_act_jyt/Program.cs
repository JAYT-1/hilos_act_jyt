using System;
using System.Threading;

namespace AdministracionCuentasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creandos una cuenta bancaria con un saldo inicial de 1000
            CuentaBancaria cuenta = new CuentaBancaria(1000);

            // Creandos hilos para simular procesos de ingreso y retiro de dinero
            Thread hiloIngreso = new Thread(() =>
            {
                cuenta.Ingresar(630);
            });

            Thread hiloRetiro = new Thread(() =>
            {
                cuenta.Retirar(155);
            });

            // Iniciamos los hilos
            hiloIngreso.Start();
            hiloRetiro.Start();

            
            hiloIngreso.Join();
            hiloRetiro.Join();

            
            Console.WriteLine("Saldo final: " + cuenta.ObtenerSaldo());

            Console.ReadKey();
        }
    }

    // Clase que representa una cuenta bancaria
    class CuentaBancaria
    {
        private decimal saldo;

        public CuentaBancaria(decimal saldoInicial)
        {
            saldo = saldoInicial;
        }

        public void Ingresar(decimal monto)
        {
            // Simulamos un proceso que lleva tiempo
            Thread.Sleep(1500);
            saldo += monto;
            Console.WriteLine("Se ingresaron " + monto + " dólares");
        }

        public void Retirar(decimal monto)
        {
            
            Thread.Sleep(1500);
            if (monto <= saldo)
            {
                saldo -= monto;
                Console.WriteLine("Se retiraron " + monto + " dólares");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes");
            }
        }

        public decimal ObtenerSaldo()
        {
            return saldo;
        }
    }
}
