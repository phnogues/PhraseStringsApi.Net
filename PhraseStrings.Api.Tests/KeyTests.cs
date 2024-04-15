using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Tests;

[TestClass]
public class KeyTests : BaseTest
{
    [TestMethod]
    public async Task GetAll_ShouldReturnResults()
    {
        var result = await localizationClient.Keys.GetAll(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }

    [TestMethod]
    public async Task GetById_ShouldReturnResult()
    {
        var randomKey = (await localizationClient.Keys.GetAll(ProjectTestId))[0];
        var result = await localizationClient.Keys.GetById(ProjectTestId, randomKey.Id);

        Assert.IsTrue(result.Id == randomKey.Id);
    }

    [TestMethod]
    public async Task GetByName_ShouldReturnResult()
    {
        var randomKey = (await localizationClient.Keys.GetAll(ProjectTestId))[0];
        var result = await localizationClient.Keys.GetByName(ProjectTestId, randomKey.Name);

        Assert.IsTrue(result.Id == randomKey.Id);
    }

    [TestMethod]
    public async Task Add_ShouldReturnResult()
    {
        Key keyToAdd = new Key()
        {
            Name = "unit_test.key",
            DataType = Enums.DataTypesEnum.String,
        };

        var result = await localizationClient.Keys.Add(ProjectTestId, keyToAdd);

        // Delete the key we just added
        await localizationClient.Keys.Delete(ProjectTestId, result.Id);

        Assert.IsTrue(result.Name == keyToAdd.Name);
    }

    [TestMethod]
    public async Task Delete_ShouldReturnTrue()
    {
        Key keyToAdd = new Key()
        {
            Name = "unit_test_to_delete.key",
            DataType = Enums.DataTypesEnum.String,
        };

        var keyAdded = await localizationClient.Keys.Add(ProjectTestId, keyToAdd);

        var result = await localizationClient.Keys.Delete(ProjectTestId, keyAdded.Id);

        Assert.IsTrue(result);
    }

}
