using System;

namespace ClassLibrary
{
    public class Admin
    {
        public static List<PerfilUsuario> ListaDeUsuarios;
    
        public void Registrar(string nombre, int id, string contraseña)
        {
            PerfilUsuario = new PerfilUsuario (nombre,id,contraseña);
            ListaDeUsuarios.add(PerfilUsuario);

        }
        public void Remover(int NumeroDeJugador)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios == NumeroDeJugador)
            {
                if (usuario.NumeroDeJugador == NumeroDeJugador)
                {
                    ListaDeUsuarios.Remove(usuario);
                }
            }
        }
    }
}