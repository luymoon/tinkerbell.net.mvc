using TinkerBell.Models;

namespace TinkerBell.Models;

public class DetailsVM
{
    public Fada Anterior { get; set;}
    public Fada Atual { get; set; }
    public Fada Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}