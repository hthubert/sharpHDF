/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace sharpHDF.Library.Structs
{
    public struct Hdf5Identifier
    {

#if HDF5_VER1_10
        public Hdf5Identifier(long _value)
        {
            Value = _value;
        }

        public long Value;
#else
        public Hdf5Identifier(Int32 _value)
        {
            Value = _value;
        }

        public readonly Int32 Value;
#endif

        public bool Equals(Hdf5Identifier _other)
        {
            return Value == _other.Value;
        }

        public override int GetHashCode()
        {
            return (int)Value;
        }
    }
}
