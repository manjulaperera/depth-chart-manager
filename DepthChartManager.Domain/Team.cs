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
                var supportingPositionGroups = _playerPositions.Where(p => p.SupportingPositionRanking >= 0).GroupBy(r => new { r.SupportingPosition.Id, r.SupportingPositionRanking });

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

            var player = new Player(League, this, name);
            _players.Add(player);
            return player;
        }

        public Player GetPlayer(string name)
        {
            return _players.Find(p => string.Equals(name, p.Name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid playerId)
        {
            var playerPosition = _playerPositions.Find(pp => pp.Player.Id == playerId);
            return _playerPositions.Where(pp => pp.SupportingPositionRanking > playerPosition?.SupportingPositionRanking);
        }

        public PlayerPosition UpdatePlayerPosition(Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            _playerPositions.RemoveAll(pp => pp.Player.Id == playerId);

            var player = _players.Find(p => p.Id == playerId);
            var supportingPosition = League.SupportingPositions.FirstOrDefault(s => s.Id == supportingPositionId);

            var playerPosition = new PlayerPosition(League, this, player, supportingPosition, supportingPositionRanking);
            _playerPositions.Add(playerPosition);
            return playerPosition;
        }
    }
}