Segunda entrega de Proyecto perteneciente al Equipo 9 de Programación II
Franco De Stefano, Sebastián Quintana, Amanda Seara, Santiago Severo

INFORME DEL PROYECTO


Funcionamientos extra:

-	Historial:
El historial consiste en dos partes: un historial general llamado historial, en el que se guardan todas las partidas jugadas por todos los jugadores, y un historial personal, en el que se guardan solo las partidas pertenecientes a un jugador.

-	Ranking:
El ranking consiste en una lista que muestra las personas con mas partidas ganadas, siendo la primera persona de la lista la que más victorias tiene a su favor.

-	Partida amistosa:
La partida amistosa consiste en un emparejamiento especial, el cual junta a dos jugadores en especifico para que jueguen una partida entre ellos. El emparejamiento normal no te empareja con quien quieras, sino que te empareja con una persona al azar.

-	Modo de juego rápido:
El modo de juego rápido consiste en una partida en la que cada persona tiene dos tiradas en lugar de una.

-	Ayudante de tiro:
El ayudante de tiro es una ayuda para el jugador dentro del juego, que muestra las posibles posiciones de los barcos en base a un ataque realizado.


Roles de clases:

- AlmacenamientoUsuario: Information holder
- DatosDePartidas: Information holder
- PartidasEnJuego: Information holder
- Planificador: Coordinator
- Iimpresora: Interface
- perfilUsuario: Information holder
- Historial: Information holder
- Partida: Controller
- TraductorDeCoordenadas: Service provider
- LogicaDeTablero: Coordinator
- impresoraConsola: Service provider
- EmparejamientoConCola: Service provider
- Tablero: Service provider
- PartidaRapida: Controller
- Handlers: Controller


Clases:

- IHandler:
Esta es una interfaz que será implementada por BaseHandler, y se crea en función del principio de inversión de dependencias, "para que los clientes de la cadena de responsabilidad, que pueden ser concretos, no dependan de una clase "handler" que potencialmente es abstracta".

- BaseHander:
Esta clase se crea para implementar el patrón chain of responsibility con los demas handlers, lo que permite que el usuario se comunique con el subsistema a traves de comandos; estos seran procesados por distintos handlers, quienes heredan de esta clase. Las clases que heredan de BaseHandler cambiarán su accionar en base a sobreescribir el metodo virtual llamdo "InternalHandle", y decidiran que mensajes procesar sobreescribiendo el metodo "CanHandle", ambos metodos presentes en BaseHandler.

- ComenzarHandler:
ComenzarHandler se encarga de "iniciar" el bot con el comando /Start, y da la opcion de registrarte o de iniciar sesion. Si un usuario se encuentra en esta etapa, tiene estado 0.

- InicioSesionHandler:
Clase encargada de buscar si un usuario existe o no en AlmacenamientoUsuarios, y de existir le permite acceder al menu. Se accede al mismo con el comando /InicioSesion Si un usuario se encuentra en esta etapa, tiene estado 0.

- RegistrarHandler:
Handler para registrar a un usuario con el comando /Registrar. Pide los datos de la persona y los almacena en AlmacenamientoUsuario. Si un usuario se encuentra en esta etapa, tiene estado 0.

- MenuHandler:
Esta clase sirve para indicarle al usuario las acciones disponibles en el estado en el que se encuentra con el comando /Menu. Permite tanto comenzar una partida como ver sus datos. Si un usuario se encuentra en esta etapa, tiene estado 1.

- AyudaHandler:
Se accede con /Ayuda, y muestra una breve descripcion de los comandos del menu. Si un usuario se encuentra en esta etapa, tiene estado 1.

- RemoverUsuarioHandler:
Esta clase permite remover a una persona del almacenamiento con el comando /Remover. Si un usuario se encuentra en esta etapa, tiene estado 1.

- VerHistorialHandler:
Esta clase le permite a un usuario ver el historial de las partidas totales que se han jugado con el comando /VerHistorial. Si un usuario se encuentra en esta etapa, tiene estado 1.

- VerHistorialPersonalHandler:
El handler VerHistorialPersonalHandler permite a un usuario ver el historial de las partidas que el mismo ha jugado con el comando /VerHistorialPersonalHandler. Si un usuario se encuentra en esta etapa, tiene estado 1.

- Verperfilhandler:
Este handler le permite al usuario ver sus datos con el comando /VerPerfil. Si un usuario se encuentra en esta etapa, tiene estado 1.

- VerRankingHandler:
Este handler le permite a un usuario ver el ranking de los usuarios con mas partidas ganadas con el comando /VisualizarRanking. Si un usuario se encuentra en esta etapa, tiene estado 1.

- BuscarPartidaHandler:
Esta clase añade a un usuario a la cola de espera para jugar una partida tanto normal como rapida con el comando /BuscarPartida. El que elige el tamaño del tablero es el ultimo jugador en elegir el tamaño del mismo, es decir, la ultima persona en entrar en la partida, por mas de que el primer jugador haya elegido otro tamaño. Si un usuario se encuentra en esta etapa, tiene estado 1.

- BuscarPartidaAmistosaHandler:
Esta clase permite a dos jugadores en especifico jugar una partida tanto normal como rapida con el comando /BuscarPartidaAmistosa. Para poder jugar una partida de este tipo es necesario conocer el numero de jugador del otro usuario. El que elige el tamaño del tablero es el ultimo jugador en elegir el tamaño del mismo, es decir, la ultima persona en entrar en la partida, por mas de que el primer jugador haya elegido otro tamaño. Si un usuario se encuentra en esta etapa, tiene estado 1.

- ConfirmarPartidaHandler:
Este handler permite a un usuario aceptar una partida de tipo amistoso con el comando /Aceptar. Al utilizar el comando /BuscarPartidaAmistosa, el usuario recibe un mensaje de que ha sido invitado, y es a partir de este handler que el jugador podrá aceptar una partida y jugar con el otro jugador. Si un usuario se encuentra en esta etapa, tiene estado 1.

- SalirEmparejamientoHandler:
Este handler le permite a un jugador que esta buscando partida salirse del emparejamiento con le comando /SalirEmparejamiento. Esto hace que el usuario vuelva al menu. Si un usuario se encuentra en esta etapa, tiene estado 1.

- AtacarHandler:
Este handler le permite a un jugador realizar un ataque con el comando /Atacar. Si un usuario se encuentra en esta etapa, tiene estado 2.

- PosicionarHandler:
Este handler le permite a un jugador posicionar un barco con el comando /Posicionar. Si un usuario se encuentra en esta etapa, tiene estado 2.

- Bot:
Esta clase guarda todos los datos necesarios para crear el bot, como la secret token y el singleton para que no exista mas de una instancia del mismo, lo que de darse provocaría un error, ya que no puede haber más de una instancia de un bot con la misma token.

- Planificador:
Hecho por Santiago.
La clase Planificadora es la que obtiene los datos que las otras clases precisan, y delega tareas a otras clases.
Esta clase es estática porque como su única responsabilidad es delegar tareas, no necesita almacenar información, y utiliza SRP por la misma razón.
También implementa el patrón Facade, ya que provee acceso a las distintas partes de la funcionalidad del sistema, y sabe a donde redirigir el pedido del cliente. Gracias a esto también evita que el jugador tenga que llamar al subsistema directamente.

- AlmacenamientoUsuarios:
Hecho por Sebastian.
Esta clase se encarga del manejo de los datos de los usuarios, ya que es la que almacena los mismos. Al ser responsable del manejo de los datos de los usuarios es capaz de, registrarlos, removerlos, devolver sus datos si se los piden (o de otros perfiles, como nombre o cantidad de partidas ganadas) o reordenar la lista de usuarios para formar el ranking.
AlmacenamientoUsuarios cumple con expert, ya que es la clase que conoce toda la informacion necesaria para implementar sus métodos gracias al acceso a la lista de usuarios.
Esta clase implementa el patrón Singleton, ya que no se necesita más de una instancia para funcionar, pero no es adecuado que la misma sea estática dado que debe de poder almacenar información.

- PerfilUsuario:
Hecho por Sebastian.
El perfil de usuario es la clase que almacena los datos de cada jugador. El mismo contiene los datos básicos de la persona como su nombre, un NumeroDeJugador para identificar los distintos jugadores basado en el orden de registro (de haber varias personas con el mismo nombre, se diferenciaran por este número), el historial de sus partidas jugadas, o la cantidad de partidas ganadas.
Esta clase implementa la interfaz ICloneable, la cual permite realizar clones del objeto a partir del método clone(). Esto sirve para facilitar la manipulación de perfiles de usuario en el ranking, dado que en el mismo se usa un objeto auxiliar de tipo PerfilUsuario, para poder almacenar temporalmente un perfil en el clon, lo cual simplifica el reordenamiento de la lista (para evitar cambiar la referenciación de los objetos dentro de la lista, se optó por una variable que contenga el valor del objeto en lugar de su referencia).
La clase PerfilUsuario cumple con expert porque es el que tiene el acceso a la informacion que procesa en sus metodos, y tambien cumple con SRP, porque su unica responsabilidad es almacenar perfiles, y solo tiene una razon de cambio, y es que cambien los datos de los perfiles.

- Iimpresora:
Hecho por Amanda.
Interfaz que contiene los métodos para imprimir, creada con el objetivo de implementar Liskov y polimorfismo.

- ImpresoraConsola:
Hecho por Amanda.
Implementa la interfaz Iimpresora. Imprime por consola.
Implementa Singleton dado que no se necesita mas de una impresora, y las clases estaticas no pueden implementar interfaces.

- Historial:
Hecho por Santiago.
El historial de partidas es el almacenamiento de todos los datos de las partidas que se han jugado en total.
Esta clase implementa Singleton, dado que no tendría sentido crear una instancia distinta cada vez que se quiera agregar una partida, pero no sería adecuado que fuera estática por la necesidad de almacenar los datos de las partidas.
Tambien cumple con SRP, ya que su unica responsabilidad es almacenar partidas, y tiene solamente podría cambiar la forma en la que se almacenan las mismas.

- DatosDePartidas:
Hecho por Amanda.
Los datos de las partidas son compuestos por los tableros de una partida, los jugadores que participaron de la misma, quien gano, quien perdió y cuantas tiradas hubo.
Se crea una instancia de estos objetos por partida jugada, y luego se almacenan tanto en el historial general como en el historial personal de cada jugador.
Esta clase cumple con SRP, dado que solamente tiene la responsabilidad de almacenar datos de las partidas, y su unica razon de cambio es que cambien los datos a guardar.

- PartidasEnJuego:
Hecho por Franco.
Esta clase se encarga de almacenar las partidas que están en juego, y las remueve cuando terminan.
Esta clase utiliza el patrón Singleton, dado que precisa almacenar las partidas y no necesita varias instancias.

- Emparejamiento:
Hecho por Sebastian.
Clase que permite colocar a dos jugadores juntos. El objetivo de la misma es emparejar a dos jugadores para que puedan jugar una partida juntos. Esta clase implementa singleton, dado que almacena jugadores y no necesita mas de una instancia. Este emparejamiento puede ser entre dos personas desconocidas o entre personas que se conocen (para lo cual necesitan saber el numero de jugador del otro), y de ser entre dos personas desconocidas se utiliza una estructura de tipo FIFO (first in first out) para simplificar la entrada y salida de los jugadores de la cola de emparejamiento, y a su vez para reducir el tiempo de espera de los jugadores, ya que de no usarse una cola, un jugador 1 podría encontrar partida antes que un jugador 2 que haya entrado en la lista previo al ingreso del jugador 1. También posee un método de remover, que permite que un jugador que este dentro de la cola pueda decidir dejar de buscar partida. En cuyo caso se remueve de la cola de espera.
Esta clase cumple con el patron expert, ya que es el experto en la informacion que necesita para implementar sus metodos.

- TraductorDeCoordenadas:
Hecho por Amanda.
El traductor de coordenadas se encarga de recibir una coordenada en forma de string, y devolver su correspondiente en integer. Este integer se devuelve en forma de arreglo para mantener la diferenciación entre filas y columnas. Es una clase estática dado que solo se encarga de realizar cálculos. De llegarle una coordenada invalida, devuelve null, aunque al no tener acceso al tamaño del tablero, no es responsable de verificar si una coordenada es mayor al tamaño del tablero o no. Por ende, de darse ese caso devuelve null, y otra clase comprueba como precondición que la coordenada sea válida.
Esta clase cumple con el principio de SRP, ya que lo unico que hace es el pasar las coordenadas de string a int[], y es un ejemplo claro de low coupling y high cohesion, dado que trabaja de forma completamente independiente a las demas clases del sistema, no esta ligada con ninguna clase en especial, y tiene cohesion funcional, dado que "ejecuta una y sólo una tarea, teniendo un unico objetivo a cumplir" (es.wikipedia.org/wiki/GRASP).

- Partida:
Hecho por Franco.
Las responsabilidades de partida son hacer un control de los ataques, de las pociciones de barco, crear los mensajes de respuesta de estas acciones delegando las tareas adecuadas en cada caso a la clase LogicaDeTablero.
Esta clase implementa OCP, porque puede ser extendida mediante herencia, y no es necesario cambiar el codigo de la misma. Tambien aplica polimorfismo mediante encadenamiento dinamico a partir de herencia.

- Partida Rápida:
Hecho por Franco.
Partida rapida es una subclase de Partida, añade la posibilidad de realizar un segundo tiro por ataque.
Hereda de partida dado que mantiene todas las características de una partida normal, salvo por el método de ataque y un atributo con las segundas tiradas.

- Tablero:
Hecho por Franco.
Es la clase encargada de manejar el espacio de juego, posiciona los barcos y ataques en el tablero, y asigna el ganador.
Cumple con expert debido a que es el unico que posee el acceso al tablero para poder modificarlo a traves de sus metodos.

- Barco:
Hecho por Franco.
Es la clase que almacena los barcos de un tablero.
Cumple con expert dado que es la clase que tiene la informacion necesaria para poder implementar sus metodos.


Excepciones:

- JugadorNoEncontradoException:
Esta excepción fue creada para ser lanzada en caso de que un jugador no existiera dentro de un contexto dado, por lo que el programa debe intentar recuperarse. La misma recupera el numero del jugador que no fue encontrado, junto con un mensaje personalizado que varía dependiendo de la situación en la que no se haya encontrado el mismo.

- ModoInvalidoException:
Esta excepción fue creada para ser lanzada en caso de que un modo de juego no corresponda con los modos existentes, por lo que el programa debe intentar recuperarse. La misma recupera el modo inexistente, junto con un mensaje personalizado que varía dependiendo de la situación en la que se haya ejecutado la excepcion.

- TableroInvalidoException:
Esta excepción fue creada para ser lanzada en caso de que el tamaño de un tablero sea demasiado grande, por lo que el programa debe intentar recuperarse. La misma recupera el tamaño invalido del tablero, junto con un mensaje personalizado que varía dependiendo de la situación en la que se haya ejecutado la excepcion.

Las tres excepciones tienen como objetivo principal satisfacer precondiciones, dado que si a un método le llega un dato que si sigue el código puede afectar negativamente al programa, es conveniente detenerlo para que no arrastre el error. Otra razón es que la creación de una excepción permite visualizar mas fácilmente la razón por la que el programa falló, gracias al mensaje explicativo y al atributo que muestra la razón del fallo.


Notas:
La tercer entrega nos resultó más sencilla que las dos anteriores, dado que ya teníamos la base de lo que teníamos que realizar. Lo más complicado fue el uso de los handlers, y aprender como los mismos se comportan, así como encontrar las relaciones entre ellos. Otra razón por las que nos resultó sencillo fue porque teníamos la clase planificador, por lo que los handlers no tenían que hablarse con el subsistema, solamente con el planificador. Por otro lado, además de los handlers, la serializacion también fue uno de los desafios de esta entrega. Encontrar cuales eran las clases a serializar y efectivamente guardar los datos fue complicado, así como deserializarlos.


Bibliografía:
Wirfs-Brock, Rebeca y McKean, Alan; "Object Design: Roles, Responsibilities, and Collaborations"; Addison-Wesley Professional; ISBN 0201379430; 2002.
(309) Cómo HACER Una MATRIZ En C# - MATRICES | Desarrollo en CSharp (C#) #28 - YouTube
(309) Cómo RELLENAR Y LEER MATRICES En C# - Ejercicio | Desarrollo en CSharp (C#) #29 - YouTube
es.wikipedia.org/wiki/GRASP
