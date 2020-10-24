﻿using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionIntegral.CapaNegocio
{
    class MetodosFamilia: ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionFamilia);
            Comando.Parameters.AddWithValue("@lista1", tr.Lista1);
            Comando.Parameters.AddWithValue("@lista2", tr.Lista2);
            Comando.Parameters.AddWithValue("@lista3", tr.Lista3);
            Comando.Parameters.AddWithValue("@tizada", tr.Tizada);
            Comando.Parameters.AddWithValue("@papel", tr.Papel);
            Comando.Parameters.AddWithValue("@tela", tr.Tela);
            Comando.ExecuteNonQuery();
            
            Conexion.Close();
        }

        public void EliminarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.Parameters.Clear();
            Comando.CommandText = "FamiliaDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.ExecuteNonQuery();
         
            Conexion.Close();
        }

        public void EditarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionFamilia);
            Comando.Parameters.AddWithValue("@lista1", tr.Lista1);
            Comando.Parameters.AddWithValue("@lista2", tr.Lista2);
            Comando.Parameters.AddWithValue("@lista3", tr.Lista2);
            Comando.Parameters.AddWithValue("@tizada", tr.Tizada);
            Comando.Parameters.AddWithValue("@papel", tr.Papel);
            Comando.Parameters.AddWithValue("@tela", tr.Tela);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public List<Familia> ListarFamilia(string condicion)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", condicion);
          
            LeerFilas = Comando.ExecuteReader();
            List<Familia> ListaGenerica = new List<Familia>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Familia
                {
                    IdFamilia = LeerFilas.GetInt32(0),
                    DescripcionFamilia = LeerFilas.GetString(1),
                    Lista1 = LeerFilas.GetInt32(2),
                    Lista2 = LeerFilas.GetInt32(3),
                    Lista3 = LeerFilas.GetInt32(4),
                    Tizada = LeerFilas.GetInt32(5),
                    Papel = LeerFilas.GetInt32(6),
                    Tela = LeerFilas.GetInt32(7),
                    Activo = LeerFilas.GetBoolean(8)

                }); ;
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public Familia CrearFamilia(int id)
        {
            Familia tr = new Familia();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion",Convert.ToString(id));
         
            LeerFilas = Comando.ExecuteReader();
            List<Familia> ListaGenerica = new List<Familia>();
            while (LeerFilas.Read())
            {
                tr.IdFamilia = LeerFilas.GetInt32(0);
                tr.DescripcionFamilia = LeerFilas.GetString(1);
                tr.Lista1= LeerFilas.GetInt32(2);
                tr.Lista2 = LeerFilas.GetInt32(3);
                tr.Lista3 = LeerFilas.GetInt32(4);
                tr.Tizada = LeerFilas.GetInt32(5);
                tr.Papel = LeerFilas.GetFloat(6);
                tr.Tela = LeerFilas.GetFloat(7);
                tr.Activo = LeerFilas.GetBoolean(8);
            }
            LeerFilas.Close();
            Conexion.Close();
            return tr;
        }

    }
}
