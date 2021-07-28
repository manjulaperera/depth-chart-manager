using DepthChartManager.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace DepthChartManager.Tests.Domain
{
    public class TeamTests
    {
        [Test]
        public void ShouldThrowExceptionIfTeamNameIsInvalid()
        {
            var league = new League("NFL");
            Assert.Throws<Exception>(() => new Team(league, string.Empty));
        }

        [Test]
        public void ShouldPassIfTeamNameIsValid()
        {
            var league = new League("NFL");
            var team = new Team(league, "Buffalo Bills");
            Assert.AreEqual("Buffalo Bills", team.Name);
        }

        [Test]
        public void ShouldThrowExceptionIfTeamPlayerNameIsInvalid()
        {
            var league = new League("NFL");
            var team = new Team(league, "Buffalo Bills");
            Assert.Throws<Exception>(() => new Player(league, team, string.Empty));
        }


        [Test]
        public void ShouldThrowExceptionIfTeamPlayerNameAlreadyExists()
        {
            var league = new League("NFL");
            var team = new Team(league, "Buffalo Bills");
            team.AddPlayer("Alice");
            Assert.Throws<Exception>(() => team.AddPlayer("Alice"));
        }

        [Test]
        public void ShouldReturnCorrectPlayerCountInATeam()
        {
            var league = new League("NFL");
            var team = new Team(league, "Buffalo Bills");
            team.AddPlayer("Alice");
            team.AddPlayer("Bob");
            Assert.AreEqual(2, team.Players.Count());
        }

        [Test]
        public void ShouldReturnCorrectPlayerPositionInATeam()
        {
            var league = new League("NFL");
            var qbPosition = league.AddSupportingPosition("QB");
            league.AddSupportingPosition("WR");
            league.AddSupportingPosition("KR");

            var team = new Team(league, "Buffalo Bills");
            var alice = team.AddPlayer("Alice");

            var playerPosition = team.UpdatePlayerPosition(alice.Id, qbPosition.Id, 0);
            Assert.AreEqual(0, playerPosition.SupportingPositionRanking);
        }

        [Test]
        public void ShouldReturnCorrectPlayerPositionsInATeam()
        {
            var league = new League("NFL");
            var qbPosition = league.AddSupportingPosition("QB");
            league.AddSupportingPosition("WR");
            league.AddSupportingPosition("KR");

            var team = new Team(league, "Buffalo Bills");
            var alice = team.AddPlayer("Alice");
            var bob = team.AddPlayer("Bob");
            var charlie = team.AddPlayer("Charlie");

            team.UpdatePlayerPosition(alice.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(bob.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(charlie.Id, qbPosition.Id, 2);

            Assert.AreEqual(bob.Id, team.PlayerPositions.ElementAtOrDefault(0).Player.Id);
            Assert.AreEqual(alice.Id, team.PlayerPositions.ElementAtOrDefault(1).Player.Id);
            Assert.AreEqual(charlie.Id, team.PlayerPositions.ElementAtOrDefault(2).Player.Id);
        }

        [Test]
        public void ShouldNotReturnRemovedPlayerPositionInATeam()
        {
            var league = new League("NFL");
            var qbPosition = league.AddSupportingPosition("QB");
            league.AddSupportingPosition("WR");
            league.AddSupportingPosition("KR");

            var team = new Team(league, "Buffalo Bills");
            var alice = team.AddPlayer("Alice");
            var bob = team.AddPlayer("Bob");
            var charlie = team.AddPlayer("Charlie");

            team.UpdatePlayerPosition(alice.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(bob.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(charlie.Id, qbPosition.Id, 2);

            Assert.AreEqual(bob.Id, team.PlayerPositions.ElementAtOrDefault(0).Player.Id);
            Assert.AreEqual(alice.Id, team.PlayerPositions.ElementAtOrDefault(1).Player.Id);
            Assert.AreEqual(charlie.Id, team.PlayerPositions.ElementAtOrDefault(2).Player.Id);

            team.UpdatePlayerPosition(alice.Id, qbPosition.Id, -1);
            Assert.AreEqual(bob.Id, team.PlayerPositions.ElementAtOrDefault(0).Player.Id);
            Assert.AreEqual(charlie.Id, team.PlayerPositions.ElementAtOrDefault(1).Player.Id);

        }

        [Test]
        public void ShouldReturnCorrectPlayerBackupPlayerPositionsInATeam()
        {
            var league = new League("NFL");
            var qbPosition = league.AddSupportingPosition("QB");
            league.AddSupportingPosition("WR");
            league.AddSupportingPosition("KR");

            var team = new Team(league, "Buffalo Bills");
            var alice = team.AddPlayer("Alice");
            var bob = team.AddPlayer("Bob");
            var charlie = team.AddPlayer("Charlie");

            team.UpdatePlayerPosition(alice.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(bob.Id, qbPosition.Id, 0);
            team.UpdatePlayerPosition(charlie.Id, qbPosition.Id, 2);

            var backupPlayerPositions = team.GetBackupPlayerPositions(bob.Id, qbPosition.Id);

            Assert.AreEqual(alice.Id, backupPlayerPositions.ElementAtOrDefault(0).Player.Id);
            Assert.AreEqual(charlie.Id, backupPlayerPositions.ElementAtOrDefault(1).Player.Id);
        }
    }
}
