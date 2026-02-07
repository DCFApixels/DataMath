using System;

namespace DCFApixels.DataMath
{
    #region Enums
    public enum AADirection
    {
        Left,
        Right,
        Down,
        Up,
        Back,
        Forward,
        Before,
        After,
    }
    [Flags]
    public enum AADirectionFlags
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,
        Down = 1 << 2,
        Up = 1 << 3,
        Back = 1 << 4,
        Forward = 1 << 5,
        Before = 1 << 6,
        After = 1 << 7,
    }
    public enum Axis { X, Y, Z, W, }
    [Flags]
    public enum AxisFlags
    {
        None = 0,
        X = 1 << 0,
        Y = 1 << 1,
        Z = 1 << 2,
        W = 1 << 3,
    }
    public enum AxisOrder
    {
        XYZW,
        YXZW,
        XZYW,
        ZXYW,
        YZXW,
        ZYXW,

        XYWZ,
        YXWZ,
        XWYZ,
        WXYZ,
        YWXZ,
        WYXZ,

        XZWY,
        ZXWY,
        XWZY,
        WXZY,
        ZWXY,
        WZXY,

        YZWX,
        ZYWX,
        YWZX,
        WYZX,
        ZWYX,
        WZYX,

        XYZ = XYZW,
        XZY = XZYW,
        YXZ = YXZW,
        YZX = YZXW,
        ZXY = ZXYW,
        ZYX = ZYXW,

        XY = XYZW,
        YX = YXZW,

        X = XYZW,
    }
    public enum RotationOrder : byte
    {
        XYZ,
        XZY,
        YXZ,
        YZX,
        ZXY,
        ZYX,
        Default = ZXY,
    };
    #endregion

    #region Enum_ctors
    public readonly ref struct Axis_ctor
    {
        public readonly Axis Value;
        public Axis_ctor(Axis a) { Value = a; }
        public Axis_ctor(AxisFlags a, Axis defaultValue = Axis.X)
        {
            switch (a)
            {
                case AxisFlags.X: Value = Axis.X; return;
                case AxisFlags.Y: Value = Axis.Y; return;
                case AxisFlags.Z: Value = Axis.Z; return;
                case AxisFlags.W: Value = Axis.W; return;
                default: Value = defaultValue; return;
            }
        }
        public static implicit operator Axis(Axis_ctor a) { return a.Value; }
        public static Axis operator ~(Axis_ctor a) { return ~a.Value; }
        public static Axis operator &(Axis_ctor a, Axis_ctor b) { return a.Value | b.Value; }
        public static Axis operator |(Axis_ctor a, Axis_ctor b) { return a.Value | b.Value; }
    }
    public readonly ref struct AxisFlags_ctor
    {
        public readonly AxisFlags Value;
        public AxisFlags_ctor(AxisFlags a) { Value = a; }
        public AxisFlags_ctor(Axis a, AxisFlags defaultValue = AxisFlags.None)
        {
            switch (a)
            {
                case Axis.X: Value = AxisFlags.X; return;
                case Axis.Y: Value = AxisFlags.Y; return;
                case Axis.Z: Value = AxisFlags.Z; return;
                case Axis.W: Value = AxisFlags.W; return;
                default: Value = defaultValue; return;
            }
        }
        public static implicit operator AxisFlags(AxisFlags_ctor a) { return a.Value; }
        public static AxisFlags operator ~(AxisFlags_ctor a) { return ~a.Value; }
        public static AxisFlags operator &(AxisFlags_ctor a, AxisFlags_ctor b) { return a.Value | b.Value; }
        public static AxisFlags operator |(AxisFlags_ctor a, AxisFlags_ctor b) { return a.Value | b.Value; }
    }

    public readonly ref struct AADirection_ctor
    {
        public readonly AADirection Value;
        public AADirection_ctor(AADirection a) { Value = a; }
        public AADirection_ctor(AADirectionFlags a, AADirection defaultValue = AADirection.Right)
        {
            switch (a)
            {
                case AADirectionFlags.Left: Value = AADirection.Left; return;
                case AADirectionFlags.Right: Value = AADirection.Right; return;
                case AADirectionFlags.Down: Value = AADirection.Down; return;
                case AADirectionFlags.Up: Value = AADirection.Up; return;
                case AADirectionFlags.Back: Value = AADirection.Back; return;
                case AADirectionFlags.Forward: Value = AADirection.Forward; return;
                case AADirectionFlags.Before: Value = AADirection.Before; return;
                case AADirectionFlags.After: Value = AADirection.After; return;
                default: Value = defaultValue; return;
            }
        }
        public AADirection_ctor(Axis a, AADirection defaultValue = AADirection.Right)
        {
            switch (a)
            {
                case Axis.X: Value = AADirection.Right; return;
                case Axis.Y: Value = AADirection.Up; return;
                case Axis.Z: Value = AADirection.Forward; return;
                case Axis.W: Value = AADirection.After; return;
                default: Value = defaultValue; return;
            }
        }
        public static implicit operator AADirection(AADirection_ctor a) { return a.Value; }
        public static AADirection operator ~(AADirection_ctor a) { return ~a.Value; }
        public static AADirection operator &(AADirection_ctor a, AADirection_ctor b) { return a.Value | b.Value; }
        public static AADirection operator |(AADirection_ctor a, AADirection_ctor b) { return a.Value | b.Value; }
    }
    public readonly ref struct AADirectionFlags_ctor
    {
        public readonly AADirectionFlags Value;
        public AADirectionFlags_ctor(AADirectionFlags a) { Value = a; }
        public AADirectionFlags_ctor(AADirection a, AADirectionFlags defaultValue = AADirectionFlags.None)
        {
            switch (a)
            {
                case AADirection.Left: Value = AADirectionFlags.Left; return;
                case AADirection.Right: Value = AADirectionFlags.Right; return;
                case AADirection.Down: Value = AADirectionFlags.Down; return;
                case AADirection.Up: Value = AADirectionFlags.Up; return;
                case AADirection.Back: Value = AADirectionFlags.Back; return;
                case AADirection.Forward: Value = AADirectionFlags.Forward; return;
                case AADirection.Before: Value = AADirectionFlags.Before; return;
                case AADirection.After: Value = AADirectionFlags.After; return;
                default: Value = defaultValue; return;
            }
        }
        public static implicit operator AADirectionFlags(AADirectionFlags_ctor a) { return a.Value; }
        public static AADirectionFlags operator ~(AADirectionFlags_ctor a) { return ~a.Value; }
        public static AADirectionFlags operator &(AADirectionFlags_ctor a, AADirectionFlags_ctor b) { return a.Value | b.Value; }
        public static AADirectionFlags operator |(AADirectionFlags_ctor a, AADirectionFlags_ctor b) { return a.Value | b.Value; }
    }
    #endregion

    public static partial class DM
    {
        private static object _cacheLock = new object();
        private static readonly AADirection[][] _aaDirectionFlagsDecomposeCache = new AADirection[(1 << 8) - 1][];
        private static readonly Axis[][] _axisFlagsDecomposeCache = new Axis[(1 << 4) - 1][];

        public static int Sign(AADirection a)
        {
            switch (a)
            {
                case AADirection.Left:
                case AADirection.Down:
                case AADirection.Back:
                case AADirection.Before:
                    return -1;
                case AADirection.Right:
                case AADirection.Up:
                case AADirection.Forward:
                case AADirection.After:
                    return 1;
                default: return 0;
            }
        }
        public static AADirection Abs(AADirection a)
        {
            switch (a)
            {
                case AADirection.Left: return AADirection.Right;
                case AADirection.Down: return AADirection.Up;
                case AADirection.Back: return AADirection.Forward;
                case AADirection.Before: return AADirection.After;
                default: return a;
            }
        }
        public static AADirectionFlags Abs(AADirectionFlags a)
        {
            a &= ~AADirectionFlags.Left;
            a &= ~AADirectionFlags.Down;
            a &= ~AADirectionFlags.Back;
            a &= ~AADirectionFlags.Before;
            return a;
        }
        public static AADirection Negation(AADirection a)
        {
            switch (a)
            {
                case AADirection.Left: return AADirection.Right;
                case AADirection.Right: return AADirection.Left;
                case AADirection.Down: return AADirection.Up;
                case AADirection.Up: return AADirection.Down;
                case AADirection.Back: return AADirection.Forward;
                case AADirection.Forward: return AADirection.Back;
                case AADirection.Before: return AADirection.After;
                case AADirection.After: return AADirection.Before;
                default: return a;
            }
        }
        public static AADirectionFlags Negation(AADirectionFlags a)
        {
            AADirectionFlags result = AADirectionFlags.None;
            foreach (var dir in Decompose(a))
            {
                result |= new AADirectionFlags_ctor(Negation(dir));
            }
            return result;
        }
        
        public static ReadOnlySpan<AADirection> Decompose(AADirectionFlags flags)
        {
            var result = _aaDirectionFlagsDecomposeCache[(byte)flags];
            if (result != null)
            {
                return result;
            }

            byte index = (byte)flags;
            lock (_cacheLock)
            {
                if (_aaDirectionFlagsDecomposeCache[index] != null)
                {
                    return _aaDirectionFlagsDecomposeCache[index];
                }

                int count = DMBits.Count((uint)flags);
                AADirection[] directions = new AADirection[count];

                if (count == 0)
                {
                    _aaDirectionFlagsDecomposeCache[index] = directions;
                    return directions;
                }

                int pos = 0;
                int mask = 1;

                for (int i = 0; i < 8 && pos < count; i++)
                {
                    if (((int)flags & mask) != 0)
                    {
                        directions[pos++] = (AADirection)i;
                    }
                    mask <<= 1;
                }

                _aaDirectionFlagsDecomposeCache[index] = directions;
                return directions;
            }
        }
        public static ReadOnlySpan<Axis> Decompose(AxisFlags flags)
        {
            var result = _axisFlagsDecomposeCache[(byte)flags];
            if (result != null)
            {
                return result;
            }

            byte index = (byte)flags;
            lock (_cacheLock)
            {
                if (_axisFlagsDecomposeCache[index] != null)
                {
                    return _axisFlagsDecomposeCache[index];
                }

                int count = DMBits.Count((uint)flags);
                Axis[] axiss = new Axis[count];

                if (count == 0)
                {
                    _axisFlagsDecomposeCache[index] = axiss;
                    return axiss;
                }

                int pos = 0;
                int mask = 1;

                for (int i = 0; i < 4 && pos < count; i++)
                {
                    if (((int)flags & mask) != 0)
                    {
                        axiss[pos++] = (Axis)i;
                    }
                    mask <<= 1;
                }

                _axisFlagsDecomposeCache[index] = axiss;
                return axiss;
            }
        }
    }

    
   
    public static partial class DM
    {
    }
    public static partial class DMGrid
    {
        public static readonly int2[] NeighborOffsetsCross = new int2[]
        {
            int2.left, int2.right, int2.down, int2.up,
        };
        public static readonly int2[] NeighborOffsetsCube = new int2[]
        {
            int2.left + int2.down,
            int2.down,
            int2.right + int2.down,
            int2.left,
            int2.right,
            int2.left + int2.up,
            int2.up,
            int2.right + int2.up,
        };
        public static ref T Get<T>(this T[] array, int pos, int size, AxisOrder order = AxisOrder.X) { return ref array[ToIndex(pos, size, order)]; }
        public static ref T Get<T>(this T[] array, int2 pos, int2 size, AxisOrder order = AxisOrder.XY) { return ref array[ToIndex(pos, size, order)]; }
        public static ref T Get<T>(this T[] array, int3 pos, int3 size, AxisOrder order = AxisOrder.XYZ) { return ref array[ToIndex(pos, size, order)]; }
        public static int ToIndex(int pos, int size, AxisOrder order = AxisOrder.X) { return pos; }
        public static int ToIndex(int2 pos, int2 size, AxisOrder order = AxisOrder.XY)
        {
            switch (order)
            {
                case AxisOrder.XY: return pos.x + pos.y * size.x;
                case AxisOrder.YX: return pos.y + pos.x * size.y;
                default: throw new System.ArgumentException($"Неизвестный порядок осей: {order}", nameof(order));
            }
        }
        public static int ToIndex(int3 pos, int3 size, AxisOrder order = AxisOrder.XYZ)
        {
            switch (order)
            {
                case AxisOrder.XYZ: return pos.x + pos.y * size.x + pos.z * size.x * size.y;
                case AxisOrder.XZY: return pos.x + pos.z * size.x + pos.y * size.x * size.z;
                case AxisOrder.YXZ: return pos.y + pos.x * size.y + pos.z * size.y * size.x;
                case AxisOrder.YZX: return pos.y + pos.z * size.y + pos.x * size.y * size.z;
                case AxisOrder.ZXY: return pos.z + pos.x * size.z + pos.y * size.z * size.x;
                case AxisOrder.ZYX: return pos.z + pos.y * size.z + pos.x * size.z * size.y;
                default: throw new System.ArgumentException($"Неизвестный порядок осей: {order}", nameof(order));
            }
        }
        public static int FromIndex(int index, int size, AxisOrder order = AxisOrder.X) { return index; }
        public static int2 FromIndex(int index, int2 size, AxisOrder order = AxisOrder.XY)
        {
            int2 result;
            switch (order)
            {
                case AxisOrder.XY:
                    result.x = index % size.x;
                    index /= size.x;
                    result.y = index;
                    break;

                case AxisOrder.YX:
                    result.y = index % size.y;
                    index /= size.y;
                    result.x = index;
                    break;

                default:
                    throw new System.ArgumentException($"Неизвестный порядок осей: {order}", nameof(order));
            }

            return result;
        }
        public static int3 FromIndex(int index, int3 size, AxisOrder order = AxisOrder.XYZ)
        {
            int3 result;
            switch (order)
            {
                case AxisOrder.XYZ:
                    result.x = index % size.x;
                    index /= size.x;
                    result.y = index % size.y;
                    index /= size.y;
                    result.z = index;
                    break;

                case AxisOrder.XZY:
                    result.x = index % size.x;
                    index /= size.x;
                    result.z = index % size.z;
                    index /= size.z;
                    result.y = index;
                    break;

                case AxisOrder.YXZ:
                    result.y = index % size.y;
                    index /= size.y;
                    result.x = index % size.x;
                    index /= size.x;
                    result.z = index;
                    break;

                case AxisOrder.YZX:
                    result.y = index % size.y;
                    index /= size.y;
                    result.z = index % size.z;
                    index /= size.z;
                    result.x = index;
                    break;

                case AxisOrder.ZXY:
                    result.z = index % size.z;
                    index /= size.z;
                    result.x = index % size.x;
                    index /= size.x;
                    result.y = index;
                    break;

                case AxisOrder.ZYX:
                    result.z = index % size.z;
                    index /= size.z;
                    result.y = index % size.y;
                    index /= size.y;
                    result.x = index;
                    break;

                default:
                    throw new System.ArgumentException($"Неизвестный порядок осей: {order}", nameof(order));
            }

            return result;
        }
        public static bool Contains(int pos, int gridSize) { return DM.All(pos >= 0) && DM.All(pos < gridSize); }
        public static bool Contains(int2 pos, int2 gridSize) { return DM.All(pos >= 0) && DM.All(pos < gridSize); }
        public static bool Contains(int3 pos, int3 gridSize) { return DM.All(pos >= 0) && DM.All(pos < gridSize); }
        public static bool Contains(int4 pos, int4 gridSize) { return DM.All(pos >= 0) && DM.All(pos < gridSize); }

        public static bool Contains(int pos, int size, int gridSize) { return DM.All(pos >= 0) && DM.All(pos <= gridSize - size); }
        public static bool Contains(int2 pos, int2 size, int2 gridSize) { return DM.All(pos >= 0) && DM.All(pos <= gridSize - size); }
        public static bool Contains(int3 pos, int3 size, int3 gridSize) { return DM.All(pos >= 0) && DM.All(pos <= gridSize - size); }
        public static bool Contains(int4 pos, int4 size, int4 gridSize) { return DM.All(pos >= 0) && DM.All(pos <= gridSize - size); }

        public static bool Overlaps(int pos, int size, int gridSize) { return DM.All(pos + size > 0) && DM.All(pos < gridSize); }
        public static bool Overlaps(int2 pos, int2 size, int2 gridSize) { return DM.All(pos + size > 0) && DM.All(pos < gridSize); }
        public static bool Overlaps(int3 pos, int3 size, int3 gridSize) { return DM.All(pos + size > 0) && DM.All(pos < gridSize); }
        public static bool Overlaps(int4 pos, int4 size, int4 gridSize) { return DM.All(pos + size > 0) && DM.All(pos < gridSize); }

        public static int Clamp(int pos, int gridSize) { return DM.Clamp(pos, 0, gridSize); }
        public static int2 Clamp(int2 pos, int2 gridSize) { return DM.Clamp(pos, 0, gridSize); }
        public static int3 Clamp(int3 pos, int3 gridSize) { return DM.Clamp(pos, 0, gridSize); }
        public static int4 Clamp(int4 pos, int4 gridSize) { return DM.Clamp(pos, 0, gridSize); }

        public static int Clamp(int pos, int size, int gridSize) { return DM.Clamp(pos, 0, gridSize - size); }
        public static int2 Clamp(int2 pos, int2 size, int2 gridSize) { return DM.Clamp(pos, 0, gridSize - size); }
        public static int3 Clamp(int3 pos, int3 size, int3 gridSize) { return DM.Clamp(pos, 0, gridSize - size); }
        public static int4 Clamp(int4 pos, int4 size, int4 gridSize) { return DM.Clamp(pos, 0, gridSize - size); }

        public static int LineralSize(int gridSize) { return gridSize; }
        public static int LineralSize(int2 gridSize) { return gridSize.x * gridSize.y; }
        public static int LineralSize(int3 gridSize) { return gridSize.x * gridSize.y * gridSize.z; }
        public static int LineralSize(int4 gridSize) { return gridSize.x * gridSize.y * gridSize.z * gridSize.w; }

        public static bool IsIndexValid(int index, int3 gridSize) { return index >= 0 && index < LineralSize(gridSize); }


        public static int RemapIndex(int3 subGridMin, int3 subGridSize, int subIndex, int3 size, AxisOrder order = AxisOrder.XYZ)
        {
            return ToIndex(subGridMin + FromIndex(subIndex, subGridSize, order), size, order);
        }
        //public static int3 MoveInDirection(int3 coords, int direction)
        //{
        //    switch (direction)
        //    {
        //        case 0: return coords + new int3(1, 0, 0);  // +X
        //        case 1: return coords + new int3(-1, 0, 0); // -X
        //        case 2: return coords + new int3(0, 1, 0);  // +Y
        //        case 3: return coords + new int3(0, -1, 0); // -Y
        //        case 4: return coords + new int3(0, 0, 1);  // +Z
        //        case 5: return coords + new int3(0, 0, -1); // -Z
        //        default: return coords;
        //    }
        //}
        //public static int3[] GetValidNeighbors(int3 coords, int3 gridSize)
        //{
        //    var neighbors = new System.Collections.Generic.List<int3>(6);
        //
        //    for (int dir = 0; dir < 6; dir++)
        //    {
        //        var neighbor = MoveInDirection(coords, dir);
        //        if (AreCoordinatesValid(neighbor, gridSize))
        //        {
        //            neighbors.Add(neighbor);
        //        }
        //    }
        //
        //    return neighbors.ToArray();
        //}
    }
}