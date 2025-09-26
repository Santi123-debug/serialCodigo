using System;
using System.IO.Ports;
using System.Threading;

class Program
{
    static SerialPort? serial;

    static void Main(string[] args)
    {
        string portName = args.Length > 0 ? args[0] : "COM3";
        int baud = args.Length > 1 ? int.Parse(args[1]) : 9600;

        Console.WriteLine("Puertos disponibles: " + string.Join(", ", SerialPort.GetPortNames()));

        serial = new SerialPort(portName, baud)
        {
            NewLine = "\n",
            ReadTimeout = 1000,
            DtrEnable = true
        };

        try
        {
            serial.Open();
            // Dejar estabilizar y enviar handshake para Arduino Uno
            Thread.Sleep(100);
            try { serial.Write("S"); Console.WriteLine($"Handshake 'S' enviado a {portName}"); } catch { }

            serial.DataReceived += Serial_DataReceived;

            Console.WriteLine($"Abierto {portName} a {baud} bps. Pulsa ENTER para cerrar.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            if (serial != null && serial.IsOpen) serial.Close();
        }
    }

    private static void Serial_DataReceived(object? sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            var sp = (SerialPort)sender!;
            string line = sp.ReadLine().Trim();
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {line}");
        }
        catch (TimeoutException) { }
        catch (Exception ex)
        {
            Console.WriteLine($"Error lectura serial: {ex.Message}");
        }
    }
}
