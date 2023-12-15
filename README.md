# MasterGames API 👾

Este projeto é uma API em desenvolvimento para manipular coleções existentes em um sistema de jogos. Ele oferece funcionalidades para interagir com entidades como jogos (Game), jogadores (Player) e estúdios de jogos (GameStudio).

## Estrutura de Diretórios 📁

- **Contracts/**: Armazena as interfaces que uma classe pode implementar.
- **Controller/**: Contém os controllers responsáveis por ações que interagem com usuários e o banco de dados.
- **Database/**: Armazena a classe que representa o banco de dados do sistema, com listas de modelos e métodos para consultas e relações entre eles.
- **Models/**: Contém os modelos do sistema: Game, Player e GameStudio.

## Funcionalidades 🎮

O arquivo `Program.cs` utiliza a classe `TrybeGamesController` para executar ações com os usuários. Para visualizar o sistema em funcionamento, execute o projeto em `src/TrybeGames` com o comando `dotnet run`.

### Relacionamentos 🔗

- **Game-Player**: Um jogo pode ter vários jogadores, armazenando os IDs dos jogadores na lista `Game.Players`. Da mesma forma, um jogador pode ter vários jogos comprados, usando a lista `Player.GamesOwned`.
- **Game-GameStudio**: Cada jogo é desenvolvido por um estúdio de jogos, utilizando o campo `Game.DeveloperStudio` para armazenar o ID do estúdio desenvolvedor.
- **Player-GameStudio**: Um jogador pode ter uma lista de estúdios favoritos, armazenada em `Player.FavoriteGameStudios`.

### Utilização dos Models 🕹️

Os modelos (`Models/`) são utilizados na classe `TrybeGamesDatabase` para compor o banco de dados. `TrybeGamesDatabase` é então usado em `TrybeGamesController` para realizar consultas e operações requisitadas pelos usuários.

## Execução do Projeto ▶️

Este projeto pode ser executado com o comando `dotnet run` na pasta `src/TrybeGames/`.
