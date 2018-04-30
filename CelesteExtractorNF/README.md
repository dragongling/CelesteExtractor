Celeste Data Extractor (NET Framework)
======================================

This is a tool for converting the `.data` files used by the game [Celeste](http://www.celestegame.com/) into easily-readable png files. 

This has been tested with files from Windows Steam version of the game.

Requirements
------------

1. [.NET Framework 4.6.1](https://www.microsoft.com/net/download/)

Usage
-----

Download the project & build. This will automatically download dependencies from NuGet.

The graphic assets of Windows Steam version are located in `steamapps\common\Celeste\Content\Graphics\Atlases`

You must pass files and/or directories as input parameters in order to convert them. For input directories it scans all files with `.data` extension. You can also pass output directory (executable directory by default):

```
Usage: CelesteExtractorNF -i Gameplay0.data
       CelesteExtractorNF -i Celeste\Content\Atlases -o outputDir\
       CelesteExtractorNF -i Celeste\Content\Atlases 00.data -o outputDir\

  -i, --inputPaths    Required. Input files & directories to be processed.

  -o, --outputDir     Output directory for extracted files.

  --help              Display this help screen.
```

Each converted `.png` file will be placed into output directory with the same folder structure. The total PNG-compressed size of Celeste's graphics assets is about 310MB.

TODO
----
* Make it crossplatform again! (and not dependent on XNA)
* Break atlases by `.meta` and `.xml` files