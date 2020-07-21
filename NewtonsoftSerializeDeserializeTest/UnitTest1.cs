using Newtonsoft.Json;
using NUnit.Framework;

namespace NewtonsoftSerializeDeserializeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeserializeNullString()
        {
            var s = @"{'Id':'1', 'Role': null}";
            var o = JsonConvert.DeserializeObject<Model>(s);
            Assert.IsTrue(o.Role == null);
        }

        [Test]
        public void DeserializeEmptyString()
        {
            var s = @"{'Id':'1', 'Role': ''}";
            var o = JsonConvert.DeserializeObject<Model>(s);
            Assert.IsTrue(o.Role == string.Empty);
        }

        [Test]
        public void DeserializeWithoutString()
        {
            var s = @"{'Id':'1'}";
            var o = JsonConvert.DeserializeObject<Model>(s);
            Assert.IsTrue(o.Role == null);
        }

        [Test]
        public void SerializeNullString()
        {
            var o = new Model
            {
                Id = 1,
                Role = null
            };
            var s = JsonConvert.SerializeObject(o);
            Assert.IsTrue(s.Contains(@"""Role"":null"));
        }

        [Test]
        public void SerializeWithoutString()
        {
            var o = new Model
            {
                Id = 1
            };
            var s = JsonConvert.SerializeObject(o);
            Assert.IsTrue(s.Contains(@"""Role"":null"));
        }
    }

    public class Model
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}