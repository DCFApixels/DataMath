//using System;
//using System.Runtime.CompilerServices;
//
//namespace DCFApixels.DataMath
//{
//#pragma warning disable CS8500 // Это принимает адрес, получает размер или объявляет указатель на управляемый тип
//    public static class UnsafeIndexerHalper
//    {
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        public static unsafe ref T GetRef<T, TN>(ref TN target, int index) 
//            where T : struct
//            where TN : struct, IVectorN<T>
//        {
//#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
//            if (index > target.length) throw new IndexOutOfRangeException($"index must be between[0...{(target.length - 1)}]");
//#endif
//            fixed (TN* array = &target) { return ref ((T*)array)[index]; }
//        }
//    }
//}
