using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    public class JugadorTests
    {
        private Jugador jugador;


        public List<Jugador> jugadores = new List<Jugador>();
    
        [SetUp]
        public void Setup()
        {
            List<Jugador> jugadores = new List<Jugador>();
        }

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

        [Test]
        public void VerAlPerfil()
        {
            AlmacenamientoUsuario verperfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            int expected = jugador1.NumeroDeJugador;
            jugador1.VerPerfil(jugador1.NumeroDeJugador);
            int actual = jugador1.NumeroDeJugador;
            Assert.AreEqual(expected,actual);

            

            
            
        }
    
        [Test]
        public void VerAlRanking()
        {
            AlmacenamientoUsuario verranking = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            List<PerfilUsuario> ranking = verranking.ObtenerRanking();
            List<PerfilUsuario> actual = ranking;
            List<PerfilUsuario> expected = ranking;
            Assert.AreEqual(expected,actual);



            

            
            
        }
    }
}