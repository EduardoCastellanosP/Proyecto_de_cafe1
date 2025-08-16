using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoC_.src.Modules.Variedades.Domain.Entities
{
    public class Variedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public TamanoGrano? TamanoGrano { get; set; }
        public int TamanoGranoId { get; set; }

        public int PorteId { get; set; }
        public Porte? Porte { get; set; }

        public int EnfermedadId { get; set; }
        public Enfermedad? Enfermedad { get; set; }

        public int ResistenciaNivelId { get; set; }
        public ResistenciaNivel? ResistenciaNivel { get; set; }

        public int PotencialId { get; set; }
        public Potencial? Potencial { get; set; }

        public int CalidadGranoId { get; set; }
        public CalidadGrano? CalidadGrano { get; set; }

        public int? ResistenciaId { get; set; }
        public Resistencia? Resistencia { get; set; }

        public int? TiempoCosechaId { get; set; }
        public TiempoCosecha? TiempoCosecha { get; set; }

        public int? NombreCientificoId { get; set; }
        public NombreCientifico? NombreCientifico { get; set; }


        public AltitudOptima? AltitudOptima { get; set; }
        public int? AltitudOptimaId { get; set; }

        public int? MaduracionId { get; set; }
        public Maduracion? Maduracion { get; set; }

        public int? OrigenLinajeId { get; set; }
        public OrigenLinaje? OrigenLinaje { get; set; }

    }
}