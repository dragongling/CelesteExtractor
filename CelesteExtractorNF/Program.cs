using System;
using System.IO;
using CommandLine;
using CommandLine.Text;

namespace CelesteExtractorNF
{
    class Options
    {
        [OptionArray('i', "input-paths", Required = true,
          HelpText = "Input files & directories to be processed.")]
        public string[] InputPaths { get; set; }

        [Option('o', "output-dir", DefaultValue = "",
          HelpText = "Output directory for extracted files.")]
        public string OutputDir { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (!Directory.Exists(options.OutputDir))
                    Directory.CreateDirectory(options.OutputDir);

                Console.WriteLine("Extracting...");
                try
                {
                    foreach (var inputPath in options.InputPaths)
                    {
                        FileAttributes attr = File.GetAttributes(inputPath);
                        if (attr.HasFlag(FileAttributes.Directory))
                            ProcessDir(inputPath, options.OutputDir);
                        else
                            ProcessFile(inputPath, options.OutputDir);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Done!");
            }
        }        

        static void ProcessDir(string inputDir, string outputDir)
        {
            foreach (string inputFilePath in Directory.EnumerateFiles(inputDir, "*.data", SearchOption.AllDirectories))
            {
                var subDirectory = Path.GetDirectoryName(inputFilePath).Substring(inputDir.Length);
                var currentOutputDirectory = EscapeDir(outputDir + subDirectory);
                Directory.CreateDirectory(currentOutputDirectory);
                ProcessFile(inputFilePath, currentOutputDirectory);
            }
        }

        static void ProcessFile(string inputFile, string outputDirectory)
        {
            var outputFilePath = EscapeDir(outputDirectory) + Path.GetFileNameWithoutExtension(inputFile) + ".png";
            Texture.FromFile(inputFile).Save(outputFilePath);
            Console.WriteLine("Extracted: " + outputFilePath);
        }

        static string EscapeDir(string path)
        {
            return path.EndsWith(@"\") || String.IsNullOrEmpty(path) ? path : path + @"\";
        }
    }
}
