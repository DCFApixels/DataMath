using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{

    public enum AAAngle : byte
    {
        _0 = 0,
        _90 = 1,
        _180 = 2,
        _270 = 3,
    }
    public static class GridRotationAngleBitsExt
    {
        public static float ToAgnle(this AAAngle angle)
        {
            switch (angle)
            {
                case AAAngle._0: return 0f;
                case AAAngle._90: return 90f;
                case AAAngle._180: return 180f;
                case AAAngle._270: return 270f;
            }
#if DEBUG
            //Debug.LogWarning("Не корректный угол RotationAngleBits");
#endif
            return 0f;
        }
    }
    public enum AAEulerEnum : uint
    {
        _00_00_00 = AAAngle._0 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._0,
        _00_00_90 = AAAngle._0 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._90,
        _00_00_180 = AAAngle._0 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._180,
        _00_00_270 = AAAngle._0 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._270,

        _00_90_00 = AAAngle._0 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._0,
        _00_90_90 = AAAngle._0 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._90,
        _00_90_180 = AAAngle._0 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._180,
        _00_90_270 = AAAngle._0 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._270,

        _00_180_00 = AAAngle._0 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._0,
        _00_180_90 = AAAngle._0 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._90,
        _00_180_180 = AAAngle._0 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._180,
        _00_180_270 = AAAngle._0 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._270,

        _00_270_00 = AAAngle._0 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._0,
        _00_270_90 = AAAngle._0 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._90,
        _00_270_180 = AAAngle._0 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._180,
        _00_270_270 = AAAngle._0 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._270,

        _90_00_00 = AAAngle._90 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._0,
        _90_00_90 = AAAngle._90 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._90,
        _90_00_180 = AAAngle._90 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._180,
        _90_00_270 = AAAngle._90 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._270,

        _90_90_00 = AAAngle._90 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._0,
        _90_90_90 = AAAngle._90 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._90,
        _90_90_180 = AAAngle._90 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._180,
        _90_90_270 = AAAngle._90 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._270,

        _90_180_00 = AAAngle._90 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._0,
        _90_180_90 = AAAngle._90 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._90,
        _90_180_180 = AAAngle._90 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._180,
        _90_180_270 = AAAngle._90 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._270,

        _90_270_00 = AAAngle._90 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._0,
        _90_270_90 = AAAngle._90 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._90,
        _90_270_180 = AAAngle._90 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._180,
        _90_270_270 = AAAngle._90 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._270,

        _180_00_00 = AAAngle._180 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._0,
        _180_00_90 = AAAngle._180 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._90,
        _180_00_180 = AAAngle._180 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._180,
        _180_00_270 = AAAngle._180 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._270,

        _180_90_00 = AAAngle._180 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._0,
        _180_90_90 = AAAngle._180 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._90,
        _180_90_180 = AAAngle._180 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._180,
        _180_90_270 = AAAngle._180 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._270,

        _180_180_00 = AAAngle._180 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._0,
        _180_180_90 = AAAngle._180 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._90,
        _180_180_180 = AAAngle._180 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._180,
        _180_180_270 = AAAngle._180 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._270,

        _180_270_00 = AAAngle._180 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._0,
        _180_270_90 = AAAngle._180 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._90,
        _180_270_180 = AAAngle._180 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._180,
        _180_270_270 = AAAngle._180 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._270,

        _270_00_00 = AAAngle._270 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._0,
        _270_00_90 = AAAngle._270 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._90,
        _270_00_180 = AAAngle._270 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._180,
        _270_00_270 = AAAngle._270 << sizeof(short) * 8 | AAAngle._0 << sizeof(byte) * 8 | AAAngle._270,

        _270_90_00 = AAAngle._270 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._0,
        _270_90_90 = AAAngle._270 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._90,
        _270_90_180 = AAAngle._270 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._180,
        _270_90_270 = AAAngle._270 << sizeof(short) * 8 | AAAngle._90 << sizeof(byte) * 8 | AAAngle._270,

        _270_180_00 = AAAngle._270 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._0,
        _270_180_90 = AAAngle._270 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._90,
        _270_180_180 = AAAngle._270 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._180,
        _270_180_270 = AAAngle._270 << sizeof(short) * 8 | AAAngle._180 << sizeof(byte) * 8 | AAAngle._270,

        _270_270_00 = AAAngle._270 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._0,
        _270_270_90 = AAAngle._270 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._90,
        _270_270_180 = AAAngle._270 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._180,
        _270_270_270 = AAAngle._270 << sizeof(short) * 8 | AAAngle._270 << sizeof(byte) * 8 | AAAngle._270,
    }
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = sizeof(uint))]
    [DebuggerDisplay("{Bits}")]
    public unsafe struct AAEuler : IEquatable<AAEuler>
    {
        [NonSerialized]
        [FieldOffset(sizeof(short))]
        public byte XRaw;
        [NonSerialized]
        [FieldOffset(sizeof(byte))]
        public byte YRaw;
        [NonSerialized]
        [FieldOffset(0)]
        public byte ZRaw;

        [FieldOffset(sizeof(short))]
        public AAAngle X;
        [FieldOffset(sizeof(byte))]
        public AAAngle Y;
        [FieldOffset(0)]
        public AAAngle Z;

        [NonSerialized]
        [FieldOffset(0)]
        public AAEulerEnum Bits;

        public AAEuler(AAEulerEnum bits) : this()
        {
            Bits = bits;
        }
        public AAEuler(float3 euler) : this()
        {
            XRaw = RoundToNearest90Index(euler.x);
            YRaw = RoundToNearest90Index(euler.y);
            ZRaw = RoundToNearest90Index(euler.z);
        }
        public AAEuler(AAAngle x, AAAngle y, AAAngle z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }


        private static byte RoundToNearest90Index(float angle)
        {
            angle = DM.Repeat(angle, 360);
            byte closestAngleIndex = 0;
            float minDifference = DM.Abs(angle - 0);
            for (byte i = 1; i < 4; i++)
            {
                float difference = DM.Abs(angle - i * 90);
                if (difference < minDifference)
                {
                    closestAngleIndex = i;
                    minDifference = difference;
                }
            }
            return closestAngleIndex;
        }

        public static AAEuler operator +(AAEuler l, AAEuler r)
        {
            byte x = (byte)((l.XRaw + r.XRaw) & 0x0004);
            byte y = (byte)((l.YRaw + r.YRaw) & 0x0004);
            byte z = (byte)((l.ZRaw + r.ZRaw) & 0x0004);
            return new AAEuler((AAAngle)x, (AAAngle)y, (AAAngle)z);
        }
        public static AAEuler operator -(AAEuler l, AAEuler r)
        {
            byte x = (byte)((l.XRaw - r.XRaw) & 0x0004);
            byte y = (byte)((l.YRaw - r.YRaw) & 0x0004);
            byte z = (byte)((l.ZRaw - r.ZRaw) & 0x0004);
            return new AAEuler((AAAngle)x, (AAAngle)y, (AAAngle)z);
        }
        public static AAEuler operator !(AAEuler a)
        {
            byte x = (byte)((5 - a.XRaw) & 0x0004);
            byte y = (byte)((5 - a.YRaw) & 0x0004);
            byte z = (byte)((5 - a.ZRaw) & 0x0004);
            return new AAEuler((AAAngle)x, (AAAngle)y, (AAAngle)z);
        }
        public static bool operator ==(AAEuler l, AAEuler r)
        {
            return l.Bits == r.Bits;
        }
        public static bool operator !=(AAEuler l, AAEuler r)
        {
            return l.Bits != r.Bits;
        }


        public static implicit operator AAEuler(AAEulerEnum a) { return new AAEuler(a); }
        public static implicit operator AAEulerEnum(AAEuler a) { return a.Bits; }

        public int3 RotateSize(int3 size)
        {
            if (Bits == AAEulerEnum._00_00_00) { return size; }
            int3 result = size;
            if (XRaw == 1 || XRaw == 3)
            {
                (result.y, result.z) = (size.z, size.y);
            }
            if (YRaw == 1 || YRaw == 3)
            {
                (result.x, result.z) = (size.z, size.x);
            }
            if (ZRaw == 1 || ZRaw == 3)
            {
                (result.x, result.y) = (size.y, size.x);
            }
            return result;
        }





        public float3 ToEuler()
        {
            return new float3(X.ToAgnle(), Y.ToAgnle(), Z.ToAgnle());
        }
        //public Matrix4x4 ToRotationMatrix(math.RotationOrder order = math.RotationOrder.XYZ)
        //{
        //    return (Matrix4x4)float4x4.Euler(ToEuler() * Mathf.Deg2Rad, order);
        //}






        public int RemapI(int i, int3 size)
        {
            return RemapI(i, size, new int3(XRaw, YRaw, ZRaw));
        }
        private static int RemapI(int i, int3 size, int3 rotation)
        {
            // Преобразуем линейный индекс в 3D координаты
            int x = i % size.x;
            int y = (i / size.x) % size.y;
            int z = i / (size.x * size.y);

            int3 coord = new int3(x, y, z);

            // Применяем повороты вокруг каждой оси в порядке Z -> Y -> X
            for (int r = 0; r < rotation.z; r++)
                coord = RotateZ(coord, size);

            for (int r = 0; r < rotation.y; r++)
                coord = RotateY(coord, size);

            for (int r = 0; r < rotation.x; r++)
                coord = RotateX(coord, size);

            // Преобразуем обратно в линейный индекс
            return coord.x + coord.y * size.x + coord.z * size.x * size.y;
        }

        // Поворот вокруг оси X на 90 градусов
        private static int3 RotateX(int3 coord, int3 size)
        {
            return new int3(
                coord.x,
                coord.z,
                size.y - 1 - coord.y
            );
        }

        // Поворот вокруг оси Y на 90 градусов
        private static int3 RotateY(int3 coord, int3 size)
        {
            return new int3(
                size.z - 1 - coord.z,
                coord.y,
                coord.x
            );
        }

        // Поворот вокруг оси Z на 90 градусов
        private static int3 RotateZ(int3 coord, int3 size)
        {
            return new int3(
                size.y - 1 - coord.y,
                coord.x,
                coord.z
            );
        }





        public int3 RotatePoint(int3 gridPosition, int3 arraySize)
        {
            return Rotate(arraySize, gridPosition, new int3(XRaw, YRaw, ZRaw));
        }
        private static int3 Rotate(int3 arraySize, int3 gridPosition, int3 gridRotation)
        {
            // Нормализуем вращение к диапазону [0, 3]
            int3 rot = gridRotation % 4;

            // Применяем вращение по осям в обратном порядке (Z -> Y -> X)
            int3 pos = gridPosition;

            // Вращение вокруг оси Z
            if (rot.z != 0)
            {
                pos = RotateZ(pos, arraySize, rot.z);
            }

            // Вращение вокруг оси Y
            if (rot.y != 0)
            {
                pos = RotateY(pos, arraySize, rot.y);
            }

            // Вращение вокруг оси X
            if (rot.x != 0)
            {
                pos = RotateX(pos, arraySize, rot.x);
            }

            return pos;
        }

        private static int3 RotateX(int3 pos, int3 size, int rotation)
        {
            int y = pos.y;
            int z = pos.z;

            switch (rotation)
            {
                case 1: // 90°
                    pos.y = size.z - 1 - z;
                    pos.z = y;
                    break;
                case 2: // 180°
                    pos.y = size.y - 1 - y;
                    pos.z = size.z - 1 - z;
                    break;
                case 3: // 270°
                    pos.y = z;
                    pos.z = size.y - 1 - y;
                    break;
            }

            return pos;
        }

        private static int3 RotateY(int3 pos, int3 size, int rotation)
        {
            int x = pos.x;
            int z = pos.z;

            switch (rotation)
            {
                case 1: // 90°
                    pos.x = z;
                    pos.z = size.x - 1 - x;
                    break;
                case 2: // 180°
                    pos.x = size.x - 1 - x;
                    pos.z = size.z - 1 - z;
                    break;
                case 3: // 270°
                    pos.x = size.z - 1 - z;
                    pos.z = x;
                    break;
            }

            return pos;
        }

        private static int3 RotateZ(int3 pos, int3 size, int rotation)
        {
            int x = pos.x;
            int y = pos.y;

            switch (rotation)
            {
                case 1: // 90°
                    pos.x = size.y - 1 - y;
                    pos.y = x;
                    break;
                case 2: // 180°
                    pos.x = size.x - 1 - x;
                    pos.y = size.y - 1 - y;
                    break;
                case 3: // 270°
                    pos.x = y;
                    pos.y = size.x - 1 - x;
                    break;
            }

            return pos;
        }

        public override string ToString()
        {
            return Bits.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is AAEuler rotation && Bits == rotation.Bits;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(XRaw, YRaw, ZRaw);
        }
        public bool Equals(AAEuler other)
        {
            return Bits == other.Bits;
        }
    }
}