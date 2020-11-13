using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_Tool
{
    public class DHCP
    {
        /// <summary>
        /// Get all the DHCP server addresses that the PC uses
        /// </summary>
        public List<string> GetDHCPServerAddresses()
        {
            List<String> DHCPServers = new List<string>();
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    foreach (IPAddress address in addresses)
                    {
                        DHCPServers.Add(address.ToString());
                    }
                }
            }
            return (DHCPServers);
        }
    }
}
