using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace CelesteExtractorNF
{
    static class Texture
    {
        static public Bitmap FromFile(String path)
        {
            Stream inputStream = File.OpenRead(path);
            return FromStream(inputStream);                
        }

        static public Bitmap FromStream(Stream inputStream)
        {
            byte[] textureDimensionsBytes = new byte[8];
            inputStream.Read(textureDimensionsBytes, 0, 8);
            int width = BitConverter.ToInt32(textureDimensionsBytes, 0);
            int height = BitConverter.ToInt32(textureDimensionsBytes, 4);
            bool isTransparent = Convert.ToBoolean(inputStream.ReadByte());

            // The texture format uses a run-length encoding which allows the same 
            // bytes to represent data for multiple sequential pixels.
            byte[] convertedRawImage = new byte[height * width * 4];
            int byteIndex = 0;
            int runLength;
            while ((runLength = inputStream.ReadByte()) != -1)
            {
                byte a, b, g, r; // Alpha, Blue, Green, Red

                if (isTransparent)
                {
                    a = (byte)inputStream.ReadByte();
                    if (a == 0)
                    {
                        b = g = r = 0;
                    }
                    else
                    {
                        b = (byte)inputStream.ReadByte();
                        g = (byte)inputStream.ReadByte();
                        r = (byte)inputStream.ReadByte();
                    }
                }
                else
                {
                    a = byte.MaxValue;
                    b = (byte)inputStream.ReadByte();
                    g = (byte)inputStream.ReadByte();
                    r = (byte)inputStream.ReadByte();
                }

                for (int i = 0; i < runLength; i++)
                {
                    byte[] newPixel = new byte[] { b, g, r, a };
                    Array.Copy(newPixel, 0, convertedRawImage, byteIndex, 4);
                    byteIndex += 4;
                }
            }
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0,
                                                                bmp.Width,
                                                                bmp.Height),
                                                  ImageLockMode.WriteOnly,
                                                  bmp.PixelFormat);
            IntPtr pNative = bmpData.Scan0;
            Marshal.Copy(convertedRawImage, 0, pNative, convertedRawImage.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
    }
}
