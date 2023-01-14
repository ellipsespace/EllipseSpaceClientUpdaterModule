using Ionic.Zip;

Console.WriteLine("You have started the EllipseSpaceClient update module." +
    "\nTo check the updater for a more up-to-date version, visit https://github.com/ellipsespace/EllipseSpaceClientUpdaterModule.");

if (args.Length > 0 && args[0] != String.Empty && File.Exists($"{Directory.GetCurrentDirectory()}/{args[0]}"))
{
    try
    {
        using (ZipFile file = ZipFile.Read($"{Directory.GetCurrentDirectory()}/{args[0]}"))
        {
            foreach (ZipEntry e in file)
                e.Extract(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
        }
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"An error occurred while installing the update: {ex.Message}");
    }

    Console.WriteLine("The update is complete.");
}
else Console.WriteLine("There are no update files in the current directory or the update module was started without parameters.");
Console.ReadLine();