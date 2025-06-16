namespace ConfigurePermissionWithBitwise;

[Flags]
public enum PermissionWithBitWise
{
    NONE = 0, // 0b0000
    VIEW = 1 << 0, // 0b0001
    CREATE = 1 << 1, // 0b0010
    EDIT = 1 << 2, // 0b0100
    DELETE = 1 << 3, // 0b1000,
    IS_ADMIN = 1 << 4, // 0b10000
}
