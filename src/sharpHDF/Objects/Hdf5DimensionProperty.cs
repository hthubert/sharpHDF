﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace sharpHDF.Library.Objects
{
    /// <summary>
    /// Details on a particular dimension in a dataset.
    /// </summary>
    public class Hdf5DimensionProperty
    {
        public Hdf5DimensionProperty()
        {
            CurrentSize = 1;
            //MaximumSize = 0;
        }

        /// <summary>
        /// Current number of elements in the dataset.
        /// </summary>
        public ulong CurrentSize { get; set; }

        /// <summary>
        /// Maximum size of a dataset.  Can only be set at creation of the dataset.
        /// </summary>
        //public ulong MaximumSize { get; set; }
    }
}
