using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartManager.Domain
{
    public class Team
    {
        private List<Player> _players = new List<Player>();
        private List<PlayerPosition> _playerPositions = new List<PlayerPosition>();

        public Team(League league, string name)
        {
            Contract.Requires<Exception>(league != null, Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);

            Id = Guid.NewGuid();
            League = league;
            Name = name;
        }

        public Guid Id { get; }

        public League Leagued { get; }
        
        public League League { get; }
        
        public string Name { get; }

        public IEnumerable<Player> Players => _players.AsReadOnly();

        public IEnumerable<PlayerPosition> PlayerPositions
        {
            get
            {
                var supportingPositionRows = _playerPositions.GroupBy(pp => new { pp.SupportingPosition.Id, pp.SupportingPositionRanking });

                foreach (var supportingPositionRow in supportingPositionRows)
                {
                    var supportingPositionRankingGroups = supportingPositionRow.GroupBy(pp => pp.SupportingPositionRanking);

                    foreach (var supportingPositionRankingGroup in supportingPositionRankingGroups)
                    {
                        foreach (var playerPosition in supportingPositionRankingGroup.Where(r => r.SupportingPositionRanking >= 0).Reverse())
                        {
                            yield return playerPosition;
                        }
                    }
                }
            }
        }

        public Player AddPlayer(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);
            Contract.Requires<Exception>(!_players.Exists(player => string.Equals(player.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.PlayerAlreadyExistsWithinTeam);

            var player = new Player(League, this, name);
            _players.Add(player);
            return player;
        }

        public Player GetPlayer(string name)
        {
            return _players.Find(p => string.Equals(name, p.Name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid playerId, Guid supportingPositionId)
        {
            var playerPositions = PlayerPositions.ToList();
            var playerPositionIndex = playerPositions.FindIndex(pp => pp.Player.Id == playerId && pp.SupportingPosition.Id == supportingPositionId);
            return playerPositions.Where(pp => pp.SupportingPosition.Id == supportingPositionId).Skip(playerPositionIndex + 1);
        }

        public PlayerPosition UpdatePlayerPosition(Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            // Remove if the same player exists in this swimlane
            _playerPositions.RemoveAll(pp => pp.Player.Id == playerId && pp.SupportingPosition.Id == supportingPositionId);

            // Update position
            var player = _players.Find(p => p.Id == playerId);
            var supportingPosition = League.SupportingPositions.FirstOrDefault(s => s.Id == supportingPositionId);
            var playerPosition = new PlayerPosition(League, this, player, supportingPosition, supportingPositionRanking);
            _playerPositions.Add(playerPosition);

            return playerPosition;
        }
    }
}