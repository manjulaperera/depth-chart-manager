using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartManager.Domain
{
    public class Team
    {
        private List<Player> _players = new List<Player>();
        private List<PlayerPosition> _playerPositions => new List<PlayerPosition>();

        public Team(Guid sportId, Guid leagueId, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);
            Id = Guid.NewGuid();
            SportId = sportId;
            LeagueId = leagueId;
            Name = name;
        }

        public Guid Id { get; }
        public Guid SportId { get; }
        public Guid LeagueId { get; }
        public string Name { get; }
        public IEnumerable<Player> Players => _players.AsReadOnly();
        public IEnumerable<PlayerPosition> PlayerPositions => _playerPositions.AsReadOnly();

        public Player AddPlayer(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);
            Contract.Requires<Exception>(!_players.Exists(player => string.Equals(player.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.PlayerAlreadyExistsWithinTeam);

            var player = new Player(SportId, LeagueId, Id, name);
            _players.Add(player);
            return player;
        }

        public Player GetPlayer(Guid playerId)
        {
            return _players.Find(p => p.Id == playerId);
        }

        public IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid playerId)
        {
            var playerPosition = _playerPositions.Find(pp => pp.PlayerId == playerId);
            return _playerPositions.Where(pp => pp.SupportingPositionRanking > playerPosition?.SupportingPositionRanking);
        }

        public PlayerPosition UpdatePlayerPosition(Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            _playerPositions.RemoveAll(pp => pp.PlayerId == playerId && pp.SupportingPositionId == supportingPositionId); // remove existing position, if any

            var playerPosition = new PlayerPosition(SportId, LeagueId, Id, playerId, supportingPositionId, supportingPositionRanking);
            _playerPositions.Add(playerPosition);
            return playerPosition;
        }
    }
}