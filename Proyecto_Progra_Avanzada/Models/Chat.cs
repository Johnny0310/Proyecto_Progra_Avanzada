namespace Proyecto_Progra_Avanzada.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con los mensajes del chat
        public ICollection<MensajeChat> MensajesChat { get; set; }
    }
}
