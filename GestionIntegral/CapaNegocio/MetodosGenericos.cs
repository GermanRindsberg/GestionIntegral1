﻿using GestionIntegral.CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionIntegral.CapaNegocio
{
    class MetodosGenericos : ConexionBBDD //heredo de conexion asi tengo los metodos de conexion
    {
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();
        public int idProvincia;

        public void LlenarComboBox(ComboBox cb, string nombreTabla)
        {
            if (nombreTabla == "Localidad")
            {
                DataTable Tabla = new DataTable();
                Comando.Connection = Conexion;
                Comando.CommandText = "ListarLocalidad";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@idProvincia", idProvincia);
                Conexion.Open();
                LeerFilas = Comando.ExecuteReader();
                Tabla.Load(LeerFilas);
                DataRow workRow = Tabla.NewRow();
                workRow[0] = 0;
                workRow[1] = 0;
                workRow[2] = "Seleccione un valor";
                workRow[3] = 0000;
                Tabla.Rows.InsertAt(workRow, 0);
                LeerFilas.Close();
                Conexion.Close();
                cb.DataSource = Tabla;
                cb.DisplayMember = "nombre";
                cb.ValueMember = "id";
                cb.AutoCompleteMode = AutoCompleteMode.Suggest;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            else
            {
                DataTable Tabla = new DataTable();
                Comando.Connection = Conexion;
                Comando.CommandText = "RellenarComboBox";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@nombreTabla", nombreTabla);
                Comando.Parameters.AddWithValue("@activo", 1);
                Conexion.Open();
                LeerFilas = Comando.ExecuteReader();
                Tabla.Load(LeerFilas);
                DataRow workRow = Tabla.NewRow();
                workRow[0] = 0;
                workRow[1] = "Seleccione un valor";
                Tabla.Rows.InsertAt(workRow, 0);
                LeerFilas.Close();
                Conexion.Close();
                cb.DataSource = Tabla;

                if (nombreTabla == "Provincia")
                {
                    cb.DisplayMember = "nombre";
                }
                else
                {
                    cb.DisplayMember = "razonSocial";
                }

                cb.ValueMember = "id";
                cb.AutoCompleteMode = AutoCompleteMode.Suggest;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

        }



    }
}
