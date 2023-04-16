using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroes;
    private Hero firstHero;
    private Hero secondHero;

    [SetUp]
    public void SetUp()
    {
        heroes = new HeroRepository();
        firstHero = new Hero("Pesho", 5);
        secondHero = new Hero("Gosho", 7);
    }
    [Test]
    public void Test_ConstructorShouldInitiateHeroCollection()
    {
        int expectedResult = 0;
        int actualResult = heroes.Heroes.Count;

        Assert.AreEqual(expectedResult, actualResult);
    }
    [Test]
    public void Test_Create_ShouldThrowExceptionIfGivenHeroIsNull()
    {
        firstHero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Create(firstHero);
        }, "Hero is null");
    }
    [Test]
    public void Test_Create_ShouldThrowExceptionIfHeroAlreadyExist()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroes.Create(firstHero);
            heroes.Create(firstHero);
        }, $"Hero with name {firstHero.Name} already exists");
    }
    [Test]
    public void Test_Create_ShouldWorkCorrectly()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        List<Hero> expectedResult = new List<Hero>()
       {
           firstHero, secondHero
       };
        IReadOnlyCollection<Hero> actualResult = heroes.Heroes;

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Test_Remove_ShouldThrowExceptionWhenValueIsNullOrWhitespace(string testName)
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Remove(null);
        }, "Name cannot be null");
    }
    [Test]
    public void Test_Remove_ShouldReturnTrue()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Assert.IsTrue(heroes.Remove("Pesho"));
    }
    [Test]
    public void Test_Remove_ShouldReturnFalse()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Assert.IsTrue(!heroes.Remove("Ivancho"));
    }
    [Test]
    public void Test_GetHeroWithHighestLevel_ShouldReturnTheHighestLevelHero()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Hero highLvlHero = heroes.GetHeroWithHighestLevel();

        int expectedLevel = secondHero.Level;
        int actualLevel = highLvlHero.Level;

        Assert.AreEqual(expectedLevel, actualLevel);
    }
    [Test]
    public void Test_GetHero_ShouldGetDesiredHero()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Hero actualHero = heroes.GetHero(firstHero.Name);

        Assert.IsNotNull(actualHero);
    }
    [Test]
    public void Test_GetHero_ShouldReturnNull()
    {
        heroes.Create(firstHero);
        heroes.Create(secondHero);

        Hero actualHero = heroes.GetHero("SomeText");

        Assert.IsNull(actualHero);
    }
}