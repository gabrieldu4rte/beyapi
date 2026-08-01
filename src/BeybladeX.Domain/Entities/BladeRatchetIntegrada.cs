using BeybladeX.Domain.Enums;

namespace BeybladeX.Domain.Entities;

public class BladeRatchetIntegrada : Peca
{
    public TipoEstilo Tipo { get; protected set; }
    public DirecaoGiro DirecaoGiro { get; protected set; }
    public int Ataque { get; protected set; }
    public int Defesa { get; protected set; }
    public int Stamina { get; protected set; }
}
