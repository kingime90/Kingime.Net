﻿using Kingime.Net.Core.Util;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingime.Net.Core.Tests.Util
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class JsonUtilTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void DeserializeAnonymousTypeTest()
        {
            var entity = new { Username = "Hello", Ticks = DateTime.Now.Ticks };
            var json = JsonConvert.SerializeObject(entity);
            var entity2 = new { Username = string.Empty, Ticks = 0L };
            var entity3 = JsonUtil.Deserialize(json, entity2);

        }
    }
}
