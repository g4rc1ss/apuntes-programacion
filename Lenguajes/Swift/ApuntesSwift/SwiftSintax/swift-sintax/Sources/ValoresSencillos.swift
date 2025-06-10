class ValoresSencillos {

    func execute() {
        print("Hello, world!")

        // Variables y tipos de datos
        var miVariable: Int = 42
        miVariable = 50
        let miConstante = 42

        let enteroImplicito = 70
        let doubleImplicito = 70.0
        let doubleExplicito: Double = 70

        let etiqueta = "El ancho es "
        let ancho = 94
        let anchoDeLaEtiqueta = etiqueta + String(ancho)

        // INTERPOLACIÓN DE CADENAS
        let manzanas = 3
        let naranjas = 5
        let totalManzanas = "Tengo \(manzanas) manzanas."
        let totalFrutas = "Tengo \(manzanas + naranjas) frutas."

        let cita = """
            Aun cuando hay espacios en blanco a la izquierda,
            las líneas no contienen sangría en realidad.
                Excepto por esta línea.
            Las comillas dobles (") pueden aparecer sin escaparlas.

            Todavía tengo \(manzanas + naranjas) frutas.
            """

        // Listas y diccionarios
        var frutas = ["fresas", "peras", "mandarinas"]

        frutas[1] = "uvas"

        var ocupaciones = [
            "Manuel": "Capitán",
            "Carlos": "Mecánico",
        ]

        ocupaciones["Julia"] = "Relaciones Públicas"
        frutas.append("moras")

        print(frutas)
        // Imprime "[fresas, uvas, mandarinas, moras]"

        // Para un array es [], para un diccionario es [:]
        frutas = []
        ocupaciones = [:]

        let arrayVacio: [String] = []
        let diccionarioVacio: [String: Float] = [:]

    }
}
