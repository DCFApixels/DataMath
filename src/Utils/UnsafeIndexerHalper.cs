//using System;
//using System.Runtime.CompilerServices;
//
//namespace DCFApixels.DataMath
//{
//#pragma warning disable CS8500 // Это принимает адрес, получает размер или объявляет указатель на управляемый тип
//    public static class UnsafeIndexerHalper
//    {
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        public static unsafe ref TVector GetRef<TVector, TVector>(ref TVector target, int index) 
//            where TVector : struct
//            where TVector : struct, IVectorN<TVector>
//        {
//#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
//            if (index > target.length) throw new IndexOutOfRangeException($"index must be between[0...{(target.length - 1)}]");
//#endif
//            fixed (TVector* array = &target) { return ref ((TVector*)array)[index]; }
//        }
//    }
//}
