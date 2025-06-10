if #available(macOS 10.15, *) {
    Task {
        await Concurrency.execute()
    }
} else {
    print("No se puede ejecutar Concurrency en esta versión de macOS.")
}
ValoresSencillos().execute()
FlujosControl().execute()
FunctionsAndClosures().execute()
ClassAndObj().execute()
EnumsAndStructs().execute()

var x = readLine(strippingNewline: true)
