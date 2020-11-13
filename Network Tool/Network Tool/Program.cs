using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            DNS dns = new DNS();
            DHCP dhcp = new DHCP();
            Networking networking = new Networking();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Resolve Hostname");
                Console.WriteLine("2) Resolve IP");
                Console.WriteLine("3) Get DHCP Server Addresses");
                Console.WriteLine("4) Local ping");
                Console.WriteLine("5) Traceroute");
                Console.Write("\r\nSelect an option: ");


                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\r\nEnter IP Address: ");
                        string UserIP = Console.ReadLine();
                        Console.WriteLine(dns.ResolveHostname(UserIP));
                        break;
                    case "2":
                        Console.Write("\r\nEnter Hostname: ");
                        string UserHostname = Console.ReadLine();
                        Console.WriteLine(dns.ResolveIP(UserHostname));
                        break;
                    case "3":
                        List<String> dhcpAddresses = dhcp.GetDHCPServerAddresses();
                        foreach (var dhcpAddress in dhcpAddresses)
                        {
                            Console.WriteLine(dhcpAddress);
                        }
                        break;
                    case "4":
                        Console.WriteLine(networking.LocalPing());
                        break;
                    case "5":
                        Console.Write("\r\nEnter Hostname or IP Address: ");
                        string UserHostnameOrIPAddress = Console.ReadLine();
                        Console.WriteLine(networking.Traceroute(UserHostnameOrIPAddress));
                        break;
                    default:
                        Console.WriteLine("Invalid key");
                        break;
                }
                Console.WriteLine("Press any key to resume..");
                Console.ReadLine();
            }
        }
    }
}
