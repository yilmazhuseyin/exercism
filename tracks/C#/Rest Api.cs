using System.Collections.Generic;
using Newtonsoft.Json;
public class RestApi
{
    private readonly List<Db> _dbs;
    public RestApi(string database) => _dbs = JsonConvert.DeserializeObject<List<Db>>(database);

    public string Get(string url, string payload = null)
    {
        string result = string.Empty;

        if (url == "/users")
        {
            List<Db> databases = new List<Db>();

            if (payload != null)
            {
                Users users = JsonConvert.DeserializeObject<Users>(payload);

                foreach (string user in users.users) foreach (var db in _dbs) if (db.name == user) databases.Add(db);
            }
            result = JsonConvert.SerializeObject(databases);
        }
        return result;
    }
    public string Post(string url, string payload)
    {
        string res = string.Empty;

        if (url == "/add")
        {
            User u = JsonConvert.DeserializeObject<User>(payload);

            Db newDb = new Db() { name = u.user };

            _dbs.Add(newDb);

            res = JsonConvert.SerializeObject(newDb);
        }
        else if (url == "/iou")
        {
            IOU iou = JsonConvert.DeserializeObject<IOU>(payload);

            foreach (Db db in _dbs)
            {
                if (iou.lender == db.name)
                {
                    if (!db.owes.ContainsKey(iou.borrower)) db.owed_by.Add(iou.borrower, iou.amount);
                    if (db.owes.ContainsKey(iou.borrower)) db.owes[iou.borrower] -= iou.amount;
                }
                if (iou.borrower == db.name)
                {
                    if (!db.owed_by.ContainsKey(iou.lender)) db.owes.Add(iou.lender, iou.amount);
                    if (db.owed_by.ContainsKey(iou.lender)) db.owed_by[iou.lender] -= iou.amount;
                }
            }

            foreach (Db db in _dbs)
            {
                List<string> debtRemove = new();
                List<string> debtorRemove = new();
                List<string> changeDebt = new();
                List<string> changeDebtor = new();
                
                foreach (var item in db.owes)
                {
                    if (item.Value == 0) debtRemove.Add(item.Key);
                    else if (item.Value < 0) changeDebt.Add(item.Key);
                }

                foreach (var item in debtRemove) db.owes.Remove(item);
                
                foreach (var item in db.owed_by)
                {
                    if (item.Value == 0) debtorRemove.Add(item.Key);
                    
                    else if (item.Value < 0) changeDebtor.Add(item.Key);
                }
                foreach (var item in debtorRemove) db.owed_by.Remove(item);
                
                foreach (var item in changeDebt)
                {
                    db.owed_by.Add(item, -db.owes[item]);
                    db.owes.Remove(item);
                }

                foreach (var item in changeDebtor)
                {
                    db.owes.Add(item, -db.owed_by[item]);
                    db.owed_by.Remove(item);
                }
            }

            var databases = new List<Db>();

            foreach (Db db in _dbs) if (db.name == iou.lender || db.name == iou.borrower) databases.Add(db);

            res = JsonConvert.SerializeObject(databases);
        }
        return res;
    }
}
public class IOU
{
    public string lender { get; set; }
    public string borrower { get; set; }
    public int amount { get; set; }
}

public class Users
{
    public List<string> users { get; set; }
}

public class User
{
    public string user { get; set; }
}

public class Db
{
    public string name { get; set; }
    public SortedDictionary<string, int> owes { get; set; }
    public SortedDictionary<string, int> owed_by { get; set; }

    public Db()
    {
        owes = new SortedDictionary<string, int>();
        owed_by = new SortedDictionary<string, int>();
    }

    public int balance
    {
        get
        {
            int balance = 0;

            foreach (KeyValuePair<string, int> item in owes) balance -= item.Value;
            foreach (KeyValuePair<string, int> item in owed_by) balance += item.Value;

            return balance;
        }
    }
}
