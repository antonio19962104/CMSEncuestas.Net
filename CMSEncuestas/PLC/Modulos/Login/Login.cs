using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLC.Modulos.Login
{
    public static class Login
    {
        public static string Autenticar(ML.Administrador aAdministrador)
        {
            try
            {
                var result = BL.Administrador.Autenticar(aAdministrador);
                if (!result.Correct)
                    return result.ExMessage;
                if (!result.Correct && result.Data.GetType().ToString() == "string")
                    return 
                var cadenaAdmin = admin.
                var token = Encrypt._Encrypt.Encrypt(admin.Username, admin.Password);    
                return token;
            }
            catch (Exception aE)
            {
                return "error";
            }
        }
    }
}
