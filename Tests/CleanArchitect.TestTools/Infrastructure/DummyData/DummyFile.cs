﻿using System.Reflection;
using Xunit.Sdk;

namespace CleanArchitect.TestTools.Infrastructure.DummyData
{
    public class DummyFile : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var fileId = "Id";
            var fileExtension = "dummy";
            return new[] { new object[] { fileId, fileExtension } };
        }
    }
}