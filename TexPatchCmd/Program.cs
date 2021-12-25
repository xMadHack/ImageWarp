
enum ProcessFlags { PatchBody, PatchHead }
class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            ShowUsage();
            return;
        }

        var flag = ParseFlag(args[0]);
        if (flag == null)
        {
            Console.WriteLine("Invalid flag");
            return;
        }
        var inFile = args[1];
        switch (flag)
        {
            case ProcessFlags.PatchBody: WarpLib.DdsTools.ConvertAnyToDds(inFile, ReplaceFileExtension(inFile, ".dds"), true, false); break;
            case ProcessFlags.PatchHead: WarpLib.DdsTools.ConvertAnyToDds(inFile, ReplaceFileExtension(inFile, ".dds"), true, true); break;
        }
        Console.WriteLine("Done");
    }

    private static string ReplaceFileExtension(string filename, string newExtWithDot)
    {
        var fileNoExtension = System.IO.Path.GetFileNameWithoutExtension(filename);
        return System.IO.Path.Combine(Path.GetDirectoryName(filename), fileNoExtension + newExtWithDot);
    }

    private static ProcessFlags? ParseFlag(string a)
    {
        switch (a)
        {
            case "-patchBody": return ProcessFlags.PatchBody;
            case "-patchHead": return ProcessFlags.PatchHead;
        }
        return null;
    }

    private static void ShowUsage()
    {
        Console.WriteLine("Usage Inforamtion.");
        Console.WriteLine("Call this executable specifying a flag and the input filename");
        Console.WriteLine("Flags:");
        Console.WriteLine("-dds: outputs to uncompressed dds file with mipmaps");
        Console.WriteLine("-ddsBC7: outputs to compressed dds file with mipmaps");
        Console.WriteLine("'png: outputs to compressed dds file with mipmaps");
        Console.WriteLine("Example1:");
        Console.WriteLine("ImgConvertCmd.exe -dds \"MySourceImage.png\"");
        Console.WriteLine("Will create a new image file in DDS format(uncompressed and with mipmaps) called \"MySourceImage.dds\"");
    }
}