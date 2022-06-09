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
            //char[,] matrizImprimir = PerfilOponente.TableroActual.matriz.Clone() as char[,];
        }

        public void ObtenerTablero(int perfil)
        {
            //Iimpresora.ImprimirTablero(tablero);
        }

        public void ObtenerHistorial(int numerodejugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            try
            {
                if (ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)) || (numerodejugador == 0)){}
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Usuario no encontrado");
                throw new NullReferenceException("Usuario no encontrado", e);
            }
            try
            {
                if (numerodejugador == 0)
                {
                    List<DatosdePartida> historial = Historial.partidas;
                    imprimir.ImprimirHistorial(historial);
                }
                else if (ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)))
                {
                    PerfilUsuario perfil = ObtenerPerfil(numerodejugador);
                    imprimir.ImprimirHistorial(perfil.VerHistorialPersonal());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo ejecutar ObtenerHistorial");
                throw new Exception("No se pudo ejecutar ObtenerHistorial", e);
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

        public void Emparejar(int modo, int jugador1)
        {
            EmparejamientoConCola.EmparejarAleatorio(modo, jugador1);
        }
        public void EmparejarAmigos(int modo, int jugador1, int jugador2)
        {
            EmparejamientoConCola.EmparejarAmigos(modo, jugador1, jugador2);
        }
    }

}