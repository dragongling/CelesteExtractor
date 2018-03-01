using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace CelesteExtractor {
    public class CelesteExtractor {
        private GraphicsDevice graphicsDevice;

        public CelesteExtractor(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
        }

        public void Extract(String path) {
            using (Stream inputStream = File.OpenRead(path))
            using (Stream outputStream = File.OpenWrite(path + ".png"))
            using (Texture2D texture = LoadTextureFromStream(inputStream)) {
                texture.SaveAsPng(outputStream, texture.Width, texture.Height);
            }
        }

        public Texture2D LoadTextureFromStream(Stream inputStream) {
            byte[] textureDimensionsBytes = new byte[8];
            inputStream.Read(textureDimensionsBytes, 0, 8);
            int textureWidth = BitConverter.ToInt32(textureDimensionsBytes, 0);
            int textureHeight = BitConverter.ToInt32(textureDimensionsBytes, 4);
            bool isTransparent = Convert.ToBoolean(inputStream.ReadByte());

            using (MemoryStream outputStream = new MemoryStream()) {
                // The texture format uses a run-length encoding which allows the same 
                // bytes to represent data for multiple sequential pixels.
                int runLength;
                while ((runLength = inputStream.ReadByte()) != -1) {
                    byte o, b, g, r; // Opacity, Blue, Green, Red

                    if (isTransparent) {
                        o = (byte)inputStream.ReadByte();

                        if (o == 0) {
                            b = g = r = 0;
                        } else {
                            b = (byte)inputStream.ReadByte();
                            g = (byte)inputStream.ReadByte();
                            r = (byte)inputStream.ReadByte();
                        }
                    } else {
                        o = byte.MaxValue;
                        b = (byte)inputStream.ReadByte();
                        g = (byte)inputStream.ReadByte();
                        r = (byte)inputStream.ReadByte();
                    }

                    for (int i = 0; i < runLength; i++) {
                        outputStream.WriteByte(r);
                        outputStream.WriteByte(g);
                        outputStream.WriteByte(b);
                        outputStream.WriteByte(o);
                    }
                }

                Texture2D texture = new Texture2D(graphicsDevice, textureWidth, textureHeight);
                texture.SetData<byte>(outputStream.GetBuffer(), 0, (int)outputStream.Length);
                return texture;
            }
        }
    }
}
