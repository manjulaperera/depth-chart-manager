using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Core.Messaging;
using DepthChartManager.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepthChartManager.ConsoleApp
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Ranking { get; set; }
    }

    public class Program
    {
        private IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            Task.Run(async () => await new Program().ConfigureServices().Run()).Wait();
        }

        private async Task Run()
        {
            // Add league
            var nfl = await AddLeague("NFL");

            // Add supporting positions
            foreach (var supportingPositionName in new List<string> { "QB", "WR", "RB", "TE", "K", "P", "KR", "PR" })
            {
                await AddSupportingPosition(nfl.Id, supportingPositionName);
            }

            // Add team
            var buffaloBills = await AddTeam(nfl.Id, "Buffalo Bills");

            // Add players
            foreach (var playerName in new[] { "Alice", "Bob", "Charlie" })
            {
                await AddPlayer(nfl.Id, buffaloBills.Id, playerName);
            }

            var alice = await GetPlayer(nfl.Id, buffaloBills.Id, "Alice");
            var bob = await GetPlayer(nfl.Id, buffaloBills.Id, "Bob");
            var charlie = await GetPlayer(nfl.Id, buffaloBills.Id, "Charlie");

            var wr = await GetSupportingPosition(nfl.Id, "WR");
            var kr = await GetSupportingPosition(nfl.Id, "KR");

            // Update player positions
            await UpdatePlayerPosition(nfl.Id, buffaloBills.Id, bob.Id, wr.Id, 0);
            await UpdatePlayerPosition(nfl.Id, buffaloBills.Id, alice.Id, wr.Id, 0);
            await UpdatePlayerPosition(nfl.Id, buffaloBills.Id, charlie.Id, wr.Id, 2);
            await UpdatePlayerPosition(nfl.Id, buffaloBills.Id, bob.Id, kr.Id, 0);

            var playerPositions = await GetPlayerPositions(nfl.Id, buffaloBills.Id);
        }

        private Program ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(ISportRepository).Assembly);
            services.AddAutoMapper(typeof(ISportRepository).Assembly);
            services.AddSingleton<ISportRepository, SportRepository>();

            _serviceProvider = services.BuildServiceProvider(); // Build the container now
            return this;
        }

        private async Task<LeagueDto> AddLeague(string leagueName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new AddLeagueCommand(new CreateLeagueDto
            {
                Name = leagueName
            }));

            return result.Result;
        }

        private async Task<SupportingPositionDto> AddSupportingPosition(Guid leagueId, string supportingPositionName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new AddSupportingPositionCommand(new CreateSupportingPositionDto
            {
                LeagueId = leagueId,
                Name = supportingPositionName
            }));

            return result.Result;
        }

        private async Task<TeamDto> AddTeam(Guid leagueId, string teamName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new AddTeamCommand(new CreateTeamDto
            {
                LeagueId = leagueId,
                Name = teamName
            }));

            return result.Result;
        }

        private async Task<PlayerDto> AddPlayer(Guid leagueId, Guid teamId, string playerName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new AddPlayerCommand(new CreatePlayerDto
            {
                LeagueId = leagueId,
                TeamId = teamId,
                Name = playerName
            }));

            return result.Result;
        }

        private async Task<PlayerDto> GetPlayer(Guid leagueId, Guid teamId, string playerName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new GetPlayerCommand(new GetPlayerDto
            {
                LeagueId = leagueId,
                TeamId = teamId,
                PlayerName = playerName
            }));

            return result.Result;
        }

        private async Task<SupportingPositionDto> GetSupportingPosition(Guid leagueId, string supportingPositionName)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new GetSupportingPositionCommand(new GetSupportingPositionDto
            {
                LeagueId = leagueId,
                SupportingPositionName = supportingPositionName
            }));

            return result.Result;
        }

        private async Task<IEnumerable<PlayerPositionDto>> GetPlayerPositions(Guid leagueId, Guid teamId)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new GetPlayerPositionsCommand(new GetPlayerPositionDto
            {
                LeagueId = leagueId,
                TeamId = teamId,
            }));

            return result.Result;
        }

        private async Task<PlayerPositionDto> UpdatePlayerPosition(Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new UpdatePlayerPositionCommand(new UpdatePlayerPositionDto
            {
                LeagueId = leagueId,
                TeamId = teamId,
                PlayerId = playerId,
                SupportingPositionId = supportingPositionId,
                SupportingPositionRanking = supportingPositionRanking
            }));

            return result.Result;
        }
    }
}