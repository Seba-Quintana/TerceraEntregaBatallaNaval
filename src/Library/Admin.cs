using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Admin
    {
        public List<PerfilUsuario> ListaDeUsuarios = new List<PerfilUsuario>();
    
        public void Registrar(string nombre, int id, string contraseña)
        {
                
            //PerfilUsuario usuario = new PerfilUsuario (nombre,id,contraseña);
            //ListaDeUsuarios.Add(usuario);
        }
        public void Remover(int NumeroDeJugador)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (usuario.NumeroDeJugador == NumeroDeJugador)
                {
                    ListaDeUsuarios.Remove(usuario);
                }
            }
        }

        public PerfilUsuario ObtenerPerfil(int usuario)
        {
            int i = 0;
            while (i != ListaDeUsuarios.Count - 1)
            {
                if (ListaDeUsuarios[i].NumeroDeJugador == usuario)
                    return ListaDeUsuarios[i];
                i++;
            }
            return null;
        }

        public void ObtenerTableroOponente(PerfilUsuario PerfilOponente)
        {
            //char[,] matrizImprimir = PerfilOponente.TableroActual.matriz.Clone();
        }

        void ObtenerTablero(string[] tablero)
        {
            //Iimpresora.ImprimirTablero(tablero);
        }

        void ObtenerHistorial(int numerodejugador)
        {
            try
            {
                if (numerodejugador == 0)
                {
                    List<DatosdePartida> historial = Historial.partidas;
                    //ImpresoraConsola.ImprimirHistorial(historial);
                }
                else if (ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)))
                {
                    PerfilUsuario perfil = ObtenerPerfil(numerodejugador);
                    //ImpresoraConsola.ImprimirHistorial(perfil.VerHistorialPersonal());
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Usuario no encontrado");
                throw e;
            }
        }

        public void ObtenerRanking()
        {

            List<PerfilUsuario> ranking = new List<PerfilUsuario>();
            int i = 0;
            while (i < ListaDeUsuarios.Count)
            {
                ranking.Add(ListaDeUsuarios[i]);
                i++;
            }
            int j = 0;
            i = 0;
            int actual = 0;
            while ((actual < ListaDeUsuarios.Count))
            {   i=actual;
                j= i+1;
                while ((i < ListaDeUsuarios.Count)&&(j < ListaDeUsuarios.Count))
                {
                    if (ranking[i].Ganadas < ranking[j].Ganadas)
                    {
                        j=j+1;
                    }
                    else 
                    {
                        i=j;
                        j=j+1;
                    }
                }
                PerfilUsuario claseCopia = (PerfilUsuario)ranking[i].Clone();
                ranking[i] = (PerfilUsuario)ranking[actual].Clone();
                ranking[actual] = claseCopia;
                actual++;
            }   
            //ImpresoraConsola imprimir = new ImpresoraConsola(); 
            //imprimir.ImprimirRanking(ranking);
        }

        public void ActualizarHistorial(DatosdePartida partida)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (partida.Ganador == usuario.NumeroDeJugador || partida.Perdedor == usuario.NumeroDeJugador)
                {
                    //PerfilUsuario.AñadiralHistorial(partida);
                }
            }
        }

        public void CrearTablero(int Tamaño, int dueño)
        {
            Tablero tablero = new Tablero(Tamaño, dueño);
        }

        public void ActualizarTablero(int filas, int columnas, char nuevovalor)
        {
            //Tablero.ActualizarTablero(filas, columnas, nuevovalor);
        }
    }

}