using System.Text;
using UnityEngine;

public class ImportCM
{
    public static TextureResource LoadTextureFile(AFileBase file, bool usePoolBuffer)
    {
        if (file == null || !file.IsValid())
        {
            return null;
        }
        if (ImportCM.m_texTempFile == null)
        {
            ImportCM.m_texTempFile = new byte[Math.Max(500000, file.GetSize())];
        }
        else if (ImportCM.m_texTempFile.Length < file.GetSize())
        {
            ImportCM.m_texTempFile = new byte[file.GetSize()];
        }
        file.Read(ref ImportCM.m_texTempFile, file.GetSize());
        BinaryReader binaryReader = new BinaryReader(new MemoryStream(ImportCM.m_texTempFile), Encoding.UTF8);
        string text = binaryReader.ReadString();
        if (text != "CM3D2_TEX")
        {
            NDebug.Assert("ProcScriptBin 例外 : ヘッダーファイルが不正です。" + text, false);
        }
        int num = binaryReader.ReadInt32();
        binaryReader.ReadString();
        int width = 0;
        int height = 0;
        TextureFormat textureFormat = TextureFormat.ARGB32;

        if (1010 <= num)
        {
            if (1011 <= num)
            {
                int num2 = binaryReader.ReadInt32();
                if (0 < num2)
                {
                    Console.WriteLine("这个图片包含多张子图，暂不支持解析子图数据。");
                    for (int i = 0; i < num2; i++)
                    {
                        float x = binaryReader.ReadSingle();
                        float y = binaryReader.ReadSingle();
                        float width2 = binaryReader.ReadSingle();
                        float height2 = binaryReader.ReadSingle();
                    }
                }
            }
            width = binaryReader.ReadInt32();
            height = binaryReader.ReadInt32();
            textureFormat = (TextureFormat)binaryReader.ReadInt32();
        }
        int num3 = binaryReader.ReadInt32();
        byte[] array2;
        if (usePoolBuffer && textureFormat == TextureFormat.ARGB32)
        {
            if (ImportCM.m_texTempImg == null)
            {
                ImportCM.m_texTempImg = new byte[Math.Max(500000, num3)];
            }
            else if (ImportCM.m_texTempImg.Length < num3)
            {
                ImportCM.m_texTempImg = new byte[num3];
            }
            binaryReader.Read(ImportCM.m_texTempImg, 0, num3);
            array2 = ImportCM.m_texTempImg;
        }
        else
        {
            array2 = new byte[num3];
            binaryReader.Read(array2, 0, num3);
        }
        if (num == 1000)
        {
            width = ((int)array2[16] << 24 | (int)array2[17] << 16 | (int)array2[18] << 8 | (int)array2[19]);
            height = ((int)array2[20] << 24 | (int)array2[21] << 16 | (int)array2[22] << 8 | (int)array2[23]);
        }
        binaryReader.Close();
        return new TextureResource(width, height, textureFormat, array2);
    }

    // Token: 0x04000C0E RID: 3086
    private static byte[] m_skinTempFile = null;

    // Token: 0x04000C0F RID: 3087
    private static byte[] m_matTempFile = null;

    // Token: 0x04000C10 RID: 3088
    private static readonly Dictionary<int, KeyValuePair<string, float>> m_hashPriorityMaterials = new Dictionary<int, KeyValuePair<string, float>>();

    // Token: 0x04000C12 RID: 3090
    private static byte[] m_texTempFile = null;

    // Token: 0x04000C13 RID: 3091
    private static byte[] m_texTempImg = null;

    // Token: 0x04000C14 RID: 3092
    public static byte[] m_aniTempFile = null;

    // Token: 0x04000C15 RID: 3093
    public static byte[] m_byPhyTempFile = null;
}
