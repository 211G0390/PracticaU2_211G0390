namespace PracticaU2_211G0390.Models.ViewModels
{
    public class MapaCurricularViewModel
    {
        public string? Nombre { get; set; }
       
        public uint Creditos {  get; set; }

        public byte numSemestres {  get; set; }
        public string? Plan { get; set; }

        public IEnumerable<Materias>? Materias { get; set; }
       


    }
}
