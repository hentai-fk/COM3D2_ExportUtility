using BCnEncoder.Decoder;
using BCnEncoder.ImageSharp;
using BCnEncoder.Shared;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using UnityEngine;

public class TextureResource
{
    public TextureResource(int width, int height, TextureFormat format, byte[] data)
    {
        this.width = width;
        this.height = height;
        this.format = format;
        this.data = data;
    }

    public Image<Rgba32> CreateTexture2D()
    {
        if (this.format == TextureFormat.DXT1 || this.format == TextureFormat.DXT5)
        {
            int num = this.width + 3 & -4;
            int num2 = this.height + 3 & -4;
            Image<Rgba32> image = null;
            if (this.width == num && this.height == num2)
            {
                image = new BcDecoder().DecodeRawToImageRgba32(this.data, width, height,
                    this.format == TextureFormat.DXT5 ? CompressionFormat.Bc3 : CompressionFormat.Bc1);
            }
            else
            {
                image = new BcDecoder().DecodeRawToImageRgba32(this.data, num, num2,
                    this.format == TextureFormat.DXT5 ? CompressionFormat.Bc3 : CompressionFormat.Bc1);
            }
            image.Mutate(x => x.Rotate(180)); // 修正上下颠倒的问题
            return image;
        }
        else
        {
            if (this.format == TextureFormat.ARGB32 || this.format == TextureFormat.RGB24)
            {
                return Image.Load<Rgba32>(data);
            }
            return null;
        }
    }

    // Token: 0x04002D26 RID: 11558
    public readonly int width;

    // Token: 0x04002D27 RID: 11559
    public readonly int height;

    // Token: 0x04002D28 RID: 11560
    public readonly TextureFormat format;

    // Token: 0x04002D2A RID: 11562
    public readonly byte[] data;
}
