public class ClassAndObj {
    public func execute() {
        let prueba = Cuadrado(longitudLado: 5.2, nombre: "cuadrado de prueba")

        prueba.area()
        prueba.descripcionBasica()

        var triangulo = TrianguloEquilatero(longitudLado: 3.1, nombre: "un triángulo")

        print(triangulo.perimetro)
        // Imprime "9.3"

        triangulo.perimetro = 9.9

        print(triangulo.longitudLado)
        // Imprime "3.3000000000000003"

        var trianguloYCuadrado = TrianguloYCuadrado(size: 10, nombre: "otra figura de prueba")

        print(trianguloYCuadrado.cuadrado.longitudLado)
        // Imprime "10.0"

        print(trianguloYCuadrado.triangulo.longitudLado)
        // Imprime "10.0"

        trianguloYCuadrado.cuadrado = Cuadrado(longitudLado: 50, nombre: "cuadrado más grande")
        print(trianguloYCuadrado.triangulo.longitudLado)
        // Imprime "50.0"

        let cuadradoOpcional: Cuadrado? = Cuadrado(longitudLado: 2.5, nombre: "cuadrado opcional")
        let longitudLado = cuadradoOpcional?.longitudLado
    }
}

class FiguraConNombre {
    var numeroDeLados: Int = 0
    var nombre: String

    init(nombre: String) {
        self.nombre = nombre
    }

    func descripcionBasica() -> String {
        return "Una figura con \(numeroDeLados) lados."
    }
}

class Cuadrado: FiguraConNombre {
    var longitudLado: Double

    init(longitudLado: Double, nombre: String) {
        self.longitudLado = longitudLado

        super.init(nombre: nombre)

        numeroDeLados = 4
    }

    func area() -> Double {
        return longitudLado * longitudLado
    }

    override func descripcionBasica() -> String {
        return "Un cuadrado con lados de longitud \(longitudLado)."
    }
}

class TrianguloEquilatero: FiguraConNombre {
    var longitudLado: Double = 0.0

    init(longitudLado: Double, nombre: String) {
        self.longitudLado = longitudLado

        super.init(nombre: nombre)

        numeroDeLados = 3
    }

    var perimetro: Double {
        get {
            return 3.0 * longitudLado
        }

        set {
            longitudLado = newValue / 3.0
        }
    }

    override func descripcionBasica() -> String {
        return "Un triángulo equilátero con lados de longitud \(longitudLado)."
    }
}

class TrianguloYCuadrado {
    var triangulo: TrianguloEquilatero {
        willSet {
            cuadrado.longitudLado = newValue.longitudLado
        }
    }

    var cuadrado: Cuadrado {
        willSet {
            triangulo.longitudLado = newValue.longitudLado
        }
    }

    init(size: Double, nombre: String) {
        cuadrado = Cuadrado(longitudLado: size, nombre: nombre)
        triangulo = TrianguloEquilatero(longitudLado: size, nombre: nombre)
    }
}
