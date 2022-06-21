using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Se crea una clase para poder realizar los test que sean posibles de la clase Jugador
    /// </summary>
    public class JugadorTests
    {
        private Jugador jugador;



        /// <summary>
        /// Comparo si el número de jugador antes del registro y el número de jugador después del registro son iguales.
        /// </summary>
        
        [Test]
        public void Registrar()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            int expected = jugador1.NumeroDeJugador;
            int actual = perfil.ObtenerPerfil(jugador1.NumeroDeJugador).NumeroDeJugador; 
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Se realiza test para comprobar si un jugador se remueve.
        /// </summary>
        [Test]
        public void Remover()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            jugador3.Remover();
            PerfilUsuario expected = null;
            PerfilUsuario actual = perfil.ObtenerPerfil(jugador3.NumeroDeJugador);
            Assert.AreEqual(expected,actual);
            
        }
        /// <summary>
        /// Se realiza test para comprobar si un jugador mantiene su número de Jugador removiendo a otro Jugador.
        /// </summary>
        [Test]
        public void RemoverConNum()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            int expected = jugador4.NumeroDeJugador;
            jugador3.Remover();
            int actual = jugador4.NumeroDeJugador;
            Assert.AreEqual(expected,actual);
            
        }
        /// <summary>
        /// Con este test podremos ver el Perfil de un jugador utilizando a su Número de Jugador el cual lo tiene definido.
        /// </summary>
        [Test]
        public void VerAlPerfil()
        {
            AlmacenamientoUsuario verperfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            int actual = jugador1.NumeroDeJugador;
            jugador1.VerPerfil(jugador1.NumeroDeJugador);
            int expected = 12;
            Assert.AreEqual(expected,actual);
        }
    
    }
}
