using Xunit;

namespace AspMvcTesting;

[CollectionDefinition("Identificador")]
public class TestFixture : ICollectionFixture<TestConfigurationToFixture> { }
