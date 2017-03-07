using ChangeBackground.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeBackground.test.Util
{
    [TestFixture]
    class ApodTest
    {

        [Test]
        public void shouldGetResult()
        {
            ApodResult result = Apod.GetDailyData();
            Assert.That(result.date, Is.Not.Null);
            Assert.That(result.explanation, Is.Not.Null);
            Assert.That(result.hdurl, Is.Not.Null);
            Assert.That(result.media_type, Is.Not.Null);
            Assert.That(result.service_version, Is.Not.Null);
            Assert.That(result.title, Is.Not.Null);
            Assert.That(result.url, Is.Not.Null);
        }
    }
}
