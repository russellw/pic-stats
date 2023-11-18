var options = true;
foreach (var arg in args) {
	var s = arg;
	if (options) {
		if (s == "--") {
			options = false;
			continue;
		}
		if (s.StartsWith('-')) {
			while (s.StartsWith('-'))
				s = s[1..];
			switch (s) {
			case "?":
			case "h":
			case "help":
				Help();
				return 0;
			case "V":
			case "v":
			case "version":
				Console.WriteLine("pic-stats 1.0");
				return 0;
			default:
				Console.WriteLine("{0}: unknown option", arg);
				return 1;
			}
		}
	}
}
foreach (var file in Directory.EnumerateFiles(".")) {
	var name = Path.GetFileName(file);
	try {
		using var image = Image.Load(name);
		Console.WriteLine("{0}\t{1}\t{2}", image.Width, image.Height, name);
	} catch (UnknownImageFormatException) {
	}
}
return 0;

static void Help() {
	Console.WriteLine("Usage: pic-stats [options]");
	Console.WriteLine("");
	Console.WriteLine("-h  Show help");
	Console.WriteLine("-V  Show version");
}
