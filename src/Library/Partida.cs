using System;
using System.Linq;
namespace ClassLibrary
{
    /// <summary>
    /// Clase mediadora de la parte logica de la partida, se comunica con clases externas 
    /// y Logica. Sus responsabilidades son, Hacer un control de los ataques, de las pociciones de barco 
    /// y crear los mensajes de respuesta de estas acciones
    /// </summary>
    public class Partida
    {
        /// <summary>
        /// Variable encargada de el controlar si se puede empezar a atacar y no se puede posicionar mas.
        /// /// </summary>
        public bool PartidaTerminada;
        /// <summary>
        /// Variable encargada de el controlar si se puede empezar a atacar y no se puede posicionar mas.
        /// /// </summary>
        public bool[] posicionamientoTerminado = new bool[2];
        /// <summary>
        /// Array encargado de guardar los 2 tableros necesarios para una partida.
        /// </summary>
        public Tablero[] tableros = new Tablero[2];
        /// <summary>
        /// Almacena los int caracteristicos de cada jugador
        /// </summary>
        public int [] jugadores = new int[2];
        /// <summary>
        /// Cantidad de ataques hechos por cada jugador
        /// </summary>
        public int [] tiradas = new int[2];
        /// <summary>
        /// Simboliza la cantidad de barcos que quedan para ubicar
        /// </summary>
        public int [] cantidadDeBarcosParaPosicionar = new int[2]; 
        /// <summary>
        ///  Constructor de la clase Partida.
        /// </summary>
        /// <param name="tamaño"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        public Partida(int tamaño ,int jugador1, int jugador2)
        {
            tableros[0] = new Tablero(tamaño,jugador1);
            jugadores[0]=jugador1; //Simboliza los jugadores, puede cambiarse a futuro
            tableros[1] = new Tablero(tamaño,jugador2);
            jugadores[1]=jugador2;
            cantidadDeBarcosParaPosicionar[0]= (tamaño*tamaño*25)/100;
            cantidadDeBarcosParaPosicionar[1]= (tamaño*tamaño*25)/100;
            tiradas[0]=0;
            tiradas[1]=0;
            posicionamientoTerminado[0]=false;
            posicionamientoTerminado[1]=false;
            PartidasEnJuego.AlmacenarPartida(this);
        }

        /// <summary>
        /// Metodo llamado para finalizar, guarda los datos mas importantes de 
        /// la partida en la clase DatosDePartida
        /// </summary>
        protected void Finalizar()
        {
            DatosdePartida Almacenaje = new DatosdePartida();
            Almacenaje.Almacenar(tableros,tiradas);
            PartidasEnJuego.RemoverPartida(this);
        }
        /// <summary>
        /// Metodo encargado de ver si un ataque es posible y devolver su mensaje de respuesta.
        /// </summary>
        /// <param name="objetivo"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>

        public virtual string Atacar(string objetivo, int jugador)
        {
            int[] LugarDeAtaque = TraductorDeCoordenadas.Traducir(objetivo);

            if (LugarDeAtaque==null)
            {
                return "La coordenada enviada fue invalida";
            }
            if (!posicionamientoTerminado[0] || !posicionamientoTerminado[1])
            {
                return "Estamos en etapa de posicionamiento, si no le quedan barcos para posicionar, entonces espere a que termine de posicionar su oponente";
            }
            if (!jugadores.Contains(jugador) )
            { 
                return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
                }
            if (LugarDeAtaque[0] >= tableros[0].Tamaño && LugarDeAtaque[1] >= tableros[0].Tamaño)
            {
                return "Las coordenadas enviadas son erroneas";
                }
            
            int fila = LugarDeAtaque[0];
            int columna = LugarDeAtaque[1];
            if (jugador == jugadores[0])
            {
                if (tiradas[0]==tiradas[1])
                {
                    
                    Tablero tablerobjetivo = tableros[1];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    tiradas[0]+=1;
                    
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(tableros[0]);
                        this.Finalizar();
                    }
                    
                    return respuesta;

                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else
            {
                if (tiradas[0]>tiradas[1])
                {
                    
                    Tablero tablerobjetivo = tableros[0];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    tiradas[1]+=1;
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(tableros[1]);
                        this.Finalizar();
                    }
                    return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
            }

        }
        /// <summary>
        /// Metodo encargado de formular los mensajes que se obtienen al atacar
        /// </summary>
        /// <param name="tablerobjetivo"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public string respuestaDeAtaque(Tablero tablerobjetivo, int fila, int columna)
        {
            
            switch (tablerobjetivo.VerCasilla(fila, columna))
            {
            case 'W':
                return "La casilla ya habia sido atacada y contiene Agua";
            case 'T':
                return "La casilla ya habia sido atacada y hay una parte de barco dañada";
            case 'B':
                return "Buen tiro, has atacado a un barco";
            case '\u0000':
                return "Que lastima! has desperdiciado una bala en el agua";
            }
        
            return "Se Agrego una direccion invalida";

        }
        /// <summary>
        /// Metodo encargado de añadir los barcos
        /// </summary>
        /// <param name="coordenadanUno"></param>
        /// <param name="coordenadaDos"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public string AñadirBarco(string coordenadanUno, string coordenadaDos, int jugador)
        {
            int [] coordenada1 = TraductorDeCoordenadas.Traducir(coordenadanUno);
            int [] coordenada2 = TraductorDeCoordenadas.Traducir(coordenadaDos);
            if (coordenada1==null || coordenada2==null)
            {
                return "Una de las coordenadas enviadas fue invalida";
            }
            if ((posicionamientoTerminado[0] && posicionamientoTerminado[1]))
            {
                return "La Etapa de posicionamiento a terminado";
            }
            if (!(this.jugadores[0] == jugador || this.jugadores[1] == jugador ))
            {
                return "Posicionamiento no ejecutado, ya que quien pociciona el barco no es uno de los jugadores de la partida";}
            // Estaria bueno un try Catch aca para ver que las coordenadas sean inferiores al tamaño de las matrices.
            // que vea que se haya vaciado la clase posicionamiento.
            int [] coordenadasOrdenadas = ordenadorDeCoordenadas(coordenada1,coordenada2);
            int filainicio = coordenadasOrdenadas[0];
            int columnainicio = coordenadasOrdenadas[1];

            int filafinal = coordenadasOrdenadas[2];
            int columnafinal = coordenadasOrdenadas[3];

            int casillasutilizadas = largoDeBarcos(filainicio, columnainicio, filafinal, columnafinal);

            if (casillasutilizadas == 0)
            {
                return "No se pueden agregar barcos diagonalmente";
            }
            
            if (jugador == jugadores[0])
            {
                
                if (casillasutilizadas <= cantidadDeBarcosParaPosicionar[0])
                {
                    
                    string respuesta;
                    try{
                        respuesta = respuestaDePonerBarcos(tableros[0], filainicio, columnainicio, filafinal, columnafinal);
                        LogicaDeTablero.Añadirbarco(tableros[0], filainicio, columnainicio, filafinal, columnafinal);
                        this.cantidadDeBarcosParaPosicionar[0] -= casillasutilizadas;
                    }
                    catch(IndexOutOfRangeException){
                        return "La coordenada enviada es invalida";}
                    if (cantidadDeBarcosParaPosicionar[0] == 0)
                    {
                        this.posicionamientoTerminado[0] = true;
                        respuesta += $"\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
                    }
                    else
                    {
                        respuesta += $"\nLe quedan {this.cantidadDeBarcosParaPosicionar[0]}";
                    }
                    return respuesta;
                }
                else
                {
                    return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcosParaPosicionar[0]} lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
                }
                
            
                
            }
            else
            {
                if (casillasutilizadas <= cantidadDeBarcosParaPosicionar[1])
                {
                    string respuesta;
                    try{
                    respuesta = respuestaDePonerBarcos(tableros[1], filainicio, columnainicio, filafinal, columnafinal);
                    LogicaDeTablero.Añadirbarco(tableros[1], filainicio, columnainicio, filafinal, columnafinal);
                    this.cantidadDeBarcosParaPosicionar[1] -= casillasutilizadas;}
                    catch(IndexOutOfRangeException){return "La coordenada enviada es invalida";}
                    if (cantidadDeBarcosParaPosicionar[1] == 0)
                    {
                        this.posicionamientoTerminado[1] = true;
                        respuesta += $"\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
                    }
                    else
                    {
                        respuesta += $"\nLe quedan {this.cantidadDeBarcosParaPosicionar[1]}";
                    }
                    return respuesta;
                }
                else
                {
                    return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcosParaPosicionar[1]} lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
                }
                
            }
        }

        /// <summary>
        /// Metodo utilizado para organizar las coordenadas, para que sea lo mismo decir A1 a A5 que A5 a A1
        /// </summary>
        /// <param name="coordenada1"></param>
        /// <param name="coordenada2"></param>
        /// <returns></returns>
        protected int[] ordenadorDeCoordenadas(int [] coordenada1, int [] coordenada2)
        {
            int [] nuevasCoordenadas = new int [4];
            if (coordenada1[0]>coordenada2[0])
            {
                nuevasCoordenadas[0] = coordenada2[0];
                nuevasCoordenadas[2] = coordenada1[0];
            }
            else
            {
                nuevasCoordenadas[0] = coordenada1[0];
                nuevasCoordenadas[2] = coordenada2[0];
            }

            if (coordenada1[1]>coordenada2[1])
            {
                nuevasCoordenadas[1] = coordenada2[1];
                nuevasCoordenadas[3] = coordenada1[1];
            }
            else
            {
                nuevasCoordenadas[1] = coordenada1[1];
                nuevasCoordenadas[3] = coordenada2[1];;
            }
            return nuevasCoordenadas;

        }
        /// <summary>
        /// Metodo encargado de obtener el largo de los barcos.
        /// </summary>
        /// <param name="filainicio"></param>
        /// <param name="columnainicio"></param>
        /// <param name="filafinal"></param>
        /// <param name="columnafinal"></param>
        /// <returns></returns>
        protected int largoDeBarcos ( int filainicio, int columnainicio, int filafinal, int columnafinal)
        {
            int resultado = 0;
            if (filainicio == filafinal)
            {
                resultado = 1 + columnafinal - columnainicio;
            }
            else if (columnainicio == columnafinal)
            {
                resultado = 1 + filafinal  - filainicio;
            }
            return resultado;
        }
        /// <summary>
        /// Constructor del mensaje devuelto en cuanto se ponen barcos.
        /// </summary>
        /// <param name="tablerobjetivo"></param>
        /// <param name="filainicio"></param>
        /// <param name="columnainicio"></param>
        /// <param name="filafinal"></param>
        /// <param name="columnafinal"></param>
        /// <returns></returns>
        protected string respuestaDePonerBarcos(Tablero tablerobjetivo, int filainicio, int columnainicio,int filafinal, int columnafinal)
        {
            if (filainicio == filafinal)
            {
                for (int i = columnainicio; i < columnafinal; i++)
                {
                    if (tablerobjetivo.VerCasilla(filainicio, i) == 'B')
                    {
                        return "Has posicionado un barco sobre otro, empezaras la partida con la parte que colisiono dañada como si le hubieran disparado";
                    }
                }
            }
            else if (columnainicio == columnafinal)
            {
                for (int i = filainicio; i < filafinal; i++)
                {          
                    if (tablerobjetivo.VerCasilla(i , columnainicio) == 'B')
                    {
                        return "Has posicionado un barco sobre otro, empezaras la partida con la parte que colisiono dañada como si le hubieran disparado";
                    }
                        
                }
            }
            return "Se Agrego correctamente el barco";
            //Estaria bueno poner una excepcion aca para que no de el index out of range y se devuelva un msg.

        }
        /// <summary>
        /// Metodo encargado de la funcionalidad de rendirse.
        /// </summary>
        /// <param name="jugador"></param>
        public void Rendirse(int jugador)
        {
            if (jugadores.Contains(jugador))
            {
                if (jugadores[0] == jugador)
                {
                    LogicaDeTablero.Finalizar(tableros[1]);
                    this.Finalizar();
                }
                else
                {
                    LogicaDeTablero.Finalizar(tableros[0]);
                    this.Finalizar();
                }
            }
        }
        /// <summary>
        /// Metodo para ver el tablero propio por cada jugador.
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public char[ , ] VerTableroPropio(int jugador)
        {
            if (!jugadores.Contains(jugador))
            {
                return null;}
            if (tableros[0].DueñodelTablero==jugador)
            {
                return tableros[0].VerTablero();
            }
            else
            {
                return tableros[1].VerTablero();
            }
        }
        /// <summary>
        /// Metodo utilizado para ver una copia del tablero del oponente sin barcos
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
            
        public char[ , ] VistaOponente (int jugador)
        {
            if (!jugadores.Contains(jugador))
            {
                return null;}
            if (tableros[0].DueñodelTablero==jugador)
            {
                char[ , ] matrizSinBarcos = tableros[1].VerTablero();
                for (int i = 0; i < tableros[1].Tamaño; i++)
                {
                    for (int j = 0; j < tableros[1].Tamaño; j++)
                    {
                        if (matrizSinBarcos[i,j]== 'B')
                        {
                            matrizSinBarcos[i,j]= '\u0000';
                        }
                    }
                }
                return matrizSinBarcos; 
            }
            else 
            {
                char[ , ] matrizSinBarcos = tableros[0].VerTablero();
                for (int i = 0; i < tableros[0].Tamaño; i++)
                {
                    for (int j = 0; j < tableros[0].Tamaño; j++)
                    {
                        if (matrizSinBarcos[i,j]== 'B')
                        {
                            matrizSinBarcos[i,j]= '\u0000';
                        }
                    }
                }
                return matrizSinBarcos; 
            }
        }

    }
}
