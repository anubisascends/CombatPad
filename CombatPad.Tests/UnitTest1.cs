using CombatPad.Models;
using CombatPad.Models.Interfaces;
using Moq;

namespace CombatPad.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "3")]
        [InlineData(4, "4")]
        [InlineData(5, "5")]
        [InlineData(6, "6/1")]
        [InlineData(7, "6/2")]
        [InlineData(8, "6/3")]
        [InlineData(9, "6/4")]
        [InlineData(10, "6/5")]
        [InlineData(11, "6/6/1")]
        [InlineData(12, "6/6/2")]
        [InlineData(13, "6/6/3")]
        [InlineData(14, "6/6/4")]
        [InlineData(15, "6/6/5")]
        [InlineData(16, "6/6/6/1")]
        [InlineData(17, "6/6/6/2")]
        [InlineData(18, "6/6/6/3")]
        [InlineData(19, "6/6/6/4")]
        [InlineData(20, "6/6/6/5")]
        public void Attacks_Success(int baseAttack, string output)
        {
            // arrange 
            var abilityContainer = new Mock<IAbilityScoreContainer>();
            var sizeContainer = new Mock<ISizeContainer>();

            sizeContainer.Setup(x => x.Strength).Returns(new AbilityScore(abilityContainer.Object));

            var attack = new Attack(sizeContainer.Object);

            // act
            attack.BaseAttack = baseAttack;
            var result = attack.ToString();

            // assess
            Assert.Equal(output, result);
        }

        [Fact]
        public void HitPoints_Success()
        {
            // arrange
            var mockAbilityContainer = new Mock<IAbilityScoreContainer>();
            var con = new AbilityScore(mockAbilityContainer.Object);

            con.BaseScore = 10;
            mockAbilityContainer.Setup(x => x.Constitution).Returns(con);

            var hitpoints = new HitPoints(mockAbilityContainer.Object);

            // act
            hitpoints.HitDice.Add(8);
            hitpoints.HitDice.Add(8);
            hitpoints.HitDice.Add(8);
            hitpoints.HitDice.Add(8);
            hitpoints.HitDice.Add(10);
            hitpoints.HitDice.Add(10);
            hitpoints.HitDice.Add(10);

            var result = hitpoints.HitDice.ToString();

            // assess
            Assert.Equal("4d8, 3d10", result);
        }
    }
}