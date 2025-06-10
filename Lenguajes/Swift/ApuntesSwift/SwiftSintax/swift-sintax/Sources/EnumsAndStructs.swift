public class EnumsAndStructs {
    public func execute() {
        let _as = Escala._as
        let valorBrutoDeAs = _as.rawValue

        if let escalaTransformada = Escala(rawValue: 3) {
            let descripcionDelTres = escalaTransformada.descripcionBasica()
        }

        let corazones = Palo.corazones
        let descripcionDeCorazones = corazones.descripcionBasica()

        let logro = RespuestaServidor.resultado("6:00 am", "6:00 pm")
        let error = RespuestaServidor.falla("Se han agotado los recursos.")

        switch logro {
        case let .resultado(amanecer, atardecer):
            print("El amanecer es a las \(amanecer) y el atardecer es a las \(atardecer).")
        case let .falla(mensaje):
            print("Error...  \(mensaje)")
        }
        // Imprime "El amanecer es a las 6:00 am y el atardecer es a las 6:00 pm."

        let tresDePicas = Carta(escala: .tres, palo: .picas)
        let descripcionDelTresDePicas = tresDePicas.descripcionBasica()
    }
}

enum Escala: Int {
    case _as = 1
    case dos, tres, cuatro, cinco, seis, siete, ocho, nueve, diez
    case jack, reina, rey

    func descripcionBasica() -> String {
        switch self {
        case ._as:
            return "as"
        case .jack:
            return "jack"
        case .reina:
            return "reina"
        case .rey:
            return "rey"
        default:
            return String(self.rawValue)
        }
    }
}

enum Palo {
    case picas, corazones, diamantes, treboles

    func descripcionBasica() -> String {
        switch self {
        case .picas:
            return "picas"
        case .corazones:
            return "corazones"
        case .diamantes:
            return "diamantes"
        case .treboles:
            return "treboles"
        }
    }
}

enum RespuestaServidor {
    case resultado(String, String)
    case falla(String)
}

struct Carta {
    var escala: Escala
    var palo: Palo

    func descripcionBasica() -> String {
        return "El \(escala.descripcionBasica()) de \(palo.descripcionBasica())."
    }
}
