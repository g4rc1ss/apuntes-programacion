using System.CommandLine;

RootCommand? rootCommand = new(
    "Ejemplo de la nueva api de Microsoft para Argumentos de comandos para CLI"
);

Option<FileInfo>? fileOpt = new(name: "--file") { Description = "The file to read" };
rootCommand.Options.Add(fileOpt);

ParseResult parseResult = rootCommand.Parse(args);

FileInfo getFile = parseResult.GetRequiredValue(fileOpt);
Console.WriteLine(await File.ReadAllTextAsync(getFile.FullName));

// --file texto_prueba.txt
