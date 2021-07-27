using DepthChartManager.Core;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Core.Messaging;
using DepthChartManager.Infrastructure.Repositories;
using MediatR;
using MediatR.SimpleInjector;
using SimpleInjector;
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

        public DateTime CreatedOn { get; set; }
    }

    public class Program
    {
        private Container _container = new Container();

        private static void Main(string[] args)
        {
            Task.Run(async () => await new Program().BuildContainer().Run()).Wait();
        }

        private async Task Run()
        {
            var mediator = _container.GetInstance<IMediator>();

            var sport = await mediator.Send(new AddSportCommand(new CreateSportDto
            {
                Name = "Baseball"
            }));

            var league = await mediator.Send(new AddLeagueCommand(new CreateLeagueDto
            {
                Name = "NFL",
                SportId = sport.Id
            }));

            foreach (var supportingPosition in new List<string> { "QB", "WR", "RB", "TE", "K", "P", "KR", "PR" })
            {
                var result = await mediator.Send(new AddSupportingPositionCommand(new CreateSupportingPositionDto
                {
                    Name = supportingPosition,
                    SportId = sport.Id
                }));
            }

            var team = await mediator.Send(new AddTeamCommand(new CreateTeamDto
            {
                Name = "Buffalo Bills",
                SportId = sport.Id,
                LeagueId = league.Id,
            }));

            foreach (var playerName in new List<string> { "Josh Allen", "Zach Moss", "Davis Webb", "Ryan Bates" })
            {
                var teamPlayer = await mediator.Send(new AddPlayerCommand(new CreatePlayerDto
                {
                    SportId = sport.Id,
                    LeagueId = league.Id,
                    TeamId = team.Id,
                    Name = playerName
                }));
            }

            var qbSupportingPosition = await mediator.Send(new GetSupportingPositionCommand(new GetSupportingPositionDto
            {
                SportId = sport.Id,
                SupportingPositionName = "QB"
            }));

            var joshAllen = await mediator.Send(new GetPlayerCommand(new GetPlayerDto
            {
                SportId = sport.Id,
                LeagueId = league.Id,
                TeamId = team.Id,
                PlayerName = "Josh Allen"
            }));

            var joshAllenPosition = await mediator.Send(new UpdatePlayerPositionCommand(new UpdatePlayerPositionDto
            {
                SportId = sport.Id,
                LeagueId = league.Id,
                TeamId = team.Id,
                PlayerId = joshAllen.Id,
                SupportingPositionId = qbSupportingPosition.Id,
                SupportingPositionRanking = 2
            }));

            joshAllenPosition = await mediator.Send(new UpdatePlayerPositionCommand(new UpdatePlayerPositionDto
            {
                SportId = sport.Id,
                LeagueId = league.Id,
                TeamId = team.Id,
                PlayerId = joshAllen.Id,
                SupportingPositionId = qbSupportingPosition.Id,
                SupportingPositionRanking = 1
            }));

            var wrSupportingPosition = await mediator.Send(new GetSupportingPositionCommand(new GetSupportingPositionDto
            {
                SportId = sport.Id,
                SupportingPositionName = "WR"
            }));

            var davisWebb = await mediator.Send(new GetPlayerCommand(new GetPlayerDto
            {
                SportId = sport.Id,
                LeagueId = league.Id,
                TeamId = team.Id,
                PlayerName = "Davis Webb"
            }));

            var davisWebbPOsition = await mediator.Send(new UpdatePlayerPositionCommand(new UpdatePlayerPositionDto
            {
                SportId = sport.Id,
                LeagueId = league.Id,
                TeamId = team.Id,
                PlayerId = davisWebb.Id,
                SupportingPositionId = wrSupportingPosition.Id,
                SupportingPositionRanking = 1
            }));
        }

        private Program BuildContainer()
        {
            _container.BuildMediator(typeof(ISportRepository).Assembly);

            _container.RegisterSingleton<ISportRepository, SportRepository>();
            _container.Verify();
            return this;
        }
    }
}