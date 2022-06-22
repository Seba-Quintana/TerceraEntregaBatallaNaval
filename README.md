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
- Jugador: Controller


Clases:

- Jugador:
Hecho por Santiago.
Un jugador es una representación de las acciones posibles que puede tomar un usuario, y a su vez es el punto de contacto entre el código y las decisiones del jugador. Los distintos métodos sirven para realizar las acciones que quiere realizar el jugador, y van desde visualizar datos, posicionar y atacar barcos, hasta rendirse y remover sus datos del sistema. Al construir un jugador automáticamente se agrega al almacenamiento de los usuarios, por lo que necesita registrarse para acceder.
Esta clase será luego sustituida por los handlers, dado que es el punto de contacto entre el jugador y el programa.

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

- LogicaDeTablero:
Hecho por Franco.
La clase LogicaDeTablero es la que obtiene los datos que Tablero precisa y le delega tareas.
Esta clase es estática porque como su única responsabilidad es delegar tareas, no necesita almacenar información, y utiliza SRP por la misma razón.

- Tablero:
Hecho por Franco.
Es la clase encargada de manejar el espacio de juego, posiciona los barcos y ataques en el tablero, y asigna el ganador.
Cumple con expert debido a que es el unico que posee el acceso al tablero para poder modificarlo a traves de sus metodos.


Excepciones:

- JugadorNoEncontradoException:
Esta excepción fue creada para ser lanzada en caso de que un jugador no existiera dentro de un contexto dado, por lo que el programa debe intentar recuperarse. La misma recupera el numero del jugador que no fue encontrado, junto con un mensaje personalizado que varía dependiendo de la situación en la que no se haya encontrado el mismo.

- ModoInvalidoException:
Esta excepción fue creada para ser lanzada en caso de que un modo de juego no corresponda con los modos existentes, por lo que el programa debe intentar recuperarse. La misma recupera el modo inexistente, junto con un mensaje personalizado que varía dependiendo de la situación en la que se haya ejecutado la excepcion.

- TableroInvalidoException:
Esta excepción fue creada para ser lanzada en caso de que el tamaño de un tablero sea demasiado grande, por lo que el programa debe intentar recuperarse. La misma recupera el tamaño invalido del tablero, junto con un mensaje personalizado que varía dependiendo de la situación en la que se haya ejecutado la excepcion.

Ambas excepciones tienen como objetivo principal satisfacer precondiciones, dado que si a un método le llega un dato que si sigue el código puede afectar negativamente al programa, es conveniente detenerlo para que no arrastre el error. Otra razón es que la creación de una excepción permite visualizar mas fácilmente la razón por la que el programa falló, gracias al mensaje explicativo y al atributo que muestra la razón del fallo.


Notas:
Tuvimos varios desafios mientras estabamos realizando la segunda entrega del proyecto. Desde un principio empezamos a agregar clases nuevas al diagrama de la primera entrega, ya que eran necesarios para aplicar de mejor manera los patrones y principios de diseño dados en clase. Al pasar del diagrama UML al codigo, nos dimos cuenta de que cosas como el manejo de matrices iba a ser mas complicado de como lo habiamos pensado en un inicio, por los que decidimos aislar los posibles problemas que pudieran surgir debido a las mismas. Otro desafio improvisto fue la funcionalidad del ayudante de tiro, el cual habiamos negociado con los docentes del curso. Hizo falta cambiar toda la logica para poder implementar dicha funcion.
Un tema interesante que fue estudiado fue la propagacion de excepciones, y como era el proceso desde que salta una excepcion en una funcion interna hasta que llega hasta la parte mas externa del mismo. Un problema que tuvimos, sin embargo, fue que el codigo de muestra acerca del tema era en java, y fue necesario traducirlo a c# para poder implementarlo. Fue gracias a este tema que decidimos utilizar un throw en las zonas mas internas del programa, para que luego las atrapara la clase que puede devolver al programa a su rumbo debido, y decidimos que la misma seria el jugador, dado que es la clase que sera sustituida por los handlers, los cuales se encargan de conseguir los datos que no pudieron ser procesados de manera correcta, y hasta delegar la responsabilidad de atrapar ciertas excepciones.
Otro tema en el cual profundizamos fueron los patrones de diseño, tales como singleton, facade, aunque no implementamos todos los que estudiamos. Estos patrones fueron realmente utiles para implementar las clases.


Bibliografía:
Wirfs-Brock, Rebeca y McKean, Alan; "Object Design: Roles, Responsibilities, and Collaborations"; Addison-Wesley Professional; ISBN 0201379430; 2002.
(309) Cómo HACER Una MATRIZ En C# - MATRICES | Desarrollo en CSharp (C#) #28 - YouTube
(309) Cómo RELLENAR Y LEER MATRICES En C# - Ejercicio | Desarrollo en CSharp (C#) #29 - YouTube
es.wikipedia.org/wiki/GRASP
