﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_1.Models.PeruTourism;
using System.Data.SqlClient;
using System.Data;

namespace Demo_1.Repository.PeruTourism
{
    public class FichaPropuestaAccess
    {





        public IEnumerable<Programa> ObtenerListadoPropuesta(int pNroPedido)
        {
            try
            {
                List<Programa> lstfprograma = new List<Programa>();

                using (SqlConnection con = new SqlConnection(Data.Data.StrCnx_WebsSql))
                {

                    //SqlCommand cmd = new SqlCommand("VTA_PropuestaServicio_S_GG", con);
                    SqlCommand cmd = new SqlCommand("P4E_Publica_S", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@CodZonaVta", SqlDbType.Char,3).Value = "PER";
                    cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = pNroPedido;
                    //cmd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = 6;

                    //cmd.Parameters.AddWithValue("@NroPedido", 162436);
                    //cmd.Parameters.AddWithValue("@NroPropuesta", 8);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Programa fprograma = new Programa
                        {

                            FchSys = Convert.ToDateTime(rdr["FchSys"].ToString()),
                            NroPrograma = rdr["NroPrograma"].ToString(),
                            StsPrograma = rdr["StsPrograma"].ToString(),
                            DesPrograma = rdr["DesPrograma"].ToString(),
                            CantDias = Convert.ToInt32(rdr["CantDias"]),
                            KeyReg = rdr["KeyReg"].ToString()

                        };

                        lstfprograma.Add(item: fprograma);
                    }

                    con.Close();
                }

                return lstfprograma;

            }
            catch (Exception ex)
            {
                throw;
            }
        }















        public IEnumerable<Propuesta> ObtenerListadoPropuesta_GG()
        {
            try
            {
                List<Propuesta> lstfpropuesta = new List<Propuesta>();

                using (SqlConnection con = new SqlConnection(Data.Data.StrCnx_WebsSql))
                {

                    //SqlCommand cmd = new SqlCommand("VTA_PropuestaServicio_S_GG", con);
                    SqlCommand cmd = new SqlCommand("VTA_PropuestaNroPedido_S_GG", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = 147140;
                    //cmd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = 6;

                    //cmd.Parameters.AddWithValue("@NroPedido", 162436);
                    //cmd.Parameters.AddWithValue("@NroPropuesta", 8);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Propuesta fpropuesta = new Propuesta
                        {
                            NroPedido = Convert.ToInt32(rdr["NroPedido"]),
                            NroPropuesta = Convert.ToInt32(rdr["NroPropuesta"]),
                            DesPropuesta = rdr["DesPropuesta"].ToString()
                            //NroDia = Convert.ToInt32(rdr["NroDia"]),
                            //7NroOrden = Convert.ToInt32(rdr["NroOrden"]),
                            //NroServicio = Convert.ToInt32(rdr["NroServicio"]),
                            //DesServicio = rdr["DesServicio"].ToString(),
                            //DesServicioDet = rdr["DesServicioDet"].ToString()
                        };

                        lstfpropuesta.Add(item: fpropuesta);
                    }

                    con.Close();
                }

                return lstfpropuesta;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Propuesta> ObtenerDetallePropuesta(int nroPedido, int nroPropuesta)
        {
            try
            {
                List<Propuesta> lstpropuestadet = new List<Propuesta>();

                using (SqlConnection con = new SqlConnection(Data.Data.StrCnx_WebsSql))
                {

                    SqlCommand cmd = new SqlCommand("VTA_PropuestaServicio_S_GG", con);
                    //SqlCommand cmd = new SqlCommand("VTA_PropuestaNroPedido_S", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = nroPedido;
                    cmd.Parameters.Add("@NroPropuesta", SqlDbType.Int).Value = nroPropuesta;

                    //cmd.Parameters.AddWithValue("@NroPedido", 162436);
                    //cmd.Parameters.AddWithValue("@NroPropuesta", 8);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        Propuesta fpropuesta = new Propuesta
                        {
                            NroPedido = Convert.ToInt32(rdr["NroPedido"]),
                            //NroPropuesta = Convert.ToInt32(rdr["NroPropuesta"]),
                            //DesPropuesta = rdr["DesPropuesta"].ToString()
                            NroDia = Convert.ToInt32(rdr["NroDia"]),
                            NroOrden = Convert.ToInt32(rdr["NroOrden"]),
                            NroServicio = Convert.ToInt32(rdr["NroServicio"]),
                            DesServicio = rdr["DesServicio"].ToString(),
                            DesServicioDet = rdr["DesServicioDet"].ToString()

                        };

                        lstpropuestadet.Add(item: fpropuesta);
                    }

                    con.Close();
                }

                return lstpropuestadet;

            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}