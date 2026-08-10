using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace SmartHomeMonitor
{
    class Program
    {
        static string filePath = "devices.json";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("================ SMART HOME MONITOR ================");
                Console.WriteLine("[1] View Devices");
                Console.WriteLine("[2] Add Device");
                Console.WriteLine("[3] Run Telemetry Simulation");
                Console.WriteLine("[4] View Diagnostic Alerts");
                Console.WriteLine("[5] Exit");
                Console.Write("\nSelect option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        DisplayDevices();
                        break;
                    case "2":
                        AddDevice();
                        break;
                    case "3":
                        RunTelemetrySimulation();
                        break;
                    case "4":
                        DisplayAlerts();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("\nExiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static List<Device> LoadDevices()
        {
            if (!File.Exists(filePath))
                return new List<Device>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Device>>(json) ?? new List<Device>();
        }

        static void SaveDevices(List<Device> devices)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(devices, options);
            File.WriteAllText(filePath, json);
        }

        static void DisplayDevices()
        {
            Console.Clear();
            Console.WriteLine("================ SMART HOME MONITOR ================");
            List<Device> devices = LoadDevices();

            Console.WriteLine("ID  | Device Name      | Room        | Status  | Temp   | Battery");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var d in devices)
            {
                Console.WriteLine($"{d.Id,-3} | {d.Name,-16} | {d.Room,-11} | {d.Status,-7} | {d.Temperature,4}°C | {d.BatteryLevel}%");
            }

            Console.WriteLine("\nPress [Enter] to return to Main Menu...");
            Console.ReadLine();
        }

        static void AddDevice()
        {
            Console.Clear();
            Console.WriteLine("================ ADD NEW DEVICE ================");
            List<Device> devices = LoadDevices();

            Console.Write("Enter Device ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Device Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Room: ");
            string room = Console.ReadLine() ?? "";

            Device newDevice = new Device
            {
                Id = id,
                Name = name,
                Room = room,
                Status = "ONLINE",
                Temperature = 20.0,
                BatteryLevel = 100
            };

            devices.Add(newDevice);
            SaveDevices(devices);

            Console.WriteLine("\nDevice added and saved successfully!");
            Console.WriteLine("Press [Enter] to return to Main Menu...");
            Console.ReadLine();
        }

        static void RunTelemetrySimulation()
        {
            Console.Clear();
            Console.WriteLine("================ TELEMETRY SIMULATION ================");
            List<Device> devices = LoadDevices();
            Random rand = new Random();

            foreach (var d in devices)
            {
                // Simulate temp change (-2°C to +5°C) and battery drop (1% to 5%)
                d.Temperature = Math.Round(d.Temperature + (rand.NextDouble() * 7 - 2), 1);
                d.BatteryLevel = Math.Max(0, d.BatteryLevel - rand.Next(1, 6));

                // Update Status based on metrics
                if (d.Temperature > 30.0 || d.BatteryLevel < 15)
                {
                    d.Status = "ALERT";
                }
                else
                {
                    d.Status = "ONLINE";
                }
            }

            SaveDevices(devices);
            Console.WriteLine("Telemetry simulation complete. Device metrics updated!");
            Console.WriteLine("\nPress [Enter] to return to Main Menu...");
            Console.ReadLine();
        }

        static void DisplayAlerts()
        {
            Console.Clear();
            Console.WriteLine("================ DIAGNOSTIC ALERTS ================");
            List<Device> devices = LoadDevices();
            bool alertFound = false;

            foreach (var d in devices)
            {
                if (d.Temperature > 30.0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[CRITICAL] {d.Name} ({d.Room}): High Temp ({d.Temperature}°C > 30°C threshold!)");
                    Console.ResetColor();
                    alertFound = true;
                }
                if (d.BatteryLevel < 15)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[WARNING] {d.Name} ({d.Room}): Battery Low ({d.BatteryLevel}% < 15% threshold!)");
                    Console.ResetColor();
                    alertFound = true;
                }
            }

            if (!alertFound)
            {
                Console.WriteLine("All system metrics are within normal operating parameters.");
            }

            Console.WriteLine("\nPress [Enter] to return to Main Menu...");
            Console.ReadLine();
        }
    }
}