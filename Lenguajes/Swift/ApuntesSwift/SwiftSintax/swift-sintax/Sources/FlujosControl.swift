public class FlujosControl {

    func execute() {
        // Condicionales
        let puntajesIndividuales = [75, 43, 103, 87, 12]
        var puntajeDelEquipo = 0

        for puntaje in puntajesIndividuales {
            if puntaje > 50 {
                puntajeDelEquipo += 3
            } else {
                puntajeDelEquipo += 1
            }
        }

        print(puntajeDelEquipo)
        // Imprime "11"

        // Operadores ternarios
        let decoracionDelPuntaje =
            if puntajeDelEquipo > 50 {
                "🎉"
            } else {
                ""
            }

        print("Puntaje: ", puntajeDelEquipo, decoracionDelPuntaje)
        // Imprime "Puntaje: 11 🎉"

        // Nulables
        var cadenaOpcional: String? = "Hola"

        print(cadenaOpcional == nil)
        // Imprime "false"

        var nombreOpcional: String? = "John Appleseed"
        var saludo = "¡Hola!"

        if let nombre = nombreOpcional {
            saludo = "Hola, \(nombre)."
        }

        let alias: String? = nil
        let nombreCompleto: String = "John Appleseed"
        let saludoInformal = "Hola, \(alias ?? nombreCompleto)"

        if let alias {
            print("Hey, \(alias)")
        }
        // No imprime nada porque alias es nil.

        // Switch
        let vegetal = "pimiento rojo"

        switch vegetal {
        case "apio":
            print("Un par de frutos verdes más y tendrás un buen batido.")
        case "pepino", "cebolla":
            print("Útiles para un buen sandwich.")
        case let x where x.hasSuffix("pimiento"):
            print("¿Es un \(x) picante?")
        default:
            print("Todo sabe bien en una sopa.")
        }
        // Imprime "¿Es un pimiento rojo picante?"

        // Bucles
        let numerosInteresantes = [
            "Primos": [2, 3, 5, 7, 11, 13],
            "Fibonacci": [1, 1, 2, 3, 5, 8],
            "Cuadrados": [1, 4, 9, 16, 25],
        ]

        var numeroMayor = 0

        for (_, numeros) in numerosInteresantes {
            for numero in numeros {
                if numero > numeroMayor {
                    numeroMayor = numero
                }
            }
        }

        print(numeroMayor)
        // Imprime "25"

        // Bucles while y repeat-while
        var n = 2

        while n < 100 {
            n *= 2
        }

        print(n)
        // Imprime "128"

        var m = 2

        repeat {
            m *= 2
        } while m < 100

        print(m)
        // Imprime "128"

        // Rangos
        var total = 0

        for i in 0..<4 {
            total += i
        }

        print(total)
        // Imprime "6"

    }
}
