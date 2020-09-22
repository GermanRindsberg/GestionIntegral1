using System;

namespace GestionIntegral.CapaDatos
{
    class Cliente
    {
        private int idCliente;
        private string razonSocial;
        private int idDireccion;
        private string tel1;
        private string tel2;
        private Boolean activo;
        private string email;
        private string cuit;
        private int idTransporte;
        private DateTime fechaAlta;
        private string observaciones;
        private int tipoLista;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Tel1 { get => tel1; set => tel1 = value; }
        public string Tel2 { get => tel2; set => tel2 = value; }
        public bool Activo { get => activo; set => activo = value; }
        public string Email { get => email; set => email = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int TipoLista { get => tipoLista; set => tipoLista = value; }

        public Cliente(string razonSocial, int idDireccion, string tel1, string tel2, bool activo, 
            string email, string cuit, int idTransporte, DateTime fechaAlta, string observaciones, int tipoLista)
        {
            RazonSocial = razonSocial;
            IdDireccion = idDireccion;
            Tel1 = tel1;
            Tel2 = tel2;
            Activo = activo;
            Email = email;
            Cuit = cuit;
            IdTransporte = idTransporte;
            FechaAlta = fechaAlta;
            Observaciones = observaciones;
            TipoLista = tipoLista;
        }

        public Cliente()
        { }

        public Cliente(int idCliente, string razonSocial, int idDireccion, string tel1, string tel2, bool activo, string email, string cuit, int idTransporte, DateTime fechaAlta, string observaciones, int tipoLista)
        {
            IdCliente = idCliente;
            RazonSocial = razonSocial;
            IdDireccion = idDireccion;
            Tel1 = tel1;
            Tel2 = tel2;
            Activo = activo;
            Email = email;
            Cuit = cuit;
            IdTransporte = idTransporte;
            FechaAlta = fechaAlta;
            Observaciones = observaciones;
            TipoLista = tipoLista;
        }
    }
}
