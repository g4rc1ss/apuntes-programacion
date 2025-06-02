using System.CommandLine;

RootCommand? rootCommand = new(
    "Ejemplo de la nueva api de Microsoft para Argumentos de comandos para CLI"
);

Option<FileInfo>? fileOpt = new(name: "--file", description: "The file to read");
rootCommand.AddOption(fileOpt);
rootCommand.SetHandler(
    async (file) =>
    {
        ArgumentNullException.ThrowIfNull(file);
        await foreach (string? line in File.ReadLinesAsync(file.FullName))
        {
            Console.WriteLine(line);
        }
    },
    fileOpt
);

await rootCommand.InvokeAsync(args);
