using System;

namespace ClassLibrary
{
    /// <summary>
    /// Tablero de modo rapido creado en caso de diseñar dicho modo.
    /// </summary>
    public class LogicaDePartidaRapida : LogicaDePartida
    {
        /// <summary>
        /// Atributo con el contador del segundo ataque de cada personaje.
        /// </summary>
        public int[] Segundastiradas = new int[2];
        /// <summary>
        /// En este contructor se asigna el tamaño de la matriz, se crea la misma y se asigna el dueño del Tablero.
        /// </summary>
        /// <param name="tamaño"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <returns></returns>
        public LogicaDePartidaRapida(int tamaño ,int jugador1, int jugador2) : base (tamaño , jugador1, jugador2)
        {
            tableros[0] = new Tablero(tamaño,jugador1);
            jugadores[0]=jugador1; //Simboliza los jugadores, puede cambiarse a futuro
            jugadores[1]=jugador2;
            tableros[1] = new Tablero(tamaño,jugador2);
            cantidadDeBarcosParaPocicionar[0]= (tamaño * 2) - 3 ;
            cantidadDeBarcosParaPocicionar[1]= (tamaño * 2) - 3 ;
            tiradas[0]=0;
            tiradas[1]=0;
            Segundastiradas[0]=0;
            Segundastiradas[1]=0;
            PartidasEnJuego.AlmacenarLogicadePartida(this);
        }
        /// <summary>
        /// Metodo encargado de llamar al metodo Atacar de Logica de Tablero se cambia ya que se debe controlar
        /// que ejecute su segundo tiro antes de que ataque el otro.
        /// </summary>
        /// <param name="LugarDeAtaque"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public override string Atacar(string lugar, int jugador)
        {
            int [] LugarDeAtaque = TraductorDeCoordenadas.Traducir(lugar);
            if (pocicionamientoTerminado[0] || pocicionamientoTerminado[1])
            {
                return "La Etapa de pocicionamiento a terminado";
            }
            if (!(this.jugadores[0] == jugador || this.jugadores[1] == jugador )){ return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";}
            if (LugarDeAtaque[0] >= tableros[0].Tamaño && LugarDeAtaque[1] >= tableros[0].Tamaño){return "Las coordenadas enviadas son erroneas";}
            int fila = LugarDeAtaque[0];
            int columna = LugarDeAtaque[1];
            if (jugador == jugadores[0])
            {
                if (tiradas[0]==tiradas[1] && Segundastiradas[0]==Segundastiradas[1])
                {
                    
                    Tablero tablerobjetivo = tableros[1];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    tiradas[0]+=1;
                    PartidaTerminada=tablerobjetivo.terminado;
                    return respuesta;

                }
                else if (Segundastiradas[0]==Segundastiradas[1])
                {
                    Tablero tablerobjetivo = tableros[1];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    Segundastiradas[0]+=1;
                    PartidaTerminada=tablerobjetivo.terminado;
                    return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else if (jugador == jugadores[1])
            {
                if (tiradas[0]>tiradas[1] && Segundastiradas[0] > Segundastiradas[1])
                {
                    
                    Tablero tablerobjetivo = tableros[0];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    tiradas[1]+=1;
                    PartidaTerminada=tablerobjetivo.terminado;
                    return respuesta;

                }
                else if (Segundastiradas[0]>Segundastiradas[1])
                {
                    Tablero tablerobjetivo = tableros[0];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    Segundastiradas[1]+=1;
                    PartidaTerminada=tablerobjetivo.terminado;
                    return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else
            {
            return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
            }

        }
       
        
    }
}