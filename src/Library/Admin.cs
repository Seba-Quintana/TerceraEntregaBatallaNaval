using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Admin
    {
        public static List<PerfilUsuario> ListaDeUsuarios;
    /*
        public void Registrar(string nombre, int id, string contraseña)
        {
            PerfilUsuario usuario = new PerfilUsuario (nombre,id,contraseña);
            ListaDeUsuarios.add(usuario);

        }*/
        public static void Remover(int NumeroDeJugador)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (usuario.NumeroDeJugador == NumeroDeJugador)
                {
                    ListaDeUsuarios.Remove(usuario);
                }
            }
        }

        public static PerfilUsuario ObtenerPerfil(int usuario)
        {
            int i = 0;
            while (i != ListaDeUsuarios.Count - 1)
            {
                if (ListaDeUsuarios[i].NumeroDeJugador == usuario)
                    return ListaDeUsuarios[i];
            }
            return null;
        }
    }
}