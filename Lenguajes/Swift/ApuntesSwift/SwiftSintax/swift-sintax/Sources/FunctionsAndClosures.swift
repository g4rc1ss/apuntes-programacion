public class FunctionsAndClosures {
    public func execute() {
        saludar(persona: "Bob", dia: "Martes")
        saludar("Juan", en: "Miercoles")

        let estadisticas: (min: Int, max: Int, suma: Int) = calcularEstadisticas(puntajes: [
            5, 3, 100, 3, 9,
        ])

        print(estadisticas.suma)
        // Imprime "120"

        print(estadisticas.2)
        // Imprime "120"

        devolverQuince()

        var incrementar = crearIncrementador()

        incrementar(7)

        var numeros = [20, 19, 7, 12]

        // Pasar delegados
        coincideAlguno(lista: numeros, condicion: menorQueDiez)

        // Funcion anonima(Es el equivalente al select en .net)
        numeros.map({ (numero: Int) -> Int in
            let resultado = 3 * numero

            return resultado
        })

        let numerosOrdenados = numeros.sorted { $0 > $1 }
        print(numerosOrdenados)
        // Imprime "[20, 19, 12, 7]"
    }

    func saludar(persona: String, dia: String) -> String {
        return "Hola, \(persona), hoy es \(dia)."
    }

    // Por defecto, las funciones usan los nombres de sus parámetros como etiquetas para sus argumentos.
    // Crea tu propia etiqueta para un argumento anteponiéndola al nombre del parámetro, o agrega _ para no usar una etiqueta para un argumento
    func saludar(_ persona: String, en dia: String) -> String {
        return "Hola, \(persona), hoy es \(dia)."
    }

    func calcularEstadisticas(puntajes: [Int]) -> (min: Int, max: Int, suma: Int) {
        var min = puntajes[0]
        var max = puntajes[0]
        var suma = 0

        for puntaje in puntajes {

            if puntaje > max {
                max = puntaje
            } else if puntaje < min {
                min = puntaje
            }

            suma += puntaje
        }

        return (min, max, suma)
    }

    func devolverQuince() -> Int {
        var y = 10

        func agregar() {
            y += 5
        }

        agregar()

        return y
    }

    func crearIncrementador() -> ((Int) -> Int) {
        func agregarUno(numero: Int) -> Int {
            return 1 + numero
        }

        return agregarUno
    }

    func coincideAlguno(lista: [Int], condicion: (Int) -> Bool) -> Bool {

        for elemento in lista {
            if condicion(elemento) {
                return true
            }
        }

        return false
    }

    func menorQueDiez(numero: Int) -> Bool {
        return numero < 10
    }

}
