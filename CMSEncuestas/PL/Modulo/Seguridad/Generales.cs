﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PL.Modulo.Seguridad
{
    /// <summary>
    /// Clase con metodos genrales del proyecto PL
    /// </summary>
    public class Generales
    {
        /// <summary>
        /// Obtiene la direccion IP del cliente
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string IPAddress = string.Empty;
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}