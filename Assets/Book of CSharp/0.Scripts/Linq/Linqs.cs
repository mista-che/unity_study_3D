using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Linqs : MonoBehaviour
{
    // LINQ (Language INtegrated Query)
    // FROM var in COLLECTION
    // WHERE condition
    // SELECT vars that satisfy condition

    public int[] numbers = { 1, 2, 3, 4, 5 };
    public List<Gamer> gamers = new();
    public List<Account> accounts = new();

    public class Gamer
    {
        public string name;
        public int score;

        public Gamer(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public class Account
    {
        public string display_name;
        public int user_id;

        public Account(string display_name, int user_id)
        {
            this.display_name = display_name;
            this.user_id = user_id;
        }
    }

    private void Start()
    {
        PopulateGamers();
        PopulateAccounts();
        JoinTablesExternal();
    }

    private void PrintAll(IEnumerable<int> numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    private void PrintAll(IEnumerable<Gamer> gamers)
    {
        foreach (var gamer in gamers)
        {
            Debug.Log(gamer.name);
        }
    }

    private void LinqTest() // 4, 5 (all n > 3)
    {
        var result = from number in numbers
                     where number > 3
                     select number;
        PrintAll(result);
    }

    private void LambdaTest() // 1, 4, 9, 16, 25 (select all n, return n^2)
    {
        var result = numbers.Select(n => n * n);
        PrintAll(result);
    }

    private void PopulateGamers()
    {
        gamers.Add(new Gamer("Agitated Gamer", 40));
        gamers.Add(new Gamer("Zoned Out Gamer", 60));
        gamers.Add(new Gamer("Veteran Gamer", 75));
        gamers.Add(new Gamer("Sweaty Gamer", 85));
        gamers.Add(new Gamer("Tranquil Gamer", 95));
    }

    private void PopulateAccounts()
    {
        accounts.Add(new Account("Agitated Gamer", 0001));
        accounts.Add(new Account("Zoned Out Gamer", 0002));
        accounts.Add(new Account("Veteran Gamer", 0003));
        accounts.Add(new Account("Sweaty Gamer", 0004));
        accounts.Add(new Account("Tranquil Gamer", 0005));
    }

    private void AddPartial()
    {
        gamers.Add(new Gamer(string.Empty, 99));
        accounts.Add(new Account("Casual Gamer", 0006));
    }

    private void CheckScoreWithLinqLambda(int cutline)
    {
        var good_gamers = gamers.Where(p => p.score > cutline);
        var bad_gamers = gamers.Except(good_gamers);

        Debug.Log("Good Gamers:");
        PrintAll(good_gamers);
        Debug.Log("Bad Gamers:");
        PrintAll(bad_gamers);
    }

    private void CheckScoreWithLinq(int cutline)
    {
        var good_gamers = from gamer in gamers
                          where gamer.score > cutline
                          select gamer;
        var bad_gamers = gamers.Except(good_gamers);

        Debug.Log("Good Gamers:");
        PrintAll(good_gamers);
        Debug.Log("Bad Gamers:");
        PrintAll(bad_gamers);
    }

    private void CheckScore(int cutline)
    {
        var good_gamers = new List<Gamer>();
        var bad_gamers = new List<Gamer>();

        foreach (var gamer in gamers)
        {
            if (gamer.score > cutline) good_gamers.Add(gamer);
            else bad_gamers.Add(gamer);
        }

        Debug.Log("Good Gamers:");
        PrintAll(good_gamers);
        Debug.Log("Bad Gamers:");
        PrintAll(bad_gamers);
    }

    private void JoinTables()
    {
        var joined_table = from gamer in gamers
                           join account in accounts on gamer.name equals account.display_name
                           select new
                           {
                               username = gamer.name,
                               UID = account.user_id,
                               highscore = gamer.score
                           };
        foreach (var user in joined_table)
        {                                                 // adds leading zeros without using ToString("0000");
            Debug.Log($"username: {user.username}, UID: {user.UID:120000}, highscore: {user.highscore}");
        }
    }

    private void JoinTablesExternal()
    {
        AddPartial();

        var joined_table_left = from gamer in gamers
                                join account in accounts on gamer.name equals account.display_name into user_accounts
                                from account in user_accounts.DefaultIfEmpty()
                                select new
                                {
                                    username = gamer.name,
                                    UID = account?.user_id ?? 999999,
                                    highscore = gamer?.score ?? 0
                                };

        var joined_table_right = from account in accounts
                                 join gamer in gamers on account.display_name equals gamer.name into account_users
                                 from gamer in account_users.DefaultIfEmpty()
                                 where gamer == null
                                 select new
                                 {
                                     username = account.display_name,
                                     UID = account?.user_id ?? 999999,
                                     highscore = gamer?.score ?? 0
                                 };
        var joined_table = joined_table_left.Union(joined_table_right);
        foreach (var user in joined_table)
        {
            var name = user.username;
            if (name == string.Empty) name = "N/A";

            var uid = user.UID.ToString();
            if (uid == "999999") uid = "N/A";
            else uid = uid.PadLeft(6, '0');

            // Use int:0000 to add leading zeros without using ToString("0000");
            Debug.Log($"username: {name}, UID: {uid}, highscore: {user.highscore}");
        }
    }
}
