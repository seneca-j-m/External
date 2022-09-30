using Microsoft.Data.Sqlite;


namespace BanishedMain;

public class DBManager
{
    //protected SqliteConnection DBConnection = new SqliteConnection(GDirectories.userDBPath);
    internal DBManager()
    {
    }

    ~DBManager() // just in caseys
    {
        //DBConnection.Close();
    }
    //
    // internal void InitUserDB()
    // {
    //     try
    //     {
    //         using (var conn = new SqliteConnection($@"Data Source={GDirectories.userDBPath}"))
    //         {
    //             conn.Open();
    //             Debug.WDMNL("Connection Initialised: userDB");
    //             var comm = conn.CreateCommand();
    //             comm.CommandText = // TODO: ADD USER ID SECTION
    //                 @"
    //                 CREATE TABLE IF NOT EXISTS users (
    //                     id INTEGER PRIMARY KEY,
    //                     firstname TEXT NOT NULL,
    //                     lastname TEXT NOT NULL,
    //                     age INTEGER NOT NULL,
    //                     password TEXT NOT NULL 
    //                 );
    //                 ";
    //             var readr = comm.ExecuteNonQuery();
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new DatabaseConnectionFailed(e);
    //     }
    // }

    internal void InitPlayerDB()
    {
        try
        {
            using (var conn = new SqliteConnection($@"Data Source={GDirectories.playerDBPath}"))
            {
                conn.Open();
                Debug.WDMNL("Connection Initialsed: playerDB");
                var comm = conn.CreateCommand();
                comm.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS players (
                        id INTEGER PRIMARY KEY,
                        playername TEXT NOT NULL,
                        playerrace TEXT NOT NULL,
                        playerclass TEXT NOT NULL,
                        playeraccolade TEXT NOT NULL
                    )
                    ";
                var readr = comm.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            throw new DatabaseConnectionFailed(e);
        }
    }

    // internal List<string> GetUserDBData()
    // {
    //     List<string> userDBData = new List<string>();
    //
    //     using (var conn = new SqliteConnection($@"Data Source={GDirectories.userDBPath}"))
    //     {
    //         conn.Open();
    //         var comm = conn.CreateCommand();
    //         comm.CommandText =
    //             @"
    //                 SELECT * FROM users;
    //             ";
    //         using (var readr = comm.ExecuteReader())
    //         {
    //             while (readr.Read())
    //             {
    //                 for (int i = 0; i <= 4; i++)
    //                 {
    //                     userDBData.Add(readr.GetValue(i).ToString());
    //                 }
    //             }
    //         }
    //     }
    //
    //     return userDBData;
    // }

    internal List<Player> GetPlayerDBData()
    {
        List<Player> playerDBData = new List<Player>();

        using (var conn = new SqliteConnection($@"Data Source={GDirectories.playerDBPath}"))
        {
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText =
                @"
                    SELECT * FROM players;
                ";
            using (var readr = comm.ExecuteReader())
            {
                while (readr.Read())
                {
                    Enum.TryParse(readr.GetValue(2).ToString().ToUpper(), out DefaultPlayerRace plRace);
                    Enum.TryParse(readr.GetValue(3).ToString().ToUpper(), out DefaultPlayerClass plClass);
                    Enum.TryParse(readr.GetValue(4).ToString().ToUpper(), out DefaultPlayerAccolade plAccolade);
                    Player player = new Player(readr.GetValue(1).ToString(), plRace,
                        plClass, plAccolade);

                    playerDBData.Add(player);
                }
            }
        }

        return playerDBData;
    }

    // internal void WriteToUserDB(User user)
    // {
    //     using (var conn = new SqliteConnection($@"Data Source={GDirectories.userDBPath}"))
    //     {
    //         conn.Open();
    //         var comm = conn.CreateCommand();
    //         comm.CommandText =
    //             $@"
    //                 INSERT INTO users (firstname, lastname, age, password) VALUES ('{user.firstname}', '{user.lastname}', '{user.age}', '{user.password}');
    //             ";
    //         using (var readr = comm.ExecuteReader()) ;
    //     }
    // }

    internal void WriteToPlayerDB(Player player)
    {
        using (var conn = new SqliteConnection($@"Data Source={GDirectories.playerDBPath}"))
        {
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText =
                $@"
                    INSERT INTO players (playername, playerrace, playerclass, playeraccolade) VALUES ('{player.playername}', '{player.playerrace.ToString()}', '{player.playerclass.ToString()}', '{player.playeraccolade.ToString()}');
                ";
            using (var readr = comm.ExecuteReader()) ;
        }
    }

    internal void DeleteFromPlayerDB(string playerName)
    {
        using (var conn = new SqliteConnection($@"Data Source={GDirectories.playerDBPath}"))
        {
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText =
                $@"
                    DELETE FROM players WHERE playername = '{playerName}';
                ";
            using (var readr = comm.ExecuteReader()) ;
        }
    }
}