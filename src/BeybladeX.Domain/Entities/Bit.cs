using BeybladeX.Domain.Enums;

namespace BeybladeX.Domain.Entities;

public class Bit : Peca
{
    public TipoEstilo Tipo { get; protected set; }
    public int Ataque { get; protected set; }
    public int Defesa { get; protected set; }
    public int Stamina { get; protected set; }
    public int Dash { get; protected set; }
    public int ResistenciaABurst { get; protected set; }
}
