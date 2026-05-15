namespace optometria.Models.Optica;

public class ConfiguracionOptica
{
    public int IdConfiguracion { get; set; }
    public string? NombreComercial { get; set; }
    public string? Ruc { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? PrefijoPais { get; set; }
    public decimal PorcentajeImpuesto { get; set; }
    public string? CarpetaRx { get; set; }
    public string? RutaLogo { get; set; }
    public string? RutaFondo { get; set; }
}
