using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Disparos
    {
        private int DisparosBarcos = 0;

        private int DisparosAgua = 0 ;

        private char ResultadoDeDisparo;

        private int Tamano;

        private int Jugador1;

        private int Jugador2;
    
        public int DisparosEnGeneral()
        {
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            DatosdePartida partida = new DatosdePartida();
            Partida PartidaEnCurso = new Partida (Tamano, Jugador1, Jugador2);
            foreach (int tiradas in partida.Tiradas)
            {
                foreach (char ataques in PartidaEnCurso.respuestaDeAtaque(ResultadoDeDisparo))
                {
                    if (ataques == 'W')
                    {
                        DisparosAgua += 1;
                    }
                    if (ataques == 'T')
                    {
                        DisparosBarcos += 1;
                    }
                } 
            }
            return DisparosAgua+DisparosBarcos;
        }
    }
}    
    
    
    