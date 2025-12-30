using Prueba_Técnica.Models;

namespace Prueba_Técnica.Data
{
    public class PersonaRepository
    {
        private static List<Persona> personas = new();
        private static int contadorId = 1;

        public void Crear(Persona persona)
        {
            persona.Id = contadorId++;
            personas.Add(persona);
        }

        public List<Persona> Listar()
        {
            return personas;
        }

        public Persona? ObtenerPorId(int id)
        {
            return personas.FirstOrDefault(p => p.Id == id);
        }

        public bool Actualizar(int id, Persona data)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null) return false;

            persona.Nombre = data.Nombre;
            persona.Apellido = data.Apellido;
            persona.Documento = data.Documento;
            persona.Correo = data.Correo;
            persona.Telefono = data.Telefono;
            persona.Edad = data.Edad;

            return true;
        }

        public bool Eliminar(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null) return false;
            personas.Remove(persona);
            return true;
        }
    }
}

