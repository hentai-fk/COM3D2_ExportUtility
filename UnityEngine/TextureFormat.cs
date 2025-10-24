using System;
using System.ComponentModel;

namespace UnityEngine
{
    // Token: 0x020001A0 RID: 416
    public enum TextureFormat
    {
        // Token: 0x0400055D RID: 1373
        Alpha8 = 1,
        // Token: 0x0400055E RID: 1374
        ARGB4444,
        // Token: 0x0400055F RID: 1375
        RGB24,
        // Token: 0x04000560 RID: 1376
        RGBA32,
        // Token: 0x04000561 RID: 1377
        ARGB32,
        // Token: 0x04000562 RID: 1378
        RGB565 = 7,
        // Token: 0x04000563 RID: 1379
        R16 = 9,
        // Token: 0x04000564 RID: 1380
        DXT1,
        // Token: 0x04000565 RID: 1381
        DXT5 = 12,
        // Token: 0x04000566 RID: 1382
        RGBA4444,
        // Token: 0x04000567 RID: 1383
        BGRA32,
        // Token: 0x04000568 RID: 1384
        RHalf,
        // Token: 0x04000569 RID: 1385
        RGHalf,
        // Token: 0x0400056A RID: 1386
        RGBAHalf,
        // Token: 0x0400056B RID: 1387
        RFloat,
        // Token: 0x0400056C RID: 1388
        RGFloat,
        // Token: 0x0400056D RID: 1389
        RGBAFloat,
        // Token: 0x0400056E RID: 1390
        YUY2,
        // Token: 0x0400056F RID: 1391
        RGB9e5Float,
        // Token: 0x04000570 RID: 1392
        BC4 = 26,
        // Token: 0x04000571 RID: 1393
        BC5,
        // Token: 0x04000572 RID: 1394
        BC6H = 24,
        // Token: 0x04000573 RID: 1395
        BC7,
        // Token: 0x04000574 RID: 1396
        DXT1Crunched = 28,
        // Token: 0x04000575 RID: 1397
        DXT5Crunched,
        // Token: 0x04000576 RID: 1398
        PVRTC_RGB2,
        // Token: 0x04000577 RID: 1399
        PVRTC_RGBA2,
        // Token: 0x04000578 RID: 1400
        PVRTC_RGB4,
        // Token: 0x04000579 RID: 1401
        PVRTC_RGBA4,
        // Token: 0x0400057A RID: 1402
        ETC_RGB4,
        // Token: 0x0400057B RID: 1403
        EAC_R = 41,
        // Token: 0x0400057C RID: 1404
        EAC_R_SIGNED,
        // Token: 0x0400057D RID: 1405
        EAC_RG,
        // Token: 0x0400057E RID: 1406
        EAC_RG_SIGNED,
        // Token: 0x0400057F RID: 1407
        ETC2_RGB,
        // Token: 0x04000580 RID: 1408
        ETC2_RGBA1,
        // Token: 0x04000581 RID: 1409
        ETC2_RGBA8,
        // Token: 0x04000582 RID: 1410
        ASTC_4x4,
        // Token: 0x04000583 RID: 1411
        ASTC_5x5,
        // Token: 0x04000584 RID: 1412
        ASTC_6x6,
        // Token: 0x04000585 RID: 1413
        ASTC_8x8,
        // Token: 0x04000586 RID: 1414
        ASTC_10x10,
        // Token: 0x04000587 RID: 1415
        ASTC_12x12,
        // Token: 0x04000588 RID: 1416
        [Obsolete("Nintendo 3DS is no longer supported.")]
        ETC_RGB4_3DS = 60,
        // Token: 0x04000589 RID: 1417
        [Obsolete("Nintendo 3DS is no longer supported.")]
        ETC_RGBA8_3DS,
        // Token: 0x0400058A RID: 1418
        RG16,
        // Token: 0x0400058B RID: 1419
        R8,
        // Token: 0x0400058C RID: 1420
        ETC_RGB4Crunched,
        // Token: 0x0400058D RID: 1421
        ETC2_RGBA8Crunched,
        // Token: 0x0400058E RID: 1422
        ASTC_HDR_4x4,
        // Token: 0x0400058F RID: 1423
        ASTC_HDR_5x5,
        // Token: 0x04000590 RID: 1424
        ASTC_HDR_6x6,
        // Token: 0x04000591 RID: 1425
        ASTC_HDR_8x8,
        // Token: 0x04000592 RID: 1426
        ASTC_HDR_10x10,
        // Token: 0x04000593 RID: 1427
        ASTC_HDR_12x12,
        // Token: 0x04000594 RID: 1428
        RG32,
        // Token: 0x04000595 RID: 1429
        RGB48,
        // Token: 0x04000596 RID: 1430
        RGBA64,
        // Token: 0x04000597 RID: 1431
        [Obsolete("Enum member TextureFormat.ASTC_RGB_4x4 has been deprecated. Use ASTC_4x4 instead (UnityUpgradable) -> ASTC_4x4")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGB_4x4 = 48,
        // Token: 0x04000598 RID: 1432
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Enum member TextureFormat.ASTC_RGB_5x5 has been deprecated. Use ASTC_5x5 instead (UnityUpgradable) -> ASTC_5x5")]
        ASTC_RGB_5x5,
        // Token: 0x04000599 RID: 1433
        [Obsolete("Enum member TextureFormat.ASTC_RGB_6x6 has been deprecated. Use ASTC_6x6 instead (UnityUpgradable) -> ASTC_6x6")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGB_6x6,
        // Token: 0x0400059A RID: 1434
        [Obsolete("Enum member TextureFormat.ASTC_RGB_8x8 has been deprecated. Use ASTC_8x8 instead (UnityUpgradable) -> ASTC_8x8")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGB_8x8,
        // Token: 0x0400059B RID: 1435
        [Obsolete("Enum member TextureFormat.ASTC_RGB_10x10 has been deprecated. Use ASTC_10x10 instead (UnityUpgradable) -> ASTC_10x10")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGB_10x10,
        // Token: 0x0400059C RID: 1436
        [Obsolete("Enum member TextureFormat.ASTC_RGB_12x12 has been deprecated. Use ASTC_12x12 instead (UnityUpgradable) -> ASTC_12x12")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGB_12x12,
        // Token: 0x0400059D RID: 1437
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_4x4 has been deprecated. Use ASTC_4x4 instead (UnityUpgradable) -> ASTC_4x4")]
        ASTC_RGBA_4x4,
        // Token: 0x0400059E RID: 1438
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_5x5 has been deprecated. Use ASTC_5x5 instead (UnityUpgradable) -> ASTC_5x5")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGBA_5x5,
        // Token: 0x0400059F RID: 1439
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_6x6 has been deprecated. Use ASTC_6x6 instead (UnityUpgradable) -> ASTC_6x6")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGBA_6x6,
        // Token: 0x040005A0 RID: 1440
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_8x8 has been deprecated. Use ASTC_8x8 instead (UnityUpgradable) -> ASTC_8x8")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        ASTC_RGBA_8x8,
        // Token: 0x040005A1 RID: 1441
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_10x10 has been deprecated. Use ASTC_10x10 instead (UnityUpgradable) -> ASTC_10x10")]
        ASTC_RGBA_10x10,
        // Token: 0x040005A2 RID: 1442
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Enum member TextureFormat.ASTC_RGBA_12x12 has been deprecated. Use ASTC_12x12 instead (UnityUpgradable) -> ASTC_12x12")]
        ASTC_RGBA_12x12
    }
}
