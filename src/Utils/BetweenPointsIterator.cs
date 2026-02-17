using DCFApixels.DataMath.Easing;
using System.Collections;
using System.Collections.Generic;

namespace DCFApixels.DataMath
{
    public struct BetweenPointsIterator : IEnumerable<float3>
    {
        public float3 From;
        public float3 To;
        public int Count;
        public Ease Ease;
        public EaseFunction EaseFunction;

        public BetweenPointsIterator(float3 from, float3 to, int count)
        {
            From = from;
            To = to;
            Count = count;
            Ease = Ease.Linear;
            EaseFunction = null;
        }
        public BetweenPointsIterator(float3 from, float3 to, int count, Ease ease)
        {
            From = from;
            To = to;
            Count = count;
            Ease = ease;
            EaseFunction = null;
        }
        public BetweenPointsIterator(float3 from, float3 to, int count, EaseFunction easeFunction)
        {
            From = from;
            To = to;
            Count = count;
            Ease = Ease.Linear;
            EaseFunction = easeFunction;
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(From, To, Count, Ease, EaseFunction);
        }
        IEnumerator<float3> IEnumerable<float3>.GetEnumerator() { return GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public struct Enumerator : IEnumerator<float3>
        {
            private readonly float3 _from;
            private readonly float3 _to;
            private readonly int _count;
            private int _currentIndex;
            private float3 _current;
            public Ease _ease;
            public EaseFunction _easeFunction;
            public Enumerator(float3 from, float3 to, int count, Ease ease, EaseFunction easeFunction)
            {
                _from = from;
                _to = to;
                _count = count;
                _currentIndex = -1;
                _current = default;
                _ease = ease;
                _easeFunction = easeFunction;
            }
            public float3 Current => _current;
            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                _currentIndex++;
                if (_currentIndex < _count)
                {
                    if (_count <= 1)
                    {
                        _current = _from;
                    }
                    else
                    {
                        float t = _currentIndex / (float)(_count - 1);
                        if(_easeFunction == null)
                        {
                            t = _ease.Evaluate(t);
                        }
                        else
                        {
                            t = _easeFunction(t);
                        }
                        _current = DM.Lerp(_from, _to, t);
                    }
                    return true;
                }

                return false;
            }
            public void Reset()
            {
                _currentIndex = -1;
            }
            public void Dispose() { }
        }
    }
}
