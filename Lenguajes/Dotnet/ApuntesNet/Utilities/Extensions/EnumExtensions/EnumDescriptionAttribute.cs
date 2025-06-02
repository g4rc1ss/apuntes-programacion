namespace EnumExtensions;

/// <summary>
/// Para evitar tener un array de claves o constantes asociado a una enumeración,
/// se puede optar por asignar un atributo a cada elemento de la enumeración, de
/// forma que toda la información se encuentra en un único lugar
/// </summary>
/// <remarks>
/// Constructor del atributo
/// </remarks>
/// <param name="text"></param>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Property,
    Inherited = false,
    AllowMultiple = true
)]
public sealed class EnumDescriptionAttribute(string text) : Attribute
{
    /// <summary>
    /// Texto que se asocia como clave a un elemento de la enumeración
    /// </summary>
    public string Text { get; set; } = text;
}
