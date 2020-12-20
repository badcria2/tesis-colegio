using System;
using System.Data.SqlClient;

namespace Comunes_Datos
{
    public class Conexion
    {
        #region Singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        #endregion Singleton
        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection(); 
            cn.ConnectionString = "Server=tcp:bdcolegio.database.windows.net,1433;Database=BDColegio;" +
                                "User ID=administrador;Password=85857855xD; ";
            return cn;
        }
        #endregion metodos
    }
}
