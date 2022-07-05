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
        /// Variable encargada de controlar si se puede empezar a atacar (no se puede posicionar mas).
        /// /// </summary>
        protected bool[] posicionamientoTerminado = new bool[2];
        /// <summary>
        /// Array encargado de guardar los 2 tableros necesarios para una partida.
        /// </summary>
        protected Tablero[] tableros = new Tablero[2];
        /// <summary>
        /// Almacena los int caracteristicos de cada jugador
        /// </summary>
        protected int [] jugadores = new int[2];
        /// <summary>
        /// Copia publica de jugadores, utilizado para respetar encapsulamiento.
        /// </summary>
        /// <value></value>
        public int [] Jugadores {get{return jugadores;}}
        /// <summary>
        /// Cantidad de ataques hechos por cada jugador
        /// </summary>
        protected int [] tiradas = new int[2];
        /// <summary>
        /// Simboliza la cantidad de barcos que quedan para ubicar
        /// </summary>
        protected int [] cantidadDeBarcosParaPosicionar = new int[2]; 
         /// <summary>
        /// Variable encargada de controlar si se puede empezar a atacar (no se puede posicionar mas).
        /// /// </summary>
        protected int[] PartesDeBarcoEnteras = new int[2];
        /// <summary>
        ///  Constructor de la clase Partida.
        /// </summary>
        /// <param name="tamano"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        public Partida(int tamano ,int jugador1, int jugador2)
        {
            try
            {
                if (tamano > 15)
                    throw new TableroInvalidoException();
            }
            catch (TableroInvalidoException)
            {
                throw new TableroInvalidoException("Tablero demasiado grande", tamano);
            }
            this.tableros[0] = new Tablero(tamano,jugador1);
            this.jugadores[0]=jugador1; //Simboliza los jugadores, puede cambiarse a futuro
            this.tableros[1] = new Tablero(tamano,jugador2);
            this.jugadores[1]=jugador2;
            this.cantidadDeBarcosParaPosicionar[0]= (tamano*tamano*25)/100;
            this.cantidadDeBarcosParaPosicionar[1]= (tamano*tamano*25)/100;
            this.tiradas[0]=0;
            this.tiradas[1]=0;
            this.posicionamientoTerminado[0]=false;
            this.posicionamientoTerminado[1]=false;
            this.PartesDeBarcoEnteras[0]=0;
            this.PartesDeBarcoEnteras[1]=0;
            PartidasEnJuego partida = PartidasEnJuego.Instance();
            partida.AlmacenarPartida(this);
        }

        /// <summary>
        /// Metodo llamado para finalizar, guarda los datos mas importantes de 
        /// la partida en la clase DatosDePartida
        /// </summary>
        protected void Finalizar()
        {
            new DatosdePartida(this.tableros, this.tiradas);
            PartidasEnJuego partida = PartidasEnJuego.Instance();
            partida.RemoverPartida(this);
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
            if (!this.posicionamientoTerminado[0] || !this.posicionamientoTerminado[1])
            {
                return "Estamos en etapa de posicionamiento, si no le quedan barcos para posicionar, entonces espere a que termine de posicionar su oponente";
            }
            if (!jugadores.Contains(jugador) )
            { 
                return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
            }
            if (LugarDeAtaque[0] >= this.tableros[0].Tamano || LugarDeAtaque[1] >= this.tableros[0].Tamano)
            {
                return "Las coordenadas enviadas son erroneas";
                }
            
            int fila = LugarDeAtaque[0];
            int columna = LugarDeAtaque[1];

            if (jugador == this.jugadores[0])
            {
                if (this.TurnoEnCurso(jugador))
                {
                    
                    Tablero tablerobjetivo = this.tableros[1];
                    char EstadoDeLaCasillaobjetivo = tablerobjetivo.Atacar(fila,columna);
                    string respuesta = respuestaDeAtaque(EstadoDeLaCasillaobjetivo);
                    this.tiradas[0]+=1;                    
                    return respuesta;

                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else
            {
                if (this.TurnoEnCurso(jugador))
                {
                    
                    Tablero tablerobjetivo = this.tableros[0];
                    char EstadoDeLaCasillaobjetivo = tablerobjetivo.Atacar(fila,columna);
                    string respuesta = respuestaDeAtaque(EstadoDeLaCasillaobjetivo);
                    this.tiradas[1]+=1;
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
        /// <param name="EstadoDeLaCasilla"></param>
        /// <returns></returns>
        public string respuestaDeAtaque(char EstadoDeLaCasilla)
        {
            
            switch (EstadoDeLaCasilla)
            {
                case 'W':
                    return "Que lastima! has desperdiciado una bala en el agua";
                case 'T':
                    return "Buen tiro, has atacado a un barco";
                case 'H':
                    return "Felicitaciones has hundido un barco";
                case 'w':
                    return "La casilla ya había sido atacada y contiene agua"; 
                case 't': 
                    return "Has atacado una casilla donde que había sido atacada anteriormente y contenía una parte de un barco dañado";
                case 'h':
                    return "Has atacado una casilla donde que había sido atacada anteriormente y contenía una parte de un barco Hundido";
                default:
                    return "Ha habido un error";
            }

        }
        /// <summary>
        /// Metodo encargado de añadir los barcos
        /// </summary>
        /// <param name="coordenadaUno"></param>
        /// <param name="coordenadaDos"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public string AgregarBarco(string coordenadaUno, string coordenadaDos, int jugador)
        {
            int [] coordenada1 = TraductorDeCoordenadas.Traducir(coordenadaUno);
            int [] coordenada2 = TraductorDeCoordenadas.Traducir(coordenadaDos);
            if (coordenada1==null || coordenada2==null)
            {
                return "Una de las coordenadas enviadas fue invalida";
            }
            if ((this.posicionamientoTerminado[0] && this.posicionamientoTerminado[1]))
            {
                return "La Etapa de posicionamiento a terminado";
            }
            if (!(this.jugadores[0] == jugador || this.jugadores[1] == jugador ))
            {
                return "Posicionamiento no ejecutado, ya que quien posiciona el barco no es uno de los jugadores de la partida";
                }
            if (coordenada1[0] >= this.tableros[0].Tamano || coordenada1[1] >= this.tableros[0].Tamano)
            {
                return "La primer coordenada enviada es invalida";
                }
            if (coordenada2[0] >= this.tableros[0].Tamano || coordenada2[1] >= this.tableros[0].Tamano)
            {
                return "La segunda coordenada enviada es invalida";
            }

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
            
            if (jugador == this.jugadores[0])
            {
                
                if (casillasutilizadas <= this.cantidadDeBarcosParaPosicionar[0])
                {
                    string respuesta = "";
                    bool SeAgregoElBarco = tableros[0].AgregarBarco(filainicio, columnainicio, filafinal, columnafinal);

                    if (SeAgregoElBarco)
                    {
                        respuesta += "Se Agrego correctamente el barco";
                        this.PartesDeBarcoEnteras[0]+=casillasutilizadas;
                        this.cantidadDeBarcosParaPosicionar[0] -= casillasutilizadas;
                    }
                    else
                    {
                        respuesta += "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor";
                    }
                    
                    if (this.cantidadDeBarcosParaPosicionar[0] == 0)
                    {
                        this.posicionamientoTerminado[0] = true;
                        respuesta += $"\nHas posicionado todas las casillas de barcos que tenias disponibles en esta partida";
                    }
                    
                    else
                    {
                        respuesta += $"\nLe quedan {this.cantidadDeBarcosParaPosicionar[0]} casilla/s de barco/s para posicionar";
                    }
                    return respuesta;
                }
                else
                {
                    return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcosParaPosicionar[0]} casilla/s para poner barcos, una cantidad inferior a el tamaño del barco que quiso colocar";
                }
                
            
                
            }
            else
            {
                if (casillasutilizadas <= this.cantidadDeBarcosParaPosicionar[1])
                {
                    string respuesta = "";
                    
                        bool SeAgregoElBarco = tableros[1].AgregarBarco(filainicio, columnainicio, filafinal, columnafinal);

                        if (SeAgregoElBarco)
                        {
                            respuesta += "Se Agrego correctamente el barco";
                            this.PartesDeBarcoEnteras[1]+=casillasutilizadas;
                            this.cantidadDeBarcosParaPosicionar[1] -= casillasutilizadas;
                        }
                        else
                        {
                            respuesta += "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor";
                        }
                    if (this.cantidadDeBarcosParaPosicionar[1] == 0)
                    {
                        this.posicionamientoTerminado[1] = true;
                        respuesta += $"\nHas posicionado todas las casillas de barcos que tenias disponibles en esta partida";
                    }
                    
                    else
                    {
                        respuesta += $"\nLe quedan {this.cantidadDeBarcosParaPosicionar[1]} casilla/s de barco/s para posicionar";
                    }
                    return respuesta;
                }
                else
                {
                    return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcosParaPosicionar[1]} casilla/s para poner barcos, una cantidad inferior a el tamaño del barco que quiso colocar";
                }
                
            }
        }
        /// <summary>
        /// Responsable de ver si un turno a finalizado. Creado para la impresion de mensajes
        /// de el handler atacar.
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public virtual bool TurnoEnCurso(int jugador)
        {
            if(jugador == jugadores[0] )
            {
                if (this.tiradas[0] > this.tiradas[1])
                    {
                        return false;
                    }
            }
            else if (jugador == jugadores[1])
            {
                if (this.tiradas[0]== this.tiradas[1])
                {
                    return false;
                }
            }
            return true;
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
        /// Metodo encargado de calcular el largo de los barcos.
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
        /// Metodo encargado de la funcionalidad de rendirse.
        /// </summary>
        /// <param name="jugador"></param>
        public void Rendirse(int jugador)
        {
            if (this.jugadores.Contains(jugador))
            {
                if (this.jugadores[0] == jugador)
                {
                    tableros[1].Victoria();
                    this.Finalizar();
                }
                else
                {
                    tableros[0].Victoria();
                    this.Finalizar();
                }
            }
        }
        /// <summary>
        /// Metodo para ver el tablero propio por cada jugador.
        /// </summary>
        /// <param name="jugador"> numeroDeJugador del jugador que deseo el tablero </param>
        /// <returns></returns>
        public Tablero VerTablero(int jugador)
        {
            if (!this.jugadores.Contains(jugador))
            {
                return null;
            }
            if (this.tableros[0].DuenodelTablero==jugador)
            {
                return tableros[0];
            }
            else
            {
                return tableros[1];
            }
        }
        /// <summary>
        /// Metodo Utilizado para ver si la etapa de posicionamiento de un jugador a finalizado
        /// desde otra clase.
        /// </summary>
        /// <param name="jugadorQueConsulta"></param>
        /// <returns></returns>
        public bool PosicionamientoFinalizado(int jugadorQueConsulta)
        {
            if (this.jugadores[0] == jugadorQueConsulta)
            {
                return this.posicionamientoTerminado[0];
            }
            else
            {
                return this.posicionamientoTerminado[1];
            }
            
        }
        /// <summary>
        /// Se encarga de confir si un tablero ha sido terminado
        /// en caso de ser cierto finaliza la partida y 
        /// devuelve true si la misma fue terminada
        /// </summary>
        /// <returns></returns>
        public bool PartidaTerminada()
        {
            if (tableros[0].terminado)
            {
                tableros[1].Victoria();
                this.Finalizar();
                return true;
            }
            else if (tableros[1].terminado)
            {
                tableros[0].Victoria();
                this.Finalizar();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Metodo encargado de ver la cantidad de partes de barco sin dañar
        /// </summary>
        /// <param name="dueño"></param>
        /// <returns></returns>
        public int PartesDeBarcoEnterasEnTablero(int dueño)
        {
            if(dueño == jugadores[0])
            {
                return this.PartesDeBarcoEnteras[0] - tableros[0].CantidadPartesBarcoDañadas;
            }
            else
            {
                return this.PartesDeBarcoEnteras[1] - tableros[1].CantidadPartesBarcoDañadas;
            }
        }
    }
}
