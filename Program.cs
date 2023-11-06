foreach (var file in Directory.EnumerateFiles("."))
{
    var name = Path.GetFileName(file);
    try
    {
        using var image = Image.Load(name);
        Console.WriteLine("{0}\t{1}\t{2}", image.Width, image.Height, name);
    }
    catch (UnknownImageFormatException)
    {
    }
}
