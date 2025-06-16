using ConfigurePermissionWithBitwise;

// Asignamos a nivel de bit los permisos View y Delete

// 0b00001 VIEW
// 0b00010 CREATE
// 0b10000 ADMIN
// 0b10011 Resultado con los bits activos(1)
PermissionWithBitWise permission =
    PermissionWithBitWise.VIEW | PermissionWithBitWise.CREATE | PermissionWithBitWise.IS_ADMIN;
Console.WriteLine(permission);

// Eliminando el permiso IsAdmin
permission ^= PermissionWithBitWise.IS_ADMIN;
Console.WriteLine(permission);

// Comprobamos si tiene activo un flag o permiso concreto:
Console.WriteLine($"Tiene View? {permission.HasFlag(PermissionWithBitWise.VIEW)}");
Console.WriteLine($"Tiene Delete? {permission.HasFlag(PermissionWithBitWise.DELETE)}");

// Comprobamos si tiene varios permisos

if (permission.HasFlag(PermissionWithBitWise.VIEW | PermissionWithBitWise.CREATE))
{
    Console.WriteLine($"Tiene View y Create");
}

Console.WriteLine("Eliminamos Create");
permission ^= PermissionWithBitWise.CREATE;

if (permission.HasFlag(PermissionWithBitWise.VIEW | PermissionWithBitWise.CREATE))
{
    Console.WriteLine($"Tiene View y Create");
}
else
{
    Console.WriteLine($"Ya no entra en la condicion de View y Create");
}
