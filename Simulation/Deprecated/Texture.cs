using OpenTK.Graphics.OpenGL;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using static OpenTK.Graphics.OpenGL.GL;

namespace Deprecated
{
    internal class Texture
    {
        private int textureID;

        private TextureUnit currentTextureUnit;
        private static TextureUnit wholeTextureUnits;

        public Texture(string path)
        {
            var image = Image.Load<Rgba32>(path);

            image.Mutate(x => x.Flip(FlipMode.Vertical));

            var data = new List<byte>(3 * image.Width * image.Height);

            for (int r = 0; r < image.Height; r++)
            {
                var row = image.GetPixelRowSpan(r);
                for (int c = 0; c < image.Width; c++)
                {
                    data.Add(row[c].R);
                    data.Add(row[c].G);
                    data.Add(row[c].B);
                    data.Add(row[c].A);
                }
            }

            textureID = GenTexture();
            BindTexture(TextureTarget.Texture2D, textureID);

            TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, data.ToArray());

            TextureParameter(textureID, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            TextureParameter(textureID, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            BindTexture(TextureTarget.Texture2D, 0);

            if (wholeTextureUnits == 0)
            {
                wholeTextureUnits = TextureUnit.Texture0;
                currentTextureUnit = wholeTextureUnits;
            }
            else
            {
                wholeTextureUnits++;
                currentTextureUnit = wholeTextureUnits;
            }
        }

        public void Use()
        {
            ActiveTexture(currentTextureUnit);
            BindTexture(TextureTarget.Texture2D, textureID);
        }
    }
}