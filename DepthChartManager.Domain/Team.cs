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

        public Team(Guid leagueId, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);
            Id = Guid.NewGuid();
            LeagueId = leagueId;
            Name = name;
        }

        public Guid Id { get; }

        public Guid LeagueId { get; }

        public string Name { get; }

        public IEnumerable<Player> Players => _players.AsReadOnly();

        public IEnumerable<PlayerPosition> PlayerPositions
        {
            get
            {
                var supportingPositionGroups = _playerPositions.Where(p => p.SupportingPositionRanking >= 0).GroupBy(r => new { r.SupportingPositionId, r.SupportingPositionRanking });

                foreach (var supportingPositionGroup in supportingPositionGroups)
                {
                    foreach (var playerPosition in supportingPositionGroup.Reverse())
                    {
                        yield return playerPosition;
                    }
                }
            }
        }

        public Player AddPlayer(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);
            Contract.Requires<Exception>(!_players.Exists(player => string.Equals(player.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.PlayerAlreadyExistsWithinTeam);

            var player = new Player(LeagueId, Id, name);
            _players.Add(player);
            return player;
        }

        public Player GetPlayer(string name)
        {
            return _players.Find(p => string.Equals(name, p.Name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid playerId)
        {
            var playerPosition = _playerPositions.Find(pp => pp.PlayerId == playerId);
            return _playerPositions.Where(pp => pp.SupportingPositionRanking > playerPosition?.SupportingPositionRanking);
        }

        public PlayerPosition UpdatePlayerPosition(Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            //_playerPositions.RemoveAll(pp => pp.PlayerId == playerId);

            var playerPosition = new PlayerPosition(LeagueId, Id, playerId, supportingPositionId, supportingPositionRanking);
            _playerPositions.Add(playerPosition);
            return playerPosition;
        }
    }
}