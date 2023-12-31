namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        var filteredGamesByDeveloper = from game in Games
                                       where game.DeveloperStudio == gameStudio.Id
                                       select game;
        List<Game> games = filteredGamesByDeveloper.ToList();

        return games;
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        var filteredGamesByPlayer = from game in Games
                                    from gameOwned in player.GamesOwned
                                    where game.Id == gameOwned
                                    select game;

        List<Game> games = filteredGamesByPlayer.ToList();
        return games;
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        var filteredGamesOwnedByPlayer = from game in Games
                                         from gameOwned in playerEntry.GamesOwned
                                         where game.Id == gameOwned
                                         select game;

        List<Game> games = filteredGamesOwnedByPlayer.ToList();
        return games;
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        var filteredGamesByDeveloper = from game in Games
                                       from gameDevelopedBy in GameStudios
                                       where game.DeveloperStudio == gameDevelopedBy.Id
                                       select new GameWithStudio { GameName = game.Name, StudioName = gameDevelopedBy.Name, NumberOfPlayers = game.Players.Count() };
        List<GameWithStudio> games = filteredGamesByDeveloper.ToList();

        return games;
    }

    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        var queryGamesTypes = from game in Games
                              group game by game.GameType into games
                              select games;

        List<GameType> gamesTypes = new List<GameType>();
        foreach (var game in queryGamesTypes)
        {
            gamesTypes.Add(game.Key);
        }

        return gamesTypes;
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        var studios = GameStudios.ToList();
        var results = new List<StudioGamesPlayers>();

        foreach (var studio in studios)
        {
            var games = Games.Where(game => game.DeveloperStudio == studio.Id).ToList();
            var gamePlayers = new List<GamePlayer>();

            foreach (var game in games)
            {
                var players = Players.Where(player => player.GamesOwned.Contains(game.Id)).ToList();
                gamePlayers.Add(new GamePlayer
                {
                    GameName = game.Name,
                    Players = players
                });
            }

            var studioGamesPlayers = new StudioGamesPlayers
            {
                GameStudioName = studio.Name,
                Games = gamePlayers
            };

            results.Add(studioGamesPlayers);
        }
        return results;
    }

}
