using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WarpLib
{
    public class TextureProject
    {

        public static void TestIt()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(new[]
            {new { name = "myName", age = 2, file= System.IO.Path.GetFullPath("aFile.txt"), kids= new []{"kid1", "kid2" } },
            new { name = "myName2", age = 3, file= System.IO.Path.GetFullPath("aFile2.txt"),kids= new []{"kid1", "kid2" } }});
            System.IO.File.WriteAllText("myfile.txt", yaml);
            System.Diagnostics.Process.Start("explorer", "myfile.txt");
        }

    }
}
