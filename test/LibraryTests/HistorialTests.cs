using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="Historial"/>
    /// </summary>
    [TestFixture]
    public class HistorialTests
    {
         /// <summary>
        /// Verifica que un DatosdePartida se agregue correctamente a la lista de Historial
        /// </summary>
        [Test]
        public void AñadirUnDatosdePartida()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Registrar("jugadorTest", 5, "Test");
			almacenamiento.Registrar("jugadorTest", 5, "Test");
            Planificador.EmparejarAmigos(0, 1, 2, 7);
            Planificador.Posicionar("A1","A6", 1);
            Planificador.Posicionar("B1","B6", 1);
            Planificador.Posicionar("E1","E6", 2);
            Planificador.Posicionar("F1","F6", 2);
            int i = 1;
            while(i <= 6)
            {
                Planificador.Atacar($"G{i}", 1);
                Planificador.Atacar($"A{i}", 2);
                i+=1;
            }
            i = 1;
            while(i <= 6)
            {
                Planificador.Atacar($"C{i}", 1);
                Planificador.Atacar($"B{i}", 2);
                i+=1;
            }

            //Verifico que se agrego en el historial
            Historial historial = Historial.Instance();
            List<DatosdePartida> expected = almacenamiento.ObtenerPerfil(2).ObtenerHistorialPersonal();
            Assert.AreEqual(expected,historial.Partidas);
        }
    }
}
