using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase mediadora de la parte logica de la partida, se comunica con clases externas 
    /// y Logica. Sus responsabilidades son, Hacer un control de los ataques, de las pociciones de barco 
    /// y crear los mensajes de respuesta de estas acciones
    /// </summary>
    public class LogicaDePartida
    {
        private Tablero[] tableros = new Tablero[2];

        private int [] jugadores = new int[2];

        private int [] tiradas = new int[2];

        private int [] cantidadDeBarcos = new int[2]; 

        public LogicaDePartida(int tamaño ,int jugador1, int jugador2)
        {
            tableros[0] = new Tablero(tamaño,jugador1);
            jugadores[0]=jugador1; //Simboliza los jugadores, puede cambiarse a futuro
            jugadores[1]=jugador2;
            tableros[1] = new Tablero(tamaño,jugador2);
            cantidadDeBarcos[0]= (tamaño * 2) - 3 ;
            cantidadDeBarcos[1]= (tamaño * 2) - 3 ;
            tiradas[0]=0;
            tiradas[1]=0;
        }

        /// <summary>
        /// Metodo llamado para finalizar, guarda los datos mas importantes de la partida en la clase DatosDePartida
        /// </summary>
        private void Finalizar()
        {
            DatosdePartida Almacenaje = new DatosdePartida();
            Almacenaje.Almacenar(tableros,tiradas);
        }
        /// <summary>
        /// Metodo encargado de ver si un ataque es posible y devolver su mensaje de respuesta.
        /// </summary>
        /// <param name="LugarDeAtaque"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>

        public string Atacar(int [] LugarDeAtaque, int jugador)
        {
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
                    return respuesta;

                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else if (jugador == jugadores[1])
            {
                if (tiradas[0]>tiradas[1])
                {
                    
                Tablero tablerobjetivo = tableros[0];
                string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                tiradas[0]+=1;
                return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
            }
            return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
            
        }
        /// <summary>
        /// Metodo encargado de formular los ataques en base de 
        /// </summary>
        /// <param name="tablerobjetivo"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        private string respuestaDeAtaque(Tablero tablerobjetivo, int fila, int columna)
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
        /// <param name="coordenada1"></param>
        /// <param name="coordenada2"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public string AñadirBarco(int [] coordenada1, int [] coordenada2, int jugador)
        {
            int [] coordenadasOrdenadas = ordenadorDeCoordenadas(coordenada1,coordenada2);
            //estaria bueno un try Catch aca para ver que las coordenadas sean inferiores al tamaño de las matrices.
            int filainicio = coordenadasOrdenadas[0];
            int columnainicio = coordenadasOrdenadas[1];

            int filafinal = coordenadasOrdenadas[2];
            int columnafinal = coordenadasOrdenadas[3];

            int casillasutilizadas = largoDeBarcos(filainicio, columnainicio, filafinal, columnafinal);
            
            if (jugador == jugadores[0])
            {
                if (casillasutilizadas != 0)
                {
                    if (casillasutilizadas < this.tiradas[0] )
                    {
                        string respuesta = respuestaDePonerBarcos(tableros[0], filainicio, columnainicio, filafinal, columnafinal);
                        LogicaDeTablero.Añadirbarco(tableros[0], filainicio, columnainicio, filafinal, columnafinal);
                        this.tiradas[0]-= casillasutilizadas;
                        respuesta += $"\nLe quedan {this.cantidadDeBarcos[0]}";
                        return respuesta;
                    }
                    else
                    {
                        return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcos[0]} lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
                    }
                }
                else
                {
                    return "No se pueden agregar barcos diagonalmente";
                }
                
            }
            else if (jugador == jugadores[1])
            {
                if (casillasutilizadas != 0)
                {
                    if (casillasutilizadas < this.tiradas[1] )
                    {
                        string respuesta = respuestaDePonerBarcos(tableros[1], filainicio, columnainicio, filafinal, columnafinal);
                        LogicaDeTablero.Añadirbarco(tableros[1], filainicio, columnainicio, filafinal, columnafinal);
                        this.tiradas[1]-= casillasutilizadas;
                        respuesta += $"\nLe quedan {this.cantidadDeBarcos[1]}";
                        return respuesta;
                    }
                    else
                    {
                        return $"No se añadio su barco ya que le quedan {this.cantidadDeBarcos[1]} lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
                    }
                }
                else
                {
                    return "No se pueden agregar barcos diagonalmente";
                }
            }
            return "Pocicionamiento no ejecutado ya que quien pociciona el barco no es uno de los jugadores de la partida";
        }

        /// <summary>
        /// Metodo utilizado para organizar las coordenadas, para que sea lo mismo decir poner barco desde A1 a A5
        /// que decir A5 a A1
        /// </summary>
        /// <param name="coordenada1"></param>
        /// <param name="coordenada2"></param>
        /// <returns></returns>
        private int[] ordenadorDeCoordenadas(int [] coordenada1, int [] coordenada2)
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
        private int largoDeBarcos ( int filainicio, int columnainicio, int filafinal, int columnafinal)
        {
            int resultado = 0;
            if (filainicio == filafinal)
            {
                resultado = columnainicio - columnafinal;
            }
            else if (columnainicio == columnafinal)
            {
                resultado = filainicio - filafinal;
            }
            return resultado;
        }
        private string respuestaDePonerBarcos(Tablero tablerobjetivo, int filainicio, int columnainicio,int filafinal, int columnafinal)
        {
            if (filainicio == filafinal)
            {
            for (int i = columnainicio; i <= columnafinal; i++)
            {
                if (tablerobjetivo.VerCasilla(filainicio, i) == 'B');
                {
                    return "Has pocicionado un barco sobre otro, empezaras la partida con la parte que coliciono dañada como si le hubieran disparado";
                }
            }
            }

            else if (columnainicio == columnafinal)
            {
                for (int i = filainicio; i <= filafinal; i++)
                {          
                    if (tablerobjetivo.VerCasilla(i , columnainicio) == 'B')
                    {
                        return "Has pocicionado un barco sobre otro, empezaras la partida con la parte que coliciono dañada como si le hubieran disparado";
                    }
                        
                }
            }
            return "Se Agrego correctamente el barco";
            //Estaria bueno poner una excepcion aca para que no de el index out of range y se devuelva un msg.

        }
    }
}