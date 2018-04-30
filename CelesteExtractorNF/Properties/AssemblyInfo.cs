using System.Reflection;
using System.Runtime.InteropServices;
using CommandLine;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Celeste Extractor (NetFramework)")]
[assembly: AssemblyDescription("Tool for converting Celeste 2018 game .data image files")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Celeste Extractor (NetFramework)")]
[assembly: AssemblyCopyright("by SamMetalWorker (github.com/dragongling), 2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("1e214d93-b677-483c-a787-7951d95602b7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// from CommandLineParser.Text
[assembly: AssemblyLicense(
    "This is free software. You may redistribute copies of it under the terms of",
    "the MIT License <http://www.opensource.org/licenses/mit-license.php>.")]
[assembly: AssemblyUsage(
    "Usage: CelesteExtractorNF -i Gameplay0.data",
    @"       CelesteExtractorNF -i Celeste\Content\Atlases\ 00.data -o outputDir\")]
