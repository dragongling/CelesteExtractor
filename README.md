Celeste Data Extractor
======================

This is a tool for converting the `.data` files used by the game [Celeste](http://www.celestegame.com/) into easily-readable png files. 

This has been tested with files from the MacOS Steam and Windows Steam versions of the game.

Requirements
------------

1. [.NET Core SDK](https://www.microsoft.com/net/download/)

Usage
-----

Just download the project and use `dotnet run` to run the code. Pass in paths to Celeste data files as arguments in order to convert them. For example, to convert all Celeste graphics assets (this will take a few minutes):

```
cp -r ~/Library/Application\ Support/Steam/steamapps/common/Celeste/Content/Graphics/Atlases/ ~/Desktop
cd ~/Downloads/CelesteExtractor/CelesteExtractor
dotnet run `find /Users/brian/Desktop/Atlases/ -type f -name "*.data"`
```

Each converted .png file will be placed in the same directory as its original .data file.

License
-------

Copyright 2018 Brian Gordon

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
