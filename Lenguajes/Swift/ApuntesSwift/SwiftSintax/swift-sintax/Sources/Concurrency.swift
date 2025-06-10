public class Concurrency {
    public static func execute() async{
        func obtenerIdDeUsuario(desde servidor: String) async -> Int {
            if servidor == "principal" {
                return 97
            }

            return 501
        }

        async let idDeUsuario = obtenerIdDeUsuario(desde: "Hola")
        let saludo = await "Hola, ID de usuario \(idDeUsuario)"

    }
}
