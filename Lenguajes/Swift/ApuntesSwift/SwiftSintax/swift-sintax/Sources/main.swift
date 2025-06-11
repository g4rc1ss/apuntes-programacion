import Foundation

func main() async throws {

    if #available(macOS 10.15, *) {
        let url = URL(string: "https://apple.es")!

        // Creamos una task en una coroutine aparte para procesarlo de forma async
        // Este tipo coroutine funcionan como en GO, a traves de hilos virtuales
        let asynTask = Task {
            do {
                let (data, response) = try await URLSession.shared.data(
                    from: url
                )
                if let http = response as? HTTPURLResponse {
                    print("Codigo: \(http.statusCode)")
                }
                print(
                    "Body: \(String(data: data, encoding: .utf8) ?? "No se pudo decodificar")"
                )
            } catch {

            }
        }

        await Concurrency.execute()

        ValoresSencillos().execute()
        FlujosControl().execute()
        FunctionsAndClosures().execute()
        ClassAndObj().execute()
        EnumsAndStructs().execute()
        try await asynTask.value

    } else {
        // Fallback on earlier versions
    }
}
