﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpHDF5.Enums;
using CSharpHDF5.Objects;
using NUnit.Framework;


namespace CSharpHDF5Tests.Objects
{
    [TestFixture]
    public class Hdf5DatasetTests
    {
        private string m_Directory = @"c:\temp\hdf5tests\datasettests";

        [OneTimeSetUp]
        public void Setup()
        {
            if (!Directory.Exists(m_Directory))
            {
                Directory.CreateDirectory(m_Directory);
            }

            string[] files = Directory.GetFiles(m_Directory);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private string GetFilename(string _file)
        {
            return Path.Combine(m_Directory, _file);
        }

        [Test]
        public void CreateDatasetInFile()
        {
            string filename = GetFilename("createdatasetinfile.h5");

            Hdf5File file = Hdf5File.CreateFile(filename);

            List<Hdf5DimensionProperty> properties = new List<Hdf5DimensionProperty>();
            Hdf5DimensionProperty property = new Hdf5DimensionProperty {CurrentSize = 100 };
            properties.Add(property);

            Hdf5Dataset dataset = file.AddDataset("dataset1", Hdf5DataTypes.Int8, 1, properties);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(1, file.Datasets.Count);

            file.Close();
        }

        [Test]
        public void OpenDatasetInFile()
        {
            string filename = GetFilename("opendatasetinfile.h5");

            Hdf5File file = Hdf5File.CreateFile(filename);

            List<Hdf5DimensionProperty> properties = new List<Hdf5DimensionProperty>();
            Hdf5DimensionProperty property = new Hdf5DimensionProperty { CurrentSize = 100 };
            properties.Add(property);

            Hdf5Dataset dataset = file.AddDataset("dataset1", Hdf5DataTypes.Int8, 1, properties);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(1, file.Datasets.Count);
            file.Close();

            file = new Hdf5File(filename);
            dataset = file.Datasets[0];
            Assert.IsNotNull(dataset);
            Assert.AreEqual("dataset1", dataset.Name);
            Assert.AreEqual(Hdf5DataTypes.Int8, dataset.DataType.Type);
            file.Close();
        }

        [Test]
        public void CreateDatasetInGroup()
        {
            string filename = GetFilename("createdatasetingroup.h5");

            Hdf5File file = Hdf5File.CreateFile(filename);

            Hdf5Group group = file.AddGroup("group1");

            List<Hdf5DimensionProperty> properties = new List<Hdf5DimensionProperty>();
            Hdf5DimensionProperty property = new Hdf5DimensionProperty { CurrentSize = 100 };
            properties.Add(property);

            Hdf5Dataset dataset = group.AddDataset("dataset1", Hdf5DataTypes.Int8, 1, properties);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(0, file.Datasets.Count);
            Assert.AreEqual(1, group.Datasets.Count);

            file.Close();
        }

        [Test]
        public void OpenDatasetInGroup()
        {
            string filename = GetFilename("opendatasetingroup.h5");

            Hdf5File file = Hdf5File.CreateFile(filename);

            Hdf5Group group = file.AddGroup("group1");

            List<Hdf5DimensionProperty> properties = new List<Hdf5DimensionProperty>();
            Hdf5DimensionProperty property = new Hdf5DimensionProperty { CurrentSize = 100 };
            properties.Add(property);

            Hdf5Dataset dataset = group.AddDataset("dataset1", Hdf5DataTypes.Int8, 1, properties);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(0, file.Datasets.Count);
            Assert.AreEqual(1, group.Datasets.Count);

            file.Close();

            file = new Hdf5File(filename);
            group = file.Groups[0];
            dataset = group.Datasets[0];

            Assert.IsNotNull(dataset);
            Assert.AreEqual("dataset1", dataset.Name);
        }



        //[Test]
        //public void ReadDataset1DInt8()
        //{
        //    string fileName = @"c:\temp\test.h5";

        //    Hdf5File file = new Hdf5File(fileName);

        //    Hdf5Dataset dataset = file.Groups[0].Groups[0].Datasets[1];

        //    Array array = dataset.GetData();

        //    file.Close();
        //}

        //[Test]
        //public void ReadDataset2DInt8()
        //{
        //    string fileName = @"c:\temp\test.h5";

        //    Hdf5File file = new Hdf5File(fileName);

        //    Hdf5Dataset dataset = file.Groups[0].Groups[0].Datasets[7];

        //    Array array = dataset.GetData();

        //    file.Close();
        //}


        //[Test]
        //public void ReadDataset2DInt16()
        //{
        //    string fileName = @"c:\temp\test.h5";

        //    Hdf5File file = new Hdf5File(fileName);

        //    Hdf5Dataset dataset = file.Groups[0].Groups[0].Datasets[12];

        //    Array array = dataset.GetData();

        //    file.Close();
        //}

        //[Test]
        //public void ReadDataset1DSingle()
        //{
        //    string fileName = @"c:\temp\test.h5";

        //    Hdf5File file = new Hdf5File(fileName);

        //    Hdf5Dataset dataset = file.Groups[0].Groups[0].Datasets[13];

        //    Array array = dataset.GetData();

        //    file.Close();
        //}

    }
}